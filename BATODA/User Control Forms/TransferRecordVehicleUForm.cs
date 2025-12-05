using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BATODA.Helpers.DataGrids;
using BATODA.Modules.Tricycle_Module.Tricycle_Classes;

namespace BATODA
{
    public partial class TransferRecordVehicleUForm : UserControl
    {
        public TransferRecordVehicleUForm()
        {
            InitializeComponent();
            LoadTransferHistoryToGrid();
        }

        private void LoadTransferHistoryToGrid()
        {
            TricycleRepository repo = new TricycleRepository();
            DataTable history = repo.LoadTransferHistory();

            if (!history.Columns.Contains("BodyNumberDisplay"))
                history.Columns.Add("BodyNumberDisplay", typeof(string));

            foreach (DataRow row in history.Rows)
            {
                row["BodyNumberDisplay"] = Convert.ToInt32(row["BodyNumber"]).ToString("D3");
            }

            TransferTricHistoryGrid.DataSource = history;

            if (TransferTricHistoryGrid.Columns.Contains("BodyNumberDisplay"))
            {
                TransferTricHistoryGrid.Columns["BodyNumberDisplay"].HeaderText = "Body No.";
                TransferTricHistoryGrid.Columns["BodyNumberDisplay"].DisplayIndex = 0;
            }

            DataGridColumns.LoadTransferHistoryToGrid(TransferTricHistoryGrid, history);
            DataGridCustom.ApplyCustomGrid(TransferTricHistoryGrid);
        }



        private void TransferRecordVehicleUForm_Load(object sender, EventArgs e)
        {
            
        }

        private void RegisteredVehicleButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new TricycleUForm());
        }

        private void TransferVehicleButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new TransferVehicleUForm());
        }

        private void TransferRecordButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new TransferRecordVehicleUForm());
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
