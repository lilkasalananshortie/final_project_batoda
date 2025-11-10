using BATODA.Helpers.Database.Members;
using BATODA.Helpers.Database.Assistance;
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
            TotalMembersLbl.Text = TotalMembers.GetCount().ToString();
            PendingReqLbl.Text = RequestsCount.CountPendingRequests().ToString();
            UpdateCodingNumber();
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
            DisplayClass.ShowMain(new MembersUForm());
            _mainForm.ActivateMainButton("Members");
        }

        private void QuickActionTransferMemberButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new TransferMembershipUForm());
            _mainForm.ActivateMainButton("Members");
        }

        private void QuickActionChangeVehicleButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new TransferVehicleUForm());
            _mainForm.ActivateMainButton("Vehicles");

        }

        private void QuickActionReviewActionButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new AssistanceLogUForm());
            _mainForm.ActivateMainButton("Assistance");

        }
    }
}
