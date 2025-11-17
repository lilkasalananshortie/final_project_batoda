using BATODA.Helpers.DataGrid;
using BATODA.Modules.Assistance_Request_Module.Renewal_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BATODA
{
    public partial class MembershipRenewalUForm : UserControl
    {
        public MembershipRenewalUForm()
        {
            InitializeComponent();
            MembershipRenewalHandler.Initialize(RenewalGrid);
            LoadRenewalGrid(); 
            ConfirmationRenewPanel.Hide();
        }


        private void LoadRenewalGrid()
        {
            RenewalRepository repo = new RenewalRepository();
            var renewals = repo.GetAllRenewals();

            RenewalGrid.Rows.Clear();

            foreach (var r in renewals)
            {
                try
                {
                    int rowIndex = RenewalGrid.Rows.Add(
                        Properties.Resources._unchecked,
                        r.BodyNumber.ToString("D3"),
                        r.FullName,
                        r.MembershipType,
                        r.ContactNumber,
                        r.DateRenewed?.ToShortDateString() ?? "",
                        r.ExpiryDate?.ToShortDateString() ?? "",
                        r.RenewalStatus
                    );

                    RenewalGrid.Rows[rowIndex].Cells["SelectMember"].Tag = "NotSelected";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void MembershipRenewalUForm_Load(object sender, EventArgs e)
        {
            LoadRenewalGrid();

            var renewalsCount = new RenewalRepository().GetAllRenewals().Count;
            MessageBox.Show($"Found {renewalsCount} renewals");
        }


        private void FinanceButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new FinanceUForm());
        }

        private void MembershipRenewalButton_Click_1(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new MembershipRenewalUForm());

        }

        private void RenewalHistoryButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new ButawUForm());
        }

       
        private void ExpiredMembersDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == RenewalGrid.Columns["SelectMember"].Index && e.RowIndex >= 0)
            {
                var selected = MembershipRenewalHandler.GetSelectedMembers(RenewalGrid);

                ConfirmationRenewPanel.Visible = selected.Count > 0;

                ConfirmationRenewPanel.Text = string.Join(", ", selected.Select(m => m.LastName));
            }
        }
        private void ShowNextCheckedMember()
        {
            DataGridViewRow nextRow = null;

            foreach (DataGridViewRow row in RenewalGrid.Rows)
            {
                bool isChecked = row.Cells["SelectMember"].Tag?.ToString() == "Selected";
                if (isChecked)
                {
                    nextRow = row;
                    break;
                }
            }

            if (nextRow == null)
            {
                ConfirmationRenewPanel.Visible = false;
                RenewalGrid.ClearSelection();
                return;
            }

            BodyNumberLabel.Text = nextRow.Cells["BodyNumber"].Value?.ToString() ?? "";
            FullNameLabel.Text = nextRow.Cells["FullName"].Value?.ToString() ?? "";
            ContactNoLabel.Text = nextRow.Cells["ContactNumber"].Value?.ToString() ?? "";
            MembershipTypeLabel.Text = nextRow.Cells["MembershipType"].Value?.ToString() ?? "";

            PreviewImagePb.Image = null;
            ConfirmationRenewPanel.Visible = true;

            var cell = nextRow.Cells["SelectMember"];
            cell.Value = Properties.Resources._unchecked;
            cell.Tag = "NotSelected";
        }




        private void RenewButton_Click(object sender, EventArgs e)
        {
            if (RenewalGrid.CurrentRow == null)
                return;

            var currentBodyNumber = BodyNumberLabel.Text;

            foreach (DataGridViewRow row in RenewalGrid.Rows)
            {
                if (row.Cells["BodyNumber"].Value?.ToString() == currentBodyNumber)
                {
                    RenewalGrid.Rows.Remove(row);
                    break;
                }
            }

            ShowNextCheckedMember();
        }



        private void CancelRenewalButton_Click(object sender, EventArgs e)
        {
            ShowNextCheckedMember();
        }

        private void RenewSelectedButton_Click(object sender, EventArgs e)
        {
            ShowNextCheckedMember();

        }
    }
    
}
