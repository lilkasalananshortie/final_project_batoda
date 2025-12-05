using System;
using System.Drawing;
using System.Windows.Forms;
using BATODA.Modules.MemberModule;

namespace BATODA.Modules.Schedule_Module
{
    internal static class PanelsHandler
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
            FlowLayoutPanel targetPanel = hasAttendance ? pastEventPanel : doneEventPanel;
            EventHandler doubleClickHandler = hasAttendance ? pastDoubleClickHandler : doneDoubleClickHandler;

            if (targetPanel.InvokeRequired)
            {
                targetPanel.Invoke(new Action(() =>
                {
                    MoveToPreviousEvents(ev, hasAttendance, pastEventPanel, doneEventPanel, pastDoubleClickHandler, doneDoubleClickHandler, panelHeight, margin);
                }));
                return;
            }

            Panel panel = new Panel
            {
                Size = new Size(hasAttendance ? 520 : 410, panelHeight),
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(margin),
                Tag = ev,
                BackColor = Color.LightGreen
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

            targetPanel.Controls.Add(panel);
            targetPanel.Controls.SetChildIndex(panel, 0);

            panel.DoubleClick += doubleClickHandler;
        }

        public static void AddDoneEventWithNoAttendees(
         CalendarEvent ev,
        FlowLayoutPanel pastEventPanel,
        EventHandler pastDoubleClickHandler,
        int panelHeight = 70,
        int panelMargin = 5)
        {
            if (pastEventPanel.InvokeRequired)
            {
                pastEventPanel.Invoke(new Action(() =>
                {
                    AddDoneEventWithNoAttendees(ev, pastEventPanel, pastDoubleClickHandler, panelHeight, panelMargin);
                }));
                return;
            }

            Panel panel = new Panel
            {
                Size = new Size(520, panelHeight),
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(panelMargin),
                BackColor = Color.LightGreen,
                Tag = ev
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

            pastEventPanel.Controls.Add(panel);
            pastEventPanel.Controls.SetChildIndex(panel, 0);

            panel.DoubleClick += pastDoubleClickHandler;
        }

        public static void UpdateEventPanel(CalendarEvent evt, FlowLayoutPanel eventsOverviewPanel)
        {
            foreach (Control ctrl in eventsOverviewPanel.Controls)
            {
                if (ctrl is Panel panel && panel.Tag == evt)
                {
                    foreach (Control child in panel.Controls)
                    {
                        if (child is Label lbl)
                        {
                            if (lbl.Font.Bold)
                                lbl.Text = evt.Title;
                            else if (!lbl.Font.Italic)
                                lbl.Text = $"{evt.Type} | {evt.Status} | {evt.Location} | {evt.Time}";
                        }
                    }
                    break;
                }
            }
        }


    }
}
