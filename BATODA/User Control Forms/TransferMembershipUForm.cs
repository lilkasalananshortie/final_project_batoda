using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BATODA.Helpers.Database.Members;
using BATODA.Modules.Member_Module.Member_Classes;
using BATODA.UI_Displays;

namespace BATODA
{
    public partial class TransferMembershipUForm : UserControl
    {
        public TransferMembershipUForm()
        {
            InitializeComponent();

            ConfirmationPanel.Hide();

            // test lang pang push
        }

        private void TransferMembershipUForm_Load(object sender, EventArgs e)
        {
            
            
        }


        private void ManageMembersButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new MembersUForm());
        }

        private void TransferMembershipButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new TransferMembershipUForm());
        }

        private void TransferRecordsButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new TransferRecordMemberUForm());
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            

            

        }

       

        private void ConfirmationButton_Click(object sender, EventArgs e)
        {
           ConfirmationPanel.Hide();
           ToastManager.Success("Membership Transferred Successfully!");
            
        }

        private void CancelConfirmation_Click(object sender, EventArgs e)
        {
            ConfirmationPanel.Hide();
            ToastManager.Info("Membership Transfer Cancelled.");
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            ConfirmationPanel.Show();
        }

        private void HolderPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        
        private void OwnerSearchTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OwnerSearchGrid.Visible = true;
                TransferSearchOwner search = new TransferSearchOwner();
                search.SearchOwner(OwnerSearchTxt, OwnerSearchGrid);
                OwnerSearchGrid.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void OwnerSearchGrid_Leave(object sender, EventArgs e)
        {
            OwnerSearchGrid.Visible = false;
        }

        private void OwnerSearchGrid_Click(object sender, EventArgs e)
        {
            if (OwnerSearchGrid.Visible)
                OwnerSearchGrid.Visible = false;
        }

        private void panel24_Click(object sender, EventArgs e)
        {
        }

        private void OwnerSearchGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // CHECK IF VALID ROW
            {
                string bodyNumber = OwnerSearchGrid.Rows[e.RowIndex].Cells["BodyNumber"].Value.ToString();

                TransferLoadOwner loader = new TransferLoadOwner();
                loader.LoadOwnerDetails(bodyNumber,
                    CurrentBodyNumberLbl,
                    CurrentFirstNameLbl,
                    CurrentLastNameLbl,
                    CurrentMiddleLbl,
                    CurrentMemberTypeLbl,
                    CurrentPlateLbl,
                    CurrentChassisLbl,
                    CurrentEngineLbl,
                    CurrentBrandLbl,
                    CurrentModelLbl,
                    CurrentBirthdateLbl,
                    CurrentContactLbl,
                    TransferBodyNumberLbl);

                OwnerSearchGrid.Visible = false;
            }
        }
    }
}
