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
            switch (status)
            {
                case "Paid":
                case "Due":
                case "Overdue":
                    dbStatus = status;
                    break;
                default:
                    dbStatus = "Due";
                    break;
            }

            using (SqlConnection conn = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=BatodaDb;Integrated Security=True;TrustServerCertificate=True"))
            {
                conn.Open();

                // CHECK IF EXIST
                string checkQuery = "SELECT PaymentID FROM MemberPayment WHERE BodyNumber=@BodyNumber AND Year=@Year AND Month=@Month";
                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@BodyNumber", bodyNumber);
                checkCmd.Parameters.AddWithValue("@Year", year);
                checkCmd.Parameters.AddWithValue("@Month", month);

                var result = checkCmd.ExecuteScalar();

                if (result != null)
                {
                    // UPDATE IF EXISTING
                    string updateQuery = "UPDATE MemberPayment SET Status=@Status, PaymentDate=@Date WHERE PaymentID=@PaymentID";
                    SqlCommand updateCmd = new SqlCommand(updateQuery, conn);
                    updateCmd.Parameters.AddWithValue("@Status", dbStatus);

                    if (dbStatus == "Paid")
                        updateCmd.Parameters.AddWithValue("@Date", DateTime.Today);
                    else
                        updateCmd.Parameters.AddWithValue("@Date", DBNull.Value);

                    updateCmd.Parameters.AddWithValue("@PaymentID", (int)result);
                    updateCmd.ExecuteNonQuery();
                }
                else
                {
                    // INSERT NEW
                    string insertQuery = "INSERT INTO MemberPayment (BodyNumber, Year, Month, Amount, Status, PaymentDate) VALUES (@BodyNumber, @Year, @Month, @Amount, @Status, @Date)";
                    SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                    insertCmd.Parameters.AddWithValue("@BodyNumber", bodyNumber);
                    insertCmd.Parameters.AddWithValue("@Year", year);
                    insertCmd.Parameters.AddWithValue("@Month", month);
                    insertCmd.Parameters.AddWithValue("@Amount", 60);
                    insertCmd.Parameters.AddWithValue("@Status", dbStatus);

                    if (dbStatus == "Paid")
                        insertCmd.Parameters.AddWithValue("@Date", DateTime.Today);
                    else
                        insertCmd.Parameters.AddWithValue("@Date", DBNull.Value);

                    insertCmd.ExecuteNonQuery();
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
