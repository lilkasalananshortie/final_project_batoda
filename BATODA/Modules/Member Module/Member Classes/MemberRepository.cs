using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BATODA.Helpers.Database.Members;

namespace BATODA.Modules.MemberModule
{
    public class MemberRepository
    {
        private readonly string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=BatodaDb;Integrated Security=True;TrustServerCertificate=True";

        // --------------- VIEW MEMBERS -----------------
        // Only fetch the ff:
        // Body Number, Last Name, First Name, Middle Name, Birthdate, MembershipType, Contact Number, MembersStatus, PenaltyLevel
        public List<MemberModel> GetAllMembers()
        {
            List<MemberModel> members = new List<MemberModel>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"SELECT 
                    BodyNumber, 
                    LastName, 
                    FirstName, 
                    MiddleInitial, 
                    Birthdate, 
                    MembershipType, 
                    ContactNumber,
                    MemberStatus, 
                    PenaltyLevel,
                    SuspensionDays,
                    SuspensionStart
                FROM MemberInfo
                ORDER BY BodyNumber DESC
                ";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        members.Add(new MemberModel
                        {
                            BodyNumber = (int)reader["BodyNumber"],
                            LastName = reader["LastName"].ToString(),
                            FirstName = reader["FirstName"].ToString(),
                            MiddleInitial = reader["MiddleInitial"].ToString(),
                            Birthdate = (DateTime)reader["Birthdate"],
                            MembershipType = reader["MembershipType"].ToString(),
                            ContactNumber = reader["ContactNumber"].ToString(),
                            MemberStatus = reader["MemberStatus"].ToString(),
                            PenaltyLevel = (int)reader["PenaltyLevel"],
                            SuspensionDays = reader["SuspensionDays"] != DBNull.Value ? Convert.ToInt32(reader["SuspensionDays"]) : 0,
                            SuspensionStartDate = reader["SuspensionStart"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(reader["SuspensionStart"]) : null
                        });

                    }
                }
            }
            return members;
        }

        // --------------- ADDING NEW MEMBERS -----------------
        public void AddMember(MemberModel member)
        {
            MemberValidator.ValidateMember(member);

            // WAG TATANGGAP NG INPUT
            if (!string.Equals(member.MembershipType, "Driver", StringComparison.OrdinalIgnoreCase) &&
                !string.Equals(member.MembershipType, "Operator", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Membership Type must be either 'Driver' or 'Operator'.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // DUPE CHECKING QUERY
                string duplicateQuery = @"
                   SELECT COUNT(*) FROM MemberInfo 
                   WHERE PlateNumber = @PlateNumber 
                   OR ChassisNumber = @ChassisNumber 
                   OR EngineNumber = @EngineNumber
                   OR ContactNumber = @ContactNumber";

                using (SqlCommand checkCmd = new SqlCommand(duplicateQuery, con))
                {
                    checkCmd.Parameters.AddWithValue("@PlateNumber", member.PlateNumber ?? "");
                    checkCmd.Parameters.AddWithValue("@ChassisNumber", member.ChassisNumber ?? "");
                    checkCmd.Parameters.AddWithValue("@EngineNumber", member.EngineNumber ?? "");
                    checkCmd.Parameters.AddWithValue("@ContactNumber", member.ContactNumber ?? "");

                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("A member with the same Plate, Chassis, \nEngine number, or Contact Number already exists!");
                        return;
                    }
                }

                string insertQuery = @"
                INSERT INTO MemberInfo 
                (MembershipType, LastName, FirstName, MiddleInitial, Birthdate, 
                TricycleBrand, TricycleModel, ContactNumber, ChassisNumber, 
                EngineNumber, PlateNumber, DateJoined, MemberStatus)
                VALUES 
                (@MembershipType, @LastName, @FirstName, @MiddleInitial, @Birthdate, 
                @TricycleBrand, @TricycleModel, @ContactNumber, @ChassisNumber, 
                @EngineNumber, @PlateNumber, @DateJoined, @MemberStatus)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                {
                    cmd.Parameters.AddWithValue("@MembershipType", member.MembershipType ?? "");
                    cmd.Parameters.AddWithValue("@LastName", member.LastName ?? "");
                    cmd.Parameters.AddWithValue("@FirstName", member.FirstName ?? "");
                    cmd.Parameters.AddWithValue("@MiddleInitial", member.MiddleInitial ?? "");
                    cmd.Parameters.AddWithValue("@Birthdate", member.Birthdate);
                    cmd.Parameters.AddWithValue("@TricycleBrand", member.TricycleBrand ?? "");
                    cmd.Parameters.AddWithValue("@TricycleModel", member.TricycleModel ?? "");
                    cmd.Parameters.AddWithValue("@ContactNumber", member.ContactNumber ?? "");
                    cmd.Parameters.AddWithValue("@ChassisNumber", member.ChassisNumber ?? "");
                    cmd.Parameters.AddWithValue("@EngineNumber", member.EngineNumber ?? "");
                    cmd.Parameters.AddWithValue("@PlateNumber", member.PlateNumber ?? "");
                    cmd.Parameters.AddWithValue("@DateJoined", DateTime.Now);
                    cmd.Parameters.AddWithValue("@MemberStatus", "Active");

                    cmd.ExecuteNonQuery();
                }
            }
        }



        // --------------- UPDATE MEMBERS -----------------
        public void UpdateMember(MemberModel member)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                // GET OLD CONTACT NUMBER
                string oldContactQuery = "SELECT ContactNumber FROM MemberInfo WHERE BodyNumber = @BodyNumber";
                string oldContact = "";
                using (SqlCommand cmd = new SqlCommand(oldContactQuery, con))
                {
                    cmd.Parameters.AddWithValue("@BodyNumber", member.BodyNumber);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                        oldContact = result.ToString();
                }

                // SOFT DELETE PENDING OR APPROVED TICKETS IF CONTACT CHANGED
                if (!string.IsNullOrEmpty(oldContact) && oldContact != member.ContactNumber)
                {
                    string softDeleteQuery = @"
                UPDATE FinancialAssistanceRequests
                SET IsActive = 0
                WHERE BodyNumber = @BodyNumber
                  AND RequestStatus IN ('Pending','Approved')";
                    using (SqlCommand cmd = new SqlCommand(softDeleteQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@BodyNumber", member.BodyNumber);
                        cmd.ExecuteNonQuery();
                    }
                }

                // UPDATE MEMBER INFO
                string updateQuery = @"
            UPDATE MemberInfo SET 
                MembershipType=@MembershipType,
                LastName=@LastName,
                FirstName=@FirstName,
                MiddleInitial=@MiddleInitial,
                Birthdate=@Birthdate,
                TricycleBrand=@TricycleBrand,
                TricycleModel=@TricycleModel,
                ContactNumber=@ContactNumber,
                ChassisNumber=@ChassisNumber,
                EngineNumber=@EngineNumber,
                PlateNumber=@PlateNumber,
                TaxBalance=@TaxBalance,
                MemberStatus=@MemberStatus,
                PenaltyLevel=@PenaltyLevel,
                SuspensionDays=@SuspensionDays,
                SuspensionStart=@SuspensionStart,
                DateJoined=@DateJoined
            WHERE BodyNumber=@BodyNumber";

                using (SqlCommand cmd = new SqlCommand(updateQuery, con))
                {
                    cmd.Parameters.AddWithValue("@BodyNumber", member.BodyNumber);
                    cmd.Parameters.AddWithValue("@MembershipType", member.MembershipType ?? "");
                    cmd.Parameters.AddWithValue("@LastName", member.LastName ?? "");
                    cmd.Parameters.AddWithValue("@FirstName", member.FirstName ?? "");
                    cmd.Parameters.AddWithValue("@MiddleInitial", member.MiddleInitial ?? "");
                    cmd.Parameters.AddWithValue("@Birthdate", member.Birthdate);
                    cmd.Parameters.AddWithValue("@TricycleBrand", member.TricycleBrand ?? "");
                    cmd.Parameters.AddWithValue("@TricycleModel", member.TricycleModel ?? "");
                    cmd.Parameters.AddWithValue("@ContactNumber", member.ContactNumber ?? "");
                    cmd.Parameters.AddWithValue("@ChassisNumber", member.ChassisNumber ?? "");
                    cmd.Parameters.AddWithValue("@EngineNumber", member.EngineNumber ?? "");
                    cmd.Parameters.AddWithValue("@PlateNumber", member.PlateNumber ?? "");
                    cmd.Parameters.AddWithValue("@TaxBalance", member.TaxBalance);
                    cmd.Parameters.AddWithValue("@MemberStatus", member.MemberStatus);
                    cmd.Parameters.AddWithValue("@PenaltyLevel", member.PenaltyLevel);
                    cmd.Parameters.AddWithValue("@SuspensionDays", member.SuspensionDays);
                    cmd.Parameters.AddWithValue("@SuspensionStart", member.SuspensionStartDate.HasValue ? (object)member.SuspensionStartDate.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@DateJoined", member.DateJoined);

                    cmd.ExecuteNonQuery();
                }
            }
        }







        // --------------- DELETE MEMBERS -----------------
        public void DeleteMember(int bodyNumber)
        {
            DateTime oldDateJoined;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string selectQuery = "SELECT DateJoined FROM MemberInfo WHERE BodyNumber = @BodyNumber";
                using (SqlCommand selectCmd = new SqlCommand(selectQuery, con))
                {
                    selectCmd.Parameters.AddWithValue("@BodyNumber", bodyNumber);
                    oldDateJoined = (DateTime)selectCmd.ExecuteScalar();
                }

                string deleteQuery = "DELETE FROM MemberInfo WHERE BodyNumber = @BodyNumber";
                using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, con))
                {
                    deleteCmd.Parameters.AddWithValue("@BodyNumber", bodyNumber);
                    deleteCmd.ExecuteNonQuery();
                }
            }

            // DELETE PAST OWNER IMAGE
            LoadOwnerImage loader = new LoadOwnerImage();
            loader.DeletePastOwnerImage(bodyNumber, oldDateJoined);
        }

        public MemberModel GetByBodyNumber(int bodyNumber)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT * FROM MemberInfo WHERE BodyNumber = @BodyNumber";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@BodyNumber", bodyNumber);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new MemberModel
                                {
                                    BodyNumber = Convert.ToInt32(reader["BodyNumber"]),
                                    DateJoined = Convert.ToDateTime(reader["DateJoined"])
                                };

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching member:\n" + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        public MemberModel MemberOverview(int bodyNumber)
        {
            string query = @"
                SELECT 
                    FirstName,
                    LastName,
                    MiddleInitial,
                    MembershipType,
                    Birthdate,
                    ContactNumber,
                    TricycleBrand,
                    TricycleModel,
                    ChassisNumber,
                    EngineNumber,
                    PlateNumber
                FROM MemberInfo
                WHERE BodyNumber = @BodyNumber;
            ";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@BodyNumber", bodyNumber);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new MemberModel
                        {
                            BodyNumber = bodyNumber,
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            MiddleInitial = reader["MiddleInitial"].ToString(),
                            MembershipType = reader["MembershipType"].ToString(),
                            Birthdate = Convert.ToDateTime(reader["Birthdate"]),
                            ContactNumber = reader["ContactNumber"].ToString(),
                            TricycleBrand = reader["TricycleBrand"].ToString(),
                            TricycleModel = reader["TricycleModel"].ToString(),
                            ChassisNumber = reader["ChassisNumber"].ToString(),
                            EngineNumber = reader["EngineNumber"].ToString(),
                            PlateNumber = reader["PlateNumber"].ToString()
                        };
                    }
                }
            }
            return null;
        }

        public void IncrementPenaltyLevel(int bodyNumber)
        {
            string query = @"
            DECLARE @CurrentLevel INT;
            SELECT @CurrentLevel = PenaltyLevel FROM MemberInfo WHERE BodyNumber = @BodyNumber;

            IF (@CurrentLevel < 3)
            BEGIN
                UPDATE MemberInfo
                SET 
                    PenaltyLevel = PenaltyLevel + 1,
                    SuspensionDays = CASE WHEN PenaltyLevel + 1 = 3 THEN 24 ELSE SuspensionDays END,
                    SuspensionStart = CASE WHEN PenaltyLevel + 1 = 3 THEN GETDATE() ELSE SuspensionStart END
                WHERE BodyNumber = @BodyNumber;
            END
            ";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@BodyNumber", bodyNumber);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateSuspensionHours()
        {
            string query = @"
        UPDATE MemberInfo
        SET 
            SuspensionDays = CASE 
                                WHEN 24 - DATEDIFF(HOUR, SuspensionStart, GETDATE()) > 0
                                THEN 24 - DATEDIFF(HOUR, SuspensionStart, GETDATE())
                                ELSE 0
                              END,
            PenaltyLevel = CASE
                            WHEN 24 - DATEDIFF(HOUR, SuspensionStart, GETDATE()) <= 0
                            THEN 0
                            ELSE PenaltyLevel
                          END,
            SuspensionStart = CASE
                                WHEN 24 - DATEDIFF(HOUR, SuspensionStart, GETDATE()) <= 0
                                THEN NULL
                                ELSE SuspensionStart
                              END
        WHERE PenaltyLevel = 3;
    ";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }






    }
}
