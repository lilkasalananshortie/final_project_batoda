using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BATODA.Helpers.Data
{
    public class FinanceRepository
    {
        private readonly string connectionString;

        public FinanceRepository()
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

                // UPDATE OR INSERT PAYMENT
                if (paymentId != null)
                {
                    string updateQuery = "UPDATE MemberPayment SET Status=@Status, PaymentDate=@Date WHERE PaymentID=@PaymentID";
                    SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                    updateCmd.Parameters.AddWithValue("@Status", dbStatus);
                    updateCmd.Parameters.AddWithValue("@PaymentID", paymentId);
                    updateCmd.Parameters.AddWithValue("@Date", dbStatus == "Paid" ? (object)DateTime.Today : DBNull.Value);
                    updateCmd.ExecuteNonQuery();
                }
                else
                {
                    string insertQuery = "INSERT INTO MemberPayment (BodyNumber, Year, Month, Amount, Status, PaymentDate) VALUES (@BodyNumber, @Year, @Month, @Amount, @Status, @Date)";
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

    }
}
