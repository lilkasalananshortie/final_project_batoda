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
            this.ActiveControl = null;
            DisplayClass.ShowMain(new DashboardUForm());
            TopPanelText.Text = "Dashboard";

            DisplayClass.Register
            (
                 HomeButton,
                 MembersMainButton,
                 RegisteredVehiclesButton,
                 AssistanceLogButton,
                 FinanceButton,
                 SettingsButton
            );

            DisplayClass.SetActive(HomeButton);

        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
           
            
            DisplayClass.SetActive(HomeButton);
            DisplayClass.ShowMain(new DashboardUForm());
            TopPanelText.Text = "Dashboard";

        
        
        }

        private void MembersMainButton_Click(object sender, EventArgs e)
        {
            

            DisplayClass.SetActive(MembersMainButton);
            DisplayClass.ShowMain(new MembersUForm());
            TopPanelText.Text = "Members Management";

        }

        private void RegisteredVehiclesButton_Click(object sender, EventArgs e)
        {
            

            DisplayClass.SetActive(RegisteredVehiclesButton);
            DisplayClass.ShowMain(new RegisteredVehicleUForm());
            TopPanelText.Text = "Registered Vehicles";

        }

        private void AssistanceLogButton_Click(object sender, EventArgs e)
        {
          
            DisplayClass.SetActive(AssistanceLogButton);
            DisplayClass.ShowMain(new AssistanceLogUForm());
            TopPanelText.Text = "Manage Assistance";

         
        }
        private void FinanceButton_Click(object sender, EventArgs e)
        {
          
            DisplayClass.SetActive(FinanceButton);
            DisplayClass.ShowMain(new FinanceUForm());
            TopPanelText.Text = "Finance Management";

          
        }
        private void SettingsButton_Click(object sender, EventArgs e)
        {
           
            DisplayClass.SetActive(SettingsButton);
            DisplayClass.ShowMain(new SettingsUForm());
            TopPanelText.Text = "Settings";

          
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

        private void TopBarPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void NavBarPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
