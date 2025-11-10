using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BATODA.Helpers.Database.Assistance
{
    internal class RequestsCount
    {
        private static readonly string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=BatodaDb;Integrated Security=True;TrustServerCertificate=True";

        public static int CountPendingRequests()
        {
            int count = 0;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM FinancialAssistanceRequests WHERE RequestStatus = 'Pending'";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    count = (int)cmd.ExecuteScalar();
                }
            }

            return count;
        }
    }

}
