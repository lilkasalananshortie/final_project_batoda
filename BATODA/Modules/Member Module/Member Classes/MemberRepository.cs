using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                            PenaltyLevel 
                         FROM MemberInfo
                         ORDER BY BodyNumber DESC";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        members.Add(new MemberModel
                        {
                            // modelvar = reader[db col]
                            BodyNumber = (int)reader["BodyNumber"],
                            LastName = reader["LastName"].ToString(),
                            FirstName = reader["FirstName"].ToString(),
                            MiddleInitial = reader["MiddleInitial"].ToString(),
                            Birthdate = (DateTime)reader["Birthdate"],
                            MembershipType = reader["MembershipType"].ToString(),
                            ContactNumber = reader["ContactNumber"].ToString(),
                            MemberStatus = reader["MemberStatus"].ToString(),
                            PenaltyLevel = (int)reader["PenaltyLevel"]
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
                string query = @"UPDATE MemberInfo SET 
                    MembershipType=@MembershipType, LastName=@LastName, FirstName=@FirstName, 
                    MiddleInitial=@MiddleInitial, Birthdate=@Birthdate, TricycleBrand=@TricycleBrand, 
                    TricycleModel=@TricycleModel, ContactNumber=@ContactNumber, ChassisNumber=@ChassisNumber, 
                    EngineNumber=@EngineNumber, PlateNumber=@PlateNumber, TaxBalance=@TaxBalance, 
                    MemberStatus=@MemberStatus, PenaltyLevel=@PenaltyLevel, SuspensionDays=@SuspensionDays, 
                    DaysRemaining=@DaysRemaining
                    WHERE BodyNumber=@BodyNumber";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@BodyNumber", member.BodyNumber);
                    cmd.Parameters.AddWithValue("@MembershipType", member.MembershipType);
                    cmd.Parameters.AddWithValue("@LastName", member.LastName);
                    cmd.Parameters.AddWithValue("@FirstName", member.FirstName);
                    cmd.Parameters.AddWithValue("@MiddleInitial", member.MiddleInitial);
                    cmd.Parameters.AddWithValue("@Birthdate", member.Birthdate);
                    cmd.Parameters.AddWithValue("@TricycleBrand", member.TricycleBrand);
                    cmd.Parameters.AddWithValue("@TricycleModel", member.TricycleModel);
                    cmd.Parameters.AddWithValue("@ContactNumber", member.ContactNumber);
                    cmd.Parameters.AddWithValue("@ChassisNumber", member.ChassisNumber);
                    cmd.Parameters.AddWithValue("@EngineNumber", member.EngineNumber);
                    cmd.Parameters.AddWithValue("@PlateNumber", member.PlateNumber);
                    cmd.Parameters.AddWithValue("@TaxBalance", member.TaxBalance);
                    cmd.Parameters.AddWithValue("@MemberStatus", member.MemberStatus);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // --------------- DELETE MEMBERS -----------------
        public void DeleteMember(int bodyNumber)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM MemberInfo WHERE BodyNumber = @BodyNumber";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@BodyNumber", bodyNumber);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
