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
            SwitchAdminPanel.Hide();
            CreateNewAdminAccountPanel.Hide();
        }

        private void BackupButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new BackupUForm());
        }

        private void LogOutButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new LogoutUForm());
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SwitchAdminAccountButton_Click(object sender, EventArgs e)
        {
            SwitchAdminPanel.Show();
            SwitchAdminPanel.BringToFront();
        }

        private void SettingsUForm_Load(object sender, EventArgs e)
        {
            DisplayClass.SetPlaceholder(UsernameTextBox, "Username");
            DisplayClass.SetPlaceholder(PasswordTextBox, "Password");
            DisplayClass.SetPlaceholder(FullnameTextbox, "Enter full name");
            DisplayClass.SetPlaceholder(NewEmailAddressTextbox, "Enter email address");
            DisplayClass.SetPlaceholder(NewPasswordTextbox, "Enter password");
            DisplayClass.SetPlaceholder(ConfirmPasswordTextbox, "Confirm your password");


        }

        private void SwitchAdminCancel_Click(object sender, EventArgs e)
        {
            SwitchAdminPanel.Hide();
        }

        private void CreateNewAdminCancelButton_Click(object sender, EventArgs e)
        {
            CreateNewAdminAccountPanel.Hide();
        }

        private void CreateNewAdminAccountButton_Click(object sender, EventArgs e)
        {
            CreateNewAdminAccountPanel.Show();
            CreateNewAdminAccountPanel.BringToFront();
        }
    }
}
