using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BATODA.User_Control_Forms;

namespace BATODA
{
    public partial class CalendarUForm : UserControl
    {
        private Dictionary<DateTime, List<CalendarEvent>> events = new Dictionary<DateTime, List<CalendarEvent>>();
        private DateTime selectedDate;
        public static int month, year;
        private static DateTime dateTime = DateTime.Now;
        public CalendarUForm()
        {
            InitializeComponent();

            AddEventPanel.Hide();
            CheckAttendancePanel.Hide();


        }



        private void CalendarUForm_Load(object sender, EventArgs e)
        {
            calendarDays();
        }
        public class CalendarEvent
        {
            public string Title { get; set; }
            public string Time { get; set; }
            public string Type { get; set; }
            public string Status { get; set; }
            public string Description { get; set; }
            public string Location { get; set; }
            public DateTime Date { get; set; }
        }

        public void calendarDays()
        {
            month = dateTime.Month;
            year = dateTime.Year;
            string monthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            lbDate.Text = $"{monthName} {year}";

            DateTime monthStart = new DateTime(year, month, 1);
            int daysInMonth = DateTime.DaysInMonth(year, month);

            // Previous month info
            int prevMonth = (month == 1) ? 12 : month - 1;
            int prevYear = (month == 1) ? year - 1 : year;
            int prevMonthDays = DateTime.DaysInMonth(prevYear, prevMonth);
            int startDayOfWeek = (int)monthStart.DayOfWeek;
            DayContainer.Controls.Clear();


            for (int i = startDayOfWeek - 1; i >= 0; i--)
            {
                DaysUForm prevDay = new DaysUForm();
                prevDay.days(prevMonthDays - i, prevMonth, prevYear);
                prevDay.BackColor = Color.LightGray;
                DayContainer.Controls.Add(prevDay);
            }


            for (int i = 1; i <= daysInMonth; i++)
            {
                DaysUForm currentDay = new DaysUForm();
                currentDay.days(i, month, year);
                DayContainer.Controls.Add(currentDay);
            }

            // fill all remaining cells 
            int totalCells = DayContainer.Controls.Count;
            int nextMonthDaysToAdd = 42 - totalCells;
            int nextMonth = (month == 12) ? 1 : month + 1;
            int nextYear = (month == 12) ? year + 1 : year;

            for (int i = 1; i <= nextMonthDaysToAdd; i++)
            {
                DaysUForm nextDay = new DaysUForm();
                nextDay.days(i, nextMonth, nextYear);
                nextDay.BackColor = Color.LightGray;
                DayContainer.Controls.Add(nextDay);

            }
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            DayContainer.Controls.Clear();
            month++;


            if (month > 12)
            {
                month = 1;
                year++;
            }

            dateTime = new DateTime(year, month, 1);
            calendarDays();
        }

        private void CancelEventButton_Click(object sender, EventArgs e)
        {
            AddEventPanel.Hide();
        }

        private void SaveEventButton_Click(object sender, EventArgs e)
        {
            if (selectedDate == default)
            {
                MessageBox.Show("Double-click a date before saving.");
                return;
            }

            string title = EvenTittleTextBox.Text.Trim();
            string type = EventTypeComboBox.Text.Trim();
            string status = StatusComboBox.Text.Trim();
            string location = EventLocationTextBox.Text.Trim();
            string description = NoteTextBox.Text.Trim();


            CalendarEvent newEvent = new CalendarEvent
            {
                Title = title,
                Type = type,
                Status = status,
                Location = location,
                Description = description,
                Date = selectedDate
            };


            if (!events.ContainsKey(selectedDate))
                events[selectedDate] = new List<CalendarEvent>();

            events[selectedDate].Add(newEvent);

            AddEventToOverview(newEvent);
            AddEventToDayCell(newEvent);

            AddEventPanel.Hide();

            EvenTittleTextBox.Clear();
            EventTypeComboBox.SelectedIndex = -1;
            
            EventLocationTextBox.Clear();
            NoteTextBox.Clear();

        }

        private void AddEventToOverview(CalendarEvent ev)
        {
            Panel panel = new Panel();
            panel.Size = new Size(425, 70);
            panel.BackColor = Color.WhiteSmoke;
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Margin = new Padding(5);
            panel.Tag = ev;

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
                ForeColor = Color.Gray,
                Location = new Point(10, 45),
                AutoSize = true
            };

            panel.Controls.Add(lblTitle);
            panel.Controls.Add(lblInfo);
            panel.Controls.Add(lblDate);

            panel.DoubleClick += EventPanel_DoubleClick;

            EventsOverviewFlowLayoutPanel.Controls.Add(panel);
            EventsOverviewFlowLayoutPanel.Controls.SetChildIndex(panel, 0);
        }

        private void EventPanel_DoubleClick(object sender, EventArgs e)
        {
            Panel clickedPanel = sender as Panel;
            if (clickedPanel == null) return;

            CalendarEvent ev = clickedPanel.Tag as CalendarEvent;
            if (ev == null) return;

            // Collapse others first
            foreach (Control ctrl in EventsOverviewFlowLayoutPanel.Controls)
            {
                if (ctrl is Panel pnl && pnl != clickedPanel && pnl.Height > 70)
                {
                    pnl.Height = 70;
                    var toRemove = pnl.Controls.OfType<Control>()
                        .Where(c => c.Tag?.ToString() == "Expanded").ToList();
                    foreach (var c in toRemove) pnl.Controls.Remove(c);
                }
            }

            bool isExpanded = clickedPanel.Height > 70;
            if (isExpanded)
            {
                clickedPanel.Height = 70;
                var toRemove = clickedPanel.Controls.OfType<Control>()
                    .Where(c => c.Tag?.ToString() == "Expanded").ToList();
                foreach (var c in toRemove) clickedPanel.Controls.Remove(c);
                return;
            }

            clickedPanel.Height = 200;

            Label lblDescription = new Label
            {
                Text = "Description: " + ev.Description,
                Location = new Point(10, 70),
                AutoSize = true,
                Tag = "Expanded"
            };

            Button btnDone = new Button
            {
                Text = "Done",
                BackColor = Color.LightGreen,
                Size = new Size(100, 30),
                Tag = "Expanded"
            };

            Button btnCancel = new Button
            {
                Text = "Cancel",
                BackColor = Color.LightCoral,
                Size = new Size(100, 30),
                Tag = "Expanded"
            };

            // Align buttons to the right bottom corner
            int marginRight = 20;
            int marginBottom = 15;
            btnCancel.Location = new Point(clickedPanel.Width - btnCancel.Width - marginRight, clickedPanel.Height - btnCancel.Height - marginBottom);
            btnDone.Location = new Point(btnCancel.Left - btnDone.Width - 10, btnCancel.Top);

            btnDone.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            btnCancel.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;

            btnDone.Click += (s, args) =>
            {
                MoveToPastEvents(ev, true);
                EventsOverviewFlowLayoutPanel.Controls.Remove(clickedPanel);
            };

            btnCancel.Click += (s, args) =>
            {
                MoveToPastEvents(ev, false);
                EventsOverviewFlowLayoutPanel.Controls.Remove(clickedPanel);
            };

            clickedPanel.Controls.Add(lblDescription);
            clickedPanel.Controls.Add(btnDone);
            clickedPanel.Controls.Add(btnCancel);
        }


        private void MoveToPastEvents(CalendarEvent ev, bool isDone)
        {
            Panel panel = new Panel();
            panel.Size = new Size(425, 70);
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Margin = new Padding(5);
            panel.BackColor = isDone ? Color.LightGreen : Color.LightCoral;

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

            // Insert new completed events on top
            PastEventFlowLayoutPanel.Controls.Add(panel);
            PastEventFlowLayoutPanel.Controls.SetChildIndex(panel, 0);
        }


        private void AddEventToDayCell(CalendarEvent ev)
        {
            foreach (Control ctrl in DayContainer.Controls)
            {
                if (ctrl is DaysUForm day && day.DateValue.Date == ev.Date.Date)
                {
                    Label info = new Label();
                    info.Text = ev.Title;
                    info.Font = new Font("Segoe UI", 7);
                    info.AutoSize = false;
                    info.Size = new Size(day.Width - 6, 25);
                    info.Location = new Point(3, day.Height - 28);
                    info.BackColor = Color.LightYellow;
                    info.TextAlign = ContentAlignment.MiddleCenter;

                    day.Controls.Add(info);
                    info.BringToFront();
                    break;
                }
            }
        }


        private void CheckAttendanceButton_Click(object sender, EventArgs e)
        {
            CheckAttendancePanel.Show();
            CheckAttendancePanel.BringToFront();
        }

        private void EditEventButton_Click(object sender, EventArgs e)
        {

        }

        private void SaveAttendanceButton_Click(object sender, EventArgs e)
        {
            CheckAttendancePanel.Hide();
        }

        private void previousButton_Click(object sender, EventArgs e)
        {
            DayContainer.Controls.Clear();
            month--;


            if (month < 1)
            {
                month = 12;
                year--;
            }

            dateTime = new DateTime(year, month, 1);
            calendarDays();
        }

        public void ShowAddEventPanel(DateTime date)
        {
            selectedDate = date;
            AddEventPanel.Show();
            AddEventPanel.BringToFront();
        }
    }
}
