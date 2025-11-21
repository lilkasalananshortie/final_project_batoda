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
        Panel TicketBox = new Panel();
        TicketBox.Size = new Size(300, 150);
        TicketBox.BackColor = Color.White;
        TicketBox.BorderStyle = BorderStyle.FixedSingle;
        TicketBox.Margin = new Padding(5);
        TicketBox.Cursor = Cursors.Hand;
        TicketBox.Tag = false;

        int y = 10;

        Panel HeaderPanel = new Panel()
        {
            Size = new Size(298, 30),
            Location = new Point(1, 1),
            BackColor = Color.LightGray
        };

        Label lblTracking = new Label()
        {
            Text = "Tracking Number: " + trackingNumber,
            Location = new Point(10, 7),
            AutoSize = true,
            Font = new Font("Microsoft Sans Serif", 10, FontStyle.Bold)

        };
        HeaderPanel.Controls.Add(lblTracking);

        y += 25;

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
            Tag = "ExpandInfo",
            Visible = false,
            Font = new Font("Microsoft Sans Serif", 9)
        };
        expandY += 22;

        Label lblAmount = new Label()
        {
            Text = "Amount: " + amount,
            Location = new Point(10, expandY),
            AutoSize = true,
            Tag = "ExpandInfo",
            Visible = false,
            Font = new Font("Microsoft Sans Serif", 9)
        };
        expandY += 22;

        Label lblAssistanceThru = new Label()
        {
            Text = "Assistance Thru: " + assistanceThru,
            Location = new Point(10, expandY),
            AutoSize = true,
            Tag = "ExpandInfo",
            Visible = false,
            Font = new Font("Microsoft Sans Serif", 9)
        };
        expandY += 22;

        Label lblContactNum = new Label()
        {
            Text = "Contact Num: " + contactNum,
            Location = new Point(10, expandY),
            AutoSize = true,
            Tag = "ExpandInfo",
            Visible = false,
            Font = new Font("Microsoft Sans Serif", 9)
        };
        expandY += 22;

        Label dateNeededLbl = new Label()
        {
            Text = "Date Needed: " + dateNeeded,
            Location = new Point(10, expandY),
            AutoSize = true,
            Tag = "ExpandInfo",
            Visible = false,
            Font = new Font("Microsoft Sans Serif", 9)
        };
        expandY += 34;

        Button approveBtn = new Button()
        {
            Text = "Approve",
            Size = new Size(80, 30),
            Location = new Point(10, expandY),
            Visible = false,
            Font = new Font("Microsoft Sans Serif", 9),
            Tag = "ExpandInfo"
        };

        Button rejectBtn = new Button()
        {
            Text = "Reject",
            Size = new Size(80, 30),
            Location = new Point(105, expandY),
            Visible = false,
            Font = new Font("Microsoft Sans Serif", 9),
            Tag = "ExpandInfo"
        };

        Button cancelBtn = new Button()
        {
            Text = "Cancel",
            Size = new Size(80, 30),
            Location = new Point(200, expandY),
            Visible = false,
            Font = new Font("Microsoft Sans Serif", 9),
            Tag = "ExpandInfo"
        };

        Button releaseBtn = new Button()
        {
            Text = "Release",
            Size = new Size(80, 30),
            Location = new Point(200, 260),
            Font = new Font("Microsoft Sans Serif", 9),
            Visible = false
        };


        approveBtn.Click += (s, e) =>
        {
            Panel parent = ((Button)s).Parent as Panel;
            HeaderPanel.BackColor = Color.LightGreen;
            lblTracking.BringToFront();
            lblTracking.BackColor = Color.LightGreen;
            lblStatus.Text = "Status: Approved";

            int ticketID = Convert.ToInt32(trackingNumber.Replace("TR-", ""));

            repo.UpdateRequestStatus(ticketID, "Approved");
            repo.UpdateActionDate(ticketID);

            releaseBtn.Visible = true;
            approveBtn.Hide();
            cancelBtn.Hide();
            rejectBtn.Hide();

            AddActivityLog("Request Approved", $"Assistance request {trackingNumber} approved", "request approved");


        };


        rejectBtn.Click += (s, e) =>
        {
            Panel parent = ((Button)s).Parent as Panel;
            HeaderPanel.BackColor = Color.LightCoral;
            lblTracking.BackColor = Color.LightCoral;
            lblTracking.BringToFront();
            lblStatus.Text = "Status: Rejected";
            int ticketID = Convert.ToInt32(trackingNumber.Replace("TR-", ""));

            repo.UpdateRequestStatus(ticketID, "Rejected");
            repo.UpdateActionDate(ticketID);

            approveBtn.Hide();
            cancelBtn.Hide();
            rejectBtn.Hide();

            AddActivityLog("Request Rejected", $"Assistance request {trackingNumber} rejected", "request rejected");
            parent.Hide();
        };


        cancelBtn.Click += (s, e) =>
        {
            Panel parent = ((Button)s).Parent as Panel;
            HeaderPanel.BackColor = Color.LightGray;
            lblTracking.BackColor = Color.LightGray;
            lblTracking.BringToFront();
            lblStatus.Text = "Status: Canceled";
            int ticketID = Convert.ToInt32(trackingNumber.Replace("TR-", ""));

            repo.UpdateRequestStatus(ticketID, "Canceled");
            repo.UpdateActionDate(ticketID);

            approveBtn.Hide();
            cancelBtn.Hide();
            rejectBtn.Hide();

            AddActivityLog("Request Canceled", $"Assistance request {trackingNumber} canceled", "canceled");
            parent.Hide();
        };

        releaseBtn.Click += (s, e) =>
        {
            Panel parent = ((Button)s).Parent as Panel;
            HeaderPanel.BackColor = Color.LightGray;
            lblTracking.BackColor = Color.LightGray;
            lblTracking.BringToFront();
            lblStatus.Text = "Status: Released";
            int ticketID = Convert.ToInt32(trackingNumber.Replace("TR-", ""));

            repo.UpdateRequestStatus(ticketID, "Released");
            repo.UpdateActionDate(ticketID);

            approveBtn.Hide();
            cancelBtn.Hide();
            rejectBtn.Hide();
            releaseBtn.Hide();

            AddActivityLog("Request Released", $"Assistance request {trackingNumber} released", "released");
            parent.Hide();
        };

        TicketBox.Controls.Add(HeaderPanel);
        TicketBox.Controls.Add(lblTracking);
        TicketBox.Controls.Add(picMember);
        TicketBox.Controls.Add(lblName);
        TicketBox.Controls.Add(lblAid);
        TicketBox.Controls.Add(lblDate);
        TicketBox.Controls.Add(lblRequestedBy);
        TicketBox.Controls.Add(lblAmount);
        TicketBox.Controls.Add(lblAssistanceThru);
        TicketBox.Controls.Add(lblContactNum);
        TicketBox.Controls.Add(lblStatus);
        TicketBox.Controls.Add(dateNeededLbl);
        TicketBox.Controls.Add(approveBtn);
        TicketBox.Controls.Add(rejectBtn);
        TicketBox.Controls.Add(cancelBtn);
        TicketBox.Controls.Add(releaseBtn);

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
        lblTracking.BackColor = Color.LightGray;

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

        panel.Height = isExpanded ? 330 : 150;

        foreach (Control control in panel.Controls)
        {
            if (control.Tag != null && control.Tag.ToString() == "ExpandInfo")
            {
                if (!isExpanded)
                {
                    control.Visible = false;
                    continue;
                }

                if (control is Button btn)
                {
                    Label lblStatus = panel.Controls.OfType<Label>()
                        .FirstOrDefault(l => l.Text.StartsWith("Status:"));
                    string status = lblStatus?.Text.Replace("Status:", "").Trim() ?? "";

                    if (status == "Approved")
                        control.Visible = btn.Text == "Release";
                    else if (status == "Rejected" || status == "Canceled")
                        control.Visible = false;
                    else
                        control.Visible = btn.Text == "Approve" || btn.Text == "Reject" || btn.Text == "Cancel";
                }
                else
                    control.Visible = isExpanded;
            }
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
                statusForImage = "request approved";  
            else if (action.Equals("Request Rejected", StringComparison.OrdinalIgnoreCase))
                statusForImage = "request rejected";  
            else if (action.Equals("Request Canceled", StringComparison.OrdinalIgnoreCase))
                statusForImage = "canceled";          
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