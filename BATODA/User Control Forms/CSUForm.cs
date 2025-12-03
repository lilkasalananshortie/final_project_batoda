using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BATODA.User_Control_Forms
{
    public partial class CSUForm : UserControl
    {
        public CSUForm()
        {
            InitializeComponent();
        }
        private Panel CreateInboxPanel(string headerText, string timeText)
        {
            var panel = new Panel();
            panel.Width = 1540;
            panel.Height = 80;
            panel.BackColor = Color.WhiteSmoke;
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Margin = new Padding(3);
            panel.Padding = new Padding(10);
            panel.AutoScroll = true;

            var header = new Label();
            header.Text = headerText;
            header.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            header.AutoSize = true;
            header.Location = new Point(10, 5);

            var time = new Label();
            time.Text = timeText;
            time.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            time.AutoSize = true;
            time.Location = new Point(1450, 10);

            var messagePreview = new Label();
            messagePreview.Text = "Sample lang";
            messagePreview.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            messagePreview.AutoSize = true;
            messagePreview.Location = new Point(10, 40);
            messagePreview.ForeColor = Color.Gray;


            panel.Controls.Add(header);
            panel.Controls.Add(time);
            panel.Controls.Add(messagePreview);

            return panel;
        }

        private void TESTPANEL_Click(object sender, EventArgs e)
        {
            var panel = CreateInboxPanel("New message", DateTime.Now.ToString("hh:mm tt"));
            InboxFlowLayoutPanel.Controls.Add(panel);
        }
    }
}
