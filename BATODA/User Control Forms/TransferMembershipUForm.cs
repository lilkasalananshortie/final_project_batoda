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
            if (!string.IsNullOrEmpty(TransferUploadImage.FileName) && File.Exists(TransferUploadImage.FileName))
            {
                ConfirmNewImage.Image = Image.FromFile(TransferUploadImage.FileName);
                ConfirmNewImage.SizeMode = PictureBoxSizeMode.StretchImage;
            }

            else if (NewOwnerPb.Image != null)
            {
                ConfirmNewImage.Image = NewOwnerPb.Image;
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
            owner = memberRepo.GetByBodyNumber(bodyNumber); // <-- assign to class field

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

                // EXTRACT DIGITS 
                string digitsOnly = new string(CurrentBodyNumberLbl.Text.Where(char.IsDigit).ToArray());

                if (string.IsNullOrEmpty(digitsOnly))
                {
                    MessageBox.Show("Invalid Body Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int bodyNumber = int.Parse(digitsOnly);

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

                if (NewOwnerPb.Image != null && !string.IsNullOrEmpty(TransferUploadImage.FileName))
                {
                    string savedPath = SaveImageToFolder.Save(TransferUploadImage.FileName, bodyNumber);
                    updatedMember.ImagePath = savedPath;
                }

                // Update record
                memberRepo.UpdateMember(updatedMember);

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
                NewOwnerPb.ImageLocation = TransferUploadImage.FileName;


                NewOwnerPb.SizeMode = PictureBoxSizeMode.StretchImage;

            }
        }
    }
}
