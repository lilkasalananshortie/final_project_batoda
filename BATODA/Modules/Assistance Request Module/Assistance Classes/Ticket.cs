using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BATODA.Modules.Assistance_Request_Module.Assistance_Classes
{
    internal class Ticket
    {
        private static readonly string connectionString =
            @"Data Source=localhost\SQLEXPRESS;Initial Catalog=BatodaDb;Integrated Security=True;TrustServerCertificate=True";

        public static int GetNextTicketID()
        {
            int nextId = 100;
            string query = "SELECT ISNULL(MAX(TicketID), 0) + 1 FROM FinancialAssistanceRequests";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                nextId = Convert.ToInt32(cmd.ExecuteScalar());
            }

            return nextId;
        }
    }
}

