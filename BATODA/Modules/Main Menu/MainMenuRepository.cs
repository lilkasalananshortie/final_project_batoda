using System;
using System.Data.SqlClient;

namespace BATODA.Modules.Main_Menu
{
    internal class MainMenuRepository
    {
        private readonly string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=BatodaDb;Integrated Security=True;TrustServerCertificate=True";

        public bool ReplaceAdminAccount(string username, string password, string fullName, out string message)
        {
            message = "";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string updateQuery = @"UPDATE UserAccount 
                                           SET Username = @Username, Password = @Password, FullName = @FullName";

                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.Parameters.AddWithValue("@FullName", fullName);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            string insertQuery = @"INSERT INTO UserAccount (Username, Password, FullName, DateCreated)
                                                   VALUES (@Username, @Password, @FullName, GETDATE())";
                            using (SqlCommand cmdInsert = new SqlCommand(insertQuery, conn))
                            {
                                cmdInsert.Parameters.AddWithValue("@Username", username);
                                cmdInsert.Parameters.AddWithValue("@Password", password);
                                cmdInsert.Parameters.AddWithValue("@FullName", fullName);

                                cmdInsert.ExecuteNonQuery();
                            }

                            message = "Admin account created successfully!";
                        }
                        else
                        {
                            message = "Admin account replaced successfully!";
                        }

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                message = "Error: " + ex.Message;
                return false;
            }
        }



    }
}
