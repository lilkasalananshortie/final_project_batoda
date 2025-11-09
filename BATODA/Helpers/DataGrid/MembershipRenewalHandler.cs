using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BATODA.Modules.MemberModule;


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
            dgv.ReadOnly = true;
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

            dgv.Columns.Clear();

            dgv.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "SelectMember",
                HeaderText = "",
                Width = 50,
                FillWeight = 10,
                FlatStyle = FlatStyle.Flat
            });

            dgv.Columns.Add("BodyNumber", "Body Number");
            dgv.Columns.Add("FullName", "Full Name");
            dgv.Columns.Add("MembershipType", "Type");
            dgv.Columns.Add("ContactNumber", "Contact");
            dgv.Columns.Add("PlateNumber", "Plate No.");
            dgv.Columns.Add("ExpiryDate", "Expiry Date");

            dgv.RowTemplate.Height = 70;
        }
        /*
         * 
         * LAHAT NG NASA BABA NG COMMENT NA TO PWEDE ALISIN AT PALITAN NG ACTUAL DB FETCH LOGIC
         * VISSUALIZATION PURPOSES LANG TO
         */

        //PWEDE ALISIN TO PAG MAY ACTUAL DATA NA DITO PAPASOK DB FETCH LOGC
        public static void LoadRenewalMembers(DataGridView dgv)
        {
            dgv.Rows.Clear();

            var sampleData = new[]
            {
        new { BodyNumber = 101, FullName = "Manalili, Mhaku", MembershipType = "Driver", ContactNumber = "09171234567", PlateNumber = "ABC-123",  ExpiryDate = DateTime.Now.AddDays(-3).ToShortDateString() },
        new { BodyNumber = 102, FullName = "Dela Cruz, Mark Arone", MembershipType = "Operator", ContactNumber = "09981234567", PlateNumber = "XYZ-456", ExpiryDate = DateTime.Now.AddDays(-5).ToShortDateString() },
        new { BodyNumber = 103, FullName = "Dulalia, Rod", MembershipType = "Driver", ContactNumber = "09281234567", PlateNumber = "LMN-789", ExpiryDate = DateTime.Now.AddDays(-2).ToShortDateString() }
    };

            foreach (var m in sampleData)
            {
                dgv.Rows.Add(false, m.BodyNumber, m.FullName, m.MembershipType, m.ContactNumber, m.PlateNumber, m.ExpiryDate);
            }
        }

        public static void LoadSelectedMemberInfo(
    Panel confirmationPanel,
    Label bodyNumberLabel,
    Label plateNumberLabel,
    Label fullNameLabel,
    Label contactNoLabel,
    Label membershipTypeLabel,
    PictureBox previewImagePb,
    DataGridView dgv)
        {
            if (dgv.CurrentRow == null) return;

            bodyNumberLabel.Text = dgv.CurrentRow.Cells["BodyNumber"].Value?.ToString() ?? "";
            plateNumberLabel.Text = dgv.CurrentRow.Cells["PlateNumber"].Value?.ToString() ?? "";
            fullNameLabel.Text = dgv.CurrentRow.Cells["FullName"].Value?.ToString() ?? "";
            contactNoLabel.Text = dgv.CurrentRow.Cells["ContactNumber"].Value?.ToString() ?? "";
            membershipTypeLabel.Text = dgv.CurrentRow.Cells["MembershipType"].Value?.ToString() ?? "";

            if (previewImagePb != null)
            {
                previewImagePb.Image = Properties.Resources.icon_add_image;
                previewImagePb.SizeMode = PictureBoxSizeMode.Zoom;
            }

            confirmationPanel.Visible = true;
        }



        // SAMPLE LANG ULIT TO PWEDE BURAHIN PARA LANG MA VISUALIZE YUNG DATAGRID
        public static List<MemberModel> GetSelectedMembers(DataGridView dgv)
        {
            List<MemberModel> selected = new List<MemberModel>();

            foreach (DataGridViewRow row in dgv.Rows)
            {
                bool isChecked = row.Cells["SelectMember"].Value != null && Convert.ToBoolean(row.Cells["SelectMember"].Value);

                if (isChecked)
                {
                    string[] nameParts = row.Cells["FullName"].Value.ToString().Split(',');
                    string lastName = nameParts[0].Trim();
                    string firstName = nameParts.Length > 1 ? nameParts[1].Trim() : "";

                    selected.Add(new MemberModel
                    {
                        BodyNumber = Convert.ToInt32(row.Cells["BodyNumber"].Value),
                        FirstName = firstName,
                        LastName = lastName,
                        MembershipType = row.Cells["MembershipType"].Value.ToString(),
                        ContactNumber = row.Cells["ContactNumber"].Value.ToString(),
                        PlateNumber = row.Cells["PlateNumber"].Value.ToString(),
                        
                    });
                }
            }

            return selected;
        }
    }
}