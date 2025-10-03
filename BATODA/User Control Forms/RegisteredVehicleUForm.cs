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
    public partial class RegisteredVehicleUForm : UserControl
    {
        public RegisteredVehicleUForm()
        {
            InitializeComponent();

        }

        private void RegisteredVehicleUForm_Load(object sender, EventArgs e)
        {
            DisplayClass.SetPlaceholder(SearchTextBox, "Search Member");
            DisplayClass.SetPlaceholder(StatusComboBox, "Brand", "Sample 1", "Sample 1", "Sample 1", "Sample 1", "Sample 1");
            DisplayClass.SetPlaceholder(MemberTypeComboBox, "Member Type", "Operator", "Driver");
            DisplayClass.SetPlaceholder(OrderComboBox, "Order By", "Ascending", "Descending");
        }

        private void RegisteredVehicleButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new RegisteredVehicleUForm());
        }

        private void TransferVehicleButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new TransferVehicleUForm());
        }

        private void TransferRecordButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new TransferRecordVehicleUForm());
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ClearInputs(this);
            ToastManager.Success("Filters Cleared Successfully!");
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            ToastManager.Success("Filters Applied!");
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {

        }
    }
}
