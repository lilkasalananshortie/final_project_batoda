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
            // Folder where member images are stored
            string imagesFolder = @"C:\BSIT 1\GIT CLONES\BATODA\Modules\Member Module\Member Images\";

            // Ensure BodyNumber is 3 digits
            string bodyNumber = owner.BodyNumber.ToString("D3");

            // Format DateJoined as MonthName + Day + Year
            string datePart = owner.DateJoined.ToString("MMMMdyyyy"); // e.g., September262004

            // Build the image file name
            string imageName = $"{bodyNumber}_{datePart}.jpg"; // change extension if needed

            // Full path to the image
            string imagePath = Path.Combine(imagesFolder, imageName);

            // Load the image if it exists, otherwise load default
            if (File.Exists(imagePath))
            {
                pictureBox.Image = Image.FromFile(imagePath);
            }
            else
            {
                string defaultImagePath = @"C:\BSIT 1\GIT CLONES\BATODA\Modules\Member Module\Member Images\USER_DEFAULT.jpg";
                if (File.Exists(defaultImagePath))
                    pictureBox.Image = Image.FromFile(defaultImagePath);
                else
                    pictureBox.Image = null;
            }
        }
    }
}
