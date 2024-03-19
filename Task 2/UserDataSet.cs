using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Task_2
{
    partial class UserDataSet
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["WebFormsTrainingConnectionString"].ConnectionString;

        // CRUD operation to insert a new user
        public void InsertUser(string userName, string email)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("InsertUser", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserName", userName);
                command.Parameters.AddWithValue("@Email", email);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // CRUD operation to select all users
        public DataTable SelectUser()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SelectUsers", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);
            }

            return dataTable;
        }

        // CRUD operation to update an existing user
        public void UpdateUser(int userID, string userName, string email)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("UpdateUser", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserID", userID);
                command.Parameters.AddWithValue("@UserName", userName);
                command.Parameters.AddWithValue("@Email", email);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // CRUD operation to delete a user
        public void DeleteUser(int userID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("DeleteUser", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserID", userID);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
