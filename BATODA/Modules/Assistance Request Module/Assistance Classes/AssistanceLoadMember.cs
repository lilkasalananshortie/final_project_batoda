using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BATODA.Modules.Assistance_Request_Module.Assistance_Classes
{
    internal class AssistanceLoadMember
    {
        private static readonly string connectionString =
            @"Data Source=localhost\SQLEXPRESS;Initial Catalog=BatodaDb;Integrated Security=True;TrustServerCertificate=True";

        public void LoadMemberDetails(
            string bodyNumberStr,
            Label BodyNumberLbl,
            Label MemberTypeLbl,
            Label FirstNameLbl,
            Label MiddleLbl,    
            Label LastNameLbl,
            Label ContactNoLbl)
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
                            MiddleInitial,       -- added
                            LastName,
                            ContactNumber
                        FROM MemberInfo
                        WHERE BodyNumber = @BodyNumber";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@BodyNumber", bodyNumberStr);
                    con.Open();

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        BodyNumberLbl.Text = reader["BodyNumber"].ToString();
                        MemberTypeLbl.Text = reader["MembershipType"].ToString();
                        FirstNameLbl.Text = reader["FirstName"].ToString();
                        MiddleLbl.Text = reader["MiddleInitial"].ToString();  
                        LastNameLbl.Text = reader["LastName"].ToString();
                        ContactNoLbl.Text = reader["ContactNumber"].ToString();
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading member details: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
