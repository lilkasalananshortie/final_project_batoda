using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BATODA.Helpers.Database.Members
{
    internal class GenerateNextBodyNumber
    {
        private static readonly string connectionString =
            @"Data Source=localhost\SQLEXPRESS;Initial Catalog=BatodaDb;Integrated Security=True;TrustServerCertificate=True";

        public static void ShowNext(Label label)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT ISNULL(MAX(BodyNumber), 0) + 1 FROM MemberInfo";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        int nextNumber = Convert.ToInt32(cmd.ExecuteScalar());
                        label.Text = "BATODA - " + nextNumber.ToString("D3");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating next Body Number:\n" + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
