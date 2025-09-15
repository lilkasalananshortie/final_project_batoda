using System;
using System.Drawing;
using System.Windows.Forms;
using BATODA.UI_Displays;

namespace BATODA
{
    public partial class DashboardForm : Form
    {

       
       
        public DashboardForm()
        {
            InitializeComponent();
            

            //WAG PALITAN NAKA HIDE DITO YUNG DAPAT DI MAKITA MUNA
            DisplayPanel.Visible = true;
            DisplayPanel.Dock = DockStyle.Fill;
            NotificationPanel.Visible = false;
            CalendarXAccoutnContainerPanel.Visible = false;

            DisplayClass.SetMainPanel(DisplayPanel);
            DisplayClass.SetMiniPanel(CalendarXAccoutnContainerPanel);

        }
        private void DashboardForm_Load(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new DashboardUForm());
            

        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new DashboardUForm());
           
        }

        private void MembersMainButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new MembersUForm());
            
        }

        private void RegisteredVehiclesButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new RegisteredVehicleUForm());
        }

        private void AssistanceLogButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new AssistanceLogUForm());
        }
        private void FinanceButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new FinanceUForm());
        }
        private void SettingsButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new SettingsUForm());
        }
        private void btnMembers_Click(object sender, EventArgs e)
        {
            
        }
          


        private void AccountButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMini(new AccountUForm());
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
            DisplayClass.ShowMini(new CalendarUForm());
            CalendarXAccoutnContainerPanel.Visible = !CalendarXAccoutnContainerPanel.Visible;
            if (CalendarXAccoutnContainerPanel.Visible)
                CalendarXAccoutnContainerPanel.BringToFront();
        }

        
    }
}
