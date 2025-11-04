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

            ConfirmationPanel.Hide();



        }
        private void AssistanceRequestUForm_Load(object sender, EventArgs e)
        {

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

            SaveButton.Enabled = true;

        }
        private void SaveButton_Click(object sender, EventArgs e)
        {

            SaveButton.Enabled = false;

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

            Label TrackingNumber = new Label();
            TrackingNumber.Text = "Tracking Number: SAMPLE";
            TrackingNumber.Dock = DockStyle.Fill;
            TrackingNumber.TextAlign = ContentAlignment.MiddleCenter;

            TicketBox.Controls.Add(TrackingNumber);
            TicketFlowLayoutPanel.Controls.Add(TicketBox);
        }


        private void CreateTicketPanel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            AddTicketBox();
        }
    }
}
