using System;
using System.Drawing;
using System.Windows.Forms;
using BATODA.User_Control_Forms;

public class AddTicketBox
{
    private FlowLayoutPanel TicketFlowLayoutPanel;
    private FlowLayoutPanel ActivityLogFlowLayoutPanel;

    public AddTicketBox(FlowLayoutPanel panel, FlowLayoutPanel activityLogPanel)
    {
        TicketFlowLayoutPanel = panel;
        ActivityLogFlowLayoutPanel = activityLogPanel;
    }

    public void CreateTicketBox
    (string trackingNumber,
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
            Font = new Font("Segoe UI", 9, FontStyle.Bold)
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
            AutoSize = true
        };

        Label lblAid = new Label()
        {
            Text = "Type of Aid: " + typeOfAid,
            Location = new Point(rightX, y + 30),
            AutoSize = true
        };

        Label lblDate = new Label()
        {
            Text = "Date Requested: " + dateRequested,
            Location = new Point(rightX, y + 55),
            AutoSize = true
        };

        Label lblStatus = new Label()
        {
            Text = "Status: " + status,
            Location = new Point(rightX, y + 80),
            AutoSize = true
        };

        int expandY = picMember.Bottom + 19;

        Label lblRequestedBy = new Label()
        {
            Text = "Requested by: " + requestedBy,
            Location = new Point(10, expandY),
            AutoSize = true,
            Tag = "ExpandInfo",
            Visible = false
        };
        expandY += 22;

        Label lblAmount = new Label()
        {
            Text = "Amount: " + amount,
            Location = new Point(10, expandY),
            AutoSize = true,
            Tag = "ExpandInfo",
            Visible = false
        };
        expandY += 22;

        Label lblAssistanceThru = new Label()
        {
            Text = "Assistance Thru: " + assistanceThru,
            Location = new Point(10, expandY),
            AutoSize = true,
            Tag = "ExpandInfo",
            Visible = false
        };
        expandY += 22;

        Label lblContactNum = new Label()
        {
            Text = "Contact Num: " + contactNum,
            Location = new Point(10, expandY),
            AutoSize = true,
            Tag = "ExpandInfo",
            Visible = false
        };
        expandY += 22;

        Label dateNeededLbl = new Label()
        {
            Text = "Date Needed: " + dateNeeded,
            Location = new Point(10, expandY),
            AutoSize = true,
            Tag = "ExpandInfo",
            Visible = false
        };
        expandY += 34;

        Button approveBtn = new Button()
        {
            Text = "Approve",
            Size = new Size(80, 30),
            Location = new Point(10, expandY),
            Visible = false,
            Tag = "ExpandInfo"
        };

        Button rejectBtn = new Button()
        {
            Text = "Reject",
            Size = new Size(80, 30),
            Location = new Point(105, expandY),
            Visible = false,
            Tag = "ExpandInfo"
        };

        Button cancelBtn = new Button()
        {
            Text = "Cancel",
            Size = new Size(80, 30),
            Location = new Point(200, expandY),
            Visible = false,
            Tag = "ExpandInfo"
        };

        Button releaseBtn = new Button()
        {
            Text = "Release",
            Size = new Size(80, 30),
            Location = new Point(200, 260),
            Visible = false
        };

       


        approveBtn.Click += (s, e) =>
        {
            Panel parent = ((Button)s).Parent as Panel;
            HeaderPanel.BackColor = Color.LightGreen;
            lblTracking.BringToFront();
            lblTracking.BackColor = Color.LightGreen;
            lblStatus.Text = "Status: Approved";
            releaseBtn.Visible = true;
            releaseBtn.Show();
            approveBtn.Hide();
            cancelBtn.Hide();
            rejectBtn.Hide();

            AddActivityLog("Request Approved", $"Assistance request {trackingNumber} approved", "Success");

        };

        rejectBtn.Click += (s, e) =>
        {
            Panel parent = ((Button)s).Parent as Panel;
            HeaderPanel.BackColor = Color.LightCoral;
            lblTracking.BackColor = Color.LightCoral;
            lblTracking.BringToFront();
            lblStatus.Text = "Status: Rejected";
            approveBtn.Hide();
            cancelBtn.Hide();
            rejectBtn.Hide();

            AddActivityLog("Request Rejected", $"Assistance request {trackingNumber} rejected", "Failed");

            
            parent.Hide();

        };

        cancelBtn.Click += (s, e) =>
        {
            Panel parent = ((Button)s).Parent as Panel;
            HeaderPanel.BackColor = Color.LightGray;
            lblTracking.BackColor = Color.LightGray;
            lblTracking.BringToFront();
            lblStatus.Text = "Status: Canceled";
            approveBtn.Hide();
            cancelBtn.Hide();
            rejectBtn.Hide();
            parent.Hide();

            AddActivityLog("Request Canceled", $"Assistance request {trackingNumber} canceled", "canceled");

        };

        releaseBtn.Click += (s, e) =>
        {
            Panel parent = ((Button)s).Parent as Panel;
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
                control.Visible = isExpanded;
            }
        }
    }

    private void AddActivityLog(string actionTitle, string actionInfo, string status)
    {
        string timestamp = DateTime.Now.ToString("hh:mm tt"); 

        ActivityassistanceLog logCard = new ActivityassistanceLog(timestamp, actionTitle, actionInfo, status);

        ActivityLogFlowLayoutPanel.Controls.Add(logCard);
        ActivityLogFlowLayoutPanel.Controls.SetChildIndex(logCard, 0);

        ActivityLogFlowLayoutPanel.ScrollControlIntoView(logCard);
    }

}
