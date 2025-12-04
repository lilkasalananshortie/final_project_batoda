using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BATODA.User_Control_Forms;
using System.Windows.Forms;

namespace BATODA.Modules.Schedule_Module
{
    internal class EventPanelUI
    {
        private const int PanelWidth = 420;
        private const int PanelHeight = 70;
        private const int PanelMargin = 5;
        private const int ExpandedHeight = 150;


        public static Panel CreateEventPanel(CalendarEvent ev, EventPanelType type, Panel hoverPanel, Label hoverLabel)
        {
            Panel panel = new Panel
            {
                Width = PanelWidth,
                Height = PanelHeight,
                Margin = new Padding(PanelMargin),
                BorderStyle = BorderStyle.FixedSingle,
                Tag = ev,
                BackColor = GetStatusColor(ev.Status)
            };

            // Title
            Label lblTitle = new Label
            {
                Text = ev.Title,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(10, 5),
                AutoSize = true
            };

            // Info
            Label lblInfo = new Label
            {
                Text = $"{ev.Type} | {ev.Status} | {ev.Location} | {ev.Time}",
                Font = new Font("Segoe UI", 8),
                Location = new Point(10, 25),
                AutoSize = true
            };

            // Date
            Label lblDate = new Label
            {
                Text = ev.Date.ToString("MMMM d, yyyy"),
                Font = new Font("Segoe UI", 8, FontStyle.Italic),
                ForeColor = Color.Gray,
                Location = new Point(10, 45),
                AutoSize = true
            };

            panel.Controls.Add(lblTitle);
            panel.Controls.Add(lblInfo);
            panel.Controls.Add(lblDate);

            // Hover preview
            panel.MouseHover += (s, e) =>
            {
                hoverLabel.Text = $"Event: {ev.Title}\nLocation: {ev.Location}\nDate: {ev.Date:MMMM d, yyyy}";
                Point screenPos = panel.PointToScreen(new Point(panel.Right + 5, panel.Top));
                hoverPanel.Location = panel.FindForm().PointToClient(screenPos);
                hoverPanel.Visible = true;
                hoverPanel.BringToFront();
            };

            panel.MouseLeave += (s, e) =>
            {
                hoverPanel.Visible = false;
            };


            if (type != EventPanelType.Past)
                panel.DoubleClick += (s, e) => ToggleExpand(panel, ev);

            return panel;
        }

        public static void AddEventToDayCell(DaysUForm day, CalendarEvent ev)
        {
            int existing = day.Controls.OfType<Label>().Count();

            Label lbl = new Label()
            {
                Text = ev.Title,
                Font = new Font("Segoe UI", 7),
                AutoSize = false,
                Size = new Size(day.Width - 6, 18),
                Location = new Point(3, day.Height - 28 - (existing * 20)),
                BackColor = GetStatusColor(ev.Status),
                TextAlign = ContentAlignment.MiddleLeft
            };

            day.Controls.Add(lbl);
            lbl.BringToFront();
        }
        private static void ToggleExpand(Panel panel, CalendarEvent ev)
        {
            if (panel.Height > PanelHeight)
            {
                Collapse(panel);
                return;
            }

            Expand(panel, ev);
        }

        private static void Expand(Panel panel, CalendarEvent ev)
        {
            panel.Height = ExpandedHeight;

            Label lblDesc = new Label()
            {
                Text = "Description: " + ev.Description,
                Location = new Point(10, 70),
                AutoSize = true,
                Tag = "Expanded"
            };

            Button btnDone = new Button()
            {
                Text = "Done",
                BackColor = Color.LightGreen,
                Size = new Size(90, 30),
                Tag = "Expanded"
            };

            Button btnCancel = new Button()
            {
                Text = "Cancel",
                BackColor = Color.LightCoral,
                Size = new Size(90, 30),
                Tag = "Expanded"
            };

            btnCancel.Location = new Point(panel.Width - btnCancel.Width - 15,
                                           panel.Height - btnCancel.Height - 10);
            btnDone.Location = new Point(btnCancel.Left - btnDone.Width - 10, btnCancel.Top);

            panel.Controls.Add(lblDesc);
            panel.Controls.Add(btnDone);
            panel.Controls.Add(btnCancel);
        }

        private static void Collapse(Panel panel)
        {
            panel.Height = PanelHeight;

            var expandControls = panel.Controls
                                      .OfType<Control>()
                                      .Where(c => c.Tag?.ToString() == "Expanded")
                                      .ToList();

            foreach (var c in expandControls)
                panel.Controls.Remove(c);
        }


        private static Color GetStatusColor(string status)
        {
            switch (status)
            {
                case "Done":
                    return Color.Green;

                case "Canceled":
                    return Color.Red;

                default:
                    return Color.White;
            }
        }


    }


    public enum EventPanelType
    {
        Overview,
        Previous,
        Past
    }
}
   
