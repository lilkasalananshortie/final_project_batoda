using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BATODA.Modules.Member_Module.Member_Classes
{
    internal class TransferLoadOwner
    {
        private static readonly string connectionString =
            @"Data Source=localhost\SQLEXPRESS;Initial Catalog=BatodaDb;Integrated Security=True;TrustServerCertificate=True";

        public void LoadOwnerDetails(string bodyNumber,
        Label CurrentBodyLbl, Label CurrentFirstNameLbl, Label CurrentLastNameLbl, Label CurrentMiddleLbl,
        Label CurrentMemberTypeLbl, Label CurrentPlateLbl, Label CurrentChassisLbl, Label CurrentEngineLbl,
        Label CurrentBrandLbl, Label CurrentModelLbl, Label CurrentBirthdateLbl, Label CurrentContactLbl)
        {
            try
            {
                string query = @"
            SELECT BodyNumber, MembershipType, LastName, FirstName, MiddleInitial, 
                   Birthdate, TricycleBrand, TricycleModel, ContactNumber, 
                   ChassisNumber, EngineNumber, PlateNumber
            FROM MemberInfo
            WHERE BodyNumber = @BodyNumber";

                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@BodyNumber", bodyNumber);
                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            CurrentBodyLbl.Text = "BATODA (" + Convert.ToInt32(reader["BodyNumber"]).ToString("D3") + ")";
                            CurrentFirstNameLbl.Text = reader["FirstName"].ToString();
                            CurrentLastNameLbl.Text = reader["LastName"].ToString();
                            CurrentMiddleLbl.Text = reader["MiddleInitial"].ToString();
                            CurrentMemberTypeLbl.Text = reader["MembershipType"].ToString();
                            CurrentPlateLbl.Text = reader["PlateNumber"].ToString();
                            CurrentChassisLbl.Text = reader["ChassisNumber"].ToString();
                            CurrentEngineLbl.Text = reader["EngineNumber"].ToString();
                            CurrentBrandLbl.Text = reader["TricycleBrand"].ToString();
                            CurrentModelLbl.Text = reader["TricycleModel"].ToString();
                            CurrentBirthdateLbl.Text = reader["Birthdate"].ToString();
                            CurrentContactLbl.Text = reader["ContactNumber"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("No record found for the selected Body Number.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading owner details: " + ex.Message);
            }
        }

    }
}
