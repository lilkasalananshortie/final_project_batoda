using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BATODA.Modules.Member_Module.Member_Classes
{
    internal class SaveImageToFolder
    {

        // TRANSFER MEMBERSHIP IMAGE SAVE (ADDING NEW IMAGE WITH UNIQUE NAME AND FORMAT)
        public static string TransferMembershipSave(string sourcePath, int bodyNumber)
        {
            try
            { 
                // PATH NG LALAGYAN NG PFP NG MGA MEMBS
                string ProjectPath = Directory.GetParent(Application.StartupPath).Parent.FullName;

                string ImagesFolder = Path.Combine(Application.StartupPath, "..\\..\\Modules\\Member Module\\Member Images");

                if (!Directory.Exists(ImagesFolder))
                {
                    Directory.CreateDirectory(ImagesFolder);
                }

                // SAMPLE FORMAT: 600_September292025.jpg
                // UNIQUE KAHIT MAY SAME BODY NO. NG PREVIOUS OWNER
                string NewFileName = $"{bodyNumber.ToString("D3")}_{DateTime.Now:MMMMddyyyy}{Path.GetExtension(sourcePath)}";
                string DestinationPath = Path.Combine(ImagesFolder, NewFileName);
                MessageBox.Show($"Saving to: {DestinationPath}");


                File.Copy(sourcePath, DestinationPath, true);

                return DestinationPath;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving image: {ex.Message}", "Image Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        // EDIT INFO OF A MEMBER (REPLACING PREVIOUS IMAGE WITH NEW ONE GAMIT YUNG SAME NAME)
        public static string EditMemberInfo(string sourcePath, int bodyNumber)
        {
            try
            {
                string imagesFolder = Path.Combine(Application.StartupPath, "..\\..\\Modules\\Member Module\\Member Images");

                if (!Directory.Exists(imagesFolder))
                    Directory.CreateDirectory(imagesFolder);

                // Look for an existing image with the same body number
                string existingImage = Directory.GetFiles(imagesFolder, $"{bodyNumber:D3}*.*").FirstOrDefault();

                string destinationPath;

                if (existingImage != null)
                {
                    // Replace existing file, keep the old full name
                    destinationPath = existingImage;
                }
                else
                {
                    // No existing image, create a new one with bodyNumber + date format
                    string datePart = DateTime.Now.ToString("MMMMddyyyy"); // e.g., November022025
                    string fileName = $"{bodyNumber:D3}_{datePart}{Path.GetExtension(sourcePath)}";
                    destinationPath = Path.Combine(imagesFolder, fileName);
                }

                // Copy and overwrite the file
                File.Copy(sourcePath, destinationPath, true);

                return destinationPath;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error replacing image: {ex.Message}", "Image Replace Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


    }
}
