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
        }
        private void TransferVehicleUForm_Load(object sender, EventArgs e)
        {
            DisplayClass.SetPlaceholder(SearchTextBox, "Search Body Number");
            TransferPanel.Visible = false;
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
            TransferPanel.Visible = true;
            SearchButton.Enabled = false;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            TransferPanel.Visible = false;
            SearchButton.Enabled = true;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            TransferPanel.Visible = false;
            SearchButton.Enabled = true;
        }
    }
}
