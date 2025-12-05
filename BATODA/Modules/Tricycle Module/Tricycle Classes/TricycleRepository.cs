using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


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

        public static void UpdateStatusLabels(Label operationalLbl, Label unavailableLbl, Label suspendedLbl, Label codingLbl)
        {
            string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=BatodaDb;Integrated Security=True;TrustServerCertificate=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                DayOfWeek today = DateTime.Today.DayOfWeek;
                string unavailableDigits = "";

                if (today == DayOfWeek.Monday) unavailableDigits = "1,2";
                else if (today == DayOfWeek.Tuesday) unavailableDigits = "3,4";
                else if (today == DayOfWeek.Wednesday) unavailableDigits = "5,6";
                else if (today == DayOfWeek.Thursday) unavailableDigits = "7,8";
                else if (today == DayOfWeek.Friday) unavailableDigits = "9,0";

                int unavailableCount = 0;
                if (today != DayOfWeek.Saturday && today != DayOfWeek.Sunday)
                {
                    string unavailableQuery = $@"
                        SELECT COUNT(*) 
                        FROM MemberInfo 
                        WHERE RIGHT(CONVERT(VARCHAR, BodyNumber), 1) IN ({unavailableDigits}) 
                        AND MemberStatus = 'Active' 
                        AND PenaltyLevel < 3
                    ";
                    using (SqlCommand cmd = new SqlCommand(unavailableQuery, conn))
                    {
                        unavailableCount = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }

                string suspendedQuery = "SELECT COUNT(*) FROM MemberInfo WHERE PenaltyLevel = 3";
                int suspendedCount = 0;
                using (SqlCommand cmd = new SqlCommand(suspendedQuery, conn))
                {
                    suspendedCount = Convert.ToInt32(cmd.ExecuteScalar());
                }

                string operationalQuery = $@"
                    SELECT COUNT(*) 
                    FROM MemberInfo 
                    WHERE MemberStatus = 'Active' 
                      AND PenaltyLevel < 3
                ";

                int operationalCount = Convert.ToInt32(new SqlCommand(operationalQuery, conn).ExecuteScalar());
                operationalCount -= unavailableCount;

                operationalLbl.Text = operationalCount.ToString();
                unavailableLbl.Text = unavailableCount.ToString();
                suspendedLbl.Text = suspendedCount.ToString();

                string codingMembers = "";
                if (today == DayOfWeek.Saturday || today == DayOfWeek.Sunday)
                {
                    string weekendQuery = "SELECT STRING_AGG(BodyNumber, ' / ') FROM MemberInfo WHERE MemberStatus = 'Active'";
                    codingMembers = Convert.ToString(new SqlCommand(weekendQuery, conn).ExecuteScalar());
                }
                else
                {
                    codingMembers = unavailableDigits.Replace(",", " / ");
                }

                codingLbl.Text = codingMembers;
            }
        }

        public TricycleModel GetTricycleDetails(int bodyNumber)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT FirstName, MiddleInitial, LastName, ContactNumber, MembershipType,
                   PlateNumber, TricycleBrand, ChassisNumber, EngineNumber, TricycleModel
            FROM MemberInfo
            WHERE BodyNumber = @BodyNumber";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@BodyNumber", bodyNumber);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return new TricycleModel
                        {
                            BodyNumber = bodyNumber,
                            FirstName = reader["FirstName"].ToString(),
                            MiddleInitial = reader["MiddleInitial"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            ContactNumber = reader["ContactNumber"].ToString(),
                            MembershipType = reader["MembershipType"].ToString(),
                            PlateNumber = reader["PlateNumber"].ToString(),
                            TricycleBrand = reader["TricycleBrand"].ToString(),
                            ChassisNumber = reader["ChassisNumber"].ToString(),
                            EngineNumber = reader["EngineNumber"].ToString(),
                            TricModel = reader["TricycleModel"].ToString()
                        };
                    }
                    return null;
                }
            }
        }

    }
}
