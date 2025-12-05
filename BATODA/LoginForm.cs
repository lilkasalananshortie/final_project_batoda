using BATODA.Modules.Login_Module;
using BATODA.UI_Displays;
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
    public partial class LoginForm : Form
    {

        Timer timer = new Timer();
        bool showPassword = false;

        public LoginForm()
        {
            InitializeComponent();

            LoadingPanel.Visible = true;
            LoadingPanel.Dock = DockStyle.Fill;
            LoadingPanel.BringToFront();
            timer.Interval = 2000;
            timer.Tick += Timer_Tick;
            timer.Start();

            PasswordTextBox.UseSystemPasswordChar = true;
            PasswordTextBox.TextChanged += PasswordTextBox_TextChanged;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            LoadingPanel.Visible = false;
        }

        private void LoginButton_Click_1(object sender, EventArgs e)
        {
            //string username = UsernameTextBox.Text.Trim();
            //string password = PasswordTextBox.Text.Trim();

            //LoginRepository repo = new LoginRepository();

            //try
            //{
            //    if (repo.VerifyLogin(username, password))
            //    {
                   
            //    }
            //    else
            //    {
            //        ToastManager.Error("Invalid username or password!");
            //        PasswordTextBox.Clear();
            //        PasswordTextBox.Focus();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ToastManager.Error(ex.Message);
            //}

            DashboardForm DashBoardform = new DashboardForm();
            DashBoardform.Show();

            ToastManager.Success("Login Successful!");
            this.Hide();
        }


        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            // Only apply mask if user typed real password (not placeholder)
            if (PasswordTextBox.ForeColor != Color.Gray)
                PasswordTextBox.UseSystemPasswordChar = !showPassword;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            DisplayClass.SetPlaceholder(UsernameTextBox, "Username");
            DisplayClass.SetPlaceholder(PasswordTextBox, "Password");

            this.ActiveControl = null;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.ActiveControl = null;
        }

        public class TransparentTextBox : TextBox
        {
            public TransparentTextBox()
            {
                SetStyle(ControlStyles.SupportsTransparentBackColor, true);
                BackColor = Color.Transparent;
                BorderStyle = BorderStyle.None;
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ShowPassButton_Click(object sender, EventArgs e)
        {
            showPassword = !showPassword;

            PasswordTextBox.UseSystemPasswordChar = !showPassword;

            ShowPassButton.Image = showPassword ? Properties.Resources.view : Properties.Resources.hide;

            PasswordTextBox.SelectionStart = PasswordTextBox.Text.Length;
        }
    }
}
