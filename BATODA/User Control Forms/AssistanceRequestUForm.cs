using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BATODA.Helpers.Database.Members;
using BATODA.Helpers.DataGrid;
using BATODA.Modules.Assistance_Request_Module;
using BATODA.Modules.Assistance_Request_Module.Assistance_Classes;
using BATODA.Modules.MemberModule;


namespace BATODA
{   
    public partial class AssistanceRequestUForm : UserControl
    {
        private AddTicketBox ticketHelper;
        public AssistanceRequestUForm()
        {
            InitializeComponent();
            ticketHelper = new AddTicketBox(TicketFlowLayoutPanel);
            FillUpFormPanel.Hide();
            ConfirmationPanel.Hide();

            TextStatusPanel.Show();
            TextStatusPanel.BringToFront();


            StyleDataGrid(AssistanceLogDataGrid);
            LoadSampleLogs();

        }
        private void AssistanceRequestUForm_Load(object sender, EventArgs e)
        {
            LoadAllTickets();
            DisplayClass.SetPlaceholder(SearchTextBox, "Search Member");
            DisplayClass.SetPlaceholder(SortComboBox, "Date");


        }

        private void LoadAllTickets()
        {
            TicketFlowLayoutPanel.Controls.Clear(); 
            AssistanceRepository repo = new AssistanceRepository();
            List<TicketModel> tickets = repo.GetAllRequests();

            foreach (TicketModel ticket in tickets)
            {
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
                    dateNeeded: ticket.TargetDate.ToString("MM-dd-yyyy")
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
                // DEFAULT PENDING STATUS SA TABLE
            };

            AssistanceRepository repo = new AssistanceRepository();
            repo.AddRequest(data);

            List<TicketModel> tickets = repo.GetAllRequests();
            TicketFlowLayoutPanel.Controls.Clear();

            foreach (TicketModel ticket in tickets)
            {
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
                    dateNeeded: ticket.TargetDate.ToString("MM-dd-yyyy")
                );
            }

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

        private void CreateTicketPanel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //AddTicketBox();
            TextStatusPanel.Hide();
            FillUpFormPanel.Show();
            FillUpFormPanel.BringToFront();
            TicketIdlbl.Text = "TR-"+Ticket.GetNextTicketID().ToString();
            DateCreatedLbl.Text = DateTime.Now.ToString("MM-dd-yyyy hh:mm tt");
        }

        private void SubmitTicket_Click(object sender, EventArgs e)
        {
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


        private void StyleDataGrid(DataGridView dgv)
        {
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersVisible = false;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.ReadOnly = true;
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv.BackgroundColor = Color.WhiteSmoke;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgv.BorderStyle = BorderStyle.FixedSingle;

            // ✅ Main style
            dgv.DefaultCellStyle = new DataGridViewCellStyle
            {
                Font = new Font("Segoe UI", 9.5f),
                ForeColor = Color.FromArgb(40, 40, 40),
                BackColor = Color.White,
                Padding = new Padding(12, 10, 12, 10),
                SelectionBackColor = Color.White,
                SelectionForeColor = Color.Black,
                WrapMode = DataGridViewTriState.True
            };

            dgv.RowTemplate.DefaultCellStyle = dgv.DefaultCellStyle;
            dgv.RowTemplate.Height = 80;


            //  Custom Log UI
            dgv.CellPainting += (s, e) =>
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    e.PaintBackground(e.CellBounds, true);
                    e.PaintContent(e.CellBounds);

                    Rectangle rect = e.CellBounds;
                    rect.Inflate(-1, -1);

                    using (Pen borderPen = new Pen(Color.LightGray, 1))
                        e.Graphics.DrawRectangle(borderPen, rect);

                    e.Handled = true;
                }
            };

            // padding between rows
            dgv.RowPostPaint += (s, e) =>
            {
                using (Brush brush = new SolidBrush(dgv.BackgroundColor))
                {
                    e.Graphics.FillRectangle(brush,
                        new Rectangle(0, e.RowBounds.Bottom, dgv.Width, 8));
                }
            };
        }

        private void LoadSampleLogs()
        {
            AssistanceLogDataGrid.Columns.Clear();
            AssistanceLogDataGrid.Rows.Clear();
            AssistanceLogDataGrid.Columns.Add("Message", "Message");

            AssistanceLogDataGrid.Rows.Add(
                "🕒  ASSISTANCE_REQUEST_ADD\nNew assistance request submitted for ₱0.03.\nNov 5, 10:39 PM"
            );
            AssistanceLogDataGrid.Rows.Add(
                "🕒  ASSISTANCE_REQUEST_UPDATE\nAssistance request details updated.\nNov 5, 10:32 PM"
            );
            AssistanceLogDataGrid.Rows.Add(
                "🕒  ASSISTANCE_REQUEST_APPROVED\nAssistance request approved successfully.\nNov 5, 10:27 PM"
            );
            AssistanceLogDataGrid.Rows.Add(
                "🕒  ASSISTANCE_REQUEST_DECLINED\nAssistance request declined for amount ₱0.\nNov 5, 10:24 PM"
            );

            AssistanceLogDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void AssistanceLogDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FillUpFormPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel27_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void ConfirmationPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BodyNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void TicketFlowLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Cerate_Click(object sender, EventArgs e)
        {

        }

        private void label38_Click(object sender, EventArgs e)
        {

        }

        private void FillUpFormPanel_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void TicketFlowLayoutPanel_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label40_Click(object sender, EventArgs e)
        {

        }

        private void ReqSearchTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ReqSearchGrid.Visible = true;
                RequestSearchOwner search = new RequestSearchOwner();
                search.SearchOwner(ReqSearchTxt, ReqSearchGrid);
                SearchResults.SetupSearchGrid(ReqSearchGrid);
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
            MessageBox.Show("Clicked row: " + bodyNumberStr);

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

        private void CreateTicketPanel_Paint(object sender, PaintEventArgs e)
        {

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
    }
}
