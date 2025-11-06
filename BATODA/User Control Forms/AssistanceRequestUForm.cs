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
            DisplayClass.SetPlaceholder(BodyNumber,"Search Body Number");
            DisplayClass.SetPlaceholder(AidTypeComboBox,"Select Aid Type");
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
            TicketBox.Size = new Size(280, 220);
            TicketBox.BackColor = Color.White;
            TicketBox.BorderStyle = BorderStyle.FixedSingle;
            TicketBox.Margin = new Padding(5);
            TicketBox.Cursor = Cursors.Hand;
           

            TicketBox.Tag = false;
            int y = 10;

            Label lblTracking = new Label()
            {
                Text = "Tracking Number: SAMPLE",
                Location = new Point(10, y),
                AutoSize = true,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };
            y += 25;

            PictureBox picMember = new PictureBox()
            {
                Location = new Point(10, y),
                Size = new Size(80, 80),
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.LightGray
            };

            Label lblName = new Label()
            {
                Text = "Full Name: Mhaku Jose Manalili",
                Location = new Point(100, y + 5),
                AutoSize = true
            };
            y += 25;

            Label lblAid = new Label()
            {
                Text = "Type of Aid: Medical",
                Location = new Point(100, y + 25),
                AutoSize = true
            };
            y += 25;

            Label lblDate = new Label()
            {
                Text = "Date Requested: 2025-11-05",
                Location = new Point(100, y + 45),
                AutoSize = true
            };

            
            Label lblRequestedBy = new Label()
            {
                Text = "Requested by: Member blah blah",
                Location = new Point(10, 150),
                AutoSize = true,
                Tag = "ExpandInfo",
                Visible = false
            };

            Label lblAmount = new Label()
            {
                Text = "Amount: ₱1000",
                Location = new Point(10, 175),
                AutoSize = true,
                Tag = "ExpandInfo",
                Visible = false
            };

            Label lblAssistanceThru = new Label()
            {
                Text = "Assistance Thru: Cash",
                Location = new Point(10, 200),
                AutoSize = true,
                Tag = "ExpandInfo",
                Visible = false
            };

            Label lblContactNum = new Label()
            {
                Text = "Contact Num: 09123456789",
                Location = new Point(10, 225),
                AutoSize = true,
                Tag = "ExpandInfo",
                Visible = false
            };

            Button approveBtn = new Button()
            {
                Text = "Approve",
                Size = new Size(100, 35),
                Location = new Point(20, 260),
                Visible = false,
                Tag = "ExpandInfo"
            };

            Button rejectBtn = new Button()
            {
                Text = "Reject",
                Size = new Size(100, 35),
                Location = new Point(130, 260),
                Visible = false,
                Tag = "ExpandInfo"
            };

            TicketBox.Controls.Add(lblTracking);
            TicketBox.Controls.Add(picMember);
            TicketBox.Controls.Add(lblName);
            TicketBox.Controls.Add(lblAid);
            TicketBox.Controls.Add(lblDate);
            TicketBox.Controls.Add(lblRequestedBy);
            TicketBox.Controls.Add(lblAmount);
            TicketBox.Controls.Add(lblAssistanceThru);
            TicketBox.Controls.Add(lblContactNum);
            TicketBox.Controls.Add(approveBtn);
            TicketBox.Controls.Add(rejectBtn);

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

            panel.Height = isExpanded ? 320 : 220;

            
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
            string selectedItem = RequestedByComboBox.SelectedItem?.ToString();
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
    }
}
