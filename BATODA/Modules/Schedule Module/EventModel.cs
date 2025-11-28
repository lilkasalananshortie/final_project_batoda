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


        public List<EventAttendee> AttendanceList { get; set; } = new List<EventAttendee>();
    }


    public class EventAttendee
    {
        public int EventId { get; set; }
        public int BodyNumber { get; set; }
        public string MemberName { get; set; }
        public byte IsPresent { get; set; } // 0 = not required, 1 = absent, 2 = present
    }

}
