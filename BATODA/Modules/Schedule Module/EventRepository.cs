using BATODA.Modules.Schedule_Module;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BATODA.Repositories
{
    public class EventRepository
    {
        private readonly string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=BatodaDb;Integrated Security=True;TrustServerCertificate=True";

        public void SaveEvent(CalendarEvent evt, string reqAttendees, bool isUpdate = false, int eventId = 0)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query;
                if (isUpdate)
                {
                    query = @"
                UPDATE ScheduleEvents
                SET EventTitle = @Title,
                    EventType = @Type,
                    Location = @Location,
                    Description = @Description,
                    Date = @EventDate,
                    Time = @EventTime,
                    EventStatus = @Status,
                    RequiredAttendees = @ReqAttendees    
                WHERE EventId = @EventId";
                }
                else
                {
                    query = @"
                        INSERT INTO ScheduleEvents
                        (EventTitle, EventType, Location, Description, Date, Time, EventStatus, RequiredAttendees)  
                        VALUES
                        (@Title, @Type, @Location, @Description, @EventDate, @EventTime, @Status, @ReqAttendees)"; 
                }

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Title", evt.Title);
                    cmd.Parameters.AddWithValue("@Type", evt.Type);
                    cmd.Parameters.AddWithValue("@Location", evt.Location);
                    cmd.Parameters.AddWithValue("@Description", evt.Description);
                    cmd.Parameters.AddWithValue("@EventDate", evt.Date.Date);
                    cmd.Parameters.AddWithValue("@EventTime", evt.Time);
                    cmd.Parameters.AddWithValue("@Status", evt.Status ?? "Pending");

                    cmd.Parameters.AddWithValue("@ReqAttendees", reqAttendees);   // ★ SAVE COMBO VALUE

                    if (isUpdate)
                        cmd.Parameters.AddWithValue("@EventId", eventId);

                    cmd.ExecuteNonQuery();
                }
            }
        }


        public List<CalendarEvent> GetAllEvents()
        {
            List<CalendarEvent> events = new List<CalendarEvent>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT EventId, EventTitle, EventType, Location, Description, Date, Time, EventStatus FROM ScheduleEvents";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CalendarEvent evt = new CalendarEvent
                        {
                            EventId = reader.GetInt32(0),
                            Title = reader.IsDBNull(1) ? null : reader.GetString(1),
                            Type = reader.IsDBNull(2) ? null : reader.GetString(2),
                            Location = reader.IsDBNull(3) ? null : reader.GetString(3),
                            Description = reader.IsDBNull(4) ? null : reader.GetString(4),
                            Date = reader.IsDBNull(5) ? DateTime.MinValue : reader.GetDateTime(5),
                            Time = reader.IsDBNull(6) ? null : reader.GetTimeSpan(6).ToString(@"hh\:mm"),
                            Status = reader.IsDBNull(7) ? "Pending" : reader.GetString(7)
                        };

                        events.Add(evt);
                    }
                }
            }

            return events;
        }
        public void UpdateEventStatus(int eventId, string status)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE ScheduleEvents SET EventStatus = @Status WHERE EventId = @EventId";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@EventId", eventId);
                    cmd.ExecuteNonQuery();
                }
            }
        }



    }
}
