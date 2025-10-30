using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BATODA.Helpers.Database.Members;
using BATODA.Helpers.DataGrids;
using BATODA.Modules.Member_Module.Member_Classes;
using BATODA.Modules.MemberModule;
using BATODA.UI_Displays;

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
            DisplayClass.SetPlaceholder(SearchTxt, "Search Member");
            DisplayClass.SetPlaceholder(StatusCmb, "Status", "Active", "Inactive");
            DisplayClass.SetPlaceholder(MemberTypeCmb, "Member Type", "Operator", "Driver");
            DisplayClass.SetPlaceholder(OrderCmb, "Order By", "Ascending", "Descending");

            SetupGridColumns();
            LoadMembersToGrid();

            AddMemberPanel.Visible = false;
            AddMemberPanel.BringToFront();
        }

        private void SetupGridColumns()
        {
            string[] columnNames = { "BodyNumber", "LastName", "FirstName", "Birthdate", "MembershipType", "ContactNumber", "MemberStatus", "PenaltyLevel" };
            string[] columnHeaders = { "Body No.", "Last Name", "First Name", "Birthdate", "Membership Type", "Contact Number", "Status", "Penalty Details" };


            // Disabling built-in sort to avoid confusion and unintentional sorting
            // Array > Hardcoded
            for (int i = 0; i < columnNames.Length; i++)
            {
                MembersDataGrid.Columns.Add(columnNames[i], columnHeaders[i]);
                MembersDataGrid.Columns[columnNames[i]].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void LoadMembersToGrid()
        {
            MembersDataGrid.Rows.Clear();
            var members = MemberRepo.GetAllMembers();

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
                    m.Birthdate.ToString("MMMM d, yyyy"),
                    m.MembershipType,
                    m.ContactNumber,
                    m.MemberStatus,
                    penaltyDisplay
                );
            }

        }
        private MemberModel GetMemberFromForm()
        {
            return new MemberModel
            {
                FirstName = AddFirstNameTxt.Text.Trim(),
                LastName = AddLastNameTxt.Text.Trim(),
                MiddleInitial = AddMiddleNameTxt.Text.Trim(),
                Birthdate = BirthdatePicker.Value,
                PlateNumber = AddPlateNumberTxt.Text.Trim(),
                EngineNumber = AddEngineNumberTxt.Text.Trim(),
                ChassisNumber = AddChassisNumberTxt.Text.Trim(),
                ContactNumber = AddContactNumber.Text.Trim(),
                TricycleBrand = AddTricycleBrand.Text.Trim(),
                TricycleModel = AddModelTxt.Text.Trim(),
                MembershipType = AddMemberTypeCmb.Text.Trim(),
            };
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
            ToastManager.Info("Member Search");    // testing lang 
            GenerateNextBodyNumber.ShowNext(AddBodyNo);
            AddMemberPanel.Visible = true;
            AddMemberButton.Enabled = false;

            SearchBtn.Enabled = false;

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
                MemberModel NewMember = GetMemberFromForm();

                //if (!MemberValidator.ValidateMember(NewMember)) // STOP VALIDATION IF FALSE
                //{
                //    return;
                //}

                if (PreviewImagePb.Image != null && !string.IsNullOrEmpty(UploadImageDialog.FileName))
                {
                    string savedPath = SaveImageToFolder.Save(UploadImageDialog.FileName, NewMember.BodyNumber);
                    NewMember.ImagePath = savedPath; 
                }

            var MemberRepo = new MemberRepository();
                MemberRepo.AddMember(NewMember);
                ToastManager.Success("New Member Added Successfully!");

                LoadMembersToGrid();

                AddMemberPanel.Visible = false;
                AddMemberButton.Enabled = true;
                SearchBtn.Enabled = true;
        }


        private void CancelButton_Click(object sender, EventArgs e)
        {
            ToastManager.Warning("Adding New Member Cancelled");
            AddMemberPanel.Visible = false;
            AddMemberButton.Enabled = true;
            SearchBtn.Enabled = true;

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
            string SearchText = SearchTxt.Text.Trim();
            DataTable MemberTable = SearchMembers.Find(SearchText);
            //DBUG LANG
            MembersDataGrid.Rows.Clear();
            foreach (DataRow row in MemberTable.Rows)
            {
                MembersDataGrid.Rows.Add(
                    row["BodyNumber"].ToString().PadLeft(3, '0'),
                    row["LastName"].ToString(),
                    row["FirstName"].ToString(),
                    Convert.ToDateTime(row["Birthdate"]).ToShortDateString(),
                    row["MembershipType"].ToString(),
                    row["ContactNumber"].ToString(),
                    row["MemberStatus"].ToString(),
                    row["PenaltyLevel"].ToString()
                );
            }

            // Show “No Results” panel if table is empty
            if (MemberTable.Rows.Count == 0)
            {
                NoResultsPanel.BringToFront();
                NoResultsPanel.Visible = true;
            }
            else
            {
                NoResultsPanel.Visible = false;
            }
        }

        private void UploadButton_Click(object sender, EventArgs e)
        {
            UploadImageDialog.Title = "Select an Image";
            UploadImageDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (UploadImageDialog.ShowDialog() == DialogResult.OK)
            {
                PreviewImagePb.ImageLocation = UploadImageDialog.FileName;
                PreviewImagePb.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void panel16_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
