using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BATODA.Helpers.Database.Tricycle;
using BATODA.Helpers.DataGrids;
using BATODA.Modules.Tricycle_Module.Tricycle_Classes;
using BATODA.UI_Displays;

namespace BATODA
{

    public partial class TricycleUForm : UserControl
    {
        private TricycleRepository repo = new TricycleRepository();

        public TricycleUForm()
        {
            InitializeComponent();
            EditTrycPanel.Hide();
        }

        private void LoadTricycleGrid()
        {
            DataGridCustom.ApplyCustomGrid(TricycleGrid);
            TricycleRepository repo = new TricycleRepository();
            List<TricycleModel> tricycles = repo.GetAllTricycles();


            DataTable table = new DataTable();
            table.Columns.Add("BodyNumber");
            table.Columns.Add("Last Name");
            table.Columns.Add("First Name");
            table.Columns.Add("Brand");
            table.Columns.Add("Model");
            table.Columns.Add("Plate No.");
            table.Columns.Add("Engine No.");
            table.Columns.Add("Chassis No.");
            table.Columns.Add("Availability");

            foreach (var t in tricycles)
            {
                table.Rows.Add(
                    t.BodyNumber.ToString("D3"),
                    t.LastName,
                    t.FirstName,
                    t.TricycleBrand,
                    t.TricModel,
                    t.PlateNumber,
                    t.EngineNumber,
                    t.ChassisNumber,
                    t.Availability
                );
            }

            TricycleGrid.DataSource = table;
            DataGridCustom.AddEditButtonOnly(TricycleGrid);

            foreach (DataGridViewColumn col in TricycleGrid.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void RegisteredVehicleUForm_Load(object sender, EventArgs e)
        {
            DisplayClass.SetPlaceholder(SearchTextBox, "Search Member");
            DisplayClass.SetPlaceholder(StatusComboBox, "Brand", "Sample 1", "Sample 1", "Sample 1", "Sample 1", "Sample 1");
            DisplayClass.SetPlaceholder(MemberTypeComboBox, "Member Type", "Operator", "Driver");
            DisplayClass.SetPlaceholder(OrderComboBox, "Order By", "Ascending", "Descending");
            TricycleRepository.UpdateStatusLabels(OperationalLbl, UnavailableLbl, SuspendedLbl, CodingLbl);
            LoadTricycleGrid();
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

        private void ClearButton_Click_1(object sender, EventArgs e)
        {
            DisplayClass.ClearInputs(this);
            ToastManager.Success("Filters Cleared Successfully!");
        }



        private void AapplyButtton_Click(object sender, EventArgs e)
        {
            ToastManager.Success("Filters Applied!");
        }

        private void ApplyearchButton_Click(object sender, EventArgs e)
        {
            string searchText = SearchTextBox.Text.Trim();
            DataTable results = SearchTricycle.Find(searchText);

            DataTable table = new DataTable();
            table.Columns.Add("BodyNumber");
            table.Columns.Add("LastName");
            table.Columns.Add("FirstName");
            table.Columns.Add("TricycleBrand");
            table.Columns.Add("Model");
            table.Columns.Add("PlateNumber");
            table.Columns.Add("EngineNumber");
            table.Columns.Add("ChassisNumber");

            foreach (DataRow r in results.Rows)
            {
                table.Rows.Add(
                    r["BodyNumber"],
                    r["LastName"],
                    r["FirstName"],
                    r["TricycleBrand"],
                    r["TricycleModel"],
                    r["PlateNumber"],
                    r["EngineNumber"],
                    r["ChassisNumber"]
                );
            }
            LoadTricycleTable.LoadTricycleGridWithData(TricycleGrid, table);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void ApplyearchButton_Click_1(object sender, EventArgs e)
        {
            string searchText = SearchTextBox.Text.Trim();

            DataTable results = SearchTricycle.Find(searchText);

            if (!results.Columns.Contains("Availability"))
                results.Columns.Add("Availability");

            foreach (DataRow row in results.Rows)
            {
                int bodyNumber = Convert.ToInt32(row["BodyNumber"]);
                row["Availability"] = new TricycleModel { BodyNumber = bodyNumber }.Availability;
            }

            // RELOAD
            DataGridColumns.LoadTricyclesToGrid(TricycleGrid, results);

            DataGridCustom.ApplyCustomGrid(TricycleGrid);
            DataGridCustom.AddEditButtonOnly(TricycleGrid);
        }

        private void TricycleGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0 || e.RowIndex == TricycleGrid.NewRowIndex) return;

            DataGridView dgv = sender as DataGridView;
            if (dgv == null) return;

            if (dgv.Columns[e.ColumnIndex].Name == "Edit")
            {
                EditTrycPanel.Show();
                int bodyNumber = Convert.ToInt32(TricycleGrid.Rows[e.RowIndex].Cells["BodyNumber"].Value);
                EditBodyNoLbl.Text = "BATODA " + "(" +bodyNumber.ToString("D3") +")"; 
                TricycleModel t = repo.GetTricycleDetails(bodyNumber);

                FullNameLbl.Text = $"{t.FirstName} {t.MiddleInitial} {t.LastName}";
                ContactLbl.Text = t.ContactNumber;
                MembershipLbl.Text = t.MembershipType;
                PlateTxt.Text = t.PlateNumber;
                BrandTxt.Text = t.TricycleBrand;
                ChassisTxt.Text = t.ChassisNumber;
                EngineTxt.Text = t.EngineNumber;
                ModelTxt.Text = t.TricModel;

            }
        }

        private void CancelEditButton_Click(object sender, EventArgs e)
        {
            EditTrycPanel.Hide();
        }

        private void SaveChangesButton_Click(object sender, EventArgs e)
        {
            if (TricycleGrid.CurrentRow == null) return;

            int bodyNumber = Convert.ToInt32(TricycleGrid.CurrentRow.Cells["BodyNumber"].Value);
            TricycleModel t = repo.GetTricycleDetails(bodyNumber);

            repo.TransferTricycle(
                bodyNumber,
                t.MembershipType,
                t.FirstName,
                t.MiddleInitial,
                t.LastName,
                BrandTxt.Text,
                ModelTxt.Text,
                PlateTxt.Text,
                ChassisTxt.Text,
                EngineTxt.Text
            );

            EditTrycPanel.Hide();
            LoadTricycleGrid();
            ToastManager.Success("Tricycle details updated successfully!");
        }


        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
