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
       


        public DashboardUForm()
        {
            InitializeComponent();
            

        }

        private void DashboardUForm_Load(object sender, EventArgs e)
        {
            
        }

        private void QuickActionNewMemberButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new MembersUForm());
            
        }

        private void QuickActionTransferMemberButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new TransferMembershipUForm());
        }

        private void QuickActionChangeVehicleButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new TransferVehicleUForm());
        }

        private void QuickActionReviewActionButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new AssistanceLogUForm());
        }
    }
}
