using BATODA.Helpers.Database.Members;
using BATODA.Helpers.DataGrid;
using BATODA.Helpers.DataGrids;
using BATODA.Modules; 
using BATODA.Modules.Assistance_Request_Module;
using BATODA.Modules.Assistance_Request_Module.Assistance_Classes;
using BATODA.Modules.Dashboard_Module.Dashboard_Classes;
using BATODA.Modules.MemberModule;
using BATODA.User_Control_Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BATODA.Modules.Assistance_Request_Module.AssistanceRepository;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace BATODA
{
    public partial class AssistanceRequestUForm : UserControl
    {
        private AddTicketBox ticketHelper;

        public AssistanceRequestUForm()
        {
            InitializeComponent();

            ticketHelper = new AddTicketBox(TicketFlowLayoutPanel, FLPActivityLog);


            FillUpFormPanel.Hide();
            ConfirmationPanel.Hide();

            TextStatusPanel.Show();
            TextStatusPanel.BringToFront();

            ticketHelper.LoadActivityLogs();
        }

        public void UpdateRequestCounts()
        {
            TotalReqLbl.Text = AssistanceSummary.GetTotalTickets().ToString();
            TotalPending.Text = AssistanceSummary.GetPendingTickets().ToString();
            TotalReleased.Text = AssistanceSummary.GetApprovedTickets().ToString();
            RejectedLbl.Text = AssistanceSummary.GetRejectedTickets().ToString();
        }


        private void AssistanceRequestUForm_Load(object sender, EventArgs e)
        {
            LoadAllTickets();
            DisplayClass.SetPlaceholder(SearchTextBox, "Search Member");
            UpdateRequestCounts(); 
        }

        public void LoadAllTickets(string statusFilter = null)
        {
            TicketFlowLayoutPanel.Controls.Clear();
            AssistanceRepository repo = new AssistanceRepository();
            List<TicketModel> tickets = repo.GetAllRequests();

            string search = SearchTextBox.Text.Trim().ToLower();

            var filtered = tickets
                .Where(t =>
                    t.IsActive == 1 &&
                    (string.IsNullOrEmpty(statusFilter) || t.RequestStatus == statusFilter) &&
                    (string.IsNullOrEmpty(search) ||
                     t.BodyNumber.ToString().Contains(search) ||
                     t.FullName.ToLower().Contains(search) ||
                     ("TR-" + t.TicketID).ToLower().Contains(search)))
                .ToList();

            foreach (TicketModel ticket in filtered)
            {
                Image memberImage = null;
                string imagesFolder = Path.Combine(Application.StartupPath, "..\\..\\Modules\\Member Module\\Member Images");
                string[] matchingImages = Directory.GetFiles(imagesFolder, $"{ticket.BodyNumber:D3}*.*");

                if (matchingImages.Length > 0)
                {
                    using (var temp = new Bitmap(matchingImages[0]))
                    {
                        memberImage = new Bitmap(temp);
                    }
                }

                ticketHelper.CreateTicketBox(
                    trackingNumber: "TR-" + ticket.TicketID,
                    fullName: ticket.FullName,
                    typeOfAid: ticket.TypeOfAid,
                    dateRequested: ticket.DateRequested.ToString("MM-dd-yyyy hh:mm tt"),
                    status: ticket.RequestStatus,
                    requestedBy: ticket.RequestedBy,
                    amount: "₱" + ticket.RequestedAmount.ToString("N2"),
                    assistanceThru: ticket.AssistanceThru,
                    contactNum: ticket.ContactNumber,
                    dateNeeded: ticket.TargetDate.ToString("MM-dd-yyyy"),
                    memberImag: memberImage
                );
            }
        }


        private void TransferToDisplayPanel()
        {
            ConfNameLbl.Text = ReqFirstNameTxt.Text + " " + ReqLastNameTxt.Text;
            ConfTypeOfAid.Text = ReqAssistanceThruCmb.Text;
            ConfDateCreatedLbl.Text = DateCreatedLbl.Text;
            ConfTicketIdLbl.Text = TicketIdlbl.Text;
            ConfDateNeededLbl.Text = DateNeededPicker.Text;
            ConfBodyNumLbl.Text = ReqBodyNoLbl.Text;
            ConfMopLbl.Text = ReqAssistanceThruCmb.Text;
            ConfReqByLbl.Text = RequestByCmb.Text;
            ConfContactLbl.Text = ReqContactLbl.Text;
            ConfAmountLbl.Text = ReqAmountTxt.Text;

            if (ReqAssistanceThruCmb.Text == "GCASH")
            {
                ConfGcashNoLbl.Text = ReqGcashNumTxt.Text;
            }
            else
            {
                ConfGcashNoLbl.Text = "XXXXXXXXXXX";
            }

            ConfPreviewImage.Image = MemberImagePb.Image;
        }


        private void AssistanceHomeButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new AssistanceLogUForm());
        }

        private void AssistanceRequestButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new AssistanceRequestUForm());
        }

        private void ARHButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new ARHUForm());
        }


        private void TicketConfirmButton_Click(object sender, EventArgs e)
        {
            AssistanceModel data = new AssistanceModel
            {
                FullName = ConfNameLbl.Text,
                BodyNumber = int.Parse(ReqBodyNoLbl.Text),
                ContactNumber = ReqContactLbl.Text,
                TypeOfAid = TypeOfAidCmb.Text,
                RequestedBy = RequestByCmb.Text,
                RequestedAmount = decimal.Parse(ReqAmountTxt.Text),
                AssistanceThru = ReqAssistanceThruCmb.Text,
                GcashNumber = ReqGcashNumTxt.Text,
                DateRequested = DateTime.Parse(DateCreatedLbl.Text),
                TargetDate = DateTime.Parse(DateNeededPicker.Text)
            };


            GmailSender GmailSend = new GmailSender();
            GmailSend.SendAssistanceEmail(
                recipientEmail: "manalilimhak@gmail.com",
                fullName: data.FullName,
                bodyNumber: data.BodyNumber.ToString("D3"),
                typeOfAid: data.TypeOfAid,
                requestedBy: data.RequestedBy,
                amount: "₱" + data.RequestedAmount.ToString("N2"),
                assistanceThru: data.AssistanceThru,
                gcashNumber: data.GcashNumber,
                dateRequested: data.DateRequested.ToString("MM-dd-yyyy hh:mm tt"),
                targetDate: data.TargetDate.ToString("MM-dd-yyyy"),
                status: "Pending",
                proofFilePath: ReqFileTxt.Text
            );

            AssistanceRepository repo = new AssistanceRepository();
            repo.AddRequest(data);

            int ticketID = Ticket.GetNextTicketID() - 1;

            var logRepo = new SystemActivityLogRepository();
            logRepo.LogNewAssistanceTicket(ticketID);

            List<TicketModel> tickets = repo.GetAllRequests();
            TicketFlowLayoutPanel.Controls.Clear();

            foreach (TicketModel ticket in tickets)
            {
                Image memberImage = null;
                string imagesFolder = Path.Combine(Application.StartupPath, "..\\..\\Modules\\Member Module\\Member Images");
                string[] matchingImages = Directory.GetFiles(imagesFolder, $"{ticket.BodyNumber:D3}*.*");

                if (matchingImages.Length > 0)
                {
                    using (var temp = new Bitmap(matchingImages[0]))
                    {
                        memberImage = new Bitmap(temp);
                    }
                }

                ticketHelper.CreateTicketBox(
                    trackingNumber: "TR-" + ticket.TicketID,
                    fullName: ticket.FullName,
                    typeOfAid: ticket.TypeOfAid,
                    dateRequested: ticket.DateRequested.ToString("MM-dd-yyyy hh:mm tt"),
                    status: ticket.RequestStatus,
                    requestedBy: ticket.RequestedBy,
                    amount: "₱" + ticket.RequestedAmount.ToString("N2"),
                    assistanceThru: ticket.AssistanceThru,
                    contactNum: ticket.ContactNumber,
                    dateNeeded: ticket.TargetDate.ToString("MM-dd-yyyy"),
                    memberImag: memberImage
                );
            }

            LoadAllTickets();
            UpdateRequestCounts();
            ConfirmationPanel.Hide();
        }

        private void TicketBox_Click(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel == null) return;

            bool isExpanded = (bool)panel.Tag;
            isExpanded = !isExpanded;
            panel.Tag = isExpanded;

            panel.Height = isExpanded ? 330 : 150;

            foreach (Control control in panel.Controls)
            {
                if (control.Tag != null && control.Tag.ToString() == "ExpandInfo")
                {
                    control.Visible = isExpanded;
                }
            }
        }

        private void SubmitTicket_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ReqFirstNameTxt.Text) ||
                string.IsNullOrWhiteSpace(ReqLastNameTxt.Text) ||
                string.IsNullOrWhiteSpace(TypeOfAidCmb.Text) ||
                string.IsNullOrWhiteSpace(ReqAssistanceThruCmb.Text) ||
                string.IsNullOrWhiteSpace(ReqAmountTxt.Text) ||
                string.IsNullOrWhiteSpace(RequestByCmb.Text) ||
                string.IsNullOrWhiteSpace(DateNeededPicker.Text))
            {
                MessageBox.Show("Please fill in all required fields before submitting.", "Incomplete Form", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }

            if (!decimal.TryParse(ReqAmountTxt.Text, out _))
            {
                MessageBox.Show("Please enter a valid amount.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TransferToDisplayPanel();
            ConfirmationPanel.Show();
            ConfirmationPanel.BringToFront();
            FillUpFormPanel.Hide();
        }


        private void ClearButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ClearInputs(this);
        }
        private void RequestedByComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = ReqAssistanceThruCmb.SelectedItem?.ToString();
            NonMemberSelectedPanel.Visible = selectedItem != "Member";
        }

        private void ReqSearchTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ReqSearchGrid.Visible = true;
                RequestSearchOwner search = new RequestSearchOwner();
                search.SearchOwner(ReqSearchTxt, ReqSearchGrid);
                SearchResults.SetupSearchGrid(ReqSearchGrid);
                DataGridCustom.ApplyCustomGridSearch(ReqSearchGrid);

                ReqSearchGrid.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void ReqSearchGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string bodyNumberStr = ReqSearchGrid.Rows[e.RowIndex].Cells["BodyNumber"].Value?.ToString();
            if (string.IsNullOrEmpty(bodyNumberStr)) return;

            string digitsOnly = new string(bodyNumberStr.Where(char.IsDigit).ToArray());
            if (!int.TryParse(digitsOnly, out int bodyNumber)) return;

            AssistanceLoadMember loader = new AssistanceLoadMember();
            loader.LoadMemberDetails(digitsOnly,
                ReqBodyNoLbl,
                ReqMembTypeLbl,
                ReqFirstNameTxt,
                ReqMiddleTxt,
                ReqLastNameTxt,
                ReqContactLbl);

            ReqBodyNoLbl.Text = bodyNumber.ToString("D3");

            MemberModel member = new MemberModel
            {
                BodyNumber = bodyNumber
            };

            LoadOwnerImage.FromMember(member, MemberImagePb);

            ReqSearchGrid.Visible = false;

        }

        private void ReqAssistanceThruCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ReqAssistanceThruCmb.SelectedItem != null &&
                    ReqAssistanceThruCmb.SelectedItem.ToString() == "GCASH")
            {
                ReqGcashNumTxt.Text = "09";
                NonMemberSelectedPanel.BackColor = Color.White;
                ReqGcashNumTxt.BackColor = Color.White;
                ReqGcashNumTxt.Enabled = true;
            }
            else
            {
                NonMemberSelectedPanel.BackColor = Color.Gainsboro;
                ReqGcashNumTxt.BackColor = Color.Gainsboro;
                ReqGcashNumTxt.Text = "XXXXXXXXXXX";
                ReqGcashNumTxt.Enabled = false;
            }
        }

        private void UploadProofBtn_Click(object sender, EventArgs e)
        {
            OpenProof.Title = "Select an Image";
            OpenProof.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (OpenProof.ShowDialog() == DialogResult.OK)
            {
                string fileName = Path.GetFileName(OpenProof.FileName);
                ReqFileTxt.Text = fileName;
            }
        }

        private void CreateTicketPanel_DoubleClick(object sender, EventArgs e)
        {
            //AddTicketBox();
            TextStatusPanel.Hide();
            FillUpFormPanel.Show();
            FillUpFormPanel.BringToFront();
            TicketIdlbl.Text = "TR-" + Ticket.GetNextTicketID().ToString();
            DateCreatedLbl.Text = DateTime.Now.ToString("MM-dd-yyyy hh:mm tt");


        }

        private void CreateTicketCancelBtn_Click(object sender, EventArgs e)
        {
            FillUpFormPanel.Hide();
        }

        private void ConfirmationPanelCancelBtn_Click(object sender, EventArgs e)
        {
            ConfirmationPanel.Hide();
        }

        private void SearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadAllTickets();
                e.SuppressKeyPress = true;
            }
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            SearchTextBox.Text = "";
            LoadAllTickets();
        }

        private void CreateTicketPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}