using BATODA.Modules.Inbox_Module.Inbox_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BATODA.User_Control_Forms
{
    public partial class CSUForm : UserControl
    {
        private GmailServiceHandler gmailHandler = new GmailServiceHandler();
        private List<(string Id, string Subject, DateTime Date)> cachedMessages;

        public CSUForm()
        {
            InitializeComponent();
            LoadGmailInbox();
            
        }
        private void CSUForm_Load(object sender, EventArgs e)
        {
            ReplyPanel.Visible = false;
        }

        private async void LoadGmailInbox()
        {
            InboxFlowLayoutPanel.Controls.Clear();

            if (cachedMessages == null)
            {
                var messages = await Task.Run(() => gmailHandler.GetMessages(10));
                cachedMessages = messages.Select(m => (m.Id, m.Subject, m.Date)).ToList();
            }

            foreach (var m in cachedMessages)
            {
                string preview = gmailHandler.GetPreview(m.Id, 70);
                var panel = CreateInboxPanel(m.Subject, preview, gmailHandler.FormatMessageTime(m.Date), m.Id);
                InboxFlowLayoutPanel.Controls.Add(panel);
            }
        }

        private Panel CreateInboxPanel(string headerText, string previewText, string timeText, string messageId)
        {
            var panel = new Panel
            {
                Width = 1535,
                Height = 80,
                BackColor = Color.WhiteSmoke,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(3),
                Padding = new Padding(10),
                AutoScroll = false
            };

            var header = new Label
            {
                Text = headerText,
                Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(10, 5)
            };

            var time = new Label
            {
                Text = timeText,
                Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(1350, 10)
            };

            var messagePreview = new Label
            {
                Text = previewText.Length > 100 ? previewText.Substring(0, 100) + "..." : previewText,
                Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular),
                AutoSize = true,
                Location = new Point(10, 40),
                ForeColor = Color.Gray
            };

            panel.Controls.Add(header);
            panel.Controls.Add(time);
            panel.Controls.Add(messagePreview);

            panel.Click += (s, e) =>
            {
                MessagePanel.Visible = true;
                var fullMsg = gmailHandler.GetFullMessage(messageId);
                FromLbl.Text = fullMsg.From;
                DateLbl.Text = fullMsg.Date.ToString("MMMM dd, yyyy");
                ContentTxt.Text = fullMsg.Body;
                
            };

            return panel;
        }


        private void TESTPANEL_Click(object sender, EventArgs e)
        {
            var panel = CreateInboxPanel(
                "Test Subject",
                "This is a sample preview of the message to demonstrate how the snippet will appear in the panel.",
                DateTime.Now.ToString("hh:mm tt"),
                "test"
            );
            InboxFlowLayoutPanel.Controls.Add(panel);
        }


        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
        }

        

        private void CloseMessage_Click(object sender, EventArgs e)
        {

        }

        private void CloseMessage_Click_1(object sender, EventArgs e)
        {
            MessagePanel.Visible = false;
            ReplyPanel.Visible = false;
        }

        private void ReplyButton_Click(object sender, EventArgs e)
        {
            MessagePanel.Location = new Point(64, 122);
            ReplyPanel.Visible = true;

        }

        private void CancelReplyButton_Click(object sender, EventArgs e)
        {
            MessagePanel.Location = new Point(260, 122);
            ReplyPanel.Visible = false;
        }

        private void SendReplyButton_Click(object sender, EventArgs e)
        {
            MessagePanel.Visible = false;
            ReplyPanel.Visible = false;
        }
    }

}
