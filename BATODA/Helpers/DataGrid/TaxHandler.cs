using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BATODA.Helpers.DataGrid
{
    public static class TaxHandler
    {
        private static string CurrentMode = "None";
        private static Panel ViewPanelReference;

        public static void Initialize(DataGridView dgv)
        {
            dgv.BorderStyle = BorderStyle.None;
            dgv.BackgroundColor = Color.White;
            dgv.GridColor = Color.FromArgb(240, 240, 240);
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.SelectionBackColor = Color.WhiteSmoke;
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);

            dgv.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);
            dgv.RowTemplate.Height = 70;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;

            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(173, 46, 36);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 13, FontStyle.Regular);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(173, 46, 36);

            dgv.CellClick -= Dgv_CellClick;
            dgv.CellClick += Dgv_CellClick;
            dgv.CellDoubleClick -= Dgv_CellDoubleClick;
            dgv.CellDoubleClick += Dgv_CellDoubleClick;
            dgv.CellPainting -= Dgv_CellPainting;
            dgv.CellPainting += Dgv_CellPainting;

        }

        private static void Dgv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            var dgv = sender as DataGridView;

           
            if (e.RowIndex < 0 || e.ColumnIndex < 3 || e.ColumnIndex == dgv.Columns["View"].Index)
                return;

            if (dgv.Columns[e.ColumnIndex] is DataGridViewImageColumn)
            {
                e.PaintBackground(e.CellBounds, true);

                Image img = e.Value as Image;
                if (img != null)
                {
                    int targetSize = 35;
                    int x = e.CellBounds.X + (e.CellBounds.Width - targetSize) / 2;
                    int y = e.CellBounds.Y + (e.CellBounds.Height - targetSize) / 2;

                    e.Graphics.DrawImage(img, x, y, targetSize, targetSize);
                }

                e.Handled = true;
            }
        }


        public static void SetMode(string mode)
        {
            CurrentMode = mode;
        }

        public static void SetViewPanel(Panel panel)
        {
            ViewPanelReference = panel;
        }
        private static void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            var column = dgv.Columns[e.ColumnIndex];
            if (column.Name == "View")
            {
                // Show the panel using the reference
                ViewPanelReference?.Show();
            }
        }


        private static void Dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (e.RowIndex < 0 || e.ColumnIndex < 3) return;

            var cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (cell.OwningColumn.HeaderText == "View")
                return;

            string current = cell.Tag as string ?? "None";
            string next;

            if (CurrentMode != "None")
            {
                next = CurrentMode;
            }
            else
            {
                switch (current)
                {
                    case "None": next = "Paid"; break;
                    case "Paid": next = "Due"; break;
                    case "Due": next = "Overdue"; break;
                    default: next = "None"; break;
                }
            }

            switch (next)
            {
                case "Paid":
                    cell.Value = Properties.Resources.paid;
                    break;
                case "Due":
                    cell.Value = Properties.Resources.due;
                    break;
                case "Overdue":
                    cell.Value = Properties.Resources.overdue;
                    break;
                default:
                    cell.Value = Properties.Resources.circle_finance;
                    break;
            }

            cell.Tag = next;
        }


        // SAMPLE LANG TO PWEDE DELETE IF EVER ND KAILANGAN 
        public static void LoadSampleData(DataGridView dgv)
        {

            dgv.Rows.Clear();
            dgv.Columns.Clear();
            dgv.Columns.Add("BodyNo", "Body No.");
            dgv.Columns.Add("MemberName", "Member Name");
            dgv.Columns.Add("Summary", "Summary");
            dgv.Columns["BodyNo"].Width = 100;
            dgv.Columns["MemberName"].Width = 300;
            dgv.Columns["Summary"].Width = 450;


            string[] months =
            {
        "Jan", "Feb", "Mar", "Apr", "May", "Jun",
        "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"
            };

            foreach (string m in months)
            {
                var monthCol = new DataGridViewImageColumn
                {
                    HeaderText = m,
                    Name = m,
                    ImageLayout = DataGridViewImageCellLayout.Zoom,
                    Width = 40
                };
                dgv.Columns.Add(monthCol);
            }

            var viewCol = new DataGridViewButtonColumn
            {
                HeaderText = "View",
                Text = "👁",
                UseColumnTextForButtonValue = true,
                Name = "View",
                Width = 20
            };
            dgv.Columns.Add(viewCol);



            for (int i = 1; i <= 4; i++)
            {
                dgv.Rows.Add($"00{i}", "Mark Arone M. Dela Cruz", "7/12");
            }



            foreach (DataGridViewRow row in dgv.Rows)
            {
                for (int i = 3; i < dgv.Columns.Count - 1; i++)
                {
                    row.Cells[i].Value = Properties.Resources.circle_finance;
                    row.Cells[i].Tag = "None";
                }
            }

            Initialize(dgv);
        }


    }
}

