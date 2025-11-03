using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BATODA.Modules.Member_Module.Member_Classes
{
    public class TransferMembershipHistoryRepository
    {
        private static readonly string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=BatodaDb;Integrated Security=True;TrustServerCertificate=True";

        public void AddTransferRecord(TransferMembershipHistoryModel record)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "INSERT INTO TransferMembershipHistory " +
                                   "(BodyNumber, PastOwnerFullName, NewOwnerFullName, ReasonForTransfer, DateOfTransfer) " +
                                   "VALUES (@BodyNumber, @PastOwnerFullName, @NewOwnerFullName, @ReasonForTransfer, @DateOfTransfer)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@BodyNumber", record.BodyNumber);
                    cmd.Parameters.AddWithValue("@PastOwnerFullName", record.PastOwnerFullName);
                    cmd.Parameters.AddWithValue("@NewOwnerFullName", record.NewOwnerFullName);
                    cmd.Parameters.AddWithValue("@ReasonForTransfer", record.ReasonForTransfer);
                    cmd.Parameters.AddWithValue("@DateOfTransfer", record.DateOfTransfer);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error saving transfer record: {ex.Message}",
                    "Database Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        public DataTable GetAllTransferRecords()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM TransferMembershipHistory ORDER BY DateOfTransfer DESC";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // GET LAST TRANSFER DATE OF BODYNUMBER
        public DateTime? GetLastTransferDate(int bodyNumber)
        {
            string query = @"SELECT TOP 1 DateOfTransfer 
                     FROM TransferMembershipHistory 
                     WHERE BodyNumber = @BodyNumber
                     ORDER BY DateOfTransfer DESC";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@BodyNumber", bodyNumber);
                conn.Open();
                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    DateTime lastTransferDate = Convert.ToDateTime(result);
                    if ((DateTime.Now - lastTransferDate).TotalDays < 3)
                    {
                        MessageBox.Show("This body number cannot be transferred yet. Please wait 3 days after the last transfer.",
                            "Transfer Blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        return lastTransferDate; // RETURN THE DATE TO INDICATE TRANSFER BLOCKED
                    }

                    return lastTransferDate; // RETURN THE LAST TRANSFER DATE IF ALLOWED
                }
            }

            return null; // RETURN NULL IF NO RECORD FOUND
        }



    }
}
