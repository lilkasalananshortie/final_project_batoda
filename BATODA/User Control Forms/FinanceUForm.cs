using BATODA.Helpers.Data;
using BATODA.Helpers.DataGrid;
using BATODA.Helpers.DataGrids;
using BATODA.UI_Displays;
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
    public partial class FinanceUForm : UserControl
    {
        public int selectedYear = 2025;
        public FinanceUForm()
        {
            InitializeComponent();
            TaxHandler.Initialize(ButawDataGrid);

            TaxHandler.LoadMemberPayments(ButawDataGrid, selectedYear);

            DisplayClass.SetPlaceholder(SearchTextBox, "Search Member");
            DisplayClass.SetPlaceholder(PaymentStatusComboBox, "Status", "Paid", "Unpaid", "Overdue");
            DisplayClass.SetPlaceholder(YearComboBox, "Year", "2025", "2024");
            DisplayClass.SetPlaceholder(SortComboBox, "Sort By", "Body Number", "Name");

            TaxHandler.SetViewPanel(ViewPanel);
        }

        private void YearComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(YearComboBox.Text, out int year))
            {
                TaxHandler.LoadMemberPayments(ButawDataGrid, year);
            }
        }

        private void LoadMassSelectGrid()
        {
            MassSelectGrid.Rows.Clear();
            MassSelectGrid.Columns.Clear();

            DataGridCustom.FinanceMultiSelectCustomGrid(MassSelectGrid);

            var repo = new TaxRepository();
            var members = repo.GetAllMembers();

            foreach (var member in members)
            {
                MassSelectGrid.Rows.Add(member.BodyNumber.ToString("D3"), member.FullName);
            }
        }



        private void LoadYears()
        {
            MultiYear.Items.Clear();
            int startYear = 2023;
            int currentYear = DateTime.Today.Year;

            for (int y = startYear; y <= currentYear; y++)
            {
                MultiYear.Items.Add(y);
            }

            MultiYear.SelectedItem = currentYear;
        }



        private void FinanceUForm_Load(object sender, EventArgs e)
        {
            LoadYears();
            LoadMassSelectGrid();
            ViewPanel.Hide();
            RenewSelectedPanelHolder.Hide();
            MassChangeSelectionPanel.Hide();
        }

        private void FinanceButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new FinanceUForm());
        }

        private void btnPaid_Click(object sender, EventArgs e)
        {
            TaxHandler.SetMode("Paid");
        }
        private void btnOverdue_Click(object sender, EventArgs e)
        {
            TaxHandler.SetMode("Overdue");
        }
        private void btnDue_Click(object sender, EventArgs e)
        {
            TaxHandler.SetMode("Due");
        }




        private void MembershipRenewalButton_Click_1(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new MembershipRenewalUForm());
        }


        private void RenewalHistoryButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new ButawUForm());
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void PaymentStatusComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ClearButton_Click_1(object sender, EventArgs e)
        {
            DisplayClass.ClearInputs(this);
            ToastManager.Success("Filters Cleared Successfully!");
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            ToastManager.Success("Filters Applied!");

        }

        private void ApplySearchButton_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void ViewPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            ViewPanel.Hide();
        }

        private void MassChangeButton_Click(object sender, EventArgs e)
        {
            MassChangeSelectionPanel.Show();
        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CurrentFirstNameLbl_Click(object sender, EventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MassSelectGrid_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void SaveMassChangeButton_Click(object sender, EventArgs e)
        {
            //CHECK IF MONTH AND ACTION ARE SELECTED
            if (MultiMonth.SelectedIndex < 0 || MultiAction.SelectedIndex < 0)
            {
                MessageBox.Show("Please select Month and Action first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MultiPreviewGrid.Rows.Clear();
            MultiPreviewGrid.Columns.Clear();
            MultiPreviewGrid.ReadOnly = true;
            MultiPreviewGrid.Enabled = false;
            MultiPreviewGrid.RowHeadersVisible = false;
            MultiPreviewGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            MultiCancel.Show();
            MultiCancel.BringToFront();
            MultiClose.Hide();

            MultiAction.Hide();
            MultiYear.Hide();
            MultiMonth.Hide();
            AssignmentLbl.Hide();

            DataGridCustom.FinanceMultiSelectCustomGrid(MultiPreviewGrid);

            foreach (DataGridViewRow row in MassSelectGrid.SelectedRows)
            {
                MultiPreviewGrid.Rows.Add(
                    row.Cells["BodyNo"].Value,
                    row.Cells["FullName"].Value
                );
            }

            MultiPreviewGrid.ClearSelection();
            MultiPreviewGrid.CurrentCell = null;
            MultiPreviewGrid.Show();
            MultiPreviewGrid.BringToFront();
            MassSelectGrid.SendToBack();
            ConfirmSave.Show();
            ConfirmSave.BringToFront();
        }




        private void CancelMassChangeButton_Click(object sender, EventArgs e)
        {
            MassSelectGrid.BringToFront();
            MultiPreviewGrid.SendToBack();
            MultiPreviewGrid.Hide();
            ConfirmSave.Hide();
            ConfirmSave.SendToBack();
            MultiCancel.Hide();
            MultiClose.Show();

            MultiAction.Show();
            MultiYear.Show();
            MultiMonth.Show();
            AssignmentLbl.Show();
        }

        private void ConfirmSave_Click(object sender, EventArgs e)
        {
            //CHECK IF ALL COMBOS ARE SELECTED
            if (MultiMonth.SelectedIndex < 0 || MultiYear.SelectedIndex < 0 || MultiAction.SelectedIndex < 0)
            {
                MessageBox.Show("Please select Month, Year, and Action first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //GET MONTH, YEAR, AND ACTION
            int month = MultiMonth.SelectedIndex + 1;
            int year = int.Parse(MultiYear.SelectedItem.ToString());
            string action = MultiAction.SelectedItem.ToString();

            var repo = new TaxRepository();

            //LOOP THROUGH SELECTED MEMBERS
            foreach (DataGridViewRow row in MassSelectGrid.SelectedRows)
            {
                int bodyNumber = int.Parse(row.Cells["BodyNo"].Value.ToString());

                //UPDATE OR INSERT PAYMENT IN DB
                TaxRepository.UpdatePaymentInDB(bodyNumber, year, month, action);
            }

            //SHOW SUCCESS AND RELOAD GRID
            MessageBox.Show("Selected members updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadMassSelectGrid();

            TaxHandler.LoadMemberPayments(ButawDataGrid, selectedYear);
            MassChangeSelectionPanel.Hide();
        }

        private void MultiClose_Click(object sender, EventArgs e)
        {
            MassChangeSelectionPanel.Hide();
        }
    }
}
