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
    public partial class AssistanceRequestUForm : UserControl
    {
        public AssistanceRequestUForm()
        {
            InitializeComponent();
            FillUpFormPanel.Hide();
            ConfirmationPanel.Hide();

            TextStatusPanel.Show();
            TextStatusPanel.BringToFront();

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
            TicketBox.Size = new Size(250, 200);
            TicketBox.BackColor = Color.LightGray;
            TicketBox.BorderStyle = BorderStyle.FixedSingle;
            TicketBox.Margin = new Padding(10);
            TicketBox.Cursor = Cursors.Hand;

            Label TrackingNumber = new Label();
            TrackingNumber.Text = "Tracking Number: SAMPLE";
            TrackingNumber.Dock = DockStyle.Top;
            TrackingNumber.Height = 40;
            TrackingNumber.TextAlign = ContentAlignment.MiddleCenter;
            TicketBox.Controls.Add(TrackingNumber);

            
            TicketBox.Click += TicketBox_Click;

            TicketFlowLayoutPanel.Controls.Add(TicketBox);
        }
        private void TicketBox_Click(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel == null) return;


            if (panel.Height > 200)
            {
                panel.Height = 200;
                panel.Controls.Clear();

                Label TrackingNumber = new Label();
                TrackingNumber.Text = "Tracking Number: SAMPLE";
                TrackingNumber.Dock = DockStyle.Top;
                TrackingNumber.Height = 40;
                TrackingNumber.TextAlign = ContentAlignment.MiddleCenter;
                panel.Controls.Add(TrackingNumber);
                return;
            }


            panel.Height = 300;
            panel.Controls.Clear();


            Label info = new Label();
            info.Text = "Tracking Number: SAMPLE";
            info.Dock = DockStyle.Top;
            info.Height = 40;
            info.TextAlign = ContentAlignment.MiddleCenter;

            Label name = new Label();
            name.Text = "Name: SAMPLE NAME";
            name.Dock = DockStyle.Top;
            name.Height = 50;
            name.TextAlign = ContentAlignment.MiddleCenter;

            Button approveBtn = new Button();
            approveBtn.Text = "Approve";
            approveBtn.Size = new Size(100, 40);
            approveBtn.Location = new Point(20, 250);

            Button rejectBtn = new Button();
            rejectBtn.Text = "Reject";
            rejectBtn.Size = new Size(100, 40);
            rejectBtn.Location = new Point(130, 250);

            panel.Controls.Add(name);
            panel.Controls.Add(approveBtn);
            panel.Controls.Add(rejectBtn);
            panel.Controls.Add(info);
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
    }
}
