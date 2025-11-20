using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BATODA.Modules.Assistance_Request_Module.Renewal_Classes
{
    internal class RenewalRepository
    {
        private readonly string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=BatodaDb;Integrated Security=True;TrustServerCertificate=True";

        public List<MemberRenewalModel> GetAllRenewals()
        {
            string query = @"
                      SELECT 
                        mi.BodyNumber,
                        mi.FirstName + ' ' + mi.LastName AS FullName,
                        mi.MembershipType,
                        mi.ContactNumber,
                        mr.DateRenewed,
                        mr.ExpiryDate,
                        mi.RenewalStatus
                    FROM MemberInfo mi
                    LEFT JOIN MemberRenewal mr ON mr.BodyNumber = mi.BodyNumber
                    ORDER BY mi.BodyNumber;
                    ";

            var list = new List<MemberRenewalModel>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new MemberRenewalModel
                        {
                            BodyNumber = (int)reader["BodyNumber"],
                            FullName = reader["FullName"].ToString(),
                            MembershipType = reader["MembershipType"].ToString(),
                            ContactNumber = reader["ContactNumber"].ToString(),
                            DateRenewed = reader["DateRenewed"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["DateRenewed"]),
                            ExpiryDate = reader["ExpiryDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["ExpiryDate"]),

                            RenewalStatus = reader["RenewalStatus"].ToString()
                        });
                    }
                }
            }

            return list;
        }

        public void AddRenewal(int bodyNumber)
        {
            string query = @"
        INSERT INTO MemberRenewal (BodyNumber, DateRenewed)
        SELECT BodyNumber, DateJoined
        FROM MemberInfo
        WHERE BodyNumber = @BodyNumber;
        ";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@BodyNumber", bodyNumber);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void RenewMembers(List<int> bodyNumbers)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                foreach (int bodyNumber in bodyNumbers)
                {
                    string checkStatusQuery = "SELECT RenewalStatus FROM MemberInfo WHERE BodyNumber=@BodyNumber";
                    SqlCommand checkStatusCmd = new SqlCommand(checkStatusQuery, con);
                    checkStatusCmd.Parameters.AddWithValue("@BodyNumber", bodyNumber);
                    string currentStatus = (string)checkStatusCmd.ExecuteScalar();

                    if (currentStatus == "Renewed")
                        continue; 


                    string updateStatusQuery = "UPDATE MemberInfo SET RenewalStatus='Renewed' WHERE BodyNumber=@BodyNumber";
                    SqlCommand updateStatusCmd = new SqlCommand(updateStatusQuery, con);
                    updateStatusCmd.Parameters.AddWithValue("@BodyNumber", bodyNumber);
                    updateStatusCmd.ExecuteNonQuery();


                    string checkRenewalQuery = "SELECT COUNT(*) FROM MemberRenewal WHERE BodyNumber=@BodyNumber";
                    SqlCommand checkRenewalCmd = new SqlCommand(checkRenewalQuery, con);
                    checkRenewalCmd.Parameters.AddWithValue("@BodyNumber", bodyNumber);
                    int count = (int)checkRenewalCmd.ExecuteScalar();

                    if (count == 0)
                    {
                        string insertRenewalQuery = "INSERT INTO MemberRenewal (BodyNumber, DateRenewed) VALUES (@BodyNumber, GETDATE())";
                        SqlCommand insertRenewalCmd = new SqlCommand(insertRenewalQuery, con);
                        insertRenewalCmd.Parameters.AddWithValue("@BodyNumber", bodyNumber);
                        insertRenewalCmd.ExecuteNonQuery();
                    }
                }
            }
        }


    }

}
