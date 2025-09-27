using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BATODA
{
    public partial class SettingsUForm : UserControl
    {
        public SettingsUForm()
        {
            InitializeComponent();
        }

        private void BackupButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new BackupUForm());
        }

        private void LogOutButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new LogoutUForm());
        }
    }
}
