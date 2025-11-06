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
using BATODA.Helpers.DataGrid;
using BATODA.Modules.Assistance_Request_Module.Assistance_Classes;


namespace BATODA
{   
    public partial class AssistanceRequestUForm : UserControl
    {
        public AssistanceRequestUForm()
        {
            InitializeComponent();
            FillUpFormPanel.Hide();
            ConfirmationPanel.Hide();

            TextStatusPanel.Show();
            TextStatusPanel.BringToFront();
            NonMemberSelectedPanel.Hide();


            StyleDataGrid(AssistanceLogDataGrid);
            LoadSampleLogs();

        }
        private void AssistanceRequestUForm_Load(object sender, EventArgs e)
        {

            DisplayClass.SetPlaceholder(TypeOfAidCmb,"Select Aid Type");
            DisplayClass.SetPlaceholder(SearchTextBox, "Search Member");
            DisplayClass.SetPlaceholder(SortComboBox, "Date");


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
            
            ConfirmationPanel.Hide();
        }
        public void AddTicketBox()
        {
            Panel TicketBox = new Panel();
            TicketBox.Size = new Size(300, 150);
            TicketBox.BackColor = Color.White;
            TicketBox.BorderStyle = BorderStyle.FixedSingle;
            TicketBox.Margin = new Padding(5);
            TicketBox.Cursor = Cursors.Hand;
            TicketBox.Tag = false;

            int y = 10;

            Panel HeaderPanel = new Panel()
            {
                Size = new Size(298, 30),
                Location = new Point(1, 1),
                BackColor = Color.LightGray
            };

            Label lblTracking = new Label()
            {
                Text = "Tracking Number: SAMPLE",
                Location = new Point(10, 7),
                AutoSize = true,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)

            };
            HeaderPanel.Controls.Add(lblTracking);

           
            y += 25;

            PictureBox picMember = new PictureBox()
            {
                Location = new Point(10, y),
                Size = new Size(80, 80),
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.LightGray
            };

            
            int rightX = picMember.Right + 10;

            Label lblName = new Label()
            {
                Text = "Full Name: Mhaku Jose Manalili",
                Location = new Point(rightX, y + 5),
                AutoSize = true
            };

            Label lblAid = new Label()
            {
                Text = "Type of Aid: Medical",
                Location = new Point(rightX, y + 30),
                AutoSize = true
            };

            Label lblDate = new Label()
            {
                Text = "Date Requested: 2025-11-05",
                Location = new Point(rightX, y + 55),
                AutoSize = true
            };

            Label lblStatus = new Label()
            {
                Text = "Status: Pending",
                Location = new Point(rightX, y + 80),
                AutoSize = true,
                
            };


            int expandY = picMember.Bottom + 19;

            Label lblRequestedBy = new Label()
            {
                Text = "Requested by: Member blah blah",
                Location = new Point(10, expandY),
                AutoSize = true,
                Tag = "ExpandInfo",
                Visible = false
            };
            expandY += 22;

            Label lblAmount = new Label()
            {
                Text = "Amount: ₱1000",
                Location = new Point(10, expandY),
                AutoSize = true,
                Tag = "ExpandInfo",
                Visible = false
            };
            expandY += 22;

            Label lblAssistanceThru = new Label()
            {
                Text = "Assistance Thru: Cash",
                Location = new Point(10, expandY),
                AutoSize = true,
                Tag = "ExpandInfo",
                Visible = false
            };
            expandY += 22;

            Label lblContactNum = new Label()
            {
                Text = "Contact Num: 09123456789",
                Location = new Point(10, expandY),
                AutoSize = true,
                Tag = "ExpandInfo",
                Visible = false
            };
            expandY += 22;

            Label dateNeeded = new Label()
            {
                Text = "Date Needed: SAMPLE",
                Location = new Point(10, expandY),
                AutoSize = true,
                Tag = "ExpandInfo",
                Visible = false
            };
            expandY += 34;

            Button approveBtn = new Button()
            {
                Text = "Approve",
                Size = new Size(80, 30),
                Location = new Point(10, expandY),
                Visible = false,
                Tag = "ExpandInfo"
            };

            Button rejectBtn = new Button()
            {
                Text = "Reject",
                Size = new Size(80, 30),
                Location = new Point(105, expandY),
                Visible = false,
                Tag = "ExpandInfo"
            };

            Button cancelBtn = new Button()
            {
                Text = "Cancel",
                Size = new Size(80, 30),
                Location = new Point(200, expandY),
                Visible = false,
                Tag = "ExpandInfo"
            };

            Button releaseBtn = new Button()
            {
                Text = "Release",
                Size = new Size(80, 30),
                Location = new Point(200, 260),
                Visible = false,
                
            };

            approveBtn.Click += (s, e) =>
            {
                Panel parent = ((Button)s).Parent as Panel;
                HeaderPanel.BackColor = Color.LightGreen;
                lblTracking.BringToFront();
                lblTracking.BackColor = Color.LightGreen;
                lblStatus.Text = "Status: Approved";
                releaseBtn.Visible = true;
                releaseBtn.Show();
                approveBtn.Hide();
                cancelBtn.Hide();
                rejectBtn.Hide();

            };

            rejectBtn.Click += (s, e) =>
            {
                Panel parent = ((Button)s).Parent as Panel;
                HeaderPanel.BackColor = Color.LightCoral;
                lblTracking.BackColor = Color.LightCoral;
                lblTracking.BringToFront();
                lblStatus.Text = "Status: Rejected";
            };

            cancelBtn.Click += (s, e) =>
            {
                Panel parent = ((Button)s).Parent as Panel;
                HeaderPanel.BackColor = Color.LightGray;
                lblTracking.BackColor = Color.LightGray;
                lblTracking.BringToFront();
                lblStatus.Text = "Status: Canceled";
            };

            releaseBtn.Click += (s, e) =>
            {
                Panel parent = ((Button)s).Parent as Panel;
                parent.Hide();
            };
            TicketBox.Controls.Add(HeaderPanel);
            TicketBox.Controls.Add(lblTracking);
            TicketBox.Controls.Add(picMember);
            TicketBox.Controls.Add(lblName);
            TicketBox.Controls.Add(lblAid);
            TicketBox.Controls.Add(lblDate);
            TicketBox.Controls.Add(lblRequestedBy);
            TicketBox.Controls.Add(lblAmount);
            TicketBox.Controls.Add(lblAssistanceThru);
            TicketBox.Controls.Add(lblContactNum);
            TicketBox.Controls.Add(lblStatus);
            TicketBox.Controls.Add(dateNeeded);
            TicketBox.Controls.Add(approveBtn);
            TicketBox.Controls.Add(rejectBtn);
            TicketBox.Controls.Add(cancelBtn);
            TicketBox.Controls.Add(releaseBtn);

            lblTracking.BringToFront();
            lblTracking.BackColor = Color.LightGray;

            TicketBox.Click += TicketBox_Click;

            TicketFlowLayoutPanel.Controls.Add(TicketBox);
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
            AddTicketBox();
            TextStatusPanel.Hide();
            FillUpFormPanel.Show();
            FillUpFormPanel.BringToFront();
            TicketIdlbl.Text = "TR-"+Ticket.GetNextTicketID().ToString();
            DateCreatedLbl.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void SubmitTicket_Click(object sender, EventArgs e)
        {
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

            ReqSearchGrid.Visible = false;
            MessageBox.Show("Clicked row: " + bodyNumberStr);

        }
    }
}
