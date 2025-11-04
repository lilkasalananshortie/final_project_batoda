using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using BATODA.Modules.Tricycle_Module.Tricycle_Classes;

namespace BATODA.Modules.Tricycle_Module.Tricycle_Classes
{
    internal class TricycleRepository
    {
        private readonly string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=BatodaDb;Integrated Security=True;TrustServerCertificate=True";

        public List<TricycleModel> GetAllTricycles()
        {
            List<TricycleModel> tricycles = new List<TricycleModel>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"SELECT 
                                    BodyNumber, 
                                    LastName, 
                                    FirstName, 
                                    TricycleBrand, 
                                    TricycleModel, 
                                    PlateNumber, 
                                    EngineNumber, 
                                    ChassisNumber
                                 FROM MemberInfo
                                 ORDER BY BodyNumber DESC";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        tricycles.Add(new TricycleModel
                        {
                            BodyNumber = (int)reader["BodyNumber"],
                            LastName = reader["LastName"].ToString(),
                            FirstName = reader["FirstName"].ToString(),
                            TricycleBrand = reader["TricycleBrand"].ToString(),
                            TricModel = reader["TricycleModel"].ToString(),
                            PlateNumber = reader["PlateNumber"].ToString(),
                            EngineNumber = reader["EngineNumber"].ToString(),
                            ChassisNumber = reader["ChassisNumber"].ToString()
                        });
                    }
                }
            }

            return tricycles;
        }

        // AVAILABLES
        public List<TricycleModel> GetAvailableToday()
        {
            List<TricycleModel> all = GetAllTricycles();
            List<TricycleModel> available = new List<TricycleModel>();

            foreach (var t in all)
            {
                if (t.Availability == "Available")
                    available.Add(t);
            }

            return available;
        }

        // UNAVAILABLES
        public List<TricycleModel> GetUnavailableToday()
        {
            List<TricycleModel> all = GetAllTricycles();
            List<TricycleModel> unavailable = new List<TricycleModel>();

            foreach (var t in all)
            {
                if (t.Availability == "Unavailable")
                    unavailable.Add(t);
            }

            return unavailable;
        }
    }
}
