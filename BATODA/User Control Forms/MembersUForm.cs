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
using BATODA.Modules.MemberModule;
using BATODA.UI_Displays;
using BATODA.Helpers.Database.Members;

namespace BATODA
{
    public partial class MembersUForm : UserControl
    {
        MemberRepository MemberRepo = new MemberRepository();

        public MembersUForm()
        {
            InitializeComponent();

            DataGridHelper.ApplyCustomGrid(MembersDataGrid);

            TotalMembersLbl.Text = TotalMembers.GetCount().ToString();
        }

        private void MembersUForm_Load(object sender, EventArgs e)
        {
            DisplayClass.SetPlaceholder(SearchTextBox, "Search Member");
            DisplayClass.SetPlaceholder(StatusComboBox, "Status", "Active", "Inactive");
            DisplayClass.SetPlaceholder(MemberTypeComboBox, "Member Type", "Operator", "Driver");
            DisplayClass.SetPlaceholder(OrderComboBox, "Order By", "Ascending", "Descending");
            DisplayClass.SetPlaceholder(AddBodyNumberTxt, "Enter Body Number");
            DisplayClass.SetPlaceholder(AddContactNumber, "Enter Cellphone Number");
            DisplayClass.SetPlaceholder(AddTricycleBrand, "Enter Unit Brand");
            DisplayClass.SetPlaceholder(AddFirstNameTxt, "Enter First Name");
            DisplayClass.SetPlaceholder(AddLastNameTxt, "Enter Last Name");
            DisplayClass.SetPlaceholder(AddMiddleNameTxt, "Enter Middle Name");
            DisplayClass.SetPlaceholder(AddPlateNumberTxt, "Enter Plate Number");
            DisplayClass.SetPlaceholder(AddMemberTypeCmb, "Member Type", "Operator", "Driver");
            DisplayClass.SetPlaceholder(AddModelTxt, "Enter Model Type");
            DisplayClass.SetPlaceholder(AddEngineNumberTxt, "Enter Engine Number");
            DisplayClass.SetPlaceholder(AddChassisNumber, "Enter Chassis Number");

            LoadMembersToGrid();

            AddMemberPanel.Visible = false;
            AddMemberPanel.BringToFront();
        }

        private void LoadMembersToGrid()
        {
            string[] columnNames = { "BodyNumber", "LastName", "FirstName", "MiddleName", "Birthdate", "MembershipType", "ContactNumber", "MemberStatus", "PenaltyLevel" };
            string[] columnHeaders = { "Body Number", "Last Name", "First Name", "Middle Name", "Birthdate", "Membership Type", "Contact Number", "Status", "Penalty Details" };

            // Disabling built-in sort to avoid confusion and unintentional sorting
            // Array > Hardcoded
            for (int i = 0; i < columnNames.Length; i++)
            {
                MembersDataGrid.Columns.Add(columnNames[i], columnHeaders[i]);
                MembersDataGrid.Columns[columnNames[i]].SortMode = DataGridViewColumnSortMode.NotSortable;
            }


            var members = MemberRepo.GetAllMembers();
            MembersDataGrid.Rows.Clear();

            foreach (var m in members)
            {
                string penaltyDisplay;

                if (m.PenaltyLevel == 0)
                {
                    penaltyDisplay = "None";
                }
                else if (m.PenaltyLevel == 1)
                {
                    penaltyDisplay = "First Warning";
                }
                else if (m.PenaltyLevel == 2)
                {
                    penaltyDisplay = "Final Warning";
                }
                else if (m.PenaltyLevel == 3)
                {
                    penaltyDisplay = $"Remaining {m.SuspensionDaysRemaining} days of Suspension";
                }
                else
                {
                    penaltyDisplay = "Unknown";
                }

                string bodyNumFormatted = m.BodyNumber.ToString("D3"); // formats 1 -> 001

                MembersDataGrid.Rows.Add(
                    bodyNumFormatted,
                    m.LastName,
                    m.FirstName,
                    m.MiddleInitial,
                    m.Birthdate.ToString("MMMM d, yyyy"),
                    m.MembershipType,
                    m.ContactNumber,
                    m.MemberStatus,
                    penaltyDisplay
                );
            }

        }

        private void TransferRecordsButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new TransferRecordMemberUForm());
        }

        private void TransferMembershipButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new TransferMembershipUForm());
        }



        private void StatusComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MemberTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void OrderComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {

        }

       

       
        private void ManageMembersButton_Click(object sender, EventArgs e)
        {

        }

        private void AddMemberButton_Click(object sender, EventArgs e)
        {
            ToastManager.Info("Member Searchd");    // testing lang 
            AddMemberPanel.Visible = true;
            AddMemberButton.Enabled = false;
            
            ApplySearchButton.Enabled = false;
            
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            ToastManager.Success("New Member Added Successfully!");
            AddMemberPanel.Visible = false;
            AddMemberButton.Enabled = true;
            ApplySearchButton.Enabled = true;
            
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            ToastManager.Warning("Adding New Member Cancelled");
            AddMemberPanel.Visible = false;
            AddMemberButton.Enabled = true;
            ApplySearchButton.Enabled = true;
            
        }

        private void AddMemberPanel_Paint(object sender, PaintEventArgs e)
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

        private void UploadButton_Click(object sender, EventArgs e)
        {

        }
    }
}
