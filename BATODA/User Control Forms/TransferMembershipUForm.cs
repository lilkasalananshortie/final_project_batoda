using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BATODA.UI_Displays;

namespace BATODA
{
    public partial class TransferMembershipUForm : UserControl
    {
        public TransferMembershipUForm()
        {
            InitializeComponent();
        }

        private void TransferMembershipUForm_Load(object sender, EventArgs e)
        {
            DisplayClass.SetPlaceholder(SearchTextBox, "Search Member");
            TransferOperationPanel.Visible = false;
        }

        private void ManageMembersButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new MembersUForm());
        }

        private void TransferMembershipButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new TransferMembershipUForm());
        }

        private void TransferRecordsButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new TransferRecordMemberUForm());
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            TransferOperationPanel.Visible =! TransferOperationPanel.Visible;
            SearchButton.Enabled = false;
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            TransferOperationPanel.Visible = false;
            SearchButton.Enabled = true;
            ToastManager.Warning("Transfership Cancelled");
            

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            TransferOperationPanel.Visible = false;
            SearchButton.Enabled = true;
            ToastManager.Success("Membership Transferred Successfully");
        }
    }
}
