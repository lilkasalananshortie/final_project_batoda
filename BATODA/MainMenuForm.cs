using System;
using System.Drawing;
using System.Windows.Forms;
using BATODA.UI_Displays;
using BATODA.User_Control_Forms;

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

            SwitchAdminPanel.Visible = false;
            SettingsPanel.Visible = false;
            DisplayPanel.Visible = true;
            DisplayPanel.Dock = DockStyle.Fill;
            NotificationPanel.Visible = false;
            CalendarXAccoutnContainerPanel.Visible = false;
        }

        private Timer clockTimer;

        private void SetupClock()
        {
            clockTimer = new Timer();
            clockTimer.Interval = 1000;
            clockTimer.Tick += ClockTimer_Tick;
            clockTimer.Start();
        }

        private void ClockTimer_Tick(object sender, EventArgs e)
        {
            MainTime.Text = DateTime.Now.ToString("hh:mm tt");
        }


        private void DashboardForm_Load(object sender, EventArgs e)
        {
            SetupClock();
            MainDate.Text = DateTime.Now.ToString("MMMM dd, yyyy (dddd)");

            this.ActiveControl = null;
            DisplayClass.ShowMain(new DashboardUForm(this));
            TopPanelText.Text = "DASHBOARD";
            SubTopPanel.Text = "Here’s what’s happening with your organization.";

            DisplayClass.Register
            (
                 HomeButton,
                 MembersMainButton,
                 RegisteredVehiclesButton,
                 AssistanceLogButton,
                 FinanceButton,
                 CSButton,
                 CalendarBtn,
                 FareMatrixButton

            );

            DisplayClass.SetActive(HomeButton);

            CreateNewAdminAccountPanel.Visible = false;
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
                    DisplayClass.ShowMain(new TricycleUForm());
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
                    DisplayClass.SetActive(CSButton);
                    DisplayClass.ShowMain(new SettingsUForm());
                    TopPanelText.Text = "SETTINGS";
                    break;

                case "Calendar":
                    DisplayClass.SetActive(CalendarBtn);
                    DisplayClass.ShowMain(new CalendarUForm());
                    TopPanelText.Text = "CALENDAR";
                    break;

                case "FareMatrix":
                    DisplayClass.SetActive(FareMatrixButton);
                    DisplayClass.ShowMain(new FareMatrixUForm());
                    TopBarPanel.Text = "FARE MATRIX";
                    break;
            }
        }
        private void HomeButton_Click(object sender, EventArgs e)
        {
            ActivateMainButton("Dashboard");
            DisplayClass.ShowMain(new DashboardUForm(this));
            TopPanelText.Text = "DASHBOARD";
            SubTopPanel.Text = "Here’s what’s happening with your organization.";

        }

        private void MembersMainButton_Click(object sender, EventArgs e)
        {
            ActivateMainButton("Members");
            DisplayClass.ShowMain(new MembersUForm());
            TopPanelText.Text = "MEMBER MANAGEMENT";
            SubTopPanel.Text = "Manage member Registrations, transfers and information";

        }

        private void RegisteredVehiclesButton_Click(object sender, EventArgs e)
        {
            ActivateMainButton("Vehicles");
            DisplayClass.ShowMain(new TricycleUForm());
            TopPanelText.Text = "MANAGE VEHICLE";
            SubTopPanel.Text = "Manage Vehicle Registrations, transfers and information";
        }

        private void AssistanceLogButton_Click(object sender, EventArgs e)
        {
            ActivateMainButton("Assistance");
            DisplayClass.ShowMain(new AssistanceRequestUForm());
            TopPanelText.Text = "MANAGE ASSISTANCE";
            SubTopPanel.Text = "Manage member assistance request and approvals.";

        }
        private void FinanceButton_Click(object sender, EventArgs e)
        {
            ActivateMainButton("Finance");
            DisplayClass.ShowMain(new FinanceUForm());
            TopPanelText.Text = "FINANCE MANAGEMENT";
            SubTopPanel.Text = "Track member tax payments (Butaw) and membership renewal status";

        }

        private void CalendarBtn_Click(object sender, EventArgs e)
        {
            ActivateMainButton("Calendar");
            DisplayClass.ShowMain(new CalendarUForm());
            TopPanelText.Text = "CALENDAR";
            SubTopPanel.Text = "Create and manage your upcoming events.";


        }
        private void FareMatrixButton_Click(object sender, EventArgs e)
        {
            ActivateMainButton("Fare Matrix");
            DisplayClass.ShowMain(new FareMatrixUForm());
            TopPanelText.Text = "FARE MATRIX";
            SubTopPanel.Text = "Check the latest fare around bulakan";

        }
        private void CSButton_Click(object sender, EventArgs e)
        {
            ActivateMainButton("CSButton");
            DisplayClass.ShowMain(new CSUForm());
            TopPanelText.Text = "CUSTOMER SERVICE";
            SubTopPanel.Text = "Manage customer service complaints and inquiries.";
        }
        private void SettingsButton_Click(object sender, EventArgs e)
        {
            ActivateMainButton("Settings");
            DisplayClass.ShowMain(new SettingsUForm());
            TopPanelText.Text = "SETTINGS";
            SubTopPanel.Text = "Backup/Restore your organizations data ";
        }
        private void SettingButton_Click(object sender, EventArgs e)
        {
            SettingsPanel.Visible = !SettingsPanel.Visible;

            if (SettingsPanel.Visible)
                SettingsPanel.Show();
            else
                SettingsPanel.Hide();       
        }

        private void CreateNewAdminCancelButton_Click_1(object sender, EventArgs e)
        {
            CreateNewAdminAccountPanel.Visible = false;
        }

        private void CreateNewAdminAccountButton_Click_1(object sender, EventArgs e)
        {
            CreateNewAdminAccountPanel.Visible = true;
            CreateNewAdminAccountPanel.BringToFront();
        }

        private void LogOutButton_Click_1(object sender, EventArgs e)
        {
            LoginForm LoginForm = new LoginForm();
            Close();
            LoginForm.Show();
        }

        private void SwitchAdminAccountButton_Click(object sender, EventArgs e)
        {
            SwitchAdminPanel.Visible = true;
            SwitchAdminPanel.BringToFront();
        }

        private void CancelBindButton_Click(object sender, EventArgs e)
        {
            SwitchAdminPanel.Visible = false;
        }
    }
}