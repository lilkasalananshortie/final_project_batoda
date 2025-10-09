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
    public partial class TransferVehicleUForm : UserControl
    {
        public TransferVehicleUForm()
        {
            InitializeComponent();
            DisplayClass.SetPlaceholder(SearchTextBox, "Search Member");
            DisplayClass.SetPlaceholder(NewTeicycleTextBox, "Enter Tricycle Brand");
            DisplayClass.SetPlaceholder(NewPlateNoTextBox, "Enter Tricycle Plate Number");
            DisplayClass.SetPlaceholder(ReasonForChangeTextBox, "Enter Change Description");



        }
        private void TransferVehicleUForm_Load(object sender, EventArgs e)
        {
            
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

        private void SearchButton_Click(object sender, EventArgs e)
        {
            
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            
        }
    }
}
