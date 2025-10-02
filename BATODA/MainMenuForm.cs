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



        //private void defaultIconColor() 
        //{ 
        //    //default gray color in nav bar buttons
        //    HomeButton.ImageColor = Color.FromArgb(105, 100, 100);
        //    HomeButton.TextColor = Color.FromArgb(105, 100, 100);

        //    MembersMainButton.ImageColor = Color.FromArgb(105, 100, 100);
        //    MembersMainButton.TextColor =  Color.FromArgb(105, 100, 100);

        //    RegisteredVehiclesButton.ImageColor = Color.FromArgb(105, 100, 100);
        //    RegisteredVehiclesButton.TextColor = Color.FromArgb(105, 100, 100);

        //    AssistanceLogButton.ImageColor = Color.FromArgb(105, 100, 100);
        //    AssistanceLogButton.TextColor = Color.FromArgb(105, 100, 100);

        //    FinanceButton.ImageColor = Color.FromArgb(105, 100, 100);
        //    FinanceButton.TextColor = Color.FromArgb(105, 100, 100);

        //    SettingsButton.ImageColor = Color.FromArgb(105, 100, 100);
        //    SettingsButton.TextColor = Color.FromArgb(105, 100, 100);

        //}
      

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
           //defaultIconColor();
            
            DisplayClass.SetActive(HomeButton);
            DisplayClass.ShowMain(new DashboardUForm());
            TopPanelText.Text = "Dashboard";

         // active color button (#AF2828)
         //   HomeButton.ImageColor = Color.FromArgb(175, 40, 40); 
         //   HomeButton.TextColor = Color.FromArgb(175, 40, 40);
        
        }

        private void MembersMainButton_Click(object sender, EventArgs e)
        {
            //defaultIconColor();

            DisplayClass.SetActive(MembersMainButton);
            DisplayClass.ShowMain(new MembersUForm());
            TopPanelText.Text = "Members Management";

            //MembersMainButton.ImageColor = Color.FromArgb(175, 40, 40);
            //MembersMainButton.TextColor = Color.FromArgb(175, 40, 40);
        }

        private void RegisteredVehiclesButton_Click(object sender, EventArgs e)
        {
            //defaultIconColor();

            DisplayClass.SetActive(RegisteredVehiclesButton);
            DisplayClass.ShowMain(new RegisteredVehicleUForm());
            TopPanelText.Text = "Registered Vehicles";

           // RegisteredVehiclesButton.ImageColor = Color.FromArgb(175, 40, 40);
           //RegisteredVehiclesButton.TextColor = Color.FromArgb(175, 40, 40);
        }

        private void AssistanceLogButton_Click(object sender, EventArgs e)
        {
            //defaultIconColor();
            DisplayClass.SetActive(AssistanceLogButton);
            DisplayClass.ShowMain(new AssistanceLogUForm());
            TopPanelText.Text = "Manage Assistance";

            //AssistanceLogButton.ImageColor = Color.FromArgb(175, 40, 40);
            //AssistanceLogButton.TextColor = Color.FromArgb(175, 40, 40);
        }
        private void FinanceButton_Click(object sender, EventArgs e)
        {
            //defaultIconColor();
            DisplayClass.SetActive(FinanceButton);
            DisplayClass.ShowMain(new FinanceUForm());
            TopPanelText.Text = "Finance Management";

            //FinanceButton.ImageColor = Color.FromArgb(175, 40, 40);
            //FinanceButton.TextColor = Color.FromArgb(175, 40, 40);
        }
        private void SettingsButton_Click(object sender, EventArgs e)
        {
            //defaultIconColor();
            DisplayClass.SetActive(SettingsButton);
            DisplayClass.ShowMain(new SettingsUForm());
            TopPanelText.Text = "Settings";

           // SettingsButton.ImageColor = Color.FromArgb(175, 40, 40);
           //SettingsButton.TextColor = Color.FromArgb(175, 40, 40);
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
    }
}
