using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Web.UI;

namespace Task_2
{
    public partial class Register : Page
    {
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string email = txtEmail.Text.Trim();
            string Password = txtPassword.Text.Trim();

            // Client-side validation for required fields
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(Password) )
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('All fields are required.');", true);
                return;
            }

            if (!IsValidEmail(email))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Invalid email format.');", true);
                return;
            }

            try
            {
                InsertUser(username, email ,Password);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Registration successful.'); setTimeout(function(){ window.location = 'Login.aspx'; }, 1000);", true);
                ClearFields();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('Registration failed: {ex.Message}');", true);
            }

        }

        private bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }

      
        private void InsertUser(string username, string email ,  string password)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["WebFormsTrainingConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (IsEmailRegistered(email))
                {
                    throw new Exception("Email is already registered.");
                }

                SqlCommand command = new SqlCommand("InsertUser", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserName", username);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private bool IsEmailRegistered(string email)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["WebFormsTrainingConnectionString"].ConnectionString;
            string query = "SELECT COUNT(*) FROM Users WHERE Email = @Email";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);

                connection.Open();
                int count = (int)command.ExecuteScalar();

                return count > 0;
            }
        }

        private void ClearFields()
        {
            txtUsername.Text = string.Empty;
            txtEmail.Text = string.Empty;
            
        }
    }
}
