using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using BATODA.Modules.Finance_Module.Finance_Classes;


namespace BATODA.Helpers.Data
{
    public class TaxRepository
    {
        private readonly string connectionString;

        public TaxRepository()
        {
            connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=BatodaDb;Integrated Security=True;TrustServerCertificate=True";
        }

        public List<(int BodyNumber, string FullName)> GetAllMembers()
        {
            var list = new List<(int, string)>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT BodyNumber, FirstName, LastName FROM MemberInfo ORDER BY BodyNumber";
                SqlCommand cmd = new SqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int bodyNo = reader.GetInt32(0);
                        string fullName = reader.GetString(1) + " " + reader.GetString(2);
                        list.Add((bodyNo, fullName));
                    }
                }
            }

            return list;
        }

        public List<int> GetDistinctPaymentYears()
        {
            List<int> years = new List<int>();
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT DISTINCT Year FROM MemberPayment ORDER BY Year", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        years.Add(reader.GetInt32(0));
                }
            }
            return years;
        }


        private string GetPaymentStatus(int bodyNumber, int year, int month)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Status FROM MemberPayment WHERE BodyNumber=@BodyNumber AND Year=@Year AND Month=@Month";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@BodyNumber", bodyNumber);
                cmd.Parameters.AddWithValue("@Year", year);
                cmd.Parameters.AddWithValue("@Month", month);

                var result = cmd.ExecuteScalar();
                return result != null ? result.ToString() : "Due";
            }
        }


        public List<MemberPaymentModel> GetAllMemberPayments(int year)
        {
            var payments = new List<MemberPaymentModel>();
            var members = GetAllMembers(); // Returns List<(int BodyNumber, string FullName)>

            foreach (var member in members)
            {
                payments.Add(new MemberPaymentModel
                {
                    BodyNumber = member.Item1,  // tuple Item1 = BodyNumber
                    FullName = member.Item2,    // tuple Item2 = FullName
                    January = GetPaymentStatus(member.Item1, year, 1),
                    February = GetPaymentStatus(member.Item1, year, 2),
                    March = GetPaymentStatus(member.Item1, year, 3),
                    April = GetPaymentStatus(member.Item1, year, 4),
                    May = GetPaymentStatus(member.Item1, year, 5),
                    June = GetPaymentStatus(member.Item1, year, 6),
                    July = GetPaymentStatus(member.Item1, year, 7),
                    August = GetPaymentStatus(member.Item1, year, 8),
                    September = GetPaymentStatus(member.Item1, year, 9),
                    October = GetPaymentStatus(member.Item1, year, 10),
                    November = GetPaymentStatus(member.Item1, year, 11),
                    December = GetPaymentStatus(member.Item1, year, 12)
                });
            }

            return payments;
        }


        public List<(int BodyNumber, int Month, string Status, decimal Amount, DateTime? PaymentDate)> GetPaymentsByYear(int year)
        {
            var list = new List<(int, int, string, decimal, DateTime?)>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT BodyNumber, Month, Status, Amount, PaymentDate
                    FROM MemberPayment
                    WHERE Year = @Year
                ";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Year", year);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int bodyNo = reader.GetInt32(0);
                        int month = reader.GetByte(1);  // TINYINT
                        string status = reader.GetString(2);
                        decimal amount = reader.GetDecimal(3);
                        DateTime? date = reader.IsDBNull(4) ? (DateTime?)null : reader.GetDateTime(4);

                        list.Add((bodyNo, month, status, amount, date));
                    }
                }
            }

            return list;
        }



        public static void UpdatePaymentInDB(int bodyNumber, int year, int month, string status)
        {
            string dbStatus;

            if (status == "Paid")
                dbStatus = "Paid";
            else if (status == "Due")
                dbStatus = "Due";
            else if (status == "Overdue")
                dbStatus = "Overdue";
            else
                dbStatus = "Due";

            using (SqlConnection conn = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=BatodaDb;Integrated Security=True;TrustServerCertificate=True"))
            {
                conn.Open();

                // GET EXISTING PAYMENT IF ANY
                string checkQuery = "SELECT PaymentID, Status, Amount FROM MemberPayment WHERE BodyNumber=@BodyNumber AND Year=@Year AND Month=@Month";
                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@BodyNumber", bodyNumber);
                checkCmd.Parameters.AddWithValue("@Year", year);
                checkCmd.Parameters.AddWithValue("@Month", month);

                int? paymentId = null;
                string oldStatus = null;
                decimal amount = 0;

                using (var reader = checkCmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        paymentId = reader.GetInt32(0);
                        oldStatus = reader.GetString(1);
                        amount = reader.GetDecimal(2); // GET EXISTING AMOUNT
                    }
                }

                // IF NEW PAYMENT, SET DEFAULT AMOUNT
                if (paymentId == null)
                {
                    amount = 60; // OR SET BASED ON YOUR BUSINESS RULE
                }

                decimal adjustment = 0;
                int currentMonth = DateTime.Today.Month;

                // CALC ADJUSTMENT BASED ON STATUS UP TO CURRENT MONTH
                if (month <= currentMonth)
                {
                    if (oldStatus != null)
                    {
                        if (oldStatus != "Paid" && dbStatus == "Paid")
                            adjustment = -amount; // SUBTRACT PAID AMOUNT
                        else if ((oldStatus != "Overdue" && dbStatus == "Overdue") || (oldStatus != "Due" && dbStatus == "Due"))
                            adjustment = amount; // ADD DUE OR OVERDUE
                    }
                    else
                    {
                        if (dbStatus == "Overdue" || dbStatus == "Due")
                            adjustment = amount; // NEW DUE OR OVERDUE
                    }
                }

                // UPDATE MEMBER TAXBALANCE
                if (adjustment != 0)
                {
                    string updateBalance = "UPDATE MemberInfo SET TaxBalance = ISNULL(TaxBalance,0) + @Adj WHERE BodyNumber=@BodyNumber";
                    SqlCommand balCmd = new SqlCommand(updateBalance, conn);
                    balCmd.Parameters.AddWithValue("@Adj", adjustment);
                    balCmd.Parameters.AddWithValue("@BodyNumber", bodyNumber);
                    balCmd.ExecuteNonQuery();
                }
                if (paymentId != null)
                {
                    string updateQuery = @"
                    UPDATE MemberPayment 
                    SET Status=@Status, 
                        PaymentDate=@Date, 
                        Amount=@Amount
                    WHERE PaymentID=@PaymentID";

                    SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                    updateCmd.Parameters.AddWithValue("@Status", dbStatus);
                    updateCmd.Parameters.AddWithValue("@Date", dbStatus == "Paid" ? (object)DateTime.Today : DBNull.Value);
                    updateCmd.Parameters.AddWithValue("@Amount", amount); // ← THIS IS THE FIX
                    updateCmd.Parameters.AddWithValue("@PaymentID", paymentId);

                    updateCmd.ExecuteNonQuery();
                }

                else
                {
                    string insertQuery = @"
                INSERT INTO MemberPayment 
                    (BodyNumber, Year, Month, Amount, Status, PaymentDate) 
                VALUES 
                    (@BodyNumber, @Year, @Month, @Amount, @Status, @Date)";

                    SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                    insertCmd.Parameters.AddWithValue("@BodyNumber", bodyNumber);
                    insertCmd.Parameters.AddWithValue("@Year", year);
                    insertCmd.Parameters.AddWithValue("@Month", month);
                    insertCmd.Parameters.AddWithValue("@Amount", amount);
                    insertCmd.Parameters.AddWithValue("@Status", dbStatus);

                    insertCmd.Parameters.AddWithValue("@Date", dbStatus == "Paid" ? (object)DateTime.Today : DBNull.Value);
                    insertCmd.ExecuteNonQuery();
                }



            }
        }

        public void UpdateAllTaxBalances()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                int currentMonth = DateTime.Today.Month;

                // GET ALL MEMBERS
                string getMembersQuery = "SELECT BodyNumber FROM MemberInfo";
                SqlCommand getMembersCmd = new SqlCommand(getMembersQuery, conn);

                var memberBodyNumbers = new List<int>();
                using (var reader = getMembersCmd.ExecuteReader())
                {
                    while (reader.Read())
                        memberBodyNumbers.Add(reader.GetInt32(0));
                }

                foreach (var bodyNumber in memberBodyNumbers)
                {
                    // GET TOTAL DUE OR OVERDUE AMOUNT UP TO CURRENT MONTH
                    string sumQuery = @"
                SELECT ISNULL(SUM(Amount),0) 
                FROM MemberPayment 
                WHERE BodyNumber=@BodyNumber 
                  AND Status IN ('Overdue','Due')
                  AND Month <= @CurrentMonth";
                    SqlCommand sumCmd = new SqlCommand(sumQuery, conn);
                    sumCmd.Parameters.AddWithValue("@BodyNumber", bodyNumber);
                    sumCmd.Parameters.AddWithValue("@CurrentMonth", currentMonth);

                    decimal balance = (decimal)sumCmd.ExecuteScalar(); // CALCULATE BALANCE

                    // UPDATE MEMBER TAXBALANCE
                    string updateQuery = "UPDATE MemberInfo SET TaxBalance=@Balance WHERE BodyNumber=@BodyNumber";
                    SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                    updateCmd.Parameters.AddWithValue("@Balance", balance);
                    updateCmd.Parameters.AddWithValue("@BodyNumber", bodyNumber);
                    updateCmd.ExecuteNonQuery();
                }
            }
        }

        public int GetPaidMonthsCount(int bodyNumber, int year)
        {
            int count = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM MemberPayment WHERE BodyNumber=@BodyNumber AND Year=@Year AND Status='Paid'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@BodyNumber", bodyNumber);
                cmd.Parameters.AddWithValue("@Year", year);
                count = (int)cmd.ExecuteScalar();
            }
            return count;
        }

        private string MonthName(int month)
        {
            return new DateTime(1, month, 1).ToString("MMMM");
        }


        public void LoadMemberPaymentsGrid(DataGridView dgv, int year)
        {
            string query = @"
            WITH Months AS (
                SELECT 1 AS Month UNION ALL SELECT 2 UNION ALL SELECT 3 UNION ALL SELECT 4
                UNION ALL SELECT 5 UNION ALL SELECT 6 UNION ALL SELECT 7 UNION ALL SELECT 8
                UNION ALL SELECT 9 UNION ALL SELECT 10 UNION ALL SELECT 11 UNION ALL SELECT 12
            )
            SELECT 
                m.BodyNumber,
                m.FirstName + ' ' + m.LastName AS FullName,
                @Year AS Year,
                mo.Month,
                ISNULL(mp.Status, 
                    CASE 
                        WHEN mo.Month < MONTH(GETDATE()) AND @Year = YEAR(GETDATE()) THEN 'Due'
                        ELSE NULL
                    END
                ) AS Status,
                mp.PaymentDate
            FROM MemberInfo m
            CROSS JOIN Months mo
            LEFT JOIN MemberPayment mp 
                ON mp.BodyNumber = m.BodyNumber AND mp.Year = @Year AND mp.Month = mo.Month
            ORDER BY m.BodyNumber, mo.Month;
            ";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Year", year);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dgv.Rows.Clear();
                dgv.Columns.Clear();

                dgv.Columns.Add("BodyNumber", "Body Number");
                dgv.Columns.Add("FullName", "Full Name");
                dgv.Columns.Add("Year", "Year");
                dgv.Columns.Add("Month", "Month");
                dgv.Columns.Add("Status", "Status");
                dgv.Columns.Add("PaymentDate", "Date Paid");

                dgv.Columns[0].Width = 60;
                dgv.Columns[1].Width = 200;
                dgv.Columns[2].Width = 50;
                dgv.Columns[3].Width = 80;
                dgv.Columns[4].Width = 100;
                dgv.Columns[5].Width = 120;

                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                foreach (DataRow row in dt.Rows)
                {
                    dgv.Rows.Add(
                        row["BodyNumber"] != DBNull.Value ? int.Parse(row["BodyNumber"].ToString()).ToString("D3") : null,
                        row["FullName"],
                        row["Year"],
                        row["Month"] != DBNull.Value ? MonthName(int.Parse(row["Month"].ToString())) : null,
                        row["Status"] != DBNull.Value ? row["Status"].ToString() : null,
                        row["PaymentDate"] != DBNull.Value ? Convert.ToDateTime(row["PaymentDate"]).ToShortDateString() : null
                    );
                }
            }
        }

        public List<(int Month, string Status, DateTime? PaymentDate)> GetMemberPayments(int bodyNumber, int year)
        {
            var list = new List<(int, string, DateTime?)>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT Month, Status, PaymentDate
                    FROM MemberPayment
                    WHERE BodyNumber = @BodyNumber AND Year = @Year
                ";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@BodyNumber", bodyNumber);
                cmd.Parameters.AddWithValue("@Year", year);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int month = reader.GetByte(0);
                        string status = reader.GetString(1);
                        DateTime? date = reader.IsDBNull(2) ? (DateTime?)null : reader.GetDateTime(2);
                        list.Add((month, status, date));
                    }
                }
            }
            return list;
        }

        public decimal GetYearTotal(int year)
        {
            decimal total = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT ISNULL(SUM(Amount),0)
                    FROM MemberPayment
                    WHERE Year=@Year AND Status='Paid'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Year", year);
                total = (decimal)cmd.ExecuteScalar();
            }
            return total;
        }

        public decimal GetMonthTotal(int year, int month)
        {
            decimal total = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT ISNULL(SUM(Amount),0)
                    FROM MemberPayment
                    WHERE Year=@Year AND Month=@Month AND Status='Paid'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Year", year);
                cmd.Parameters.AddWithValue("@Month", month);
                total = (decimal)cmd.ExecuteScalar();
            }
            return total;
        }

        public decimal GetPaidTodayTotal()
        {
            decimal total = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT ISNULL(SUM(Amount),0)
                    FROM MemberPayment
                    WHERE Status='Paid' AND PaymentDate = CAST(GETDATE() AS DATE)";
                SqlCommand cmd = new SqlCommand(query, conn);
                total = (decimal)cmd.ExecuteScalar();
            }
            return total;
        }

        public decimal GetOverdueLastMonthTotal()
        {
            decimal total = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                int lastMonth = DateTime.Today.AddMonths(-1).Month;
                int year = DateTime.Today.AddMonths(-1).Year;

                string query = @"
                    SELECT ISNULL(SUM(Amount),0)
                    FROM MemberPayment
                    WHERE Year=@Year AND Month=@Month AND Status='Overdue'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Year", year);
                cmd.Parameters.AddWithValue("@Month", lastMonth);
                total = (decimal)cmd.ExecuteScalar();
            }
            return total;

        }
    }
}
