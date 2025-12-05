using BATODA.Helpers.DataGrid;
using BATODA.Helpers.DataGrids;
using BATODA.Modules.MemberModule;
using BATODA.Modules.Schedule_Module;
using BATODA.Repositories;
using BATODA.User_Control_Forms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BATODA
{
    public partial class CalendarUForm : UserControl
    {
        private Dictionary<DateTime, List<CalendarEvent>> events = new Dictionary<DateTime, List<CalendarEvent>>();
        private DateTime selectedDate;
        private CalendarEvent editingEvent;
        private readonly object eventLock = new object();
        private Panel selectedEventPanel = null;
        private Panel previousEventSelectedPanel = null;
        private Panel selectedPastEventPanel = null;

        //WAG IBAHINNESS
        private const int EventPanelWidth = 420;
        private const int EventPanelHeight = 70;
        private const int EventPanelMargin = 5;
        private const int EventLabelHeight = 20;
        private const int EventLabelSpacing = 22;

        public int month;
        public int year;
        private DateTime dateTime = DateTime.Now;

        // COORDS
        private string selectedCoords = "";

        private readonly EventRepository eventRepo = new EventRepository();


        public CalendarUForm()
        {
            InitializeComponent();
            AttendanceHandler.ApplyCustomGridWithCheckbox(SetAttendanceGrid);
            AttendanceHandler.ApplyCustomGridWithCheckbox(AttendanceListDGV);
            AddEventPanel.Hide();
            CheckAttendancePanel.Hide();
            ReqAttendeesCmb.SelectedIndexChanged += ReqAttendeesCmb_SelectedIndexChanged;
            DefaultAttendancePanel.Show();
            MiniPanel.Visible = false;

        }

        private void WebViewMap_WebMessageReceived(object sender, Microsoft.Web.WebView2.Core.CoreWebView2WebMessageReceivedEventArgs e)
        {
            selectedCoords = e.TryGetWebMessageAsString();
        }

        private async void CalendarUForm_Load(object sender, EventArgs e)
        {

            var allEvents = eventRepo.GetAllEvents();

            foreach (var ev in allEvents)
            {
                if (!events.ContainsKey(ev.Date))
                    events[ev.Date] = new List<CalendarEvent>();
                events[ev.Date].Add(ev);

                // PENDING EVENTS
                if (ev.Status == "Pending")
                    CalendarHandler.AddEventToOverview(ev, EventsOverviewFlowLayoutPanel, EventPanel_DoubleClick,
                    EventPanel_Click, EventPanelWidth, EventPanelHeight, EventPanelMargin);

                // DONE: All / Specific members
                if (ev.Status == "Done" &&
                   (ev.RequiredAttendees == "All Members" || ev.RequiredAttendees == "Specific Members Only"))
                {
                    // CHECK IF ATTENDANCE EXISTS FOR THIS EVENT
                    bool hasAttendance = eventRepo.EventHasAttendance(ev.EventId);
                    PanelsHandler.MoveToPreviousEvents(
                        ev,
                        hasAttendance,
                        PastEventFlowLayoutPanel,
                        DoneEventFlowLayoutPanel,
                        PastEventPanel_DoubleClick,
                        DoneEventPanel_DoubleClick
                    );
                }


                // DONE: None (go straight to PastEventFlowLayoutPanel)
                if (ev.Status == "Done" &&
                    ev.RequiredAttendees == "None")
                {
                    PanelsHandler.AddDoneEventWithNoAttendees(ev, PastEventFlowLayoutPanel, PastEventPanel_DoubleClick, EventPanelHeight, EventPanelMargin);

                }
            }

            await webViewMap.EnsureCoreWebView2Async(null);
            webViewMap.WebMessageReceived += WebViewMap_WebMessageReceived;
            string html = @"
            <!DOCTYPE html>
            <html>
            <head>
                <meta charset=""utf-8"" />
                <title>OSM Click + Search</title>
                <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                <link rel=""stylesheet"" href=""https://unpkg.com/leaflet@1.9.4/dist/leaflet.css""/>
                <link rel=""stylesheet"" href=""https://unpkg.com/leaflet-control-geocoder/dist/Control.Geocoder.css"" />
                <script src=""https://unpkg.com/leaflet@1.9.4/dist/leaflet.js""></script>
                <script src=""https://unpkg.com/leaflet-control-geocoder/dist/Control.Geocoder.js""></script>
                <style>html, body, #map { height: 100%; margin: 0; }</style>
            </head>
            <body>
                <div id=""map""></div>
                <script>
                    var map = L.map('map').setView([14.5995, 120.9842], 12);
                    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', { maxZoom: 19 }).addTo(map);

                    var marker;

                    // Click to place marker

                    map.on('click', function(e) {
                        if(marker) map.removeLayer(marker);
                        marker = L.marker(e.latlng).addTo(map);
                        window.chrome.webview.postMessage(e.latlng.lat + ',' + e.latlng.lng);
                    });

                    // Search box       

                    L.Control.geocoder({
                        defaultMarkGeocode: false
                    }).on('markgeocode', function(e) {
                        var center = e.geocode.center;
                        map.setView(center, 16);
                        if(marker) map.removeLayer(marker);
                        marker = L.marker(center).addTo(map);
                        window.chrome.webview.postMessage(center.lat + ',' + center.lng);
                    }).addTo(map);
                </script>
            </body>
            </html>
            ";

            webViewMap.NavigateToString(html);

            month = dateTime.Month;
            year = dateTime.Year;
            CalendarHandler.DisplayCalendarDays(month, year, DayContainer, lbDate, events, AddEventToDayCell);

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
            CalendarHandler.DisplayCalendarDays(month, year, DayContainer, lbDate, events, AddEventToDayCell);

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
            CalendarHandler.DisplayCalendarDays(month, year, DayContainer, lbDate, events, AddEventToDayCell);

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

            string title = EventTitleTxt.Text.Trim();
            string type = EventTypeCmb.Text.Trim();
            string location = EventLocationTxt.Text.Trim();
            string description = NoteTxt.Text.Trim();
            string time = TimePicker.Value.ToString("HH:mm");
            string reqAttendees = ReqAttendeesCmb.SelectedItem?.ToString() ?? "None";

            lock (eventLock)
            {
                List<int> selectedMembers = new List<int>();

                if (reqAttendees == "Specific Members Only")
                {
                    for (int i = 0; i < SelectMembersGrid.Rows.Count; i++)
                    {
                        bool isSelected = Convert.ToBoolean(SelectMembersGrid.Rows[i].Cells[0].Value);
                        if (isSelected)
                        {
                            selectedMembers.Add(int.Parse(SelectMembersGrid.Rows[i].Cells["BodyNumber"].Value.ToString()));
                        }
                    }
                }

                if (editingEvent != null)
                {
                    editingEvent.Title = title;
                    editingEvent.Type = type;
                    editingEvent.Location = location;
                    editingEvent.Description = description;
                    editingEvent.Time = time;
                    editingEvent.Date = selectedDate;
                    editingEvent.RequiredAttendees = reqAttendees;

                    eventRepo.SaveEvent(editingEvent, reqAttendees, true, editingEvent.EventId, selectedMembers);

                    PanelsHandler.UpdateEventPanel(editingEvent, EventsOverviewFlowLayoutPanel);
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
                        Location = location,
                        Description = description,
                        Time = time,
                        Date = selectedDate,
                        RequiredAttendees = reqAttendees
                    };

                    int savedId = eventRepo.SaveEvent(newEvent, reqAttendees, false, 0, selectedMembers);
                    newEvent.EventId = savedId;

                    if (!events.ContainsKey(selectedDate))
                        events[selectedDate] = new List<CalendarEvent>();

                    events[selectedDate].Add(newEvent);

                    CalendarHandler.AddEventToOverview(newEvent, EventsOverviewFlowLayoutPanel, EventPanel_DoubleClick, EventPanel_Click, EventPanelWidth, EventPanelHeight, EventPanelMargin);
                    AddEventToDayCell(newEvent);
                }
            }

            SpecificMembsPanel.Visible = false;
            AddEventPanel.Hide();
            EventTitleTxt.Clear();
            EventTypeCmb.SelectedIndex = -1;
            EventLocationTxt.Clear();
            NoteTxt.Clear();
            TimePicker.Value = DateTime.Now;
        }


        private void EventPanel_Click(object sender, EventArgs e)
        {
            selectedEventPanel = sender as Panel;
        }

        //EXPAND AND COLLAPSE PANEL
        private void EventPanel_DoubleClick(object sender, EventArgs e)
        {
            Panel clickedPanel = sender as Panel;
            if (clickedPanel == null) return;

            CalendarEvent ev = clickedPanel.Tag as CalendarEvent;
            if (ev == null) return;

            selectedEventPanel = clickedPanel;

            if (MiniPanel.Visible)
                MiniPanel.Visible = false;

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
            panel.Height = 150;

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
            Button btnInfo = new Button
            {
                Text = "Info",
                BackColor = Color.LightCoral,
                Size = new Size(100, 30),
                Tag = "Expanded"
            }
            ;

            // POSITION BUTTONS
            int marginRight = 20;
            int marginBottom = 15;
            int marginTop = 10;
            btnCancel.Location = new Point(panel.Width - btnCancel.Width - marginRight, panel.Height - btnCancel.Height - marginBottom);
            btnDone.Location = new Point(btnCancel.Left - btnDone.Width - 10, btnCancel.Top);
            btnInfo.Location = new Point(panel.Width - btnInfo.Width - marginRight, marginTop);

            btnDone.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            btnCancel.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            btnInfo.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            // DONE CLICK - UPDATE STATUS IN DB AND REMOVE FROM OVERVIEW
            btnDone.Click += (s, args) =>
            {
                Panel mini = this.Controls["MiniPanel"] as Panel;
                if (mini == null) return;

                if (MiniPanel.Visible)
                    MiniPanel.Visible = false;

                ev.Status = "Done";
                eventRepo.UpdateEventStatus(ev.EventId, "Done");
                UpdateEventInDayCell(ev);

                EventsOverviewFlowLayoutPanel.Controls.Remove(panel);

                if (ev.RequiredAttendees != "None")
                {
                    MoveToPreviousEvents(ev, true);
                }
                else
                {
                    Panel pastPanel = new Panel();
                    pastPanel.Size = new Size(520, EventPanelHeight);
                    pastPanel.BorderStyle = BorderStyle.FixedSingle;
                    pastPanel.Margin = new Padding(EventPanelMargin);
                    pastPanel.BackColor = Color.LightGreen;
                    pastPanel.Tag = ev;

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

                    pastPanel.Controls.Add(lblTitle);
                    pastPanel.Controls.Add(lblInfo);
                    pastPanel.Controls.Add(lblDate);

                    PastEventFlowLayoutPanel.Controls.Add(pastPanel);
                    PastEventFlowLayoutPanel.Controls.SetChildIndex(pastPanel, 0);

                    pastPanel.DoubleClick += PastEventPanel_DoubleClick;
                }


                if (selectedEventPanel == panel)
                    selectedEventPanel = null;
            };


            // CANCEL CLICK - UPDATE STATUS IN DB AND REMOVE FROM OVERVIEW
            btnCancel.Click += (s, args) =>
            {
                Panel mini = this.Controls["MiniPanel"] as Panel;
                if (mini == null) return;

                if (MiniPanel.Visible)
                    MiniPanel.Visible = false;

                ev.Status = "Canceled";
                eventRepo.UpdateEventStatus(ev.EventId, "Canceled"); // UPDATE DATABASE
                UpdateEventInDayCell(ev); // UPDATE CALENDAR CELL
                EventsOverviewFlowLayoutPanel.Controls.Remove(panel); // REMOVE FROM OVERVIEW
                if (selectedEventPanel == panel)
                    selectedEventPanel = null;
            };
            btnInfo.Click += (s, args) =>
            {
                Panel mini = this.Controls["MiniPanel"] as Panel;
                if (mini == null) return;


                if (MiniPanel.Visible)
                    MiniPanel.Visible = false;

                // Calculate position
                Point screenPos = panel.PointToScreen(Point.Empty);
                Point localPos = this.PointToClient(screenPos);

                int gap = 10;

                int leftX = localPos.X - mini.Width - gap;
                int topY = localPos.Y;

                if (leftX < 0)
                    leftX = 0;

                mini.Location = new Point(leftX, topY);
                mini.Visible = true;
                mini.BringToFront();
            };


            panel.Controls.Add(lblDescription);
            panel.Controls.Add(btnDone);
            panel.Controls.Add(btnCancel);
            panel.Controls.Add(btnInfo);
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

        //MOVE TO PREVIOUS EVENTS PANEL
        private void MoveToPreviousEvents(CalendarEvent ev, bool isDone)
        {
            Panel panel = new Panel();
            panel.Size = new Size(480, EventPanelHeight);
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Margin = new Padding(EventPanelMargin);
            panel.BackColor = isDone ? Color.LightGreen : Color.LightCoral;

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
                ForeColor = Color.Black,
                Location = new Point(10, 45),
                AutoSize = true
            };

            panel.Controls.Add(lblTitle);
            panel.Controls.Add(lblInfo);
            panel.Controls.Add(lblDate);

            DoneEventFlowLayoutPanel.Controls.Add(panel);
            DoneEventFlowLayoutPanel.Controls.SetChildIndex(panel, 0);

            panel.DoubleClick += DoneEventPanel_DoubleClick;
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

        private void PastEventPanel_DoubleClick(object sender, EventArgs e)
        {
            selectedPastEventPanel = sender as Panel;
            CalendarEvent ev = selectedPastEventPanel.Tag as CalendarEvent;
            if (ev == null) return;
            DefaultAttendancePanel.Hide();
            AttendanceListDGV.Columns.Clear();
            AttendanceListDGV.Rows.Clear();

            AttendanceListDGV.Columns.Add("BodyNumber", "Body Number");
            AttendanceListDGV.Columns.Add("MemberName", "Member Name");
            AttendanceListDGV.Columns.Add("Status", "Status");

            if (ev.RequiredAttendees == "All Members")
            {
                var memberRepo = new MemberRepository();
                var allMembers = memberRepo.GetAllMembers();

                foreach (var m in allMembers)
                {
                    string fullName = $"{m.LastName}, {m.FirstName} {m.MiddleInitial}";

                    var attendance = eventRepo.GetAttendanceForMember(ev.EventId, m.BodyNumber);
                    string status = (attendance != null && attendance.IsPresent == 2) ? "Present" : "Absent";

                    AttendanceListDGV.Rows.Add(m.BodyNumber.ToString("D3"), fullName, status);
                }
            }
            else if (ev.RequiredAttendees == "Specific Members Only")
            {
                var allAttendees = eventRepo.GetSavedEventAttendees(ev.EventId);

                foreach (var a in allAttendees)
                {
                    string status = a.IsPresent == 2 ? "Present" : "Absent";
                    AttendanceListDGV.Rows.Add(a.BodyNumber.ToString("D3"), a.MemberName, status);
                }
            }


        }

        private void DoneEventPanel_DoubleClick(object sender, EventArgs e)
        {
            previousEventSelectedPanel = sender as Panel;
            CalendarEvent ev = previousEventSelectedPanel.Tag as CalendarEvent;

            if (ev == null)
                return;

            SetAttendanceGrid.Rows.Clear();
            SetAttendanceGrid.Columns.Clear();

            SetAttendanceGrid.Columns.Add(new DataGridViewCheckBoxColumn { HeaderText = "", Width = 30 });
            SetAttendanceGrid.Columns.Add("BodyNumber", "Body Number");
            SetAttendanceGrid.Columns.Add("MemberName", "Member Name");

            if (ev.RequiredAttendees == "All Members")
            {
                var repo = new MemberRepository();
                var allMembers = repo.GetAllMembers();

                foreach (var m in allMembers)
                {
                    string fullName = $"{m.LastName}, {m.FirstName} {m.MiddleInitial}";
                    SetAttendanceGrid.Rows.Add(false, m.BodyNumber.ToString("D3"), fullName);
                }
            }
            else if (ev.RequiredAttendees == "Specific Members Only")
            {
                var repo = new EventRepository();
                var attendees = repo.GetSavedEventAttendees(ev.EventId);

                foreach (var a in attendees)
                {
                    SetAttendanceGrid.Rows.Add(false, a.BodyNumber.ToString("D3"), a.MemberName);
                }
            }
            else if (ev.RequiredAttendees == "None")
            {
                PastEventFlowLayoutPanel.Controls.Add(previousEventSelectedPanel);
                PastEventFlowLayoutPanel.Controls.SetChildIndex(previousEventSelectedPanel, 0);
            }
            //1167, 741
            CheckAttendancePanel.Location = PreviousEventPanel.Location;
            CheckAttendancePanel.Show();
            CheckAttendancePanel.BringToFront();
            PreviousEventPanel.Hide();
        }

        private void SaveAttendanceButton_Click(object sender, EventArgs e)
        {
            if (previousEventSelectedPanel?.Tag is CalendarEvent ev)
            {
                // SAVE ATTENDANCE FOR THIS EVENT
                eventRepo.SaveAttendanceForEvent(ev.EventId, SetAttendanceGrid);

                // REMOVE FROM DONE PANEL
                DoneEventFlowLayoutPanel.Controls.Remove(previousEventSelectedPanel);

                // ADD TO PAST PANEL
                previousEventSelectedPanel.Width = 410;

                previousEventSelectedPanel.Size = new Size(520, EventPanelHeight);

                previousEventSelectedPanel.BackColor = Color.LightGreen;

                // CHANGE THE DOUBLE-CLICK HANDLER
                previousEventSelectedPanel.DoubleClick -= DoneEventPanel_DoubleClick;
                previousEventSelectedPanel.DoubleClick += PastEventPanel_DoubleClick;

                // ADD TO PAST PANEL
                PastEventFlowLayoutPanel.Controls.Add(previousEventSelectedPanel);
                PastEventFlowLayoutPanel.Controls.SetChildIndex(previousEventSelectedPanel, 0);
            }

            // RESET UI
            PreviousEventPanel.Show();
            PreviousEventPanel.BringToFront();
            CheckAttendancePanel.Hide();
        }

        private void EditEventButton_Click(object sender, EventArgs e)
        {
            if (selectedEventPanel != null && selectedEventPanel.Tag is CalendarEvent evt)
            {
                EventTitleTxt.Text = evt.Title;
                EventTypeCmb.Text = evt.Type;
                EventLocationTxt.Text = evt.Location;
                NoteTxt.Text = evt.Description;

                if (TimeSpan.TryParse(evt.Time, out TimeSpan time))
                {
                    DatePicker.Value = DateTime.Today.Add(time);
                }

                selectedDate = evt.Date;
                editingEvent = evt;
                SaveEventButton.Text = "Update";
                AddEventPanel.Show();
                AddEventPanel.BringToFront();
            }
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

        private void LoadAttendanceIntoDGV(CalendarEvent ev)
        {
            AttendanceListDGV.Columns.Clear();
            AttendanceListDGV.Rows.Clear();

            AttendanceListDGV.Columns.Add("BodyNumber", "Body Number");
            AttendanceListDGV.Columns.Add("MemberName", "Member Name");
            AttendanceListDGV.Columns.Add("Status", "Status");

            foreach (var member in ev.AttendanceList)
            {
                AttendanceListDGV.Rows.Add(
                    member.BodyNumber,
                    member.MemberName,
                    member.IsPresent == 2 ? "Present" : "Absent"
                );
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MapPanel.Visible = !MapPanel.Visible;
        }

        private async void SelectPlaceBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedCoords)) return;

            var parts = selectedCoords.Split(',');
            var lat = parts[0];
            var lng = parts[1];

            string url = $"https://nominatim.openstreetmap.org/reverse?lat={lat}&lon={lng}&format=json";

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", "BATODAApp");
                var response = await client.GetStringAsync(url);
                dynamic result = Newtonsoft.Json.JsonConvert.DeserializeObject(response);

                if (result?.display_name != null)
                {
                    EventLocationTxt.Text = result.display_name;
                    MapPanel.Visible = false;
                }
                else
                {
                    MessageBox.Show("Place not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void ReqAttendeesCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ReqAttendeesCmb.SelectedItem != null &&
                ReqAttendeesCmb.SelectedItem.ToString() == "Specific Members Only")
            {
                AttendanceHandler.ApplyCustomGridWithCheckbox(SelectMembersGrid);
                SpecificMembsPanel.Visible = true;
                SpecificMembsPanel.BringToFront();
                LoadAllMembersToSelectMembersGrid();
            }
            else
            {
                SpecificMembsPanel.Visible = false;
            }
        }

        private void LoadAllMembersToSelectMembersGrid()
        {
            SelectMembersGrid.Rows.Clear();
            SelectMembersGrid.Columns.Clear();

            DataGridViewCheckBoxColumn checkCol = new DataGridViewCheckBoxColumn();
            checkCol.HeaderText = "";
            checkCol.Width = 30;
            SelectMembersGrid.Columns.Add(checkCol);

            SelectMembersGrid.Columns.Add("BodyNumber", "Body Number");

            SelectMembersGrid.Columns.Add("FullName", "Full Name");

            var repo = new MemberRepository();
            var members = repo.GetAllMembers();

            foreach (var m in members)
            {
                string bodyNumberFormatted = m.BodyNumber.ToString("D3");
                string fullName = $"{m.LastName}, {m.FirstName} {m.MiddleInitial}";
                SelectMembersGrid.Rows.Add(false, bodyNumberFormatted, fullName);
            }
        }

        private List<(int BodyNumber, string MemberName)> GetSelectedMembers()
        {
            var selected = new List<(int, string)>();
            foreach (DataGridViewRow row in SelectMembersGrid.Rows)
            {
                if (row.Cells[0].Value is bool isChecked && isChecked)
                {
                    int bodyNumber = int.Parse(row.Cells["BodyNumber"].Value.ToString());
                    string memberName = row.Cells["FullName"].Value.ToString();
                    selected.Add((bodyNumber, memberName));
                }
            }
            return selected;
        }

        private void SaveSelectedBtn_Click(object sender, EventArgs e)
        {
            SpecificMembsPanel.Visible = false;
        }
    }
}