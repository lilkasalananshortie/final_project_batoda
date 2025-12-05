using BATODA.Modules.Inbox_Module.Gform_Classes;
using Google.Apis.Gmail.v1.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;


namespace BATODA.User_Control_Forms
{

    public partial class GFormUForm : UserControl
    {
        private Panel currentSelectedPanel;
        private GFormResponseModel currentSelectedResponse;

        public GFormUForm()
        {
            InitializeComponent();
            LoadGFormResponses();
        }


        private void MembersTopPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void EmailRcvButton_Click(object sender, EventArgs e)
        {
            DisplayClass.ShowMain(new CSUForm());

        }

        private void LoadGFormResponses()
        {
            GFormFlowLayoutPanel.Controls.Clear();

            string spreadsheetId = "1lu-qmS_YiG8qeGFABSv_mb6iOjZGo91TIRGyPwrwP8k"; 
            string range = "Form Responses 1!A:F"; 

            var gformHandler = new GFormServiceHandler();
            var responses = gformHandler.GetResponses(spreadsheetId, range);

            foreach (var r in responses)
            {
                var model = new GFormResponseModel
                {
                    Name = r.Name,
                    Email = r.Email,
                    Timestamp = r.Timestamp,
                    question_1 = r.question_1,
                    question_2 = r.question_2,
                    question_3 = r.question_3,
                    question_4 = r.question_4,
                };

                var panel = CreateInboxPanel(model);
                GFormFlowLayoutPanel.Controls.Add(panel);
            }

        }



        private Panel CreateInboxPanel(GFormResponseModel response)
        {
            Panel panel = new Panel
            {
                Width = 1460,
                Height = 80,
                BackColor = Color.WhiteSmoke,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(3),
                Padding = new Padding(10),
                Tag = response
            };

            System.Windows.Forms.Label header = new System.Windows.Forms.Label
            {
                Text = $"From: @{response.Email.Split('@')[0]}",
                Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold),
                AutoSize = true,
                Dock = DockStyle.Top
            };

            System.Windows.Forms.Label preview = new System.Windows.Forms.Label
            {
                Text = "Received a report via Gform",
                Font = new Font("Microsoft Sans Serif", 10, FontStyle.Regular),
                AutoSize = true,
                Dock = DockStyle.Top,
                ForeColor = Color.Gray,
                Padding = new Padding(0, 5, 0, 0)
            };

            System.Windows.Forms.Label time = new System.Windows.Forms.Label
            {
                Text = response.Timestamp.ToString("MMMM dd, yyyy"),
                Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold),
                AutoSize = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
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
                        p.Width = 790;
                }

                currentSelectedPanel = panel;
                currentSelectedResponse = response;

                GFormFlowLayoutPanel.Size = new Size(803, 739);
                GFormFlowLayoutPanel.Location = new Point(20, 82);

                MessagePanel.Visible = true;
                FromLbl.Text = response.Email;
                DateLbl.Text = response.Timestamp.ToString("MMMM dd, yyyy");

                ContentTxt.Text =
                      "\nBATODA Report Case\n\n" +
                      $"Complainant Full Name: {response.Name}\n" +
                      $"Complaint: {response.question_1}\n" +
                      $"Driver involved Body/Plate no.: BATODA - ({response.question_2})\n" +
                      $"Complainant Contact Number: {response.question_3}\n\n" +
                      "This message was automatically generated following the reported incident. " +
                      "\nPlease review and respond promptly to ensure timely assistance and reassure the passenger.\n\n";
            };

            return panel;
        }


        private void CloseMessage_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in GFormFlowLayoutPanel.Controls)
            {
                if (ctrl is Panel p)
                {
                    p.Width = 1460;
                }
            }

            currentSelectedPanel = null;

            GFormFlowLayoutPanel.Size = new Size(1486, 725);
            GFormFlowLayoutPanel.Location = new Point(20, 82);

            MessagePanel.Visible = false;
        }

        private void CancelReplyButton_Click(object sender, EventArgs e)
        {
           
        }

        private void ReplyButton_Click(object sender, EventArgs e)
        {
            if (currentSelectedResponse == null)
            {
                MessageBox.Show("No report selected to reply to.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                "Would you like to send a response to the complainant to acknowledge that their concern has been received and is being addressed?",
                "Confirm Reply",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    string senderEmail = currentSelectedResponse.Email; 
                    string subject = "BATODA Concern Acknowledgment";
                    string body = "Good day,\n\n";
                    body += "Your concern for the ff:\n";
                    body += "Complaint: " + currentSelectedResponse.question_1 + "\n";
                    body += "Driver involved Body/Plate no.: BATODA - (" + currentSelectedResponse.question_2 + ")\n\n";
                    body += "We have received your report and your concern is duly noted. ";
                    body += "Rest assured, appropriate action will be taken regarding the driver involved. ";
                    body += "On behalf of BATODA, we sincerely apologize for the incident and any inconvenience caused.\n\n";
                    body += "- BATODA President";



                    SmtpClient client = new SmtpClient("smtp.gmail.com")
                    {
                        Port = 587,
                        Credentials = new NetworkCredential("markaronedc@gmail.com", "joyztgyuzszcehja"),
                        EnableSsl = true
                    };


                    MailMessage mail = new MailMessage("markaronedc@gmail.com", senderEmail, subject, body);
                    client.Send(mail);

                    MessageBox.Show("Reply sent successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to send email: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SendReplyButton_Click(object sender, EventArgs e)
        {

        }
    }
}