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

        // MODIFYED SaveEvent TO HANDLE SELECTED MEMBERS
        public void SaveEvent(CalendarEvent evt, string reqAttendees, bool isUpdate = false, int eventId = 0, List<int> selectedMembers = null)
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
                    // INSERT NEW EVENT AND GET GENERATED ID
                    query = @"
                INSERT INTO ScheduleEvents
                (EventTitle, EventType, Location, Description, Date, Time, EventStatus, RequiredAttendees)  
                VALUES
                (@Title, @Type, @Location, @Description, @EventDate, @EventTime, @Status, @ReqAttendees); 
                SELECT SCOPE_IDENTITY();";
                }

                int savedEventId;
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Title", evt.Title);
                    cmd.Parameters.AddWithValue("@Type", evt.Type);
                    cmd.Parameters.AddWithValue("@Location", evt.Location);
                    cmd.Parameters.AddWithValue("@Description", evt.Description);
                    cmd.Parameters.AddWithValue("@EventDate", evt.Date.Date);
                    cmd.Parameters.AddWithValue("@EventTime", evt.Time);
                    cmd.Parameters.AddWithValue("@Status", evt.Status ?? "Pending");
                    cmd.Parameters.AddWithValue("@ReqAttendees", reqAttendees);

                    if (isUpdate)
                    {
                        cmd.Parameters.AddWithValue("@EventId", eventId);
                        cmd.ExecuteNonQuery();
                        savedEventId = eventId;
                    }
                    else
                    {
                        savedEventId = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }

                // SAVE SPECIFIC MEMBERS IF PROVIDED
                if (selectedMembers != null && selectedMembers.Count > 0)
                {
                    foreach (var bodyNumber in selectedMembers)
                    {
                        using (SqlCommand cmd = new SqlCommand(@"
                    INSERT INTO EventAttendees (EventId, BodyNumber, MemberName, Present)
                    VALUES (@EventId, @BodyNumber, @MemberName, 0)", conn))
                        {
                            cmd.Parameters.AddWithValue("@EventId", savedEventId);
                            cmd.Parameters.AddWithValue("@BodyNumber", bodyNumber);
                            cmd.Parameters.AddWithValue("@MemberName", ""); // CAN FETCH NAME IF NEEDED
                            cmd.ExecuteNonQuery();
                        }
                    }
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

        /* -------------------------------------- ATTENDEES ----------------------------------------*/
        public void AllMembersRequired(EventAttendee attendee)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"INSERT INTO EventAttendees (EventId, BodyNumber, MemberName, IsPresent)
                         VALUES (@EventId, @BodyNumber, @MemberName, @IsPresent)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EventId", attendee.EventId);
                    cmd.Parameters.AddWithValue("@BodyNumber", attendee.BodyNumber);
                    cmd.Parameters.AddWithValue("@MemberName", attendee.MemberName);
                    cmd.Parameters.AddWithValue("@IsPresent", attendee.IsPresent);
                    cmd.ExecuteNonQuery();
                }
            }
        }



    }
}
