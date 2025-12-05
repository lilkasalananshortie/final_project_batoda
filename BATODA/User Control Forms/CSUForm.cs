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
        private int panelGenertedBig = 1460;
        private int panelGenertedSmall = 933;

        private Panel overlay;
        private Panel progressBarBackground;
        private Panel progressBarFill;

        public CSUForm()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint, true);
            this.UpdateStyles();
        }

        private async void CSUForm_Load(object sender, EventArgs e)
        {
            ReplyPanel.Visible = false;

           
            ShowOverlay();
            Application.DoEvents();

            await LoadGmailInboxAsync();

            HideOverlay();
        }

        private async Task LoadGmailInboxAsync()
        {
            InboxFlowLayoutPanel.Controls.Clear();

            if (cachedMessages == null)
            {
                var messages = await Task.Run(() => gmailHandler.GetMessages(10));
                cachedMessages = messages.Select(m => (m.Id, m.Subject, m.Date)).ToList();
            }

            int total = cachedMessages.Count;
            int counter = 0;

            foreach (var m in cachedMessages)
            {
                
                var preview = await Task.Run(() => gmailHandler.GetPreview(m.Id, 70));
                var time = await Task.Run(() => gmailHandler.FormatMessageTime(m.Date));

                
                var panel = CreateInboxPanel(m.Subject, preview, time, m.Id);
                InboxFlowLayoutPanel.Controls.Add(panel);

                
                counter++;
                int percentage = counter * 100 / total;
                UpdateProgress(percentage);

                await Task.Delay(20);
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
                    if (ctrl is Panel p)
                        p.Width = 780;

                currentSelectedPanel = panel;

                MessagePanel.Visible = true;

                InboxFlowLayoutPanel.Size = new Size(803, 739);
                InboxFlowLayoutPanel.Location = new Point(20, 82);

                var full = gmailHandler.GetFullMessage(messageId);
                FromLbl.Text = full.From;
                DateLbl.Text = full.Date.ToString("MMMM dd, yyyy");
                ContentTxt.Text = full.Body;
            };

            return panel;
        }

        private void CloseMessage_Click_1(object sender, EventArgs e)
        {
            foreach (Control ctrl in InboxFlowLayoutPanel.Controls)
                if (ctrl is Panel p)
                    p.Width = panelGenertedBig;

            currentSelectedPanel = null;

            InboxFlowLayoutPanel.Size = new Size(1486, 725);
            InboxFlowLayoutPanel.Location = new Point(20, 82);

            MessagePanel.Visible = false;
            ReplyPanel.Visible = false;
        }

        private void ReplyButton_Click(object sender, EventArgs e)
        {
            ReplyPanel.Visible = true;
            ReplyPanel.Location = new Point(270, 140);
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
                if (ctrl is Panel p)
                    p.Width = panelGenertedBig;

            currentSelectedPanel = null;

            InboxFlowLayoutPanel.Size = new Size(1480, 767);
            InboxFlowLayoutPanel.Location = new Point(20, 82);

            MessagePanel.Visible = false;
            ReplyPanel.Visible = false;
        }

        private void GFormRcvButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new GFormUForm());
        }

        // ---------------- Overlay + custom progress bar ----------------
        private void CreateOverlay()
        {
            if (overlay != null) return;

            overlay = new Panel
            {
                BackColor = Color.FromArgb(140, 0, 0, 0),
                Dock = DockStyle.Fill,
                Visible = false
            };

          
            progressBarBackground = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 5,
                BackColor = Color.DarkRed
            };

            
            progressBarFill = new Panel
            {
                Dock = DockStyle.Left,
                Height = 5,
                Width = 0,
                BackColor = Color.Red
            };

            progressBarBackground.Controls.Add(progressBarFill);
            overlay.Controls.Add(progressBarBackground);

           
            overlay.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
                   .SetValue(overlay, true, null);
        }

        private void ShowOverlay()
        {
            if (overlay == null)
                CreateOverlay();

            var form = this.FindForm();
            if (form == null) return;

            if (!form.Controls.Contains(overlay))
                form.Controls.Add(overlay);

            overlay.BringToFront();
            overlay.Visible = true;
            overlay.Refresh();
        }

        private void HideOverlay()
        {
            if (overlay != null)
                overlay.Visible = false;
        }

        private void UpdateProgress(int percentage)
        {
            if (progressBarFill != null && progressBarBackground != null)
            {
                int width = progressBarBackground.Width * percentage / 100;
                progressBarFill.Width = width;
                progressBarFill.Refresh();
            }
        }
    }
}
