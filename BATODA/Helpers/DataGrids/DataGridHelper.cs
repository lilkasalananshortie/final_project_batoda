using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BATODA.Helpers.DataGrids
{
    internal static class DataGridHelper
    {
        /// <summary>
        /// Applies consistent font and row height style to any DataGridView.
        /// </summary>
        public static void ApplyCustomGrid(DataGridView dgv)
        {
            if (dgv == null) return;

            dgv.Font = new Font("Microsoft Sans Serif", 18, FontStyle.Regular);
            dgv.RowTemplate.Height = 60;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 18, FontStyle.Bold);
        }
    }
}