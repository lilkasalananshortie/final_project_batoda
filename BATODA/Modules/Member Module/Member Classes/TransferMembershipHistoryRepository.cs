using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
