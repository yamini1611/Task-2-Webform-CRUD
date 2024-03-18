using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Task_2;

namespace Task_2
{
    public partial class CRUD1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGridData();
            }
        }

        protected void LoadGridData()
        {
            UserDataSet userAdapter = new UserDataSet();
            DataTable dt = userAdapter.SelectUser();
            MyGridView.DataSource = dt; 
            MyGridView.DataBind();
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(email))
            {
                UserDataSet userAdapter = new UserDataSet();
                userAdapter.InsertUser(userName, email);
                txtUserName.Text = string.Empty;
                txtEmail.Text = string.Empty;

                LoadGridData();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Both User Name and Email are required.');", true);
            }
        }

        protected void btnRead_Click(object sender, EventArgs e)
        {
            LoadGridData();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtUserID.Text, out int userID))
            {
                UserDataSet userAdapter = new UserDataSet();
                userAdapter.UpdateUser(userID, txtUserName.Text, txtEmail.Text);
                LoadGridData();
                txtUserName.Text = string.Empty;
                txtEmail.Text = string.Empty;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
         
            if (int.TryParse(txtUserID.Text, out int userID))
            {
                UserDataSet userAdapter = new UserDataSet();
                userAdapter.DeleteUser(userID);
                LoadGridData();
            }
        }

       protected void MyGridView_RowEditing(object sender, GridViewEditEventArgs e)
{
    MyGridView.EditIndex = e.NewEditIndex;
    LoadGridData();
    GridViewRow row = MyGridView.Rows[e.NewEditIndex];
    txtUserID.Text = MyGridView.DataKeys[e.NewEditIndex]["UserID"].ToString();
    txtUserName.Text = ((Label)row.FindControl("lblUserName")).Text;
    txtEmail.Text = ((Label)row.FindControl("lblEmail")).Text;
}


        protected void MyGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            MyGridView.EditIndex = -1;
            LoadGridData();
        }

        protected void MyGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int userID = Convert.ToInt32(MyGridView.DataKeys[e.RowIndex].Value);

            UserDataSet userAdapter = new UserDataSet();
            userAdapter.DeleteUser(userID);

            LoadGridData();
        }
    }
}
