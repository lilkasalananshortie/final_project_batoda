using BATODA.Helpers.Database.Members;
using BATODA.Helpers.DataGrids;
using BATODA.Modules.Dashboard_Module.Dashboard_Classes;
using BATODA.Modules.Member_Module.Member_Classes;
using BATODA.Modules.MemberModule;
using BATODA.UI_Displays;
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

namespace BATODA
{
    public partial class TransferMembershipUForm : UserControl
    {

        private MemberModel owner;

        public TransferMembershipUForm()
        {
            InitializeComponent();

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

        private void ConfirmationButton_Click(object sender, EventArgs e)
        {

            ToastManager.Success("Membership Transferred Successfully!");

        }

        private void CancelConfirmation_Click(object sender, EventArgs e)
        {
            ToastManager.Info("Membership Transfer Cancelled.");
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            HolderPanel1.SendToBack();
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

        private void TransferUploadBtn_Click_1(object sender, EventArgs e)
        {
            TransferUploadImage.Title = "Select an Image";
            TransferUploadImage.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (TransferUploadImage.ShowDialog() == DialogResult.OK)
            {
                using (var temp = new Bitmap(TransferUploadImage.FileName))
                {
                    NewOwnerPb.Image = new Bitmap(temp);
                }

                NewOwnerPb.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void OwnerSearchTxt_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OwnerSearchGrid.Visible = true;
                TransferMemberSearchOwner search = new TransferMemberSearchOwner();
                search.SearchOwner(OwnerSearchTxt, OwnerSearchGrid);
                DataGridCustom.ApplyCustomGridSearch(OwnerSearchGrid);
                OwnerSearchGrid.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void OwnerSearchGrid_CellClick_1(object sender, DataGridViewCellEventArgs e)
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

        private void TransferBtn_Click(object sender, EventArgs e)
        {
            try
            {
                // ASK FOR CONFIRMATION
                var result = MessageBox.Show("Are you sure you want to transfer this membership to the new member?",
                                             "Confirm Transfer",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                {
                    return; // STOP IF USER CHOOSES NO
                }

                int bodyNumber = int.Parse(new string(CurrentBodyNumberLbl.Text.Where(char.IsDigit).ToArray()));

                var memberRepo = new MemberRepository();
                var transferRepo = new TransferMembershipHistoryRepository();

                // CHECK TAX BALANCE BEFORE TRANSFER
                if (!transferRepo.CanTransferMember(bodyNumber))
                {
                    return;
                }

                // CHECK LAST TRANSFER DATE
                DateTime? lastTransferDate = transferRepo.GetLastTransferDate(bodyNumber);
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
                    PenaltyLevel = 0,
                    DateJoined = DateTime.Now
                };

                // SAVE NEW IMAGE IF AVAILABLE
                if (NewOwnerPb.Image != null && !string.IsNullOrEmpty(TransferUploadImage.FileName))
                {
                    string savedPath = SaveImageToFolder.TransferMembershipSave(TransferUploadImage.FileName, bodyNumber);
                    updatedMember.ImagePath = savedPath;
                }

                // UPDATE MEMBER DATA
                memberRepo.TransferMember(updatedMember);

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

                var logRepo = new SystemActivityLogRepository();
                logRepo.LogMembershipTransfer(bodyNumber, $"{TransferFirstNameTxt.Text} {TransferLastNameTxt.Text}");

                MessageBox.Show("Owner information updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                HolderPanel1.SendToBack();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating member: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}