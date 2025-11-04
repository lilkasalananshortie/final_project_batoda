using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BATODA.Modules.Tricycle_Module.Tricycle_Classes
{
    internal class TransferTricLoadOwner
    {
        private static readonly string connectionString =
            @"Data Source=localhost\SQLEXPRESS;Initial Catalog=BatodaDb;Integrated Security=True;TrustServerCertificate=True";

        public void LoadOwnerDetails(
            string bodyNumberStr,
            Label BodyNumberLbl,
            Label MemberTypeLbl,
            Label FirstNameLbl,
            Label MiddleLbl,
            Label LastNameLbl,
            TextBox BrandTxt,
            TextBox PlateTxt,
            TextBox ChassisTxt,
            TextBox EngineTxt,
            TextBox ModelTxt)
        {
            if (string.IsNullOrEmpty(bodyNumberStr))
                return;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = @"
                        SELECT 
                            BodyNumber,
                            MembershipType,
                            FirstName,
                            MiddleInitial,
                            LastName,
                            TricycleBrand,
                            PlateNumber,
                            ChassisNumber,
                            EngineNumber,
                            TricycleModel
                        FROM MemberInfo
                        WHERE BodyNumber = @BodyNumber";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@BodyNumber", bodyNumberStr);
                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        // LABELS
                        BodyNumberLbl.Text = reader["BodyNumber"].ToString();
                        MemberTypeLbl.Text = reader["MembershipType"].ToString();
                        FirstNameLbl.Text = reader["FirstName"].ToString();
                        MiddleLbl.Text = reader["MiddleInitial"].ToString();
                        LastNameLbl.Text = reader["LastName"].ToString();

                        // TXT
                        BrandTxt.Text = reader["TricycleBrand"].ToString();
                        PlateTxt.Text = reader["PlateNumber"].ToString();
                        ChassisTxt.Text = reader["ChassisNumber"].ToString();
                        EngineTxt.Text = reader["EngineNumber"].ToString();
                        ModelTxt.Text = reader["TricycleModel"].ToString();
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading tricycle owner details: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
