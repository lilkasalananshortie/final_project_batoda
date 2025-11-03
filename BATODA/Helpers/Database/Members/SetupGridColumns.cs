using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BATODA.Helpers.Database.Members
{
    public class SetupGridColumns
    {
        public void ApplyGridSetup(DataGridView grid)
        {
            string[] columnNames = { "BodyNumber", "LastName", "FirstName", "Birthdate", "MembershipType", "ContactNumber", "MemberStatus", "PenaltyLevel" };
            string[] columnHeaders = { "Body No.", "Last Name", "First Name", "Birthdate", "Membership Type", "Contact Number", "Status", "Penalty Details" };


            // Disabling built-in sort to avoid confusion and unintentional sorting
            // Array > Hardcoded
            for (int i = 0; i < columnNames.Length; i++)
            {
                grid.Columns.Add(columnNames[i], columnHeaders[i]);
                grid.Columns[columnNames[i]].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
    }
}
