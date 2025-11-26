using BATODA.Helpers.Data;
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
        private static int CurrentYear = DateTime.Today.Year;
        private static Panel ReceiptContainerPanel;



        private static string GetDefaultStatus(int year, int month)
        {
            DateTime today = DateTime.Today;

            if (year < today.Year || (year == today.Year && month < today.Month))
                return "Overdue"; // PAST
            else if (year == today.Year && month == today.Month)
                return "Due"; // CURRENT
            else
                return "None"; // FUTURE
        }

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
       

        private static void Dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = sender as DataGridView;         
            if (e.RowIndex < 0 || e.ColumnIndex < 3) return;

            var cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (cell.OwningColumn.HeaderText == "View") return;

            string current = cell.Tag as string ?? "None";
            string next;

            if (CurrentMode != "None")
                next = CurrentMode;
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
                case "Paid": cell.Value = Properties.Resources.paid; break;
                case "Due": cell.Value = Properties.Resources.due; break;
                case "Overdue": cell.Value = Properties.Resources.overdue; break;
                default: cell.Value = Properties.Resources.circle_finance; break;
            }
            cell.Tag = next;

            int bodyNumber = int.Parse(dgv.Rows[e.RowIndex].Cells["BodyNo"].Value.ToString());
            int year = CurrentYear;
            int month = e.ColumnIndex - 2;

            TaxRepository.UpdatePaymentInDB(bodyNumber, year, month, next);

        }



        public static void EnsureYearRecords(int year)
        {
            var repo = new TaxRepository();
            var members = repo.GetAllMembers();
            var payments = repo.GetPaymentsByYear(year);
            DateTime today = DateTime.Today;

            foreach (var member in members)
            {
                for (int month = 1; month <= 12; month++)
                {
                    bool exists = payments.Any(p => p.BodyNumber == member.BodyNumber && p.Month == month);
                    string status = TaxHandler.GetDefaultStatus(year, month);

                    if (!exists)
                    {
                        TaxRepository.UpdatePaymentInDB(member.BodyNumber, year, month, status);
                    }
                    else
                    {
                        var payment = payments.First(p => p.BodyNumber == member.BodyNumber && p.Month == month);
                        if (year < today.Year || (year == today.Year && month < today.Month))
                        {
                            if (payment.Status != "Paid")
                                TaxRepository.UpdatePaymentInDB(member.BodyNumber, year, month, "Overdue");
                        }
                    }
                }
            }
        }


        public static void LoadCurrentYear(DataGridView dgv)
        {
            int currentYear = DateTime.Today.Year;
            EnsureYearRecords(currentYear);
            LoadMemberPayments(dgv, currentYear);
        }


        // SAMPLE LANG TO PWEDE DELETE IF EVER ND KAILANGAN 

        public static void LoadMemberPayments(DataGridView dgv, int year)
        {
            CurrentYear = year;

            dgv.Rows.Clear();
            dgv.Columns.Clear();

            dgv.Columns.Add("BodyNo", "Body No.");
            dgv.Columns.Add("MemberName", "Member Name");
            dgv.Columns.Add("Summary", "Summary");
        

            string[] months = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
            foreach (string m in months)
            {
                dgv.Columns.Add(new DataGridViewImageColumn
                {
                    HeaderText = m,
                    Name = m,
                    ImageLayout = DataGridViewImageCellLayout.Zoom,
                    Width = 40
                });
            }

            dgv.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "View",
                Text = "👁",
                UseColumnTextForButtonValue = true,
                Name = "View",
                Width = 20
            });
            var queries = new TaxRepository();
            var members = queries.GetAllMembers();
            var payments = queries.GetPaymentsByYear(year);

            DateTime today = DateTime.Today;

            foreach (var member in members)
            {
                int rowIndex = dgv.Rows.Add(member.BodyNumber.ToString("D3"), member.FullName, "0/12");
                int paidCount = queries.GetPaidMonthsCount(member.BodyNumber, year);
                dgv.Rows[rowIndex].Cells["Summary"].Value = $"{paidCount}/12";

                for (int i = 1; i <= 12; i++) // LOOP EACH MONTH
                {
                    var payment = payments.Find(p => p.BodyNumber == member.BodyNumber && p.Month == i); // FIND PAYMENT FOR MEMBER AND MONTH
                    string statusToUse;

                    if (payment.BodyNumber != 0) // IF PAYMENT EXISTS
                    {
                        statusToUse = (year == today.Year && i > today.Month) ? "None" : payment.Status;

                        switch (statusToUse) // SET IMAGE BASED ON STATUS
                        {
                            case "Paid": dgv.Rows[rowIndex].Cells[i + 2].Value = Properties.Resources.paid; break;
                            case "Due": dgv.Rows[rowIndex].Cells[i + 2].Value = Properties.Resources.due; break;
                            case "Overdue": dgv.Rows[rowIndex].Cells[i + 2].Value = Properties.Resources.overdue; break;
                            default: dgv.Rows[rowIndex].Cells[i + 2].Value = Properties.Resources.circle_finance; break;
                        }
                        dgv.Rows[rowIndex].Cells[i + 2].Tag = statusToUse; // STORE STATUS IN TAG

                    }
                    else // IF NO PAYMENT FOUND
                    {
                        var defaultStatus = GetDefaultStatus(year, i); // DETERMINE DEFAULT STATUS (PAST/CURRENT/FUTURE)
                        if (year == today.Year && i > today.Month) defaultStatus = "None";

                        switch (defaultStatus) // SET IMAGE BASED ON DEFAULT STATUS
                        {
                            case "Overdue": dgv.Rows[rowIndex].Cells[i + 2].Value = Properties.Resources.overdue; break;
                            case "Due": dgv.Rows[rowIndex].Cells[i + 2].Value = Properties.Resources.due; break;
                            default: dgv.Rows[rowIndex].Cells[i + 2].Value = Properties.Resources.circle_finance; break;
                        }
                        dgv.Rows[rowIndex].Cells[i + 2].Tag = defaultStatus; // STORE DEFAULT STATUS IN TAG

                    }
                }
            }
            Initialize(dgv);
        }

       
    }
}

