using BATODA.Modules.Assistance_Request_Module;
using BATODA.Modules.Assistance_Request_Module.Assistance_Classes;
using BATODA.User_Control_Forms;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

public class AddTicketBox
{
    private FlowLayoutPanel TicketFlowLayoutPanel;
    private FlowLayoutPanel ActivityLogFlowLayoutPanel;
    AssistanceRepository repo = new AssistanceRepository();

    // added field to track currently expanded box
    private Panel expandedPanel = null;

    public AddTicketBox(FlowLayoutPanel panel, FlowLayoutPanel activityLogPanel)
    {
        TicketFlowLayoutPanel = panel;
        ActivityLogFlowLayoutPanel = activityLogPanel;
    }
    public void CreateTicketBox(
        string trackingNumber,
        string fullName,
        string typeOfAid,
        string dateRequested,
        string status,
        string requestedBy,
        string amount,
        string assistanceThru,
        string contactNum,
        string dateNeeded)
    {
        Panel TicketBox = new Panel()
        {
            Size = new Size(300, 150),
            BackColor = Color.WhiteSmoke,
            BorderStyle = BorderStyle.FixedSingle,
            Margin = new Padding(5),
            Cursor = Cursors.Hand,
            Tag = false
        };

        int y = 10;

        // Header
        Panel HeaderPanel = new Panel()
        {
            Size = new Size(298, 30),
            Location = new Point(1, 1),
            BackColor = (status == "Approved") ? Color.LightGreen :
                        (status == "Rejected") ? Color.LightCoral :
                        Color.LightGray
        };

        Label lblTracking = new Label()
        {
            Text = "Tracking Number: " + trackingNumber,
            Location = new Point(10, 7),
            AutoSize = true,
            BackColor = HeaderPanel.BackColor,
            Font = new Font("Microsoft Sans Serif", 11, FontStyle.Bold)
        };
        HeaderPanel.Controls.Add(lblTracking);

        y += 25;

        // Picture
        PictureBox picMember = new PictureBox()
        {
            Location = new Point(10, y),
            Size = new Size(80, 80),
            BorderStyle = BorderStyle.FixedSingle,
            SizeMode = PictureBoxSizeMode.StretchImage,
            BackColor = Color.LightGray
        };

        int rightX = picMember.Right + 10;

        Label lblName = new Label()
        {
            Text = "Full Name: " + fullName,
            Location = new Point(rightX, y + 5),
            AutoSize = true,
            Font = new Font("Microsoft Sans Serif", 9)
        };

        Label lblAid = new Label()
        {
            Text = "Type of Aid: " + typeOfAid,
            Location = new Point(rightX, y + 30),
            AutoSize = true,
            Font = new Font("Microsoft Sans Serif", 9)
        };

        Label lblDate = new Label()
        {
            Text = "Date Requested: " + dateRequested,
            Location = new Point(rightX, y + 55),
            AutoSize = true,
            Font = new Font("Microsoft Sans Serif", 9)
        };

        Label lblStatus = new Label()
        {
            Text = "Status: " + status,
            Location = new Point(rightX, y + 80),
            AutoSize = true,
            Font = new Font("Microsoft Sans Serif", 9)
        };

        int expandY = picMember.Bottom + 19;

        Label lblRequestedBy = new Label()
        {
            Text = "Requested by: " + requestedBy,
            Location = new Point(10, expandY),
            AutoSize = true,
            Font = new Font("Microsoft Sans Serif", 9),
            Tag = "ExpandInfo",
            Visible = false
        };
        expandY += 22;

        Label lblAmount = new Label()
        {
            Text = "Amount: " + amount,
            Location = new Point(10, expandY),
            AutoSize = true,
            Font = new Font("Microsoft Sans Serif", 9),
            Tag = "ExpandInfo",
            Visible = false
        };
        expandY += 22;

        Label lblAssistanceThru = new Label()
        {
            Text = "Assistance Thru: " + assistanceThru,
            Location = new Point(10, expandY),
            AutoSize = true,
            Font = new Font("Microsoft Sans Serif", 9),
            Tag = "ExpandInfo",
            Visible = false
        };
        expandY += 22;

        Label lblContactNum = new Label()
        {
            Text = "Contact Num: " + contactNum,
            Location = new Point(10, expandY),
            AutoSize = true,
            Font = new Font("Microsoft Sans Serif", 9),
            Tag = "ExpandInfo",
            Visible = false
        };
        expandY += 22;

        Label dateNeededLbl = new Label()
        {
            Text = "Date Needed: " + dateNeeded,
            Location = new Point(10, expandY),
            AutoSize = true,
            Font = new Font("Microsoft Sans Serif", 9),
            Tag = "ExpandInfo",
            Visible = false
        };

        // Buttons (DECLARED BEFORE USE)
        Button approveBtn = new Button() { Text = "Approve", Location = new Point(10, expandY + 25), Size = new Size(80, 30) };
        Button rejectBtn = new Button() { Text = "Reject", Location = new Point(105, expandY + 25), Size = new Size(80, 30) };
        Button cancelBtn = new Button() { Text = "Cancel", Location = new Point(200, expandY + 25), Size = new Size(80, 30) };
        Button releaseBtn = new Button() { Text = "Release", Location = new Point(220, expandY + 25), Size = new Size(80, 30), Visible = false };

        // Button events
        approveBtn.Click += (s, e) =>
        {
            if (expandedPanel == TicketBox) expandedPanel = null;

            HeaderPanel.BackColor = Color.LightGreen;
            lblTracking.BackColor = Color.LightGreen;
            lblTracking.BringToFront();
            lblStatus.Text = "Status: Approved";

            int ticketID = Convert.ToInt32(trackingNumber.Replace("TR-", ""));
            repo.UpdateRequestStatus(ticketID, "Approved");

            approveBtn.Hide();
            cancelBtn.Hide();
            rejectBtn.Hide();
            releaseBtn.Visible = true;

            AddActivityLog("Request Approved",
                           $"Assistance request {trackingNumber} approved",
                           "request approved");
        };

        rejectBtn.Click += (s, e) =>
        {
            if (expandedPanel == TicketBox) expandedPanel = null;

            HeaderPanel.BackColor = Color.LightCoral;
            lblTracking.BackColor = Color.LightCoral;
            lblTracking.BringToFront();
            lblStatus.Text = "Status: Rejected";

            int ticketID = Convert.ToInt32(trackingNumber.Replace("TR-", ""));
            repo.UpdateRequestStatus(ticketID, "Rejected");

            approveBtn.Hide();
            cancelBtn.Hide();
            rejectBtn.Hide();

            AddActivityLog("Request Rejected",
                           $"Assistance request {trackingNumber} rejected",
                           "request rejected");

            TicketBox.Hide();
        };

        cancelBtn.Click += (s, e) =>
        {
            if (expandedPanel == TicketBox) expandedPanel = null;

            HeaderPanel.BackColor = Color.LightGray;
            lblTracking.BackColor = Color.LightGray;
            lblTracking.BringToFront();
            lblStatus.Text = "Status: Canceled";

            int ticketID = Convert.ToInt32(trackingNumber.Replace("TR-", ""));
            repo.UpdateRequestStatus(ticketID, "Canceled");

            approveBtn.Hide();
            cancelBtn.Hide();
            rejectBtn.Hide();

            AddActivityLog("Request Canceled",
                           $"Assistance request {trackingNumber} canceled",
                           "canceled");

            TicketBox.Hide();
        };

        releaseBtn.Click += (s, e) =>
        {
            if (expandedPanel == TicketBox) expandedPanel = null;
            TicketBox.Hide();
        };

        // Add controls to panel
        TicketBox.Controls.Add(HeaderPanel);
        TicketBox.Controls.Add(lblTracking);
        TicketBox.Controls.Add(picMember);
        TicketBox.Controls.Add(lblName);
        TicketBox.Controls.Add(lblAid);
        TicketBox.Controls.Add(lblDate);
        TicketBox.Controls.Add(lblStatus);
        TicketBox.Controls.Add(lblRequestedBy);
        TicketBox.Controls.Add(lblAmount);
        TicketBox.Controls.Add(lblAssistanceThru);
        TicketBox.Controls.Add(lblContactNum);
        TicketBox.Controls.Add(dateNeededLbl);
        TicketBox.Controls.Add(approveBtn);
        TicketBox.Controls.Add(rejectBtn);
        TicketBox.Controls.Add(cancelBtn);
        TicketBox.Controls.Add(releaseBtn);

        // Initial status colors
        if (status == "Approved")
        {
            HeaderPanel.BackColor = Color.LightGreen;
            lblTracking.BackColor = Color.LightGreen;
            releaseBtn.Visible = true;
        }
        else if (status == "Rejected" || status == "Canceled")
        {
            HeaderPanel.BackColor = (status == "Rejected") ? Color.LightCoral : Color.LightGray;
            lblTracking.BackColor = HeaderPanel.BackColor;
        }

        lblTracking.BringToFront();
        TicketBox.Click += TicketBox_Click;

        TicketFlowLayoutPanel.Controls.Add(TicketBox);
    }


    private void TicketBox_Click(object sender, EventArgs e)
    {
        Panel panel = sender as Panel;
        if (panel == null)
            return;

        // close previous panel
        if (expandedPanel != null && expandedPanel != panel)
        {
            CollapsePanel(expandedPanel);
            expandedPanel = null;
        }

        bool expand = !(bool)panel.Tag;

        if (expand)
        {
            ExpandPanel(panel);
            expandedPanel = panel;
        }
        else
        {
            CollapsePanel(panel);
            expandedPanel = null;
        }
    }

    private void ExpandPanel(Panel panel)
    {
        panel.Tag = true;
        panel.Height = 330;

        Label lblStatus = panel.Controls.OfType<Label>()
            .FirstOrDefault(l => l.Text.StartsWith("Status:"));

        string status = lblStatus.Text.Replace("Status:", "").Trim();

        foreach (Control c in panel.Controls)
        {
            if (c.Tag != null && c.Tag.ToString() == "ExpandInfo")
            {
                if (c is Button btn)
                {
                    if (status == "Approved")
                    {
                        c.Visible = btn.Text == "Release";
                    }
                    else if (status == "Rejected" || status == "Canceled")
                    {
                        c.Visible = false;
                    }
                    else
                    {
                        c.Visible = btn.Text == "Approve" ||
                                    btn.Text == "Reject" ||
                                    btn.Text == "Cancel";
                    }
                }
                else
                {
                    c.Visible = true;
                }
            }
        }
    }

    private void CollapsePanel(Panel panel)
    {
        panel.Tag = false;
        panel.Height = 150;

        foreach (Control c in panel.Controls)
        {
            if (c.Tag != null && c.Tag.ToString() == "ExpandInfo")
                c.Visible = false;
        }
    }


    // ----------------- Activity Log Methods Applied -----------------

    private void AddActivityLog(string actionTitle, string actionInfo, string status)
    {
        string timestamp = DateTime.Now.ToString("hh:mm tt");
        repo.InsertActionLog(actionTitle, actionInfo);

        ActivityassistanceLog logCard = new ActivityassistanceLog(timestamp, actionTitle, actionInfo, status);
        ActivityLogFlowLayoutPanel.Controls.Add(logCard);
        ActivityLogFlowLayoutPanel.Controls.SetChildIndex(logCard, 0);
        ActivityLogFlowLayoutPanel.ScrollControlIntoView(logCard);
    }

    public void LoadActivityLogs()
    {
        ActivityLogFlowLayoutPanel.Controls.Clear();

        var logs = repo.GetAllActionLogs();

        foreach (var log in logs)
        {
            string action = (log.RequestAction ?? "").Trim();
            string statusForImage;

            if (action.Equals("Request Approved", StringComparison.OrdinalIgnoreCase))
                statusForImage = "request approved";  // <-- match switch
            else if (action.Equals("Request Rejected", StringComparison.OrdinalIgnoreCase))
                statusForImage = "request rejected";  // <-- match switch
            else if (action.Equals("Request Canceled", StringComparison.OrdinalIgnoreCase))
                statusForImage = "canceled";          // <-- match switch
            else
                statusForImage = "unknown";

            ActivityassistanceLog logCard = new ActivityassistanceLog(
                log.DateDisplay,
                log.RequestAction,
                log.ActionDescription,
                statusForImage
            );

            ActivityLogFlowLayoutPanel.Controls.Add(logCard);
        }


    }


}
