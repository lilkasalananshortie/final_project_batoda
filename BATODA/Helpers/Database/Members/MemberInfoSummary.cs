using System;
using System.Data.SqlClient;
using BATODA.Modules.MemberModule;

namespace BATODA.Helpers.Database.Members
{
    internal static class MemberInfoSummary
    {
        private static readonly string connectionString =
            @"Data Source=localhost\SQLEXPRESS;Initial Catalog=BatodaDb;Integrated Security=True;TrustServerCertificate=True";

        // ACTIVE MEMBERS
        public static int GetActiveCount()
        {
            return GetCountByStatus("Active");
        }

        // INACTIVE MEMBERS
        public static int GetInactiveCount()
        {
            return GetCountByStatus("Inactive");
        }

        // DRIVERS
        public static int GetDriverCount()
        {
            return GetCountByMembershipType("Driver");
        }

        // OPRATORS
        public static int GetOperatorCount()
        {
            return GetCountByMembershipType("Operator");
        }

        public static MemberModel FetchMemberData(int bodyNumber)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM MemberInfo WHERE BodyNumber = @BodyNumber";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@BodyNumber", bodyNumber);
                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new MemberModel
                            {
                                BodyNumber = (int)reader["BodyNumber"],
                                MembershipType = reader["MembershipType"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                FirstName = reader["FirstName"].ToString(),
                                MiddleInitial = reader["MiddleInitial"] != DBNull.Value ? reader["MiddleInitial"].ToString() : "",
                                Birthdate = (DateTime)reader["Birthdate"],
                                TricycleBrand = reader["TricycleBrand"].ToString(),
                                TricycleModel = reader["TricycleModel"].ToString(),
                                ContactNumber = reader["ContactNumber"].ToString(),
                                ChassisNumber = reader["ChassisNumber"].ToString(),
                                EngineNumber = reader["EngineNumber"].ToString(),
                                PlateNumber = reader["PlateNumber"].ToString(),
                                TaxBalance = reader["TaxBalance"] != DBNull.Value ? Convert.ToDecimal(reader["TaxBalance"]) : 0,
                                MemberStatus = reader["MemberStatus"].ToString(),
                                PenaltyLevel = reader["PenaltyLevel"] != DBNull.Value ? Convert.ToInt32(reader["PenaltyLevel"]) : 0,
                                SuspensionDays = reader["SuspensionDays"] != DBNull.Value ? Convert.ToInt32(reader["SuspensionDays"]) : 0,
                                DateJoined = (DateTime)reader["DateJoined"]
                            };
                        }
                    }
                }
            }
            return null;
        }


        public static int GetSuspendedCount()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM MemberInfo WHERE PenaltyLevel = 3";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        private static int GetCountByStatus(string status)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM MemberInfo WHERE LTRIM(RTRIM(MemberStatus)) = @status";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@status", status);
                    conn.Open();
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        private static int GetCountByMembershipType(string type)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM MemberInfo WHERE MembershipType = @type";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@type", type);
                    conn.Open();
                    return (int)cmd.ExecuteScalar();
                }
            }
        }
    }
}
