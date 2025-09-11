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
    public partial class MembersUForm : UserControl
    {
        public MembersUForm()
        {
            InitializeComponent();
            
        }

        private void MembersUForm_Load(object sender, EventArgs e)
        {

            DisplayClass.SetPlaceholder(SearchTextBox, "Search Member");
            DisplayClass.SetPlaceholder(StatusComboBox, "Status", "Active", "Inactive");
            DisplayClass.SetPlaceholder(MemberTypeComboBox, "Member Type", "Operator", "Driver");
            DisplayClass.SetPlaceholder(OrderComboBox, "Order By", "Ascending", "Descending");



        }
        private void TransferRecordsButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new TransferRecordMemberUForm());
        }
        private void TransferMembershipButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new TransferMembershipUForm());
        }

        private void StatusComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MemberTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void OrderComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {

        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ClearInputs(this);
        }
    }
}
