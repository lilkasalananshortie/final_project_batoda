using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Apis.Gmail.v1.Data;

namespace BATODA.User_Control_Forms
{
    public partial class GFormUForm : UserControl
    {
        private Panel currentSelectedPanel;
        public GFormUForm()
        {
            InitializeComponent();
            ReplyPanel.Visible = false;
        }

        private void MembersTopPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void EmailRcvButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new CSUForm());

        }

        private Panel CreateInboxPanel(string headerText, string previewText, string timeText, string messageId)
        {
            Panel panel = new Panel
            {
                Width = 1500,
                Height = 80,
                BackColor = Color.WhiteSmoke,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(3),
                Padding = new Padding(10)
            };

            System.Windows.Forms.Label header = new System.Windows.Forms.Label
            {
                Text = headerText,
                Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold),
                AutoSize = true,
                Dock = DockStyle.Top
            };

            System.Windows.Forms.Label time = new System.Windows.Forms.Label
            {
                Text = timeText,
                Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold),
                AutoSize = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };

            System.Windows.Forms.Label preview = new System.Windows.Forms.Label
            {
                Text = previewText,
                Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular),
                AutoSize = true,
                Dock = DockStyle.Top,
                ForeColor = Color.Gray,
                Padding = new Padding(0, 5, 0, 0)
            };

            panel.Controls.Add(preview);
            panel.Controls.Add(header);
            panel.Controls.Add(time);

            panel.Resize += (s, e) =>
            {
                time.Location = new Point(panel.Width - time.Width - 20, 10);
            };

            panel.Click += (s, e) =>
            {
                foreach (Control ctrl in GFormFlowLayoutPanel.Controls)
                {
                    if (ctrl is Panel p)
                    {
                        p.Width = 850;
                    }
                }

                currentSelectedPanel = panel;
                GFormFlowLayoutPanel.Size = new Size(860, 1067);
                GFormFlowLayoutPanel.Location = new Point(50, 70);

                //var full = gmailhandler.getfullmessage(messageid);
               // fromlbl.text = full.from;
               // datelbl.text = full.date.tostring("mmmm dd, yyyy");
               // contenttxt.text = full.body;
            };

            return panel;
        }

        private void CloseMessage_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in GFormFlowLayoutPanel.Controls)
            {
                if (ctrl is Panel p)
                {
                    p.Width = 1530;
                }
            }

            currentSelectedPanel = null;

            GFormFlowLayoutPanel.Size = new Size(1535, 1067);
            GFormFlowLayoutPanel.Location = new Point(50, 70);

            MessagePanel.Visible = false;
            ReplyPanel.Visible = false;
        }

        private void CancelReplyButton_Click(object sender, EventArgs e)
        {
            ReplyPanel.Hide();
        }

        private void ReplyButton_Click(object sender, EventArgs e)
        {
            ReplyPanel.Visible = true;

        }

        private void SendReplyButton_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in GFormFlowLayoutPanel.Controls)
            {
                if (ctrl is Panel p)
                {
                    p.Width = 1530;
                }
            }

            currentSelectedPanel = null;

            GFormFlowLayoutPanel.Size = new Size(1535, 1067);
            GFormFlowLayoutPanel.Location = new Point(50, 70);

            MessagePanel.Visible = false;
            ReplyPanel.Visible = false;
        }
    }
}