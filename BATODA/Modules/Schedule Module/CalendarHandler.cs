using BATODA.User_Control_Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace BATODA.Modules.Schedule_Module
{
    internal class CalendarHandler
    {
        public static void GenerateCalendarDays(
            FlowLayoutPanel container,
            int month,
            int year,
            Action<DaysUForm> disablePastDayAction)
        {
            container.SuspendLayout();
            container.Controls.Clear();

            DateTime monthStart = new DateTime(year, month, 1);
            int daysInMonth = DateTime.DaysInMonth(year, month);

            int prevMonth = (month == 1) ? 12 : month - 1;
            int prevYear = (month == 1) ? year - 1 : year;
            int prevMonthDays = DateTime.DaysInMonth(prevYear, prevMonth);
            int startDayOfWeek = (int)monthStart.DayOfWeek;

            // Previous month days
            for (int i = startDayOfWeek - 1; i >= 0; i--)
            {
                DaysUForm prevDay = new DaysUForm();
                prevDay.days(prevMonthDays - i, prevMonth, prevYear);
                prevDay.BackColor = Color.LightGray;
                disablePastDayAction?.Invoke(prevDay);
                container.Controls.Add(prevDay);
            }

            // Current month days
            for (int i = 1; i <= daysInMonth; i++)
            {
                DaysUForm currentDay = new DaysUForm();
                currentDay.days(i, month, year);
                currentDay.BackColor = Color.White;
                disablePastDayAction?.Invoke(currentDay);
                container.Controls.Add(currentDay);
            }

            // Next month days to fill 42 cells
            int totalCells = container.Controls.Count;
            int nextMonthDaysToAdd = 42 - totalCells;
            int nextMonth = (month == 12) ? 1 : month + 1;
            int nextYear = (month == 12) ? year + 1 : year;

            for (int i = 1; i <= nextMonthDaysToAdd; i++)
            {
                DaysUForm nextDay = new DaysUForm();
                nextDay.days(i, nextMonth, nextYear);
                nextDay.BackColor = Color.LightGray;
                disablePastDayAction?.Invoke(nextDay);
                container.Controls.Add(nextDay);
            }

            container.ResumeLayout();
        }

        public static void DisplayCalendarDays(
            int month,
            int year,
            FlowLayoutPanel dayContainer,
            Label monthYearLabel,
            Dictionary<DateTime, List<CalendarEvent>> events,
            Action<CalendarEvent> addEventToDayCell)
        {
            string monthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            monthYearLabel.Text = $"{monthName} {year}";

            GenerateCalendarDays(dayContainer, month, year, DisablePastDay);

            RefreshEventIndicators(dayContainer, month, year, events, addEventToDayCell);
        }

        public static void DisablePastDay(DaysUForm day)
        {
            if (day.DateValue.Date < DateTime.Today)
            {
                day.Enabled = false;
                day.BackColor = Color.DarkGray;
            }
        }

        public static void RefreshEventIndicators(
            FlowLayoutPanel container,
            int month,
            int year,
            Dictionary<DateTime, List<CalendarEvent>> events,
            Action<CalendarEvent> addEventToDayCell)
        {
            foreach (var dateEvents in events)
            {
                if (dateEvents.Key.Month == month && dateEvents.Key.Year == year)
                {
                    foreach (var evt in dateEvents.Value)
                    {
                        addEventToDayCell(evt);
                    }
                }
            }
        }

        public static void AddEventToOverview(
        CalendarEvent ev,
        FlowLayoutPanel eventsOverviewPanel,
        EventHandler eventPanelDoubleClick,
        EventHandler eventPanelClick,
        int panelWidth = 410,
        int panelHeight = 70,
        int panelMargin = 5)
        {
            Panel panel = new Panel
            {
                Size = new Size(panelWidth, panelHeight),
                BackColor = Color.WhiteSmoke,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(panelMargin),
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
                Text = $"{ev.Type} | {ev.Status} | {ev.Location} | {ev.Time}",
                Font = new Font("Segoe UI", 8),
                Location = new Point(10, 25),
                AutoSize = true
            };

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

            panel.DoubleClick += eventPanelDoubleClick;
            panel.Click += eventPanelClick;

            int insertIndex = 0;
            foreach (Control ctrl in eventsOverviewPanel.Controls)
            {
                if (ctrl is Panel pnl && pnl.Tag is CalendarEvent existingEv)
                {
                    if (ev.Date < existingEv.Date ||
                        (ev.Date == existingEv.Date && ev.Time.CompareTo(existingEv.Time) < 0))
                    {
                        break;
                    }
                    insertIndex++;
                }
            }

            eventsOverviewPanel.Controls.Add(panel);
            eventsOverviewPanel.Controls.SetChildIndex(panel, insertIndex);
        }


    }
}
