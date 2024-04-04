using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using Serilog;

namespace Task_2
{
    public partial class CRUD1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    LoadGridData();
                }
                catch (Exception ex)
                {
                    LogError(ex);
                }
            }
        }

        protected void LoadGridData()
        {
            try
            {
                UserDataSet userAdapter = new UserDataSet();
                DataTable dt = userAdapter.SelectUser();
                MyGridView.DataSource = dt;
                MyGridView.DataBind();
            }
            catch (Exception ex)
            {
                LogError(ex);
                throw; 
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                string userName = txtUserName.Text.Trim();
                string email = txtEmail.Text.Trim();
                string password = txtPassword.Text.Trim();

                if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
                {
                    UserDataSet userAdapter = new UserDataSet();
                    userAdapter.InsertUser(userName, email, password);
                    txtUserName.Text = string.Empty;
                    txtEmail.Text = string.Empty;
                    txtPassword.Text = string.Empty;

                    LoadGridData();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Both User Name and Email are required.');", true);
                }
            }
            catch (Exception ex)
            {
                LogError(ex);
            }
        }

        private void LogError(Exception ex)
        {
            string logFilePath = ConfigurationManager.AppSettings["ErrorLogFilePath"];

            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"Timestamp: {DateTime.Now}");
                writer.WriteLine($"Error Message: {ex.Message}");
                writer.WriteLine($"Stack Trace: {ex.StackTrace}");
                writer.WriteLine(new string('-', 50));
            }
        }
    }
}
