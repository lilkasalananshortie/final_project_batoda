using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

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

        public void TransferTricycle(
            int bodyNumber,
            string membershipType,
            string firstName,
            string middleInitial,
            string lastName,
            string brand,
            string model,
            string plate,
            string chassis,
            string engine)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
                    UPDATE MemberInfo
                    SET 
                        MembershipType = @MembershipType,
                        FirstName = @FirstName,
                        MiddleInitial = @MiddleInitial,
                        LastName = @LastName,
                        TricycleBrand = @TricycleBrand,
                        TricycleModel = @TricycleModel,
                        PlateNumber = @PlateNumber,
                        ChassisNumber = @ChassisNumber,
                        EngineNumber = @EngineNumber
                    WHERE BodyNumber = @BodyNumber";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@MembershipType", membershipType);
                    cmd.Parameters.AddWithValue("@FirstName", firstName);
                    cmd.Parameters.AddWithValue("@MiddleInitial", middleInitial);
                    cmd.Parameters.AddWithValue("@LastName", lastName);
                    cmd.Parameters.AddWithValue("@TricycleBrand", brand);
                    cmd.Parameters.AddWithValue("@TricycleModel", model);
                    cmd.Parameters.AddWithValue("@PlateNumber", plate);
                    cmd.Parameters.AddWithValue("@ChassisNumber", chassis);
                    cmd.Parameters.AddWithValue("@EngineNumber", engine);
                    cmd.Parameters.AddWithValue("@BodyNumber", bodyNumber);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void SaveTricycleTransferHistory(int bodyNumber, string fullName, string processType, string reason)
        {
            string query = @"INSERT INTO TransferTricycleHistory 
                     (BodyNumber, FullName, ProcessType, ReasonForTransfer)
                     VALUES (@BodyNumber, @FullName, @ProcessType, @ReasonForTransfer)";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@BodyNumber", bodyNumber);
                cmd.Parameters.AddWithValue("@FullName", fullName);
                cmd.Parameters.AddWithValue("@ProcessType", processType);
                cmd.Parameters.AddWithValue("@ReasonForTransfer", reason);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable LoadTransferHistory()
        {
            string query = "SELECT TransferID, BodyNumber, FullName, ProcessType, ReasonForTransfer, CONVERT(varchar(10), DateTransferred, 120) AS DateTransferred FROM TransferTricycleHistory ORDER BY TransferID DESC";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
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
