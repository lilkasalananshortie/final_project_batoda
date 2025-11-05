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


        private void ConfirmButton_Click(object sender, EventArgs e)
        {

           

        }
       

        private void TicketConfirmButton_Click(object sender, EventArgs e)
        {
            
            ConfirmationPanel.Hide();
        }
        public void AddTicketBox()
        {
            Panel TicketBox = new Panel();
            TicketBox.Size = new Size(280, 220);
            TicketBox.BackColor = Color.LightGray;
            TicketBox.BorderStyle = BorderStyle.FixedSingle;
            TicketBox.Margin = new Padding(10);
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
        



        private void BodyNumber_TextChanged(object sender, EventArgs e)
        {

        }

       
        private void TicketFlowLayoutPanel_Paint(object sender, PaintEventArgs e)
        {
            
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

       
    }
}
