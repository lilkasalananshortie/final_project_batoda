using BATODA.Modules.Assistance_Request_Module.Renewal_Classes;
using BATODA.Modules.MemberModule;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BATODA.Helpers.DataGrid
{
    public static class MembershipRenewalHandler
    {

        public static void Initialize(DataGridView dgv)
        {
            dgv.BorderStyle = BorderStyle.None;
            dgv.BackgroundColor = Color.White;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AllowUserToResizeColumns = false;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ColumnHeadersHeight = 40;
            dgv.MultiSelect = false;
            dgv.ReadOnly = false;

            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 230, 230);
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 18, FontStyle.Regular);

            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(173, 46, 36);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 13, FontStyle.Regular);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(173, 46, 36);

            dgv.CellClick -= Dgv_CellClick;
            dgv.CellClick += Dgv_CellClick;

            dgv.CellPainting -= Dgv_CellPainting;
            dgv.CellPainting += Dgv_CellPainting;

            dgv.Columns.Clear();

            // Checkbox column
            var selectColumn = new DataGridViewImageColumn
            {
                Name = "SelectMember",
                HeaderText = "",
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                Width = 40
            };

            dgv.Columns.Add(selectColumn);

            dgv.Columns.Add("BodyNumber", "Body No.");
            dgv.Columns.Add("FullName", "Full Name");
            dgv.Columns.Add("MembershipType", "Role");
            dgv.Columns.Add("ContactNumber", "Contact No.");
            dgv.Columns.Add("DateRenewed", "Date Renewed");
            dgv.Columns.Add("ExpiryDate", "Expiry Date");
            dgv.Columns.Add("RenewalStatus", "Status");

            dgv.RowTemplate.Height = 50;
        }

        /*
         * 
         * LAHAT NG NASA BABA NG COMMENT NA TO PWEDE ALISIN AT PALITAN NG ACTUAL DB FETCH LOGIC
         * VISSUALIZATION PURPOSES LANG TO
         */

        //PWEDE ALISIN TO PAG MAY ACTUAL DATA NA DITO PAPASOK DB FETCH LOGC

        public static void LoadSelectedMemberInfo(
            Panel confirmationPanel,
            Label bodyNumberLabel,
            Label fullNameLabel,
            Label contactNoLabel,
            Label membershipTypeLabel,
            Label dateJoinedLabel,
            Label expiryDateLabel,
            Label renewalStatusLabel,
            DataGridView dgv)
        {
            if (dgv.CurrentRow == null) return;

            bodyNumberLabel.Text = dgv.CurrentRow.Cells["BodyNumber"].Value?.ToString() ?? "";
            fullNameLabel.Text = dgv.CurrentRow.Cells["FullName"].Value?.ToString() ?? "";
            contactNoLabel.Text = dgv.CurrentRow.Cells["ContactNumber"].Value?.ToString() ?? "";
            membershipTypeLabel.Text = dgv.CurrentRow.Cells["MembershipType"].Value?.ToString() ?? "";
            dateJoinedLabel.Text = dgv.CurrentRow.Cells["DateJoined"].Value != DBNull.Value
                ? Convert.ToDateTime(dgv.CurrentRow.Cells["DateJoined"].Value).ToShortDateString()
                : "";
            expiryDateLabel.Text = dgv.CurrentRow.Cells["ExpiryDate"].Value != DBNull.Value
                ? Convert.ToDateTime(dgv.CurrentRow.Cells["ExpiryDate"].Value).ToShortDateString()
                : "";
            renewalStatusLabel.Text = dgv.CurrentRow.Cells["RenewalStatus"].Value?.ToString() ?? "";

            confirmationPanel.Visible = true;
        }


        private static void Dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = sender as DataGridView;
            if (e.RowIndex < 0) return;

            if (dgv.Columns[e.ColumnIndex].Name == "SelectMember")
            {
                var cell = dgv.Rows[e.RowIndex].Cells["SelectMember"];

                bool isSelected = (cell.Tag as string) == "Selected";

                if (isSelected)
                {
                    cell.Value = Properties.Resources._unchecked;
                    cell.Tag = "NotSelected";
                }
                else
                {
                    cell.Value = Properties.Resources._checked;
                    cell.Tag = "Selected";
                }
            }
        }


        private static void Dgv_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            var dgv = sender as DataGridView;

            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;

            if (dgv.Columns[e.ColumnIndex].Name != "SelectMember")
                return;

            e.PaintBackground(e.CellBounds, true);

            Image img = e.Value as Image;
            if (img != null)
            {
                int targetSize = 20;        
                int padding = 10;           

                int x = e.CellBounds.X + padding;
                int y = e.CellBounds.Y + (e.CellBounds.Height - targetSize) / 2;

                e.Graphics.DrawImage(img, x, y, targetSize, targetSize);
            }

            e.Handled = true;
        }

        // SAMPLE LANG ULIT TO PWEDE BURAHIN PARA LANG MA VISUALIZE YUNG DATAGRID
        public static List<MemberRenewalModel> GetSelectedMembers(DataGridView dgv)
        {
            List<MemberRenewalModel> selected = new List<MemberRenewalModel>();

            foreach (DataGridViewRow row in dgv.Rows)
            {
                bool isChecked = row.Cells["SelectMember"].Tag?.ToString() == "Selected";

                if (isChecked)
                {
                    string fullName = row.Cells["FullName"].Value?.ToString() ?? "";

                    DateTime? dateRenewed = null;
                    DateTime tempDate;
                    if (row.Cells["DateRenewed"].Value != null &&
                        DateTime.TryParse(row.Cells["DateRenewed"].Value.ToString(), out tempDate))
                    {
                        dateRenewed = tempDate;
                    }

                    DateTime? expiryDate = null;
                    if (row.Cells["ExpiryDate"].Value != null &&
                        DateTime.TryParse(row.Cells["ExpiryDate"].Value.ToString(), out tempDate))
                    {
                        expiryDate = tempDate;
                    }

                    selected.Add(new MemberRenewalModel
                    {
                        BodyNumber = Convert.ToInt32(row.Cells["BodyNumber"].Value),
                        FullName = fullName,
                        MembershipType = row.Cells["MembershipType"].Value?.ToString() ?? "",
                        ContactNumber = row.Cells["ContactNumber"].Value?.ToString() ?? "",
                        DateRenewed = dateRenewed,
                        ExpiryDate = expiryDate,
                        RenewalStatus = row.Cells["RenewalStatus"].Value?.ToString() ?? ""
                    });
                }
            }

            return selected;
        }



    }
}