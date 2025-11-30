using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BATODA.Helpers.DataGrid
{
    public static class AttendanceHandler
    {
        public static void ApplyCustomGridWithCheckbox(DataGridView dgv)
        {
            if (dgv == null) return;

            // Clear existing columns
            dgv.Columns.Clear();

            // Add checkbox column
            DataGridViewCheckBoxColumn chkColumn = new DataGridViewCheckBoxColumn();
            chkColumn.Name = "chkSelect";
            chkColumn.HeaderText = "";
            chkColumn.Width = 15;
            chkColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            chkColumn.ReadOnly = false;
            chkColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns.Add(chkColumn);


            DataGridViewTextBoxColumn bodyNumberColumn = new DataGridViewTextBoxColumn();
            bodyNumberColumn.Name = "colBodyNumber";
            bodyNumberColumn.HeaderText = "Body No.";
            bodyNumberColumn.Width = 90;
            bodyNumberColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            bodyNumberColumn.ReadOnly = true;
            bodyNumberColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns.Add(bodyNumberColumn);


            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.Name = "colName";
            nameColumn.HeaderText = "Name";
            nameColumn.ReadOnly = true;
            nameColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns.Add(nameColumn);

            dgv.BorderStyle = BorderStyle.None;
            dgv.BackgroundColor = Color.White;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgv.AllowUserToResizeRows = false;
            dgv.AllowUserToResizeColumns = false;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ColumnHeadersHeight = 30;

            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dgv.ReadOnly = false;

            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 230, 230);
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);

            dgv.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);
            dgv.RowTemplate.Height = 30;
            dgv.MultiSelect = false;

            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(173, 46, 36);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 13, FontStyle.Regular);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(173, 46, 36);

            dgv.CellContentClick += (s, e) =>
            {
                if (dgv.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
                    dgv.CommitEdit(DataGridViewDataErrorContexts.Commit);
            };
        }
    }
}
