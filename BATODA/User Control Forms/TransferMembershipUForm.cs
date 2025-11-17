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
using BATODA.Modules.MemberModule;
using BATODA.UI_Displays;

namespace BATODA
{
    public partial class TransferMembershipUForm : UserControl
    {
        private MemberModel owner;

        public TransferMembershipUForm()
        {
            InitializeComponent();

            ConfirmationPanel.Hide();
            ConfirmationTransferPanel.Hide();

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
            // CURRENT OWNER
            if (owner != null)
            {
                LoadOwnerImage.FromMember(owner, ConfirmCurrentImage);
            }

            // NEW OWNER (UPLOADED FROM BTN)
            if (NewOwnerPb.Image != null)
            {
                // Make a memory copy so the original NewOwnerPb image doesn't lock any file
                using (var temp = new Bitmap(NewOwnerPb.Image))
                {
                    ConfirmNewImage.Image = new Bitmap(temp);
                }
                ConfirmNewImage.SizeMode = PictureBoxSizeMode.StretchImage;
            }


            HolderPanel1.SendToBack();
            ConfirmationPanel.Show();
            ConfirmationTransferPanel.BringToFront();
            ConfirmationTransferPanel.Show();
        }


        private void HolderPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        
        private void OwnerSearchTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OwnerSearchGrid.Visible = true;
                TransferMemberSearchOwner search = new TransferMemberSearchOwner();
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
            if (e.RowIndex < 0) return;

            string bodyNumberStr = OwnerSearchGrid.Rows[e.RowIndex].Cells["BodyNumber"].Value?.ToString();
            if (string.IsNullOrEmpty(bodyNumberStr)) return;

            if (!int.TryParse(bodyNumberStr, out int bodyNumber)) return;

            TransferLoadOwner loader = new TransferLoadOwner();
            loader.LoadOwnerDetails(bodyNumberStr,
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

            MemberRepository memberRepo = new MemberRepository();
            owner = memberRepo.GetByBodyNumber(bodyNumber);

            if (owner != null)
            {
                LoadOwnerImage.FromMember(owner, CurrentOwnerPb);
            }

            OwnerSearchGrid.Visible = false;
        }


        private void ConfirmationTransferPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SavePanelButton_Click(object sender, EventArgs e)
        {
            try
            {
                var memberRepo = new MemberRepository();
                var transferRepo = new TransferMembershipHistoryRepository(); // REPO FOR HISTORY

                // EXTRACT DIGITS FROM LABEL
                string digitsOnly = new string(CurrentBodyNumberLbl.Text.Where(char.IsDigit).ToArray());
                if (string.IsNullOrEmpty(digitsOnly))
                {
                    MessageBox.Show("Invalid Body Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int bodyNumber = int.Parse(digitsOnly);

                // 🔥 CHECK LAST TRANSFER DATE
                DateTime? lastTransferDate = transferRepo.GetLastTransferDate(bodyNumber); // YOU’LL ADD THIS METHOD BELOW
                if (lastTransferDate.HasValue && (DateTime.Now - lastTransferDate.Value).TotalDays < 3)
                {
                    MessageBox.Show("This member was recently transferred. Please wait 3 days before transferring again.",
                                    "Transfer Restricted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // CREATE UPDATED MEMBER INFO
                MemberModel updatedMember = new MemberModel
                {
                    BodyNumber = bodyNumber,
                    MembershipType = TransferMemberTypeCmb.Text,
                    LastName = TransferLastNameTxt.Text,
                    FirstName = TransferFirstNameTxt.Text,
                    MiddleInitial = TransferMiddleTxt.Text,
                    Birthdate = TransferBirthdatePicker.Value,
                    TricycleBrand = TransferBrandTxt.Text,
                    TricycleModel = TransferModelTxt.Text,
                    ContactNumber = TransferContactTxt.Text,
                    ChassisNumber = TransferChassisTxt.Text,
                    EngineNumber = TransferEngineTxt.Text,
                    PlateNumber = TransferPlateTxt.Text,
                    TaxBalance = 0,
                    MemberStatus = "Active",
                    PenaltyLevel = 1,
                    DateJoined = DateTime.Now
                };

                // SAVE NEW IMAGE IF AVAILABLE
                if (NewOwnerPb.Image != null && !string.IsNullOrEmpty(TransferUploadImage.FileName))
                {
                    string savedPath = SaveImageToFolder.TransferMembershipSave(TransferUploadImage.FileName, bodyNumber);
                    updatedMember.ImagePath = savedPath;
                }

                // UPDATE MEMBER DATA
                memberRepo.UpdateMember(updatedMember);

                // RECORD TRANSFER HISTORY
                TransferMembershipHistoryModel transferRecord = new TransferMembershipHistoryModel
                {
                    BodyNumber = bodyNumber,
                    PastOwnerFullName = $"{CurrentFirstNameLbl.Text} {CurrentLastNameLbl.Text}",
                    NewOwnerFullName = $"{TransferFirstNameTxt.Text} {TransferLastNameTxt.Text}",
                    ReasonForTransfer = TransferReasonTxt.Text,
                    DateOfTransfer = DateTime.Now
                };

                transferRepo.AddTransferRecord(transferRecord);

                MessageBox.Show("Owner information updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ConfirmationTransferPanel.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating member: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void CancelPanelButton_Click(object sender, EventArgs e)
        {
            ConfirmationTransferPanel.Hide();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void openFileDialog1_FileOk_1(object sender, CancelEventArgs e)
        {
                    }

        private void TransferUploadBtn_Click(object sender, EventArgs e)
        {
            TransferUploadImage.Title = "Select an Image";
            TransferUploadImage.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (TransferUploadImage.ShowDialog() == DialogResult.OK)
            {
                // Load a memory copy to avoid locking the file
                using (var temp = new Bitmap(TransferUploadImage.FileName))
                {
                    NewOwnerPb.Image = new Bitmap(temp);
                }

                NewOwnerPb.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void label46_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel24_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void TransferModelTxt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
