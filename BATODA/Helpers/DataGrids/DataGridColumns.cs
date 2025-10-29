using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BATODA.Helpers.DataGrids
{
    public static class DataGridColumns
    {
        public static void LoadMembersToGrid(DataGridView grid, DataTable table)
        {
            grid.Rows.Clear();

            foreach (DataRow row in table.Rows)
            {
                grid.Rows.Add(
                    row["BodyNumber"].ToString().PadLeft(3, '0'),
                    row["LastName"].ToString(),
                    row["FirstName"].ToString(),
                    Convert.ToDateTime(row["Birthdate"]).ToShortDateString(),
                    row["MembershipType"].ToString(),
                    row["ContactNumber"].ToString(),
                    row["MemberStatus"].ToString(),
                    row["PenaltyLevel"].ToString()
                );
            }
        }
    }
}
