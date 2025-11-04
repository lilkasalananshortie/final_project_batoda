using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BATODA.Helpers.DataGrids;

namespace BATODA.Helpers.Database.Tricycle
{
    public static class LoadTricycleTable
    {
        // Pass the DataGridView as a parameter so this method can be reused
        public static void LoadTricycleGridWithData(DataGridView grid, DataTable table)
        {
            // Apply custom grid style
            DataGridCustom.ApplyCustomGrid(grid);

            // Load data into grid
            DataGridColumns.LoadTricyclesToGrid(grid, table);

            // Add only Edit button
            DataGridCustom.AddEditButtonOnly(grid);
        }
    }
}
