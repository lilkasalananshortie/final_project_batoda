using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace BATODA.Modules.Dashboard_Module.Dashboard_Classes
{
    public class SystemActivityLogRepository
    {
        private readonly string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=BatodaDb;Integrated Security=True;TrustServerCertificate=True";

        // SAVE LOG TO DATABASE
        public void AddLog(string moduleName, string actionType, string description)
        {
            string query = @"
                INSERT INTO SystemActivityLog (ModuleName, ActionType, Description, DateRecorded)
                VALUES (@ModuleName, @ActionType, @Description, @DateRecorded)
            ";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ModuleName", moduleName);
                cmd.Parameters.AddWithValue("@ActionType", actionType);
                cmd.Parameters.AddWithValue("@Description", description ?? "");
                cmd.Parameters.AddWithValue("@DateRecorded", DateTime.Now);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }



        // MEMBER MODULE
        public void LogAddMember(string memberFullName)
        {
            AddLog(
                moduleName: "Members",
                actionType: "Add Member",
                description: $"Added {memberFullName} as a new member"
            );
        }

        public void LogPenaltyAction(string memberName, bool isSuspended)
        {
            string moduleName = "Members";
            string actionType = isSuspended ? "Suspend Member" : "Penalize Member";
            string description = isSuspended
            ? $"{memberName} has been suspended for 24 hours"
            : $"{memberName} has been penalized";

            string query = @"
            INSERT INTO SystemActivityLog (ModuleName, ActionType, Description, DateRecorded)
            VALUES (@ModuleName, @ActionType, @Description, @DateRecorded)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ModuleName", moduleName);
                cmd.Parameters.AddWithValue("@ActionType", actionType);
                cmd.Parameters.AddWithValue("@Description", description);
                cmd.Parameters.AddWithValue("@DateRecorded", DateTime.Now);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void LogMembershipTransfer(int bodyNumber, string newOwnerFullName)
        {
            AddLog(
            moduleName: "Members",
            actionType: "Transferred Membership",
            description: $"Body No. {bodyNumber} is transferred to {newOwnerFullName}"
            );
        }

        public void LogMemberUpdate(int bodyNumber)
        {
            string moduleName = "Members";
            string actionType = "Updated Member Info";
            string description = $"Body No. {bodyNumber} info has been updated";

            AddLog(moduleName, actionType, description);
        }

        public void LogNewAssistanceTicket(int ticketID)
        {
            string moduleName = "Assistance Request";
            string actionType = "Added New Ticket";
            string description = $"T-{ticketID} Financial Request is added";
            AddLog(moduleName, actionType, description);
        }

        public void LogReleaseFinancialRequest(int ticketID)
        {
            string moduleName = "Assistance Request";
            string actionType = "Release of Financial Request";
            string description = $"Financial Request of T-{ticketID} has been released";
            AddLog(moduleName, actionType, description);
        }

        public void LogEditVehicle(int bodyNumber)
        {
            AddLog(
                moduleName: "Registered Vehicle",
                actionType: "Edit Vehicle Information",
                description: $"Body No. {bodyNumber} Edited Vehicle Information"
            );
        }

        public void LogTransferVehicle(int bodyNumber)
        {
            AddLog(
                moduleName: "Registered Vehicle",
                actionType: "Transfer",
                description: $"Body No. {bodyNumber} transferred to new vehicle"
            );
        }


        public DataTable GetAllLogs()
        {
            string query = @"SELECT ModuleName, ActionType, Description, DateRecorded FROM SystemActivityLog ORDER BY DateRecorded DESC";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }

    }
}
