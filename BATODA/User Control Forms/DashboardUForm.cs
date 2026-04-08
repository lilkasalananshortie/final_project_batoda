using BATODA.Helpers.Data;
using BATODA.Helpers.Database.Assistance;
using BATODA.Helpers.Database.Members;
using BATODA.Helpers.DataGrids;
using BATODA.Modules.Dashboard_Module.Dashboard_Classes;
using BATODA.Repositories;
using BATODA.User_Control_Forms;
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
    public partial class DashboardUForm : UserControl
    {

        private DashboardForm _mainForm;

        public DashboardUForm(DashboardForm mainForm)
        {
            InitializeComponent();

            _mainForm = mainForm;
        }

        private void DashboardUForm_Load(object sender, EventArgs e)
        {
            TotalMembersLbl.Text = (TotalMembers.GetCount() + 1).ToString();
            PendingReqLbl.Text = RequestsCount.CountPendingRequests().ToString();
            UpdateCodingNumber();
            LoadSystemLogs();

            var taxRepo = new TaxRepository();
            TaxTodayLbl.Text = "₱" + taxRepo.GetPaidTodayTotal().ToString("N2");
            OverdueLbl.Text = "₱" + taxRepo.GetOverdueLastMonthTotal().ToString("N2");

            var eventRepo = new EventRepository();
            int currentMonth = DateTime.Today.Month;
            int currentYear = DateTime.Today.Year;

            var allEvents = eventRepo.GetAllEvents();
            int totalThisMonth = 0;
            int completedThisMonth = 0;

            foreach (var ev in allEvents)
            {
                if (ev.Date.Month == currentMonth && ev.Date.Year == currentYear)
                {
                    totalThisMonth++;
                    if (ev.Status == "Done")
                    {
                        completedThisMonth++;
                    }
                }
            }

            EventsLbl.Text = totalThisMonth.ToString() + " Event(s)";
            CompletedEventsLbl.Text = completedThisMonth.ToString() + " Event(s)";


        }


        private void UpdateCodingNumber()
        {
            string codingText = "";
            DayOfWeek today = DateTime.Now.DayOfWeek;

            switch (today)
            {
                case DayOfWeek.Monday:
                    codingText = "XX1 - XX2";
                    break;
                case DayOfWeek.Tuesday:
                    codingText = "XX3 - XX4";
                    break;
                case DayOfWeek.Wednesday:
                    codingText = "XX5 - XX6";
                    break;
                case DayOfWeek.Thursday:
                    codingText = "XX7 - XX8";
                    break;
                case DayOfWeek.Friday:
                    codingText = "XX9 - XX0";
                    break;
                case DayOfWeek.Saturday:
                case DayOfWeek.Sunday:
                    codingText = "All Available";
                    break;
            }

            CodingNoLbl.Text = codingText;
        }


        private void QuickActionNewMemberButton_Click(object sender, EventArgs e)
        {
           
            _mainForm.ActivateMainButton("Members");
            var membersUC = new MembersUForm();
            DisplayClass.ShowMain(membersUC);
            membersUC.ShowAddMemberPanel();
            
        }

        private void LoadSystemLogs()
        {
            var logRepo = new SystemActivityLogRepository();
            SystemLogGrid.DataSource = logRepo.GetAllLogs();

            SystemLogGrid.Columns["ModuleName"].HeaderText = "Module";
            SystemLogGrid.Columns["ActionType"].HeaderText = "Action Type";
            SystemLogGrid.Columns["Description"].HeaderText = "Description";
            SystemLogGrid.Columns["DateRecorded"].HeaderText = "Date";

            DataGridCustom.ApplyActivityLogGrid(SystemLogGrid);
        }


        private void QuickActionTransferMemberButton_Click(object sender, EventArgs e)
        {
           
            _mainForm.ActivateMainButton("Members");
            DisplayClass.ShowMain(new TransferMembershipUForm());
        }

        private void QuickActionChangeVehicleButton_Click(object sender, EventArgs e)
        {
            
            _mainForm.ActivateMainButton("Vehicles");
            DisplayClass.ShowMain(new TransferVehicleUForm());

        }

        private void QuickActionReviewActionButton_Click(object sender, EventArgs e)
        {
           
            _mainForm.ActivateMainButton("Assistance");
            DisplayClass.ShowMain(new AssistanceRequestUForm());

        }

        private void dataGridView7_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
