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
        private Panel currentSelectedPanel;
        private int panelGenertedBig = 1530;
        private int panelGenertedSmall = 933;
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
                Width = panelGenertedBig,
                Height = 80,
                BackColor = Color.WhiteSmoke,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(3),
                Padding = new Padding(10)
            };

            var header = new Label
            {
                Text = headerText,
                Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold),
                AutoSize = true,
                Dock = DockStyle.Top
            };

            var time = new Label
            {
                Text = timeText,
                Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold),
                AutoSize = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };

            var preview = new Label
            {
                Text = previewText.Length > 100 ? previewText.Substring(0, 100) + "..." : previewText,
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
                foreach (Control ctrl in InboxFlowLayoutPanel.Controls)
                {
                    if (ctrl is Panel p)
                    {
                        p.Width = 850;
                    }
                }

                currentSelectedPanel = panel;

                MessagePanel.Visible = true;

                InboxFlowLayoutPanel.Size = new Size(860, 1067);
                InboxFlowLayoutPanel.Location = new Point(50, 70);

                var full = gmailHandler.GetFullMessage(messageId);
                FromLbl.Text = full.From;
                DateLbl.Text = full.Date.ToString("MMMM dd, yyyy");
                ContentTxt.Text = full.Body;
            };

            return panel;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
        }



        private void CloseMessage_Click(object sender, EventArgs e)
        {

        }

        private void CloseMessage_Click_1(object sender, EventArgs e)
        {
            foreach (Control ctrl in InboxFlowLayoutPanel.Controls)
            {
                if (ctrl is Panel p)
                {
                    p.Width = panelGenertedBig;
                }
            }

            currentSelectedPanel = null;

            InboxFlowLayoutPanel.Size = new Size(1535, 1067);
            InboxFlowLayoutPanel.Location = new Point(50, 70);

            MessagePanel.Visible = false;
            ReplyPanel.Visible = false;
        }

        private void ReplyButton_Click(object sender, EventArgs e)
        {

            ReplyPanel.Visible = true;

        }

        private void CancelReplyButton_Click(object sender, EventArgs e)
        {

            ReplyPanel.Visible = false;
        }

        private void SendReplyButton_Click(object sender, EventArgs e)
        {
            if (currentSelectedPanel == null) return;

            string replyText = ReplyContentRTextbox.Text.Trim();
            if (string.IsNullOrEmpty(replyText))
            {
                MessageBox.Show("Reply cannot be empty.");
                return;
            }

            string recipient = FromLbl.Text;
            string subject = "Re: " + (currentSelectedPanel.Controls.OfType<Label>().FirstOrDefault(l => l.Font.Bold)?.Text ?? "(No Subject)");

            try
            {
                gmailHandler.SendEmail(recipient, subject, replyText);
                MessageBox.Show("Reply sent successfully.");
                ReplyContentRTextbox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending reply: " + ex.Message);
            }

            foreach (Control ctrl in InboxFlowLayoutPanel.Controls)
            {
                if (ctrl is Panel p)
                {
                    p.Width = panelGenertedBig;
                }
            }

            currentSelectedPanel = null;

            InboxFlowLayoutPanel.Size = new Size(1535, 1067);
            InboxFlowLayoutPanel.Location = new Point(50, 70);

            MessagePanel.Visible = false;
            ReplyPanel.Visible = false;

        }

        private void GFormRcvButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new GFormUForm());
        }
    }

}