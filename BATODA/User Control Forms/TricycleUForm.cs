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
            try
            {
                string searchText = SearchTextBox.Text.Trim();
                if (string.IsNullOrWhiteSpace(searchText))
                {
                    ToastManager.Warning("Please enter a search term.");
                    return;
                }

                DataTable results = SearchTricycle.Find(searchText);
                if (results == null || results.Rows.Count == 0)
                {
                    ToastManager.Warning("No tricycles found matching the search.");
                    return;
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

                foreach (DataRow r in results.Rows)
                {
                    if (r == null) continue;

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

                if (table.Rows.Count == 0)
                {
                    ToastManager.Warning("No tricycles found after processing results.");
                    return;
                }

                LoadTricycleTable.LoadTricycleGridWithData(TricycleGrid, table);
                ToastManager.Success("Search completed successfully!");
            }
            catch (Exception ex)
            {
                ToastManager.Error("An error occurred during the search: " + ex.Message);
            }
        }


        private void ApplyearchButton_Click_1(object sender, EventArgs e)
        {
            try
            {
                string searchText = SearchTextBox.Text.Trim();
                if (string.IsNullOrWhiteSpace(searchText))
                {
                    ToastManager.Warning("Please enter a search term.");
                    return;
                }

                DataTable results = SearchTricycle.Find(searchText);
                if (results == null || results.Rows.Count == 0)
                {
                    ToastManager.Warning("No tricycles found matching the search.");
                    return;
                }

                if (!results.Columns.Contains("Availability"))
                    results.Columns.Add("Availability");

                foreach (DataRow row in results.Rows)
                {
                    if (row == null) continue;

                    if (!int.TryParse(row["BodyNumber"]?.ToString(), out int bodyNumber))
                    {
                        ToastManager.Warning("Invalid Body Number detected in results.");
                        continue;
                    }

                    row["Availability"] = new TricycleModel { BodyNumber = bodyNumber }.Availability;
                }

                if (results.Rows.Count == 0)
                {
                    ToastManager.Warning("No valid tricycles found after processing results.");
                    return;
                }

                DataGridColumns.LoadTricyclesToGrid(TricycleGrid, results);
                DataGridCustom.ApplyCustomGrid(TricycleGrid);
                DataGridCustom.AddEditButtonOnly(TricycleGrid);

                ToastManager.Success("Search completed successfully!");
            }
            catch (Exception ex)
            {
                ToastManager.Error("An error occurred during the search: " + ex.Message);
            }
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
            ToastManager.Info("Edit cancelled.");
        }

        private void SaveChangesButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (TricycleGrid.CurrentRow == null)
                {
                    ToastManager.Warning("No tricycle selected to update.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(BrandTxt.Text))
                {
                    ToastManager.Warning("Brand cannot be empty.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(ModelTxt.Text))
                {
                    ToastManager.Warning("Model cannot be empty.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(PlateTxt.Text))
                {
                    ToastManager.Warning("Plate number cannot be empty.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(EngineTxt.Text))
                {
                    ToastManager.Warning("Engine number cannot be empty.");
                    return;
                }

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
            catch (FormatException fex)
            {
                ToastManager.Error("Invalid number format: " + fex.Message);
            }
            catch (Exception ex)
            {
                ToastManager.Error("Error updating tricycle: " + ex.Message);
            }
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
            try
            {
                string searchText = SearchTextBox.Text.Trim();
                if (string.IsNullOrWhiteSpace(searchText))
                {
                    ToastManager.Warning("Please enter a search term.");
                    return;
                }

                List<TricycleModel> allTricycles = repo.GetAllTricycles();
                if (allTricycles == null || allTricycles.Count == 0)
                {
                    ToastManager.Warning("No tricycles available to search.");
                    return;
                }

                var filtered = allTricycles.Where(t =>
                    t.BodyNumber.ToString("D3").Contains(searchText) ||
                    (!string.IsNullOrEmpty(t.FirstName) && t.FirstName.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (!string.IsNullOrEmpty(t.LastName) && t.LastName.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (!string.IsNullOrEmpty(t.PlateNumber) && t.PlateNumber.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                ).ToList();

                if (filtered.Count == 0)
                {
                    ToastManager.Warning("No tricycles found matching the search.");
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

                if (table.Rows.Count > 0)
                    ToastManager.Success("Search completed successfully!");
            }
            catch (Exception ex)
            {
                ToastManager.Error("An error occurred during the search: " + ex.Message);
            }
        }


    }
}
