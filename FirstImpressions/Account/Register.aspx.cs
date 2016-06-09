using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using FirstImpressions.Models;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace FirstImpressions.Account
{
    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = new UserManager();
            var user = new ApplicationUser() { UserName = txtUserName.Text };
            IdentityResult result = manager.Create(user, txtPassword.Text);
            if (result.Succeeded)
            {
                IdentityHelper.SignIn(manager, user, isPersistent: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }

        public string getConnectionString()
        {
            string constr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            return constr;
        }


        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string str = getConnectionString();
            SqlConnection con = new SqlConnection(str);
            con.Open();
            string teststr = "spSelectUsername";
            SqlCommand command = new SqlCommand(teststr, con);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.AddWithValue("@username", txtUserName.Text.ToString().Trim());
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);

            int result = command.ExecuteNonQuery();
            if (dt.Rows.Count > 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('The username already exists. Please select a new username.')", true);
            }

            else
            {

                SqlConnection con1 = new SqlConnection(str);
                con1.Open();
                string teststr1 = "spInsertRegistration";
                SqlCommand command1 = new SqlCommand(teststr1, con1);
                command1.CommandType = CommandType.StoredProcedure;

                command1.Parameters.AddWithValue("@gender", txtGender.SelectedValue.ToString());
                command1.Parameters.AddWithValue("@age", txtAge.Text.ToString().Trim());
                command1.Parameters.AddWithValue("@username", txtUserName.Text.ToString().Trim());
                command1.Parameters.AddWithValue("@userpassword", txtPassword.Text.ToString().Trim());
                command1.Parameters.AddWithValue("@confirmpassword", txtConfirmPassword.Text.ToString().Trim());
                int result1 = command1.ExecuteNonQuery();
                if (result1 == 1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('User has been registered succesfully');location.href='Login.aspx'", true);
                }
                con1.Close();
                con1.Dispose();
            }
        }
    }
}