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
            DisplayClass.SetMainPanel(DisplayPanel);
            DisplayClass.SetMiniPanel(CalendarXAccoutnContainerPanel);

            DisplayPanel.Visible = true;
            DisplayPanel.Dock = DockStyle.Fill;
            NotificationPanel.Visible = false;
            CalendarXAccoutnContainerPanel.Visible = false;

          

        }
        private void DashboardForm_Load(object sender, EventArgs e)
        {
            this.ActiveControl = null;
            DisplayClass.ShowMain(new DashboardUForm(this));
            TopPanelText.Text = "DASHBOARD";

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

        public void ActivateMainButton(string module)
        {
            switch (module)
            {
                case "Dashboard":
                    DisplayClass.SetActive(HomeButton);
                    DisplayClass.ShowMain(new DashboardUForm(this));
                    TopPanelText.Text = "DASHBOARD";
                    break;

                case "Members":
                    DisplayClass.SetActive(MembersMainButton);
                    DisplayClass.ShowMain(new MembersUForm());
                    TopPanelText.Text = "MEMBER MANAGEMENT";
                    break;

                case "Vehicles":
                    DisplayClass.SetActive(RegisteredVehiclesButton);
                    DisplayClass.ShowMain(new RegisteredVehicleUForm());
                    TopPanelText.Text = "MANAGE VEHICLE";
                    break;

                case "Assistance":
                    DisplayClass.SetActive(AssistanceLogButton);
                    DisplayClass.ShowMain(new AssistanceLogUForm());
                    TopPanelText.Text = "MANAGE ASSISTANCE";
                    break;

                case "Finance":
                    DisplayClass.SetActive(FinanceButton);
                    DisplayClass.ShowMain(new FinanceUForm());
                    TopPanelText.Text = "FINANCE MANAGEMENT";
                    break;

                case "Settings":
                    DisplayClass.SetActive(SettingsButton);
                    DisplayClass.ShowMain(new SettingsUForm());
                    TopPanelText.Text = "SETTINGS";
                    break;
            }
        }
        private void HomeButton_Click(object sender, EventArgs e)
        {
            ActivateMainButton("Dashboard");
            DisplayClass.ShowMain(new DashboardUForm(this));
            TopPanelText.Text = "DASHBOARD"; 
        }

        private void MembersMainButton_Click(object sender, EventArgs e)
        {
            ActivateMainButton("Members");
            DisplayClass.ShowMain(new MembersUForm());
            TopPanelText.Text = "MEMBER MANAGEMENT";
        }

        private void RegisteredVehiclesButton_Click(object sender, EventArgs e)
        {
            ActivateMainButton("Vehicles");
            DisplayClass.ShowMain(new RegisteredVehicleUForm());
            TopPanelText.Text = "MANAGE VEHICLE";
        }

        private void AssistanceLogButton_Click(object sender, EventArgs e)
        {
            ActivateMainButton("Assistance"); 
            DisplayClass.ShowMain(new AssistanceLogUForm());
            TopPanelText.Text = "MANAGE ASSISTANCE";
        }
        private void FinanceButton_Click(object sender, EventArgs e)
        {
            ActivateMainButton("Finance");
            DisplayClass.ShowMain(new FinanceUForm());
            TopPanelText.Text = "FINANCE MANAGEMENT";
        }
        private void SettingsButton_Click(object sender, EventArgs e)
        {
            ActivateMainButton("Settings");
            DisplayClass.ShowMain(new SettingsUForm());
            TopPanelText.Text = "SETTINGS";
        }
        //THIS PART IS FOR CALENDAR AND ACCOUNT BUTTONS NEED PA AYUSIN LOGIC KAPAG TINOGLE BUTTON CLOSE OR MAY IN BUILT CLOSE BTN
        private void AccountButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMini(new AccountUForm());
            CalendarXAccoutnContainerPanel.Visible = true; 
            CalendarXAccoutnContainerPanel.BringToFront();
        }

        private void CalendarButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMini(new CalendarUForm());
            CalendarXAccoutnContainerPanel.Visible = true; 
            CalendarXAccoutnContainerPanel.BringToFront();
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void NotificationButton_Click(object sender, EventArgs e)
        {
            NotificationPanel.Visible = !NotificationPanel.Visible;
                 if (NotificationPanel.Visible)
                   NotificationPanel.BringToFront();
        }

       

        private void TopBarPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void NavBarPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
