using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BATODA.Modules.Member_Module.Member_Classes
{
    internal class TransferSearchOwner
    {
        private static readonly string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=BatodaDb;Integrated Security=True;TrustServerCertificate=True";
        public void SearchOwner(TextBox OwnerSearchTxt, DataGridView OwnerSearchGrid)
        {
            if (string.IsNullOrWhiteSpace(OwnerSearchTxt.Text))
                return;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    OwnerSearchGrid.Rows.Clear();
                    OwnerSearchGrid.Visible = true;

                    string query = @"
                    SELECT 
                        RIGHT('000' + CAST(BodyNumber AS VARCHAR(3)), 3) AS BodyNumber, 
                        FirstName, 
                        LastName 
                    FROM MemberInfo
                    WHERE FirstName LIKE @search + '%' 
                       OR LastName LIKE @search + '%' 
                       OR RIGHT('000' + CAST(BodyNumber AS VARCHAR(3)), 3) LIKE @search + '%'";


                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@search", OwnerSearchTxt.Text.Trim());

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string paddedBodyNumber = reader["BodyNumber"].ToString();
                        OwnerSearchGrid.Rows.Add(paddedBodyNumber, reader["FirstName"].ToString(), reader["LastName"].ToString());
                    }


                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
