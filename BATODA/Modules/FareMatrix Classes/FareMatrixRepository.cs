using BATODA.Modules.FareMatrix_Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace BATODA.Modules.FareMatrix_Classes
{
    internal class FareMatrixRepository
    {
        private readonly string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=BatodaDb;Integrated Security=True;TrustServerCertificate=True";

        public void UpdateFare(FareInfo fare)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE FareMatrix SET BaseFare=@BaseFare, SeniorFare=@SeniorFare, StudentFare=@StudentFare WHERE RouteID=@RouteID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@BaseFare", fare.BaseFare);
                    cmd.Parameters.AddWithValue("@SeniorFare", fare.SeniorFare);
                    cmd.Parameters.AddWithValue("@StudentFare", fare.StudentFare);
                    cmd.Parameters.AddWithValue("@RouteID", fare.RouteID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<FareInfo> GetAllFares()
        {
            List<FareInfo> fares = new List<FareInfo>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT RouteID, BaseFare, SeniorFare, StudentFare FROM FareMatrix ORDER BY RouteID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        fares.Add(new FareInfo
                        {
                            RouteID = reader.GetInt32(0),
                            BaseFare = reader.GetDecimal(1),
                            SeniorFare = reader.GetDecimal(2),
                            StudentFare = reader.GetDecimal(3)
                        });
                    }
                }
            }

            return fares;
        }


    }
}
