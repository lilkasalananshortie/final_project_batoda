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

            ConfirmationPanel.Hide();
            DisplayClass.SetPlaceholder(BodyNumberTextBox, "Enter Body Number");
            DisplayClass.SetPlaceholder(ContactNumTextBox, "Enter Cellphone Number");
            DisplayClass.SetPlaceholder(VehicleInfoTextBox, "Enter Unit Brand");
            DisplayClass.SetPlaceholder(FirstNameTextBox, "Enter First Name");
            DisplayClass.SetPlaceholder(LastNameTextBox, "Enter Last Name");
            DisplayClass.SetPlaceholder(MiddleNameTextBox, "Enter Middle Name");
            DisplayClass.SetPlaceholder(PlateNumberTextBox, "Enter Plate Number");
            DisplayClass.SetPlaceholder(MTypeComboBox, "Member Type", "Operator", "Driver");
            DisplayClass.SetPlaceholder(ModelTextBox, "Enter Model");
            DisplayClass.SetPlaceholder(RTransferTextBox, "Enter Transfer Description");
            DisplayClass.SetPlaceholder(ChassisNumberTextBox,"Enter Chassis Number");
            DisplayClass.SetPlaceholder(EngineNumberTextBox, "Enter Engine Number");


        }

        private void TransferMembershipUForm_Load(object sender, EventArgs e)
        {
            
            
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
            
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            

            

        }

       

        private void ConfirmationButton_Click(object sender, EventArgs e)
        {
           ConfirmationPanel.Hide();
           ToastManager.Success("Membership Transferred Successfully!");
            
        }

        private void CancelConfirmation_Click(object sender, EventArgs e)
        {
            ConfirmationPanel.Hide();
            ToastManager.Info("Membership Transfer Cancelled.");
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            ConfirmationPanel.Show();
        }

        
    }
}
