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
