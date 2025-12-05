using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BATODA.Helpers.DataGrids
{
    internal static class DataGridCustom
    {
        /// <summary>
        /// Applies consistent font and row height style to any DataGridView.
        /// </summary>
        public static void ApplyCustomGrid(DataGridView dgv)
        {
            if (dgv == null) return;

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
            dgv.ColumnHeadersHeight = 70;

            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
                dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dgv.ReadOnly = true;


            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 230, 230);
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
            dgv.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
            dgv.RowTemplate.Height = 70;
            dgv.MultiSelect = false;
            

            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(173, 46, 36);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(173, 46, 36);
        }

        public static void ApplyCustomMemberHistoryGrid(DataGridView dgv)
        {
            if (dgv == null) return;

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
            dgv.ColumnHeadersHeight = 60;

            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
                dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dgv.ReadOnly = true;


            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 230, 230);
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
            dgv.RowTemplate.Height = 55;
            dgv.MultiSelect = false;


            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(173, 46, 36);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(173, 46, 36);
        }



        public static void FinanceMultiSelectCustomGrid(DataGridView dgv)
        {
            if (dgv == null) return;

            dgv.Rows.Clear();
            dgv.Columns.Clear();

            dgv.BorderStyle = BorderStyle.None;
            dgv.BackgroundColor = Color.White;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.AllowUserToResizeColumns = false;

            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = true;
            dgv.ReadOnly = true;

            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ColumnHeadersHeight = 40;

            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(173, 46, 36);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(173, 46, 36);

            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 230, 230);
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.RowTemplate.Height = 50;


            var colBodyNo = new DataGridViewTextBoxColumn();
            colBodyNo.Name = "BodyNo";
            colBodyNo.HeaderText = "Body No.";
            colBodyNo.Width = 100; 
            colBodyNo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var colFullName = new DataGridViewTextBoxColumn();
            colFullName.Name = "FullName";
            colFullName.HeaderText = "Member Name";
            colFullName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colFullName.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.Columns.Add(colBodyNo);
            dgv.Columns.Add(colFullName);
        }



        //edit button with hover effect =)
        public static void AddEditButtonOnly(DataGridView dgv)
        {
            if (dgv == null) return;

            if (dgv.Columns.Contains("Edit"))
                dgv.Columns.Remove("Edit");

            var editColumn = new DataGridViewImageColumn
            {
                Name = "Edit",
                HeaderText = "Edit",
                Image = Properties.Resources.edit,
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Width = 40 
            };

            dgv.Columns.Add(editColumn);
            editColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            editColumn.DefaultCellStyle.Padding = new Padding(5);

          
            int hoveredRow = -1;

           
            dgv.CellMouseEnter += (s, e) =>
            {
                if (e.RowIndex < 0 || e.ColumnIndex != dgv.Columns["Edit"].Index) return;
                hoveredRow = e.RowIndex;
                dgv.InvalidateCell(e.ColumnIndex, e.RowIndex); 
            };

            dgv.CellMouseLeave += (s, e) =>
            {
                if (e.RowIndex < 0 || e.ColumnIndex != dgv.Columns["Edit"].Index) return;
                hoveredRow = -1;
                dgv.InvalidateCell(e.ColumnIndex, e.RowIndex);
            };

            dgv.CellPainting += (s, e) =>
            {
                if (e.RowIndex < 0 || e.ColumnIndex != dgv.Columns["Edit"].Index) return;

                e.PaintBackground(e.CellBounds, true);

                bool isHover = e.RowIndex == hoveredRow;

                Image img = isHover ? Properties.Resources.edit_hover : Properties.Resources.edit;

                int targetSize = 20; 
                int x = e.CellBounds.X + (e.CellBounds.Width - targetSize) / 2;
                int y = e.CellBounds.Y + (e.CellBounds.Height - targetSize) / 2;

                e.Graphics.DrawImage(img, x, y, targetSize, targetSize);
                e.Handled = true;
            };
        }

        // with hover na rin =)
        public static void AddActionButtons(DataGridView dgv)
        {
            if (dgv == null) return;

            if (dgv.Columns.Contains("Edit"))
                dgv.Columns.Remove("Edit");
            if (dgv.Columns.Contains("Delete"))
                dgv.Columns.Remove("Delete");

            var editColumn = new DataGridViewImageColumn
            {
                Name = "Edit",
                HeaderText = "Edit",
                Image = Properties.Resources.edit,
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Width = 70, 
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            };

            var deleteColumn = new DataGridViewImageColumn
            {
                Name = "Delete",
                HeaderText = "Delete",
                Image = Properties.Resources.delete,
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Width = 70, 
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            };

            dgv.Columns.Add(editColumn);
            dgv.Columns.Add(deleteColumn);

            foreach (DataGridViewColumn col in new[] { editColumn, deleteColumn })
            {
                col.DefaultCellStyle.Padding = new Padding(5);
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            int hoveredRow = -1;
            int hoveredCol = -1;

            dgv.CellMouseEnter += (s, e) =>
            {
                if (e.RowIndex < 0) return;
                if (e.ColumnIndex == dgv.Columns["Edit"].Index || e.ColumnIndex == dgv.Columns["Delete"].Index)
                {
                    hoveredRow = e.RowIndex;
                    hoveredCol = e.ColumnIndex;
                    dgv.InvalidateCell(e.ColumnIndex, e.RowIndex);
                }
            };

            dgv.CellMouseLeave += (s, e) =>
            {
                if (e.RowIndex < 0) return;
                if (e.ColumnIndex == hoveredCol)
                {
                    hoveredRow = -1;
                    hoveredCol = -1;
                    dgv.InvalidateCell(e.ColumnIndex, e.RowIndex);
                }
            };

            dgv.CellPainting += (s, e) =>
            {
                if (e.RowIndex < 0) return;
                if (e.ColumnIndex != dgv.Columns["Edit"].Index && e.ColumnIndex != dgv.Columns["Delete"].Index)
                    return;

                e.PaintBackground(e.CellBounds, true);

                bool isHover = e.RowIndex == hoveredRow && e.ColumnIndex == hoveredCol;
                Image img = e.ColumnIndex == dgv.Columns["Edit"].Index
                    ? (isHover ? Properties.Resources.edit_hover : Properties.Resources.edit)
                    : (isHover ? Properties.Resources.delete_hover : Properties.Resources.delete);

                int targetSize = 20;
                int x = e.CellBounds.X + (e.CellBounds.Width - targetSize) / 2;
                int y = e.CellBounds.Y + (e.CellBounds.Height - targetSize) / 2;

                e.Graphics.DrawImage(img, x, y, targetSize, targetSize);
                e.Handled = true;
            };
        }


    }
}

