using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BATODA.Helpers.Database.Members;
using BATODA.Modules.Member_Module.Member_Classes;
using BATODA.Modules.MemberModule;
using System.IO;


namespace BATODA.User_Control_Forms
{
    public partial class MembersEditPanel : UserControl
    {
        public MembersEditPanel()
        {
            InitializeComponent();

            try
            {
                if (!string.IsNullOrEmpty(SelectedMemberImage.ImagePath) &&
                    File.Exists(SelectedMemberImage.ImagePath))
                {
                    PreviewImagePb.Image = Image.FromFile(SelectedMemberImage.ImagePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading member image: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void MembersEditPanel_Load(object sender, EventArgs e)
        {
           
           
        }

        string EditImagePath = "";
        private void SaveEditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int bodyNumber = LoadBodyNumber.GetCurrentNumber();

                if (!string.IsNullOrEmpty(EditImagePath) && PreviewImagePb.Image != null)
                {
                    string imagesFolder = Path.Combine(Application.StartupPath, "..\\..\\Modules\\Member Module\\Member Images");
                    string existingImage = Directory.GetFiles(imagesFolder, $"{bodyNumber:D3}*.*").FirstOrDefault();

                    if (existingImage != null)
                    {
                        PreviewImagePb.Image.Dispose();
                        PreviewImagePb.Image = null;

                        File.Copy(EditImagePath, existingImage, true); // OVERWRITE
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




        private void CancelButton_Click(object sender, EventArgs e)
        {
            DisplayClass.CloseMini(this);
            DisplayClass.ShowMain(new MembersUForm());
        }

        private void UploadImageBtn_Click(object sender, EventArgs e)
        {
            EditFileDialog.Title = "Select an Image";
            EditFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (EditFileDialog.ShowDialog() == DialogResult.OK)
            {
                EditImagePath = EditFileDialog.FileName; 
                PreviewImagePb.ImageLocation = EditImagePath;
                PreviewImagePb.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

    }
}
