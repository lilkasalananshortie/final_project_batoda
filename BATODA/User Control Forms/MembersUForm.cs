using BATODA.Helpers.Data;
using BATODA.Helpers.Database.Members;
using BATODA.Helpers.DataGrids;
using BATODA.Modules.Assistance_Request_Module.Renewal_Classes;
using BATODA.Modules.Member_Module.Member_Classes;
using BATODA.Modules.MemberModule;
using BATODA.UI_Displays;
using BATODA.User_Control_Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BATODA
{
    public partial class MembersUForm : UserControl
    {
        MemberRepository MemberRepo = new MemberRepository();


        public MembersUForm()
        {
            InitializeComponent();

            TotalMembersLbl.Text = TotalMembers.GetCount().ToString();
            TotalActiveLbl.Text = MemberInfoSummary.GetActiveCount().ToString();
            TotalInactiveLbl.Text = MemberInfoSummary.GetInactiveCount().ToString();
            TotalSuspendedLbl.Text = MemberInfoSummary.GetSuspendedCount().ToString();
            
           
        }


        private void MembersUForm_Load(object sender, EventArgs e)
        {
            var repo = new TaxRepository();

            DisplayClass.SetPlaceholder(SearchTxt, "Search Member");
            DisplayClass.SetPlaceholder(SortStatusCmb, "Status", "Active", "Inactive");
            DisplayClass.SetPlaceholder(SortMembertTypeCmb, "Member Type", "Operator", "Driver");
            DisplayClass.SetPlaceholder(SortOrderCmb, "Order By", "Ascending", "Descending");
            DataGridCustom.ApplyCustomGrid(MembersDataGrid);

            MembersDataGrid.AutoGenerateColumns = false;
            repo.UpdateAllTaxBalances();
            SetupGridColumns();
            LoadMembersToGrid();

            DataGridCustom.ApplyCustomGrid(MembersDataGrid);
            DataGridCustom.AddActionButtons(MembersDataGrid);


            AddMemberPanel.Visible = false;
            AddMemberPanel.BringToFront();
            ViewMemberInfoPanel.Visible = false;
        }

        private void SetupGridColumns()
        {
            string[] columnNames = { "BodyNumber", "LastName", "FirstName", "Birthdate", "MembershipType", "ContactNumber", "MemberStatus", "PenaltyLevel" };
            string[] columnHeaders = { "Body No.", "Surname", "First Name", "Birthdate", "Role", "Contact Number", "Status", "Penalty Details" };


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
            MemberRepo.UpdateSuspensionHours();
            MembersDataGrid.Rows.Clear();
            var members = MemberRepo.GetAllMembers();

            foreach (var m in members)
            {
                string penaltyDisplay;

                if (m.PenaltyLevel == 0)
                {
                    penaltyDisplay = "";
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
                    penaltyDisplay = $"Remaining {m.SuspensionDays} Hours of Suspension";
                }
                else
                {
                    penaltyDisplay = "Unknown";
                }

                string bodyNumFormatted = m.BodyNumber.ToString("D3");

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



       
        private void AddMemberButton_Click(object sender, EventArgs e)
        {
            ToastManager.Info("Member Search");    // testing lang 
            LoadBodyNumber.ShowNext(AddBodyNo);
            AddMemberPanel.Visible = true;
            AddMemberButton.Enabled = false;

            SearchBtn.Enabled = false;

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            int nextBodyNumber = LoadBodyNumber.GetNextNumber(); 

            MemberModel NewMember = GetMemberFromForm();
            NewMember.BodyNumber = nextBodyNumber;

            if (PreviewImagePb.Image != null && !string.IsNullOrEmpty(UploadImageDialog.FileName))
            {
                string savedPath = SaveImageToFolder.TransferMembershipSave(UploadImageDialog.FileName, nextBodyNumber);
                NewMember.ImagePath = savedPath;
            }

            var MemberRepo = new MemberRepository();
            MemberRepo.AddMember(NewMember);

            var renewalRepo = new RenewalRepository();
            renewalRepo.AddRenewal(NewMember.BodyNumber);

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

        private void ClearButton_Click_1(object sender, EventArgs e)
        {
            DisplayClass.ClearInputs(this);
            ToastManager.Success("Filters Cleared Successfully!");
        }



        private void ApplyButton_Click(object sender, EventArgs e)
        {
            string memberType = SortMembertTypeCmb.SelectedItem?.ToString();
            string order = SortOrderCmb.SelectedItem?.ToString();
            string status = SortStatusCmb.SelectedItem?.ToString();

            DataTable dataTable = MemberSort.ApplyFilter(memberType, order, status);
            MembersDataGrid.Rows.Clear();

            DataGridColumns.LoadMembersToGrid(MembersDataGrid, dataTable);

            ToastManager.Success("Filters Applied!");
        }

        private void ApplySearchButton_Click(object sender, EventArgs e)
        {
            string SearchText = SearchTxt.Text.Trim();

            if (string.IsNullOrEmpty(SearchText))
            {
                MessageBox.Show("Search input cannot be empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable MemberTable = SearchMembers.Find(SearchText);

            DataGridColumns.LoadMembersToGrid(MembersDataGrid, MemberTable);

            foreach (DataGridViewRow row in MembersDataGrid.Rows)
            {
                if (row.IsNewRow) continue;

                int level = 0;
                int.TryParse(row.Cells["PenaltyLevel"].Value?.ToString(), out level);

                string text =
                    level == 1 ? "First Warning" :
                    level == 2 ? "Final Warning" :
                    level == 3 ? $"Remaining {row.Cells["SuspensionDays"].Value} Hours of Suspension" :
                    "";

                row.Cells["PenaltyLevel"].Value = text;
            }

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

        private void MembersDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex == MembersDataGrid.NewRowIndex) return;

            DataGridView dgv = sender as DataGridView;
            if (dgv == null) return;

            if (dgv.Columns[e.ColumnIndex].Name == "Edit")
            {
                int bodyNumber = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["BodyNumber"].Value);
                SelectedMemberImage.BodyNumber = bodyNumber;

                string imagesFolder = Path.Combine(Application.StartupPath, "..\\..\\Modules\\Member Module\\Member Images");
                string[] matchingImages = Directory.GetFiles(imagesFolder, $"{bodyNumber:D3}*.*");
                if (matchingImages.Length > 0)
                    SelectedMemberImage.ImagePath = matchingImages[0];
                else
                    SelectedMemberImage.ImagePath = "";

                DisplayClass.CloseMiniAndMain();
                DisplayClass.ShowMini(new MembersEditPanel());
            }

            else if (dgv.Columns[e.ColumnIndex].Name == "Delete")
            {
                int bodyNumber = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["BodyNumber"].Value);

                var confirm = MessageBox.Show(
                    "Are you sure you want to delete this member?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirm == DialogResult.Yes)
                {
                    MemberRepository repo = new MemberRepository();
                    repo.DeleteMember(bodyNumber);

                    LoadMembersToGrid();
                }
            }
        }

        private void MembersDataGrid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;

            ViewMemberInfoPanel.Visible = true;
            ViewMemberInfoPanel.BringToFront();

            try
            {
                int bodyNumber = Convert.ToInt32(MembersDataGrid.Rows[e.RowIndex].Cells["BodyNumber"].Value);

                LoadMemberOverview(bodyNumber);

                string imagesFolder = Path.Combine(Application.StartupPath, "..\\..\\Modules\\Member Module\\Member Images");
                string[] matchingImages = Directory.GetFiles(imagesFolder, $"{bodyNumber:D3}*.*");

                if (EditImagePb.Image != null)
                {
                    EditImagePb.Image.Dispose();
                    EditImagePb.Image = null;
                }

                if (matchingImages.Length > 0)
                {
                    using (var temp = new Bitmap(matchingImages[0]))
                    {
                        EditImagePb.Image = new Bitmap(temp);
                    }
                    SelectedMemberImage.ImagePath = matchingImages[0];
                }
                else
                {
                    EditImagePb.Image = null;
                    SelectedMemberImage.ImagePath = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading member: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CloseBtn_Click(object sender, EventArgs e)
        {
            ViewMemberInfoPanel.Visible = false;
        }

        private void GoToEditPanel_Click(object sender, EventArgs e)
        {
            // CHECK IF RETRIEVED YUNG DATA
            if (!string.IsNullOrEmpty(SelectedMemberImage.ImagePath))
            {
                DisplayClass.CloseMiniAndMain();
                DisplayClass.ShowMini(new MembersEditPanel());
            }
            else
            {
                MessageBox.Show("No member selected to edit.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SearchTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                if (string.IsNullOrWhiteSpace(SearchTxt.Text))
                {
                    MessageBox.Show("Search input cannot be empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ApplySearchButton_Click(sender, e);
            }
        }


        private void LoadMemberOverview(int bodyNumber)
        {
            var repo = new MemberRepository();
            var member = repo.MemberOverview(bodyNumber); 

            if (member != null)
            {
                BodyNumLbl.Text = "BATODA - " + "(" + member.BodyNumber.ToString("D3") + ")";
                CurrentNameLbl.Text = $"{member.FirstName} {member.MiddleInitial}. {member.LastName}";
                CurrentBirthdayLbl.Text = member.Birthdate.ToString("MM-dd-yyyy");
                CurrentContactLbl.Text = member.ContactNumber;
                CurrentMemberTypeLbl.Text = member.MembershipType;
                CurrentBrandLbl.Text = member.TricycleBrand;
                CurrentModelLbl.Text = member.TricycleModel;
                CurrentChassisLbl.Text = member.ChassisNumber;
                CurrentEngineLbl.Text = member.EngineNumber;
                CurrentPlateLbl.Text = member.PlateNumber;

                AddPenaltyBtn.Text = member.PenaltyLevel == 3 ? "Suspend" : "Add Penalty";
            }
        }

        private void ViewMemberInfoPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AddPenaltyBtn_Click(object sender, EventArgs e)
        {
            if (MembersDataGrid.SelectedRows.Count == 0) return;

            int bodyNumber = Convert.ToInt32(MembersDataGrid.SelectedRows[0].Cells["BodyNumber"].Value);
            var repo = new MemberRepository();
            var member = repo.MemberOverview(bodyNumber);

            if (member == null) return;

            var confirm = MessageBox.Show(
                $"Are you sure you want to add a penalty to {member.FirstName} {member.MiddleInitial}. {member.LastName}?",
                "Confirm Penalty",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {

                var latestMember = repo.MemberOverview(bodyNumber);

                if (latestMember.PenaltyLevel == 3)
                {
                    MessageBox.Show(
                        $"{latestMember.FirstName} {latestMember.MiddleInitial}. {latestMember.LastName} is already under suspension (24 hours).",
                        "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                repo.IncrementPenaltyLevel(bodyNumber);
                MessageBox.Show("Penalty added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                repo.UpdateSuspensionHours();

                LoadMemberOverview(bodyNumber);
                LoadMembersToGrid();
            }
        }




        private void label17_Click(object sender, EventArgs e)
        {

        }
    }
}
