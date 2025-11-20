﻿using BATODA.Modules.Assistance_Request_Module.Assistance_Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

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

        public void UpdateRequestStatus(int ticketID, string newStatus)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string updateQuery = "UPDATE FinancialAssistanceRequests SET RequestStatus = @Status WHERE TicketID = @TicketID";
                using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Status", newStatus);
                    cmd.Parameters.AddWithValue("@TicketID", ticketID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void LoadTicketHistory(DataGridView grid)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
                SELECT 
                    CONCAT('TR-', f.TicketID) AS TicketID,
                    RIGHT('000' + CAST(f.BodyNumber AS VARCHAR(3)), 3) AS BodyNumber,
                    f.FullName,
                    f.ContactNumber,
                    f.TypeOfAid,
                    f.RequestedBy,
                    f.RequestedAmount,
                    f.AssistanceThru,
                    f.GcashNumber,
                    f.DateRequested,
                    f.RequestStatus,
                    h.ActionDate
                FROM FinancialAssistanceRequests f
                LEFT JOIN AssistanceActionHistory h
                    ON f.TicketID = h.TicketID
                ORDER BY h.ActionDate DESC";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                grid.DataSource = dt;

                grid.Columns["TicketID"].HeaderText = "Tracking No.";
                grid.Columns["BodyNumber"].HeaderText = "Body No.";
                grid.Columns["FullName"].HeaderText = "Full Name";
                grid.Columns["ContactNumber"].HeaderText = "Contact No.";
                grid.Columns["TypeOfAid"].HeaderText = "Aid";
                grid.Columns["RequestedBy"].HeaderText = "Requested By";
                grid.Columns["RequestedAmount"].HeaderText = "Amount";
                grid.Columns["AssistanceThru"].HeaderText = "Method";
                grid.Columns["GcashNumber"].HeaderText = "Gcash No.";
                grid.Columns["DateRequested"].HeaderText = "Date Req.";
                grid.Columns["RequestStatus"].HeaderText = "Status";
                grid.Columns["ActionDate"].HeaderText = "Action Date";
            }
        }

        public void UpdateActionDate(int ticketID)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string check = "SELECT COUNT(*) FROM AssistanceActionHistory WHERE TicketID = @TicketID";
                using (SqlCommand chk = new SqlCommand(check, conn))
                {
                    chk.Parameters.AddWithValue("@TicketID", ticketID);
                    int exists = (int)chk.ExecuteScalar();

                    if (exists == 0)
                    {
                        string insert = @"INSERT INTO AssistanceActionHistory (TicketID, ActionDate)
                                  VALUES (@TicketID, GETDATE())";
                        using (SqlCommand ins = new SqlCommand(insert, conn))
                        {
                            ins.Parameters.AddWithValue("@TicketID", ticketID);
                            ins.ExecuteNonQuery();
                        }
                        return;
                    }
                }

                string update = @"UPDATE AssistanceActionHistory
                          SET ActionDate = GETDATE()
                          WHERE TicketID = @TicketID";
                using (SqlCommand upd = new SqlCommand(update, conn))
                {
                    upd.Parameters.AddWithValue("@TicketID", ticketID);
                    upd.ExecuteNonQuery();
                }
            }
        }

        public void InsertActionLog(string requestAction, string actionDescription)
        {
            string query = "INSERT INTO AssistanceActionLog (RequestAction, ActionDescription, ActionDate) " +
                           "VALUES (@action, @desc, @date)";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@action", requestAction);
                cmd.Parameters.AddWithValue("@desc", actionDescription);
                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<TicketModel> GetAllRequests()
        {
            List<TicketModel> tickets = new List<TicketModel>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
        SELECT * 
        FROM FinancialAssistanceRequests
        WHERE RequestStatus IN ('Pending','Approved')
          AND IsActive = 1
        ORDER BY BodyNumber";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tickets.Add(new TicketModel
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
                        });
                    }
                }
            }
            return tickets;
        }


        public List<ActionLogModel> GetAllActionLogs()
        {
            List<ActionLogModel> logs = new List<ActionLogModel>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM AssistanceActionLog ORDER BY ActionDate DESC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DateTime date = Convert.ToDateTime(reader["ActionDate"]);
                        logs.Add(new ActionLogModel
                        {
                            RequestAction = reader["RequestAction"].ToString(),
                            ActionDescription = reader["ActionDescription"].ToString(),
                            Date = date,
                            Status = reader["RequestStatus"].ToString(),
                            DateDisplay = FormatDateDisplay(date)
                        });
                    }
                }
            }

            return logs;
        }

        private string FormatDateDisplay(DateTime date)
        {
            TimeSpan diff = DateTime.Now - date;
            if (diff.Days == 0) return "Today";
            if (diff.Days == 1) return "1 day ago";
            return diff.Days + " days ago";
        }
    }
}