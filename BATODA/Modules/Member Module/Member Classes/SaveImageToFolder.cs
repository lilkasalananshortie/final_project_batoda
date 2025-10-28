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
        public static string Save(string sourcePath, int bodyNumber)
        {
            try
            { 
                // PATH NG LALAGYAN NG PFP NG MGA MEMBS
                string ProjectPath = Directory.GetParent(Application.StartupPath).Parent.FullName;
                string ImagesFolder = Path.Combine(ProjectPath, "Modules", "Member Module", "Member Images");

                if (!Directory.Exists(ImagesFolder))
                {
                    Directory.CreateDirectory(ImagesFolder);
                }

                // SAMPLE FORMAT: 600_September292025.jpg
                // UNIQUE KAHIT MAY SAME BODY NO. NG PREVIOUS OWNER
                string NewFileName = $"{bodyNumber}_{DateTime.Now:MMMMddyyyy}{Path.GetExtension(sourcePath)}";
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
    }
}
