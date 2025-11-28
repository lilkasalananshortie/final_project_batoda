using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BATODA.Helpers.DataGrid
{
    internal class BackupSettings
    {
        public static void ApplyBackupGrid(DataGridView dgv)
        {
            if (dgv == null) return;

            dgv.Columns.Clear();
            dgv.RowHeadersVisible = false;

            var colName = new DataGridViewTextBoxColumn
            {
                Name = "colBackupName",
                HeaderText = "Backup Name",
                Width = 330,   
                ReadOnly = true
            };
            dgv.Columns.Add(colName);
            colName.DefaultCellStyle.Padding = new Padding(10, 0, 10, 0);

            var colDate = new DataGridViewTextBoxColumn
            {
                Name = "colDateCreated",
                HeaderText = "Date Created",
                Width = 330,                
                ReadOnly = true
            };
            dgv.Columns.Add(colDate);

            var colSize = new DataGridViewTextBoxColumn
            {
                Name = "colSize",
                HeaderText = "Size",
                Width = 159,               
                ReadOnly = true
            };
            dgv.Columns.Add(colSize);

            var colType = new DataGridViewTextBoxColumn
            {
                Name = "colType",
                HeaderText = "Type",
                Width = 159,               
                ReadOnly = true
            };
            dgv.Columns.Add(colType);


            // ------------------------------------------------------
            // ** GENERAL VISUALS **
            // ------------------------------------------------------
            dgv.BackgroundColor = Color.White;
            dgv.GridColor = Color.FromArgb(173, 46, 36);
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.AllowUserToResizeColumns = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.BorderStyle = BorderStyle.FixedSingle;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgv.RowTemplate.Height = 55;

            // -------------------------------  
            // HEADER DESIGN
            // -------------------------------
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(173, 46, 36);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = dgv.ColumnHeadersDefaultCellStyle.BackColor;
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = dgv.ColumnHeadersDefaultCellStyle.ForeColor;

            dgv.ColumnHeadersHeight = 40;

            // -------------------------------
            // CELL DESIGN
            // -------------------------------
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(245, 245, 245);
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.FromArgb(240, 244, 248);
            dgv.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.DefaultCellStyle.Padding = new Padding(10, 5, 10, 5);

           
        }

    }
}
