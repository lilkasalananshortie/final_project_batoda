using System;
using System.Windows.Forms;

namespace BATODA
{
    public partial class DashboardForm : Form
    {

       
       
        public DashboardForm()
        {
            InitializeComponent();
            //DEFAULT WAG PALITAN

            //WAG PALITAN NAKA HIDE DITO YUNG DAPAT DI MAKITA MUNA
            DisplayPanel.Visible = true;
            DisplayPanel.Dock = DockStyle.Fill;
            NotificationPanel.Visible = false;
            CalendarXAccoutnContainerPanel.Visible = false;

        }
             
        //USED TO DISPLAY USER CONTROL
        private void ShowControl(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;    
            DisplayPanel.Controls.Clear(); 
            DisplayPanel.Controls.Add(uc);
        }

        private void ShowControlMini(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;
            CalendarXAccoutnContainerPanel.Controls.Clear();
            CalendarXAccoutnContainerPanel.Controls.Add(uc);
        }
        private void HomeButton_Click_1(object sender, EventArgs e)
        {
            ShowControl(new DashboardUForm());
        }

        
        private void btnMembers_Click(object sender, EventArgs e)
        {
            
        }
        private void MembersMainButton_Click(object sender, EventArgs e)
        {
            
            ShowControl(new MembersUForm());
        }

        private void btnRegistered_Click(object sender, EventArgs e)
        {
            
            ShowControl(new RegisteredVehicleUForm());
        }

        private void btnAssistance_Click(object sender, EventArgs e)
        {
            
            ShowControl(new AssistanceLogUForm());
        }

        private void btnFinance_Click(object sender, EventArgs e)
        {
           
            ShowControl(new FinanceUForm());
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            
            ShowControl(new SettingsUForm());

        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            ShowControl(new DashboardUForm());

        }

        private void AccountButton_Click(object sender, EventArgs e)
        {
            ShowControlMini(new AccountUForm());
            CalendarXAccoutnContainerPanel.Visible = !CalendarXAccoutnContainerPanel.Visible;
            if (CalendarXAccoutnContainerPanel.Visible)
                CalendarXAccoutnContainerPanel.BringToFront();
        }

        private void NotificationButton_Click(object sender, EventArgs e)
        {
            NotificationPanel.Visible = !NotificationPanel.Visible;
            if (NotificationPanel.Visible)
                NotificationPanel.BringToFront();
        }

        private void CalendarButton_Click(object sender, EventArgs e)
        {
            ShowControlMini(new CalendarUForm());
            CalendarXAccoutnContainerPanel.Visible = !CalendarXAccoutnContainerPanel.Visible;
            if (CalendarXAccoutnContainerPanel.Visible)
                CalendarXAccoutnContainerPanel.BringToFront();
        }

       
    }
}
