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
    public partial class MembersUForm : UserControl
    {
        public MembersUForm()
        {
            InitializeComponent();
            
        }

        private void MembersUForm_Load(object sender, EventArgs e)
        {
            

            DisplayClass.SetButtonToggleColor(TransferRecordsButton, Color.DarkGray, Color.Gray, Color.Gray);
            DisplayClass.SetButtonToggleColor(ManageMembersButton, Color.DarkGray, Color.Gray, Color.Gray);
            DisplayClass.SetButtonToggleColor(TransferMembershipButton, Color.DarkGray, Color.Gray, Color.Gray);

            DisplayClass.SetPlaceholder(SearchTextBox, "Search Member");
            DisplayClass.SetPlaceholder(StatusComboBox, "Status", "Active", "Inactive");
            DisplayClass.SetPlaceholder(MemberTypeComboBox, "Member Type", "Operator", "Driver");
            DisplayClass.SetPlaceholder(OrderComboBox, "Order By", "Ascending", "Descending");
            DisplayClass.SetPlaceholder(BodyNumberTextBox, "Enter Body Number");
            DisplayClass.SetPlaceholder(ContactNumTextBox, "Enter Cellphone Number");
            DisplayClass.SetPlaceholder(VehicleInfoTextBox, "Enter Unit Brand");
            DisplayClass.SetPlaceholder(FirstNameTextBox, "Enter First Name");
            DisplayClass.SetPlaceholder(LastNameTextBox, "Enter Last Name");
            DisplayClass.SetPlaceholder(MiddleNameTextBox, "Enter Middle Name");

            AddMemberPanel.Visible = false;
            AddMemberPanel.BringToFront();



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

        private void ManageMembersButton_Click(object sender, EventArgs e)
        {

        }

        private void AddMemberButton_Click(object sender, EventArgs e)
        {
            ToastManager.Info("Member Searchd");    // testing lang 
            AddMemberPanel.Visible = true;
            AddMemberButton.Enabled = false;
            ClearButton.Enabled = false;
            ApplyButton.Enabled = false;
            
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            ToastManager.Success("New Member Added Successfully!");
            AddMemberPanel.Visible = false;
            AddMemberButton.Enabled = true;
            ApplyButton.Enabled = true;
            ClearButton.Enabled = true;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            ToastManager.Warning("Adding New Member Cancelled");
            AddMemberPanel.Visible = false;
            AddMemberButton.Enabled = true;
            ApplyButton.Enabled = true;
            ClearButton.Enabled = true;
        }

        private void AddMemberPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
