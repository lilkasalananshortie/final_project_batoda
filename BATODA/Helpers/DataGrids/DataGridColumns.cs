using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BATODA.Helpers.DataGrids
{
    public static class DataGridColumns
    {

        // LIST OF MEMBERS
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

        // LIST OF MEMBERSHIP TRANSFER HISTORY
        public static void LoadMembershipTransferHistoryToGrid(DataGridView grid, DataTable table)
        {
            grid.Columns.Clear();
            grid.Rows.Clear();

            grid.Columns.Add("TransferID", "Transfer ID");
            grid.Columns.Add("BodyNumber", "Body Number");
            grid.Columns.Add("PastOwnerFullName", "Past Owner");
            grid.Columns.Add("NewOwnerFullName", "New Owner");
            grid.Columns.Add("ReasonForTransfer", "Reason");
            grid.Columns.Add("DateOfTransfer", "Date of Transfer");

            foreach (DataRow row in table.Rows)
            {
                grid.Rows.Add(
                    row["TransferID"].ToString(),
                    row["BodyNumber"].ToString().PadLeft(3, '0'),
                    row["PastOwnerFullName"].ToString(),
                    row["NewOwnerFullName"].ToString(),
                    row["ReasonForTransfer"].ToString(),
                    Convert.ToDateTime(row["DateOfTransfer"]).ToShortDateString()
                );
            }
        }


    }
}
