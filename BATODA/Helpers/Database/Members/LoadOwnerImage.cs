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

            // Look for any file that starts with bodyNumber_
            string[] files = Directory.GetFiles(ImagesFolder, $"{bodyNumber}_*.*");

            if (files.Length > 0)
            {
                pictureBox.Image = Image.FromFile(files[0]); 
            }
            else
            {
                string defaultImagePath = Path.Combine(ImagesFolder, "USER_DEFAULT.jpg");
                pictureBox.Image = File.Exists(defaultImagePath) ? Image.FromFile(defaultImagePath) : null;
            }
        }
    }
}
