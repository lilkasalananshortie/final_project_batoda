using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using BATODA.Modules.MemberModule;
using BATODA.Properties;


namespace BATODA.Helpers.Database.Members
{
    internal class LoadOwnerImage
    {
        public static void FromMember(MemberModel owner, PictureBox pictureBox)
        {
            string ImagesFolder = Path.Combine(Application.StartupPath, "..\\..\\Modules\\Member Module\\Member Images");
            string bodyNumber = owner.BodyNumber.ToString("D3");

            string[] files = Directory.GetFiles(ImagesFolder, $"{bodyNumber}_*.*");

            try
            {
                if (files.Length > 0)
                {
                    // SAVE HERE TO AVOID LOCK
                    using (var temp = new Bitmap(files[0]))
                    {
                        pictureBox.Image?.Dispose();
                        pictureBox.Image = new Bitmap(temp);
                    }
                }
                else
                {
                    string defaultImagePath = Path.Combine(ImagesFolder, "USER_DEFAULT.jpg");

                    if (File.Exists(defaultImagePath))
                    {
                        using (var temp = new Bitmap(defaultImagePath))
                        {
                            pictureBox.Image?.Dispose();
                            pictureBox.Image = new Bitmap(temp);
                        }
                    }
                    else
                    {
                        pictureBox.Image?.Dispose();
                        pictureBox.Image = null;
                    }
                }

                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading member image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DeletePastOwnerImage(int bodyNumber, DateTime oldDateJoined)
        {
            try
            {
                string imagesFolder = Path.Combine(Application.StartupPath, "..\\..\\Modules\\Member Module\\Member Images");

                string filePattern = $"{bodyNumber:D3}_{oldDateJoined:MMMMddyyyy}.*";

                string[] filesToDelete = Directory.GetFiles(imagesFolder, filePattern);

                foreach (var file in filesToDelete)
                {
                    File.Delete(file);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting past owner's image: {ex.Message}", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }

}
