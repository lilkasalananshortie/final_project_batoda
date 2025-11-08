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

        public static void LoadTransferHistoryToGrid(DataGridView grid, DataTable table)
        {
            grid.DataSource = table;

            grid.Columns["TransferID"].Visible = false;
            grid.Columns["BodyNumber"].HeaderText = "Body Number";
            grid.Columns["FullName"].HeaderText = "Owner Name";
            grid.Columns["ProcessType"].HeaderText = "Process Type";
            grid.Columns["ReasonForTransfer"].HeaderText = "Reason";
            grid.Columns["DateTransferred"].HeaderText = "Date";

            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            foreach (DataGridViewColumn col in grid.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        public static void LoadTricyclesToGrid(DataGridView grid, DataTable table)
        {
            grid.DataSource = null;

            grid.Columns.Clear();

            grid.Columns.Add("BodyNumber", "Body No.");
            grid.Columns.Add("LastName", "Surname");
            grid.Columns.Add("FirstName", "First Name");
            grid.Columns.Add("TricycleBrand", "Brand");
            grid.Columns.Add("TricModel", "Model");
            grid.Columns.Add("PlateNumber", "Plate No.");
            grid.Columns.Add("EngineNumber", "Engine No.");
            grid.Columns.Add("ChassisNumber", "Chassis No.");
            grid.Columns.Add("Availability", "Availability");

            foreach (DataGridViewColumn col in grid.Columns)
                col.SortMode = DataGridViewColumnSortMode.NotSortable;

            grid.Rows.Clear();

            if (!table.Columns.Contains("BodyNumber"))
                table.Columns.Add("BodyNumber");
            if (!table.Columns.Contains("Availability"))
                table.Columns.Add("Availability");

            foreach (DataRow row in table.Rows)
            {
                grid.Rows.Add(
                    row["BodyNumber"].ToString().PadLeft(3, '0'), 
                    row["LastName"].ToString(),
                    row["FirstName"].ToString(),
                    row["TricycleBrand"].ToString(),
                    row["TricycleModel"].ToString(),
                    row["PlateNumber"].ToString(),
                    row["EngineNumber"].ToString(),
                    row["ChassisNumber"].ToString(),
                    row["Availability"].ToString()
                );
            }
        }
    }
}
