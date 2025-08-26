using System;
using System.Windows.Forms;

namespace BATODA
{
    public partial class DashboardForm : Form
    {

        //ALL RELATED TO PANEL AND NAV BAR TOP AND LEFT
        Panel activePanel;
        bool expanding;
        int step = 10;
        int collapsedHeight = 80;  
        int expandedHeight = 290;   
        
        public DashboardForm()
        {
            InitializeComponent();
            //DEFAULT WAG PALITAN
            MembersContainer.Height = collapsedHeight;
            RegisteredContainer.Height = collapsedHeight;
            AssistanceLogContainer.Height = collapsedHeight;
            FinanceContainer.Height = collapsedHeight;
            SettingsContainer.Height = collapsedHeight;
            //ANIMATION TIMER
            timer1.Interval = 15;
            timer1.Tick += Timer1_Tick;

            DisplayPanel.Visible = true;
        }
        //ANIMATION METHOD
        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (activePanel == null) return;

            if (expanding)
            {
                activePanel.Height += step;
                if (activePanel.Height >= expandedHeight)
                {
                    activePanel.Height = expandedHeight;
                    timer1.Stop();
                }
            }
            else
            {
                activePanel.Height -= step;
                if (activePanel.Height <= collapsedHeight)
                {
                    activePanel.Height = collapsedHeight;
                    timer1.Stop();
                }
            }
        }

        // PWEDE MAALIS KAPAG DI NAGAMIT 
        //private void CollapseAll()
        //{
        //    foreach (Control ctrl in NavBarPanel.Controls)
        //    {
        //        if (ctrl is Panel p)
        //        {
        //            p.Height = collapsedHeight;

        //        }
        //    }
        //    activePanel = null;
        //}

        private void CollapseAllExcept(Panel panelToKeepOpen)
        {
            foreach (Control ctrl in NavBarPanel.Controls)
            {
                if (ctrl is Panel p && p != panelToKeepOpen)
                {
                    p.Height = collapsedHeight;
                }
            }
        }
        //USED TO DISPLAY USER CONTROL
        private void ShowControl(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;    
            DisplayPanel.Controls.Clear(); 
            DisplayPanel.Controls.Add(uc); 
        }
        //SA NAV BAR
        private void TogglePanel(Panel panel)
        {
            if (activePanel == panel && panel.Height > collapsedHeight)
            {
                return;
            }
          
            CollapseAllExcept(panel);
            activePanel = panel;

            if (panel.Height == collapsedHeight)
            {
                expanding = true;
                timer1.Start();
            }
        }


        private void btnMembers_Click(object sender, EventArgs e)
        {
            TogglePanel(MembersContainer);
            ShowControl(new MembersUForm());

        }

        private void btnRegistered_Click(object sender, EventArgs e)
        {
            TogglePanel(RegisteredContainer);
            ShowControl(new RegisteredVehicleUForm());
        }

        private void btnAssistance_Click(object sender, EventArgs e)
        {
            TogglePanel(AssistanceLogContainer);
            ShowControl(new AssistanceLogUForm());
        }

        private void btnFinance_Click(object sender, EventArgs e)
        {
            TogglePanel(FinanceContainer);
            ShowControl(new FinanceUForm());
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            TogglePanel(SettingsContainer);
            ShowControl(new SettingsUForm());

        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            ShowControl(new DashboardUForm());

        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            if (activePanel != null && activePanel.Height > collapsedHeight)
            {
                expanding = false;
                timer1.Start();
            }
            else if (activePanel != null && activePanel.Height == collapsedHeight)
            {    
                activePanel = null;
            }        
            ShowControl(new DashboardUForm());        
        }

        private void TransferMembershipButton_Click(object sender, EventArgs e)
        {
            ShowControl(new TransferMembershipUForm());
        }

        private void TransferRecordsButton_Click(object sender, EventArgs e)
        {

        }

        private void AssistanceRequestButton_Click(object sender, EventArgs e)
        {
            
        }

        private void ARHButton_Click(object sender, EventArgs e)
        {

        }

        private void TransferVehicleButton_Click(object sender, EventArgs e)
        {

        }

        private void TransferRecordButton_Click(object sender, EventArgs e)
        {

        }

        private void ButawButton_Click(object sender, EventArgs e)
        {

        }

        private void MembershipRenewalButton_Click(object sender, EventArgs e)
        {

        }

        private void LogOutButton_Click(object sender, EventArgs e)
        {

        }

        private void BackupButton_Click(object sender, EventArgs e)
        {

        }

        private void DisplayPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        
    }
}
