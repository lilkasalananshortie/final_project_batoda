using System;
using System.Drawing;
using System.Windows.Forms;
using BATODA.Modules.MemberModule;

namespace BATODA.Modules.Schedule_Module
{
    internal static class DoneToPreviousEvents
    {
        public static void MoveToPreviousEvents(
            CalendarEvent ev,
            bool hasAttendance,
            FlowLayoutPanel pastEventPanel,
            FlowLayoutPanel doneEventPanel,
            EventHandler pastDoubleClickHandler,
            EventHandler doneDoubleClickHandler,
            int panelHeight = 70,
            int margin = 5)
        {
            Panel panel = new Panel
            {
                Size = new Size(410, panelHeight),
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(margin),
                Tag = ev,
                BackColor = hasAttendance ? Color.LightGreen : Color.LightCoral
            };

            Label lblTitle = new Label
            {
                Text = ev.Title,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(10, 5),
                AutoSize = true
            };

            Label lblInfo = new Label
            {
                Text = $"{ev.Type} | {ev.Status} | {ev.Location}",
                Font = new Font("Segoe UI", 8),
                Location = new Point(10, 25),
                AutoSize = true
            };

            Label lblDate = new Label
            {
                Text = ev.Date.ToString("MMMM d, yyyy"),
                Font = new Font("Segoe UI", 8, FontStyle.Italic),
                ForeColor = Color.Black,
                Location = new Point(10, 45),
                AutoSize = true
            };

            panel.Controls.Add(lblTitle);
            panel.Controls.Add(lblInfo);
            panel.Controls.Add(lblDate);

            if (hasAttendance)
            {
                pastEventPanel.Controls.Add(panel);
                panel.DoubleClick += pastDoubleClickHandler;
                pastEventPanel.Controls.SetChildIndex(panel, 0);
            }
            else
            {
                doneEventPanel.Controls.Add(panel);
                panel.DoubleClick += doneDoubleClickHandler;
                doneEventPanel.Controls.SetChildIndex(panel, 0);
            }
        }
    }
}
