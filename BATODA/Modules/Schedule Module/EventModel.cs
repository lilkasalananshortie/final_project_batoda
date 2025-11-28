using System;
using System.Collections.Generic;

namespace BATODA.Modules.Schedule_Module
{
    public class CalendarEvent
    {
        public string Title { get; set; }
        public string Time { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public int EventId { get; set; }
        public string RequiredAttendees { get; set; }


        public List<MemberAttendance> AttendanceList { get; set; } = new List<MemberAttendance>();
    }

    public class MemberAttendance
    {
        public string MemberName { get; set; }
        public string BodyNumber { get; set; }
        public bool Present { get; set; }
    }
}
