using BATODA.Modules.Schedule_Module;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BATODA.Repositories
{
    public class EventRepository
    {
        private readonly string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=BatodaDb;Integrated Security=True;TrustServerCertificate=True";

        // MODIFYED SaveEvent TO HANDLE SELECTED MEMBERS
        public int SaveEvent(CalendarEvent evt, string reqAttendees, bool isUpdate = false, int eventId = 0, List<int> selectedMembers = null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query;
                if (isUpdate)
                {
                    // UPDATE EXISTING EVENT
                    query = @"UPDATE ScheduleEvents
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
                    // INSERT NEW EVENT
                    query = @"INSERT INTO ScheduleEvents
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

                        // DELETE OLD ATTENDEES FOR UPDATED EVENT
                        using (SqlCommand deleteCmd = new SqlCommand("DELETE FROM EventAttendees WHERE EventId = @EventId", conn))
                        {
                            deleteCmd.Parameters.AddWithValue("@EventId", eventId);
                            deleteCmd.ExecuteNonQuery();
                        }

                        savedEventId = eventId;
                    }
                    else
                    {
                        savedEventId = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }

                evt.EventId = savedEventId;

                if (selectedMembers != null && selectedMembers.Count > 0)
                {
                    foreach (var bodyNumber in selectedMembers)
                    {
                        // INSERT SELECTED MEMBERS INTO EventAttendees
                        using (SqlCommand cmd = new SqlCommand(@"
                    INSERT INTO EventAttendees (EventId, BodyNumber, MemberName, IsPresent)
                    VALUES (@EventId, @BodyNumber, @MemberName, 0)", conn))
                        {
                            cmd.Parameters.AddWithValue("@EventId", savedEventId);
                            cmd.Parameters.AddWithValue("@BodyNumber", bodyNumber);

                            // GET MEMBER NAME FOR THE BODYNUMBER
                            using (SqlCommand nameCmd = new SqlCommand("SELECT FirstName, LastName, MiddleInitial FROM MemberInfo WHERE BodyNumber = @BodyNumber", conn))
                            {
                                nameCmd.Parameters.AddWithValue("@BodyNumber", bodyNumber);
                                using (SqlDataReader reader = nameCmd.ExecuteReader())
                                {
                                    string fullName = "";
                                    if (reader.Read())
                                    {
                                        fullName = $"{reader["LastName"]}, {reader["FirstName"]} {reader["MiddleInitial"]}";
                                    }
                                    cmd.Parameters.AddWithValue("@MemberName", fullName);
                                }
                            }

                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                return savedEventId;
            }
        }


        public List<EventAttendee> GetSavedEventAttendees(int eventId)
        {
            var list = new List<EventAttendee>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT EventId, BodyNumber, MemberName, IsPresent FROM EventAttendees WHERE EventId = @EventId", conn))
                {
                    cmd.Parameters.AddWithValue("@EventId", eventId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new EventAttendee
                            {
                                EventId = Convert.ToInt32(reader["EventId"]),
                                BodyNumber = Convert.ToInt32(reader["BodyNumber"]),
                                MemberName = reader["MemberName"].ToString(),
                                IsPresent = Convert.ToInt32(reader["IsPresent"])
                            });
                        }
                    }
                }
            }
            return list;
        }




        public List<CalendarEvent> GetAllEvents()
        {
            List<CalendarEvent> events = new List<CalendarEvent>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT EventId, EventTitle, EventType, Location, Description, Date, Time, EventStatus, RequiredAttendees FROM ScheduleEvents";

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
                            Status = reader.IsDBNull(7) ? "Pending" : reader.GetString(7),
                            RequiredAttendees = reader.IsDBNull(8) ? "" : reader.GetString(8) // added
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
        public void SaveAttendanceForEvent(int eventId, DataGridView attendanceGrid)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                foreach (DataGridViewRow row in attendanceGrid.Rows)
                {
                    if (row.IsNewRow) continue;

                    int bodyNumber = int.Parse(row.Cells["BodyNumber"].Value.ToString());
                    string memberName = row.Cells["MemberName"].Value.ToString();
                    bool isChecked = row.Cells[0].Value is bool b && b;
                    int isPresent = isChecked ? 2 : 1; // 2 = PRESENT, 1 = ABSENT

                    // CHECK IF RECORD ALREADY EXISTS FOR THIS EVENT AND MEMBER
                    string checkQuery = @"SELECT COUNT(*) FROM EventAttendees 
                                  WHERE EventId = @EventId AND BodyNumber = @BodyNumber";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@EventId", eventId);
                        checkCmd.Parameters.AddWithValue("@BodyNumber", bodyNumber);
                        int count = (int)checkCmd.ExecuteScalar();

                        if (count > 0)
                        {
                            // UPDATE EXISTING RECORD IF ALREADY EXISTS
                            string updateQuery = @"UPDATE EventAttendees
                                           SET IsPresent = @IsPresent
                                           WHERE EventId = @EventId AND BodyNumber = @BodyNumber";
                            using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                            {
                                updateCmd.Parameters.AddWithValue("@IsPresent", isPresent);
                                updateCmd.Parameters.AddWithValue("@EventId", eventId);
                                updateCmd.Parameters.AddWithValue("@BodyNumber", bodyNumber);
                                updateCmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            // INSERT NEW RECORD IF NONE EXISTS
                            string insertQuery = @"INSERT INTO EventAttendees (EventId, BodyNumber, MemberName, IsPresent)
                                           VALUES (@EventId, @BodyNumber, @MemberName, @IsPresent)";
                            using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                            {
                                insertCmd.Parameters.AddWithValue("@EventId", eventId);
                                insertCmd.Parameters.AddWithValue("@BodyNumber", bodyNumber);
                                insertCmd.Parameters.AddWithValue("@MemberName", memberName);
                                insertCmd.Parameters.AddWithValue("@IsPresent", isPresent);
                                insertCmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
        }

        public bool EventHasAttendance(int eventId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM EventAttendees WHERE EventId = @EventId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EventId", eventId);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public EventAttendee GetAttendanceForMember(int eventId, int bodyNumber)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT EventId, BodyNumber, MemberName, IsPresent
                         FROM EventAttendees
                         WHERE EventId = @EventId AND BodyNumber = @BodyNumber";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@EventId", eventId);
                    cmd.Parameters.AddWithValue("@BodyNumber", bodyNumber);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new EventAttendee
                            {
                                EventId = Convert.ToInt32(reader["EventId"]),
                                BodyNumber = Convert.ToInt32(reader["BodyNumber"]),
                                MemberName = reader["MemberName"].ToString(),
                                IsPresent = Convert.ToInt32(reader["IsPresent"])
                            };
                        }
                    }
                }
            }

            return null;
        }
    }
}
