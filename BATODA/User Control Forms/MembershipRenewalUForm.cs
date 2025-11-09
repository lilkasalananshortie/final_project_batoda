using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BATODA.Helpers.DataGrid;

namespace BATODA
{
    public partial class MembershipRenewalUForm : UserControl
    {
        public MembershipRenewalUForm()
        {
            InitializeComponent();
           
            ConfirmationRenewPanel.Hide();

        }
        private void MembershipRenewalUForm_Load(object sender, EventArgs e)
        {
            MembershipRenewalHandler.Initialize(ExpiredMembersDataGridView);
            MembershipRenewalHandler.LoadRenewalMembers(ExpiredMembersDataGridView);
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
            if (e.ColumnIndex == ExpiredMembersDataGridView.Columns["SelectMember"].Index && e.RowIndex >= 0)
            {
                var selected = MembershipRenewalHandler.GetSelectedMembers(ExpiredMembersDataGridView);

                ConfirmationRenewPanel.Visible = selected.Count > 0;

                ConfirmationRenewPanel.Text = string.Join(", ", selected.Select(m => m.LastName));
            }
        }
        private void ShowNextCheckedMember()
        {
            DataGridViewRow nextRow = null;

            foreach (DataGridViewRow row in ExpiredMembersDataGridView.Rows)
            {
                bool isChecked = Convert.ToBoolean(row.Cells["SelectMember"].Value ?? false);
                if (isChecked)
                {
                    nextRow = row;
                    break;
                }
            }

            if (nextRow == null)
            {
                ConfirmationRenewPanel.Visible = false;
                ExpiredMembersDataGridView.ClearSelection();
                return;
            }

            BodyNumberLabel.Text = nextRow.Cells["BodyNumber"].Value?.ToString() ?? "";
            PlateNumberLabel.Text = nextRow.Cells["PlateNumber"].Value?.ToString() ?? "";
            FullNameLabel.Text = nextRow.Cells["FullName"].Value?.ToString() ?? "";
            ContactNoLabel.Text = nextRow.Cells["ContactNumber"].Value?.ToString() ?? "";
            MembershipTypeLabel.Text = nextRow.Cells["MembershipType"].Value?.ToString() ?? "";

            PreviewImagePb.Image = null;
            ConfirmationRenewPanel.Visible = true;

            nextRow.Cells["SelectMember"].Value = false;
        }



        private void RenewButton_Click(object sender, EventArgs e)
        {
            if (ExpiredMembersDataGridView.CurrentRow == null)
                return;

            var currentBodyNumber = BodyNumberLabel.Text;

            foreach (DataGridViewRow row in ExpiredMembersDataGridView.Rows)
            {
                if (row.Cells["BodyNumber"].Value?.ToString() == currentBodyNumber)
                {
                    ExpiredMembersDataGridView.Rows.Remove(row);
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
