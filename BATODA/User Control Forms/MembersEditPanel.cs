using BATODA.Helpers.Database.Members;
using BATODA.Modules.Dashboard_Module.Dashboard_Classes;
using BATODA.Modules.MemberModule;
using BATODA.UI_Displays;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BATODA.User_Control_Forms
{
    public partial class MembersEditPanel : UserControl
    {
        string EditImagePath = "";

        public MembersEditPanel()
        {
            InitializeComponent();

            try
            {
                // CHECK IF MAY CLICKED CELL
                if (!string.IsNullOrEmpty(SelectedMemberImage.ImagePath) && File.Exists(SelectedMemberImage.ImagePath))
                {
                    // LOAD COPY TO AVOID FILE LOCKING
                    using (var temp = new Bitmap(SelectedMemberImage.ImagePath))
                    {
                        PreviewImagePb.Image = new Bitmap(temp);
                    }
                    PreviewImagePb.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    PreviewImagePb.Image = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading member image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);               
            }
        }

        private void SaveEditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string destinationPath = SelectedMemberImage.ImagePath;

                // IMAGE UPDATE SECTION - ONLY RUNS IF NEW IMAGE WAS CHOSEN
                if (!string.IsNullOrEmpty(EditImagePath))
                {
                    string imagesFolder = Path.Combine(Application.StartupPath, "..\\..\\Modules\\Member Module\\Member Images");
                    string currentImagePath = SelectedMemberImage.ImagePath;

                    if (!string.IsNullOrEmpty(currentImagePath) && File.Exists(currentImagePath))
                    {
                        destinationPath = currentImagePath; // KEEP SAME NAME IF EXISTS
                    }
                    else
                    {
                        string fileName = $"{SelectedMemberImage.BodyNumber:D3}_{DateTime.Now:MMMMddyyyy}{Path.GetExtension(EditImagePath)}";
                        destinationPath = Path.Combine(imagesFolder, fileName);
                    }

                    // DISPOSE IMAGE FIRST TO AVOID FILE ACCESS ERROR
                    if (PreviewImagePb.Image != null)
                    {
                        PreviewImagePb.Image.Dispose();
                        PreviewImagePb.Image = null;
                    }

                    File.Copy(EditImagePath, destinationPath, true);

                    using (var temp = new Bitmap(destinationPath))
                    {
                        PreviewImagePb.Image = new Bitmap(temp);
                    }
                    PreviewImagePb.SizeMode = PictureBoxSizeMode.StretchImage;

                    SelectedMemberImage.ImagePath = destinationPath;
                    EditImagePath = "";
                }

                // MEMBER INFO UPDATE SECTION - ALWAYS RUNS EVEN WITHOUT NEW IMAGE
                MemberRepository repo = new MemberRepository();
                var existing = MemberInfoSummary.FetchMemberData(SelectedMemberImage.BodyNumber);

                if (existing != null)
                {
                    existing.FirstName = EditFirstNameTxt.Text.Trim();
                    existing.LastName = EditLastNameTxt.Text.Trim();
                    existing.MiddleInitial = EditMiddleTxt.Text.Trim();
                    existing.ContactNumber = EditContactNoLbl.Text.Trim();
                    existing.Birthdate = EditBirthdatePicker.Value;
                    existing.ImagePath = destinationPath;

                    repo.UpdateMember(existing);
                }

                // SUCCESS MESSAGE AND PANEL REFRESH
                var logRepo = new SystemActivityLogRepository();
                logRepo.LogMemberUpdate(SelectedMemberImage.BodyNumber);

                ToastManager.Success("Member details and image updated successfully!");        
                DisplayClass.CloseMiniAndMain();
                DisplayClass.ShowMain(new MembersUForm());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DisplayClass.CloseMini(this);
            DisplayClass.ShowMain(new MembersUForm());
        }

        private void UploadImageBtn_Click(object sender, EventArgs e)
        {
            try
            {
                EditFileDialog.Title = "Select an Image";
                EditFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (EditFileDialog.ShowDialog() == DialogResult.OK)
                {
                    EditImagePath = EditFileDialog.FileName;

                    using (var temp = new Bitmap(EditImagePath))
                    {
                        if (PreviewImagePb.Image != null)
                        {
                            PreviewImagePb.Image.Dispose();
                        }

                        PreviewImagePb.Image = new Bitmap(temp);
                    }

                    PreviewImagePb.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            catch (FileNotFoundException)
            {
                ToastManager.Error("Selected image file was not found.");
            }
            catch (OutOfMemoryException)
            {
                ToastManager.Error("The selected file is not a valid image.");
            }
            catch (Exception ex)
            {
                ToastManager.Error($"Failed to load image: {ex.Message}");
            }
        }
        private void MembersEditPanel_Load(object sender, EventArgs e)
        {
            int bodyNumber = SelectedMemberImage.BodyNumber;

            var member = MemberInfoSummary.FetchMemberData(bodyNumber);

            if (member != null)
            {
                EditBodyNoPreviewLbl.Text = "BATODA (" + member.BodyNumber.ToString("D3") + ")";
                EditFirstNameTxt.Text = member.FirstName;
                EditLastNameTxt.Text = member.LastName;
                EditMiddleTxt.Text = member.MiddleInitial;
                EditContactNoLbl.Text = member.ContactNumber;
                EditBirthdatePicker.Value = member.Birthdate;
                EditPlateNoLbl.Text = member.PlateNumber;
                EditEngineNoLbl.Text = member.EngineNumber;
                EditChassisNoLbl.Text = member.ChassisNumber;
                EditBrandLbl.Text = member.TricycleBrand;
                EditModelLbl.Text = member.TricycleModel;
                EditMemberTypeLbl.Text = member.MembershipType;
                StatusLbl.Text = member.MemberStatus;

            }
        }
    }
}
