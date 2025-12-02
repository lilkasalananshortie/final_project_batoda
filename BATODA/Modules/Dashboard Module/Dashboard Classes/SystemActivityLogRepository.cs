using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
