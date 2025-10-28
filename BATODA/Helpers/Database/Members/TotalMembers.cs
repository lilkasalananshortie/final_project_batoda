using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BATODA.Helpers.Database.Members
{

    /// <summary>
    /// Applies consistent font and row height style to any DataGridView.
    /// </summary>
   
    // used in MembersUForm to display total members
    public static class TotalMembers
    {
        private static readonly string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=BatodaDb;Security=True;TrustServerCertificate=True";
        public static int GetCount()
        {
            int total = 0;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT COUNT(*) FROM MemberInfo";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    total = (int)cmd.ExecuteScalar();
                }
            }
            return total;
        }
    }
}
