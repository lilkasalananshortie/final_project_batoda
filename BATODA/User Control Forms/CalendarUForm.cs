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
        private CalendarEvent editingEvent;
        private readonly object eventLock = new object();
        private Panel selectedEventPanel = null;

        //WAG IBAHINNESS
        private const int EventPanelWidth = 425;
        private const int EventPanelHeight = 70;
        private const int EventPanelMargin = 5;
        private const int EventLabelHeight = 20;
        private const int EventLabelSpacing = 22;

        public int month;
        public int year;
        private DateTime dateTime = DateTime.Now;

        public CalendarUForm()
        {
            InitializeComponent();

            AddEventPanel.Hide();
            CheckAttendancePanel.Hide();
        }

        private void CalendarUForm_Load(object sender, EventArgs e)
        {
            month = dateTime.Month;
            year = dateTime.Year;
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
            string monthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            lbDate.Text = $"{monthName} {year}";

            DateTime monthStart = new DateTime(year, month, 1);
            int daysInMonth = DateTime.DaysInMonth(year, month);

            int prevMonth = (month == 1) ? 12 : month - 1;
            int prevYear = (month == 1) ? year - 1 : year;
            int prevMonthDays = DateTime.DaysInMonth(prevYear, prevMonth);
            int startDayOfWeek = (int)monthStart.DayOfWeek;

            DayContainer.SuspendLayout();
            DayContainer.Controls.Clear();

            for (int i = startDayOfWeek - 1; i >= 0; i--)
            {
                DaysUForm prevDay = new DaysUForm();
                prevDay.days(prevMonthDays - i, prevMonth, prevYear);
                prevDay.BackColor = Color.LightGray;
                DisablePastDay(prevDay);
                DayContainer.Controls.Add(prevDay);
            }

            for (int i = 1; i <= daysInMonth; i++)
            {
                DaysUForm currentDay = new DaysUForm();
                currentDay.days(i, month, year);
                currentDay.BackColor = Color.White;
                DisablePastDay(currentDay);
                DayContainer.Controls.Add(currentDay);
            }

            int totalCells = DayContainer.Controls.Count;
            int nextMonthDaysToAdd = 42 - totalCells;
            int nextMonth = (month == 12) ? 1 : month + 1;
            int nextYear = (month == 12) ? year + 1 : year;

            for (int i = 1; i <= nextMonthDaysToAdd; i++)
            {
                DaysUForm nextDay = new DaysUForm();
                nextDay.days(i, nextMonth, nextYear);
                nextDay.BackColor = Color.LightGray;
                DisablePastDay(nextDay);
                DayContainer.Controls.Add(nextDay);
            }

            DayContainer.ResumeLayout();

            RefreshEventIndicators();
        }

       
        private void DisablePastDay(DaysUForm day)
        {
            
            if (day.DateValue.Date < DateTime.Today)
            {
                day.Enabled = false;
                day.BackColor = Color.DarkGray; 
            }
        }

        private void RefreshEventIndicators()
        {
            foreach (var dateEvents in events)
            {
                if (dateEvents.Key.Month == month && dateEvents.Key.Year == year)
                {
                    foreach (var evt in dateEvents.Value)
                    {
                        AddEventToDayCell(evt);
                    }
                }
            }
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
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
            editingEvent = null;
            SaveEventButton.Text = "Save";
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
            string time = EventTimePicker.Value.ToString("HH:mm");

            lock (eventLock)
            {
                if (editingEvent != null)
                {
                    editingEvent.Title = title;
                    editingEvent.Type = type;
                    editingEvent.Status = status;
                    editingEvent.Location = location;
                    editingEvent.Description = description;
                    editingEvent.Time = time;
                    editingEvent.Date = selectedDate;

                    UpdateEventPanel(editingEvent);
                    UpdateEventInDayCell(editingEvent);
                    editingEvent = null;
                    SaveEventButton.Text = "Save";
                }
                else
                {
                    CalendarEvent newEvent = new CalendarEvent
                    {
                        Title = title,
                        Type = type,
                        Status = status,
                        Location = location,
                        Description = description,
                        Time = time,
                        Date = selectedDate
                    };

                    if (!events.ContainsKey(selectedDate))
                        events[selectedDate] = new List<CalendarEvent>();

                    events[selectedDate].Add(newEvent);

                    AddEventToOverview(newEvent);
                    AddEventToDayCell(newEvent);
                }
            }

            AddEventPanel.Hide();

            EvenTittleTextBox.Clear();
            EventTypeComboBox.SelectedIndex = -1;
            StatusComboBox.Clear();
            EventLocationTextBox.Clear();
            NoteTextBox.Clear();
            EventTimePicker.Value = DateTime.Now;
        }
        //ADDING OF EVENT AFTER SAVING
        private void AddEventToOverview(CalendarEvent ev)
        {
            Panel panel = new Panel();
            panel.Size = new Size(EventPanelWidth, EventPanelHeight);
            panel.BackColor = Color.WhiteSmoke;
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Margin = new Padding(EventPanelMargin);
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

            panel.DoubleClick += EventPanel_DoubleClick;
            panel.Click += EventPanel_Click;

            int insertIndex = 0;
            foreach (Control ctrl in EventsOverviewFlowLayoutPanel.Controls)
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

            EventsOverviewFlowLayoutPanel.Controls.Add(panel);
            EventsOverviewFlowLayoutPanel.Controls.SetChildIndex(panel, insertIndex);
        }

        private void EventPanel_Click(object sender, EventArgs e)
        {
            selectedEventPanel = sender as Panel;
        }

        private void UpdateEventPanel(CalendarEvent evt)
        {
            foreach (Control ctrl in EventsOverviewFlowLayoutPanel.Controls)
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
        //EXPAND AND COLLAPSE PANEL
        private void EventPanel_DoubleClick(object sender, EventArgs e)
        {
            Panel clickedPanel = sender as Panel;
            if (clickedPanel == null) return;

            CalendarEvent ev = clickedPanel.Tag as CalendarEvent;
            if (ev == null) return;

            selectedEventPanel = clickedPanel;

            foreach (Control ctrl in EventsOverviewFlowLayoutPanel.Controls)
            {
                if (ctrl is Panel pnl && pnl != clickedPanel)
                {
                    CollapsePanel(pnl);
                }
            }

            if (clickedPanel.Height > EventPanelHeight)
            {
                CollapsePanel(clickedPanel);
            }
            else
            {
                ExpandPanel(clickedPanel, ev);
            }
        }

        private void CollapsePanel(Panel panel)
        {
            panel.Height = EventPanelHeight;
            var toRemove = panel.Controls.OfType<Control>()
                .Where(c => c.Tag?.ToString() == "Expanded").ToList();
            foreach (var c in toRemove) panel.Controls.Remove(c);
        }

        private void ExpandPanel(Panel panel, CalendarEvent ev)
        {
            panel.Height = 200;

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

            int marginRight = 20;
            int marginBottom = 15;
            btnCancel.Location = new Point(panel.Width - btnCancel.Width - marginRight, panel.Height - btnCancel.Height - marginBottom);
            btnDone.Location = new Point(btnCancel.Left - btnDone.Width - 10, btnCancel.Top);

            btnDone.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            btnCancel.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;

            btnDone.Click += (s, args) =>
            {
                ev.Status = "Done";
                UpdateEventInDayCell(ev);
                MoveToPastEvents(ev, true);
                EventsOverviewFlowLayoutPanel.Controls.Remove(panel);
                if (selectedEventPanel == panel)
                    selectedEventPanel = null;
            };

            btnCancel.Click += (s, args) =>
            {
                ev.Status = "Canceled";
                UpdateEventInDayCell(ev);
                MoveToPastEvents(ev, false);
                EventsOverviewFlowLayoutPanel.Controls.Remove(panel);
                if (selectedEventPanel == panel)
                    selectedEventPanel = null;
            };

            panel.Controls.Add(lblDescription);
            panel.Controls.Add(btnDone);
            panel.Controls.Add(btnCancel);
        }
        //MOVE TO PAST EVENTS PANEL
        private void MoveToPastEvents(CalendarEvent ev, bool isDone)
        {
            Panel panel = new Panel();
            panel.Size = new Size(EventPanelWidth, EventPanelHeight);
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Margin = new Padding(EventPanelMargin);
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

            PastEventFlowLayoutPanel.Controls.Add(panel);
            PastEventFlowLayoutPanel.Controls.SetChildIndex(panel, 0);
        }
        //ADDING OF EVENT LABEL TO DAY CELL IN CALENDAR NOW CAN ADD MULTIPLE EVENTS IN THE SAME DAY 
        private void AddEventToDayCell(CalendarEvent ev)
        {
            foreach (Control ctrl in DayContainer.Controls)
            {
                if (ctrl is DaysUForm day && day.DateValue.Date == ev.Date.Date)
                {
                    int eventCount = day.Controls.OfType<Label>().Count();

                    Color backColor;
                    if (ev.Status == "Done")
                        backColor = Color.LightGreen;
                    else if (ev.Status == "Canceled")
                        backColor = Color.LightCoral;
                    else
                        backColor = GetEventColor(ev.Type);

                    Label info = new Label
                    {
                        Text = ev.Title,
                        Font = new Font("Segoe UI", 7),
                        AutoSize = false,
                        Size = new Size(day.Width - 6, EventLabelHeight),
                        Location = new Point(3, day.Height - 28 - (eventCount * EventLabelSpacing)),
                        BackColor = backColor,
                        TextAlign = ContentAlignment.MiddleLeft
                    };

                    day.Controls.Add(info);
                    info.BringToFront();
                    break;
                }
            }
        }

        private void UpdateEventInDayCell(CalendarEvent ev)
        {
            foreach (Control ctrl in DayContainer.Controls)
            {
                if (ctrl is DaysUForm day && day.DateValue.Date == ev.Date.Date)
                {
                    foreach (Control child in day.Controls)
                    {
                        if (child is Label lbl && lbl.Text == ev.Title)
                        {
                            if (ev.Status == "Done")
                                lbl.BackColor = Color.LightGreen;
                            else if (ev.Status == "Canceled")
                                lbl.BackColor = Color.LightCoral;
                            else
                                lbl.BackColor = GetEventColor(ev.Type);
                            break;
                        }
                    }
                    break;
                }
            }
        }
        //COLOR CODE FOR EVENT TYPES
        private Color GetEventColor(string eventType)
        {
            switch (eventType)
            {
                case "Meeting":
                    return Color.LightBlue;
                case "Collection":
                    return Color.Salmon;
                case "Reminder":
                    return Color.LightYellow;
                case "Relief":
                    return Color.LightGreen;
                default:
                    return Color.LightGray;
            }
        }

        private void CheckAttendanceButton_Click(object sender, EventArgs e)
        {
            CheckAttendancePanel.Show();
            CheckAttendancePanel.BringToFront();
        }

        private void EditEventButton_Click(object sender, EventArgs e)
        {
            if (selectedEventPanel != null && selectedEventPanel.Tag is CalendarEvent evt)
            {
                EvenTittleTextBox.Text = evt.Title;
                EventTypeComboBox.Text = evt.Type;
                StatusComboBox.Text = evt.Status;
                EventLocationTextBox.Text = evt.Location;
                NoteTextBox.Text = evt.Description;

                if (TimeSpan.TryParse(evt.Time, out TimeSpan time))
                {
                    EventTimePicker.Value = DateTime.Today.Add(time);
                }

                selectedDate = evt.Date;
                editingEvent = evt;
                SaveEventButton.Text = "Update";
                AddEventPanel.Show();
                AddEventPanel.BringToFront();
            }
        }

        private void SaveAttendanceButton_Click(object sender, EventArgs e)
        {
            CheckAttendancePanel.Hide();
        }

        private void previousButton_Click(object sender, EventArgs e)
        {
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
            if (date.Date < DateTime.Today)
            {
                MessageBox.Show("Cannot add events to past dates.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            selectedDate = date;
            AddEventPanel.Show();
            AddEventPanel.BringToFront();
        }
    }
}