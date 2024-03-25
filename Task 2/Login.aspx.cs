using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace Task_2
{
    public partial class Login : System.Web.UI.Page
    {
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string usernameOrEmail = txtUsername.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (AuthenticateUser(usernameOrEmail, email, password))
            {
                int userID = GetUserID(usernameOrEmail);

                Session["UserID"] = userID;
                Session["Username"] = usernameOrEmail;

                Response.Redirect("~/");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Invalid username/email or password.');", true);
            }
        }
        public static int GetUserID(string usernameOrEmail)
        {
            int userID =0; 
            string connectionString = ConfigurationManager.ConnectionStrings["WebFormsTrainingConnectionString"].ConnectionString;
            string query = "SELECT UserID FROM Users WHERE Username = @Username OR Email = @Email";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Username", usernameOrEmail);
                    command.Parameters.AddWithValue("@Email", usernameOrEmail);
                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            userID = Convert.ToInt32(result);
                        }
                    }
                    catch (Exception ex)
                    {
                      
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
            return userID;
        }


        private bool AuthenticateUser(string usernameOrEmail , string Email, string Password)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["WebFormsTrainingConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SELECT UserID, Username FROM Users WHERE (Username = @Username OR Email = @Email) AND Password = @Password", connection);
                command.Parameters.AddWithValue("@Username", usernameOrEmail);
                command.Parameters.AddWithValue("@Email", Email);
                command.Parameters.AddWithValue("@Password", Password);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Session["UserID"] = reader["UserID"].ToString();
                    Session["Username"] = reader["Username"].ToString();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
