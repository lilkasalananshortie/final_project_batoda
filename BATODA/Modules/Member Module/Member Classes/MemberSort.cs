using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BATODA.Modules.Member_Module.Member_Classes
{
    public static class MemberSort
    {
        private static readonly string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=BatodaDb;Integrated Security=True;TrustServerCertificate=True";

        public static DataTable ApplyFilter(string memberType, string order, string status)
        {
            string query = "SELECT RIGHT('000' + CAST(BodyNumber AS VARCHAR(3)), 3) AS BodyNumber, LastName, FirstName, Birthdate, MembershipType, ContactNumber, MemberStatus, PenaltyLevel FROM MemberInfo";


            List<string> conditions = new List<string>();

            // FILTER
            if (!string.IsNullOrEmpty(memberType))
                conditions.Add($"MembershipType = '{memberType}'");

            if (!string.IsNullOrEmpty(status))
                conditions.Add($"MemberStatus = '{status}'");

            if (conditions.Count > 0)
                query += " WHERE " + string.Join(" AND ", conditions);

            // SORT
            if (!string.IsNullOrEmpty(order))
            {
                switch (order)
                {
                    case "A-Z":
                        query += " ORDER BY LastName ASC";
                        break;
                    case "Z-A":
                        query += " ORDER BY LastName DESC";
                        break;
                    case "Low-High":
                        query += " ORDER BY CAST(BodyNumber AS INT) ASC";
                        break;
                    case "High-Low":
                        query += " ORDER BY CAST(BodyNumber AS INT) DESC";
                        break;
                }
            }

            MessageBox.Show(query); // DEBUG PURPOSES

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }
}
