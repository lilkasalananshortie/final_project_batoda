using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BATODA.Modules.Tricycle_Module.Tricycle_Classes
{
    public static class SearchTricycle
    {
        private static readonly string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=BatodaDb;Integrated Security=True;TrustServerCertificate=True";

        public static DataTable Find(string searchText)
        {
            DataTable tricycleTable = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = @"
                    SELECT * FROM MemberInfo
                    WHERE RIGHT('000' + CAST(BodyNumber AS VARCHAR), 3) LIKE @search
                       OR FirstName LIKE @search
                       OR LastName LIKE @search
                       OR EngineNumber LIKE @search
                       OR ChassisNumber LIKE @search
                       OR PlateNumber LIKE @search
                ";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@search", "%" + searchText + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(tricycleTable);
                }
            }
            return tricycleTable;
        }
    }
}
