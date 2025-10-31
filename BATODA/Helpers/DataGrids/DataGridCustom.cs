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

            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 230, 230);
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 18, FontStyle.Regular);

            dgv.Font = new Font("Microsoft Sans Serif", 18, FontStyle.Regular);
            dgv.RowTemplate.Height = 70;
            dgv.MultiSelect = false;

            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(173, 46, 36);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 13, FontStyle.Regular);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(173, 46, 36);
        }

        public static void AddActionButtons(DataGridView dgv)
        {
            if (dgv == null) return;

            if (dgv.Columns.Contains("Edit"))
                dgv.Columns.Remove("Edit");
            if (dgv.Columns.Contains("Delete"))
                dgv.Columns.Remove("Delete");

            var baseColor = Color.FromArgb(173, 46, 36);
            var hoverColor = ControlPaint.Dark(baseColor, 0.2f);

            var editButton = new DataGridViewButtonColumn
            {
                Name = "Edit",
                HeaderText = "Edit",
                Text = "Edit",
                UseColumnTextForButtonValue = true,
                Width = 80,
                FlatStyle = FlatStyle.Flat
            };

            var deleteButton = new DataGridViewButtonColumn
            {
                Name = "Delete",
                HeaderText = "Delete",
                Text = "Delete",
                UseColumnTextForButtonValue = true,
                Width = 80,
                FlatStyle = FlatStyle.Flat
            };

            dgv.Columns.Add(editButton);
            dgv.Columns.Add(deleteButton);

            dgv.DataBindingComplete += (s, e) =>
            {
                if (dgv.Columns.Contains("Edit") && dgv.Columns.Contains("Delete"))
                {
                    editButton.DisplayIndex = dgv.Columns.Count - 2;
                    deleteButton.DisplayIndex = dgv.Columns.Count - 1;
                }
            };


            dgv.CellPainting += (s, e) =>
            {

                if (e.RowIndex < 0) return;

                
                if (e.RowIndex == dgv.NewRowIndex)
                {
                    e.Handled = true;
                    return;
                }


                if (e.ColumnIndex == dgv.Columns["Edit"].Index || e.ColumnIndex == dgv.Columns["Delete"].Index)
                {
                    e.PaintBackground(e.CellBounds, false);

                    var mousePos = dgv.PointToClient(Control.MousePosition);
                    bool isHover = e.CellBounds.Contains(mousePos);

                    var fillColor = isHover ? hoverColor : baseColor;

                    using (var brush = new SolidBrush(fillColor))
                        e.Graphics.FillRectangle(brush, e.CellBounds);

                    TextRenderer.DrawText(  
                        e.Graphics,
                        e.Value?.ToString(),
                        e.CellStyle.Font,
                        e.CellBounds,
                        Color.White,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
                    );

                    e.Handled = true;
                }
            };
            dgv.NewRowNeeded += (s, e) =>
            {
                if (dgv.Columns.Contains("Edit"))
                    dgv["Edit", dgv.NewRowIndex].ReadOnly = true;
                if (dgv.Columns.Contains("Delete"))
                    dgv["Delete", dgv.NewRowIndex].ReadOnly = true;
            };
        }
    }
}

