using BATODA.Helpers.Database.Tricycle;
using BATODA.Helpers.DataGrids;
using BATODA.Modules.Dashboard_Module.Dashboard_Classes;
using BATODA.Modules.Tricycle_Module.Tricycle_Classes;
using BATODA.UI_Displays;
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
            table.Columns.Add("LastName");
            table.Columns.Add("FirstName");
            table.Columns.Add("TricycleBrand");
            table.Columns.Add("TricModel");
            table.Columns.Add("PlateNumber");
            table.Columns.Add("EngineNumber");
            table.Columns.Add("ChassisNumber");
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

            TricycleGrid.Columns["BodyNumber"].HeaderText = "Body No."; 
            TricycleGrid.Columns["LastName"].HeaderText = "Surname"; 
            TricycleGrid.Columns["FirstName"].HeaderText = "First Name"; 
            TricycleGrid.Columns["TricycleBrand"].HeaderText = "Brand"; 
            TricycleGrid.Columns["TricModel"].HeaderText = "Model"; 
            TricycleGrid.Columns["PlateNumber"].HeaderText = "Plate No."; 
            TricycleGrid.Columns["EngineNumber"].HeaderText = "Engine No."; 
            TricycleGrid.Columns["ChassisNumber"].HeaderText = "Chassis No."; 
            TricycleGrid.Columns["Availability"].HeaderText = "Availability";

            foreach (DataGridViewColumn col in TricycleGrid.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void RegisteredVehicleUForm_Load(object sender, EventArgs e)
        {
            DisplayClass.SetPlaceholder(SearchTextBox, "Search Member");
            DisplayClass.SetPlaceholder(StatusCmb, "Brand", "Operational", "Unavailable");
            DisplayClass.SetPlaceholder(OrderCmb, "Order By", "Ascending", "Descending");
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
            List<TricycleModel> tricycles = repo.GetAllTricycles();

            string status = StatusCmb.Text.Trim();
            if (!string.IsNullOrEmpty(status) && (status == "Operational" || status == "Unavailable"))
            {
                tricycles = tricycles.Where(t => t.Availability.Equals(status, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            string order = OrderCmb.Text.Trim();
            if (!string.IsNullOrEmpty(order))
            {
                tricycles = order == "Ascending"
                    ? tricycles.OrderBy(t => t.BodyNumber).ToList()
                    : tricycles.OrderByDescending(t => t.BodyNumber).ToList();
            }

            DataTable table = new DataTable();
            table.Columns.Add("BodyNumber");
            table.Columns.Add("LastName");
            table.Columns.Add("FirstName");
            table.Columns.Add("TricycleBrand");
            table.Columns.Add("TricModel");
            table.Columns.Add("PlateNumber");
            table.Columns.Add("EngineNumber");
            table.Columns.Add("ChassisNumber");
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

            DataGridColumns.LoadTricyclesToGrid(TricycleGrid, table);
            DataGridCustom.ApplyCustomGrid(TricycleGrid);
            DataGridCustom.AddEditButtonOnly(TricycleGrid);

            NoResultsPanel.Visible = table.Rows.Count == 0;
            if (NoResultsPanel.Visible) NoResultsPanel.BringToFront();

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
            table.Columns.Add("TricModel");
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

            var logRepo = new SystemActivityLogRepository();
            logRepo.LogEditVehicle(bodyNumber);

            EditTrycPanel.Hide();
            LoadTricycleGrid();
            ToastManager.Success("Tricycle details updated successfully!");
        }

        private void SearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                PerformSearch();
            }
        }

        private void PerformSearch()
        {
            string searchText = SearchTextBox.Text.Trim();
            if (string.IsNullOrEmpty(searchText))
            {
                MessageBox.Show("Search input cannot be empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<TricycleModel> allTricycles = repo.GetAllTricycles();

            var filtered = allTricycles.Where(t =>
                t.BodyNumber.ToString("D3").Contains(searchText) ||
                t.FirstName.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                t.LastName.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                t.PlateNumber.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0
            ).ToList();
            
            DataTable table = new DataTable();
            table.Columns.Add("BodyNumber");
            table.Columns.Add("LastName");
            table.Columns.Add("FirstName");
            table.Columns.Add("TricycleBrand");
            table.Columns.Add("TricModel");
            table.Columns.Add("PlateNumber");
            table.Columns.Add("EngineNumber");
            table.Columns.Add("ChassisNumber");
            table.Columns.Add("Availability");

            foreach (var t in filtered)
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

            DataGridColumns.LoadTricyclesToGrid(TricycleGrid, table);

            DataGridCustom.ApplyCustomGrid(TricycleGrid);
            DataGridCustom.AddEditButtonOnly(TricycleGrid);

            NoResultsPanel.Visible = table.Rows.Count == 0;
            if (NoResultsPanel.Visible) NoResultsPanel.BringToFront();

        }

    }
}
