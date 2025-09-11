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
        public LoginForm()
        {
            InitializeComponent();
            
            LoadingPanel.Visible = true;
            LoadingPanel.Dock = DockStyle.Fill;
            timer.Interval = 2000;
            timer.Tick += Timer_Tick;
            timer.Start();


        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop(); 
            LoadingPanel.Visible = false; 
        }

        private void LoginButton_Click_1(object sender, EventArgs e)
        {
            DashboardForm DashBoardform = new DashboardForm();
            DashBoardform.Show();
            this.Hide();
        }

        private void UsernameTextBox_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {

            
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            PlaceHolderTextBox.SetPlaceholder(UsernameTextBox, "Username");
            PlaceHolderTextBox.SetPlaceholder(PasswordTextBox, "Password");

            this.ActiveControl = null;
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.ActiveControl = null; 
        }
        

    }
}

