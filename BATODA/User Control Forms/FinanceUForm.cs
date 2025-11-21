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

          
            ViewReceiptPanel.Hide(); 
            ButawDataGrid.CellContentClick += ButawDataGrid_CellContentClick;

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
            LoadReceiptPanels();

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

        private void CloseReceipt_Click(object sender, EventArgs e)
        {
            ViewReceiptPanel.Hide();
        }

        public void LoadReceiptPanels()
        {
            MainRecieptFlowPanel.Controls.Clear();
            string[] months = new string[]
         {
        "Jan","Feb","Mar","Apr","May","Jun",
        "Jul","Aug","Sep","Oct","Nov","Dec"
          };

            MainRecieptFlowPanel.WrapContents = false;
            MainRecieptFlowPanel.FlowDirection = FlowDirection.TopDown;
            MainRecieptFlowPanel.AutoScroll = true;
            MainRecieptFlowPanel.Padding = new Padding(0);
            MainRecieptFlowPanel.Margin = new Padding(0);

           
            for (int i = 0; i < 12; i++)
            {
                MainRecieptFlowPanel.Controls.Add(CreateReceiptPanel(i, months[i]));
            }
        }
        //DITO EEDIT YUNG LAMAN <--ARONE 
        private Panel CreateReceiptPanel(int index, string monthName)
        {
            Panel box = new Panel();
            box.Height = 70;
            box.Width = MainRecieptFlowPanel.Width - 20;
            box.Margin = new Padding(0, 0, 0, 6);
            box.BackColor = Color.White;
            box.BorderStyle = BorderStyle.FixedSingle;

            Label lblMonth = new Label();
            lblMonth.Text = monthName;
            lblMonth.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            lblMonth.Location = new Point(10, 8);
            lblMonth.AutoSize = true;

          
            Label lblPaid = new Label();
            lblPaid.Text = "Paid +60";
            lblPaid.Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
            lblPaid.AutoSize = true;
            lblPaid.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPaid.Location = new Point(box.Width - lblPaid.Width - 15, 8);

        
            Label lblDate = new Label();
            lblDate.Text = "Date Paid: 00/00/00";
            lblDate.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
            lblDate.Location = new Point(10, 35);
            lblDate.AutoSize = true;

            box.Controls.Add(lblMonth);
            box.Controls.Add(lblPaid);
            box.Controls.Add(lblDate);

            
            box.Paint += (s, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, box.ClientRectangle,
                    Color.Red, ButtonBorderStyle.Solid);
            };

            return box;
        }

        private void ButawDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var column = ButawDataGrid.Columns[e.ColumnIndex];
            if (column.Name == "View")
            {
                ViewReceiptPanel.Show();
                ViewReceiptPanel.BringToFront();

                LoadReceiptPanels();
            }
        }
    }
}
