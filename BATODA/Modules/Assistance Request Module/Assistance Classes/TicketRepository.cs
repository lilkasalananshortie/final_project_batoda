using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BATODA.Modules.Assistance_Request_Module.Assistance_Classes;

namespace BATODA.Modules.Assistance_Request_Module
{
    internal class AssistanceRepository
    {
        private readonly string connectionString =
            @"Data Source=localhost\SQLEXPRESS;Initial Catalog=BatodaDb;Integrated Security=True;TrustServerCertificate=True";

        public void AddRequest(AssistanceModel data)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO FinancialAssistanceRequests 
                                (FullName, BodyNumber, ContactNumber, TypeOfAid, RequestedBy, 
                                 RequestedAmount, AssistanceThru, GcashNumber, DateRequested, 
                                 TargetDate, RequestStatus)
                                VALUES 
                                (@FullName, @BodyNumber, @ContactNumber, @TypeOfAid, @RequestedBy, 
                                 @RequestedAmount, @AssistanceThru, @GcashNumber, @DateRequested, 
                                 @TargetDate, @RequestStatus)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FullName", data.FullName);
                    cmd.Parameters.AddWithValue("@BodyNumber", data.BodyNumber);
                    cmd.Parameters.AddWithValue("@ContactNumber", data.ContactNumber);
                    cmd.Parameters.AddWithValue("@TypeOfAid", data.TypeOfAid);
                    cmd.Parameters.AddWithValue("@RequestedBy", data.RequestedBy);
                    cmd.Parameters.AddWithValue("@RequestedAmount", data.RequestedAmount);
                    cmd.Parameters.AddWithValue("@AssistanceThru", data.AssistanceThru);
                    cmd.Parameters.AddWithValue("@GcashNumber", data.GcashNumber);
                    cmd.Parameters.AddWithValue("@DateRequested", data.DateRequested);
                    cmd.Parameters.AddWithValue("@TargetDate", data.TargetDate);
                    cmd.Parameters.AddWithValue("@RequestStatus", data.RequestStatus ?? "Pending");

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<TicketModel> GetAllRequests()
        {
            List<TicketModel> tickets = new List<TicketModel>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM FinancialAssistanceRequests ORDER BY BodyNumber"; // adjust column names if needed
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TicketModel ticket = new TicketModel
                            {
                                TicketID = reader.GetInt32(reader.GetOrdinal("TicketID")),
                                BodyNumber = reader.GetInt32(reader.GetOrdinal("BodyNumber")),
                                FullName = reader.GetString(reader.GetOrdinal("FullName")),
                                RequestedBy = reader.GetString(reader.GetOrdinal("RequestedBy")),
                                TypeOfAid = reader.GetString(reader.GetOrdinal("TypeOfAid")),
                                AssistanceThru = reader.GetString(reader.GetOrdinal("AssistanceThru")),
                                RequestedAmount = reader.GetDecimal(reader.GetOrdinal("RequestedAmount")),
                                TargetDate = reader.GetDateTime(reader.GetOrdinal("TargetDate")),
                                RequestStatus = reader.GetString(reader.GetOrdinal("RequestStatus")),
                                DateRequested = reader.GetDateTime(reader.GetOrdinal("DateRequested")),
                                GcashNumber = reader.GetString(reader.GetOrdinal("GcashNumber"))
                            };
                            tickets.Add(ticket);
                        }
                    }
                }
            }
            return tickets;
        }

        public void UpdateRequestStatus(int ticketID, string newStatus)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE FinancialAssistanceRequests SET RequestStatus = @Status WHERE TicketID = @TicketID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Status", newStatus);
                    cmd.Parameters.AddWithValue("@TicketID", ticketID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
