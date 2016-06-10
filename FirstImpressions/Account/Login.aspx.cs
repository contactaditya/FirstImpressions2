using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
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
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Validate the user password
                var manager = new UserManager();
                ApplicationUser user = manager.Find(txtUserName.Text, txtPassword.Text);
                if (user != null)
                {
                    IdentityHelper.SignIn(manager, user, RememberMe.Checked);
                    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                }
                else
                {
                    FailureText.Text = "Invalid username or password.";
                    ErrorMessage.Visible = true;
                }
            }
        }

        public string getConnectionString()
        {
            string constr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            return constr;
        }


        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string str = getConnectionString();
            SqlConnection con = new SqlConnection(str);
            con.Open();
            string teststr = "spSelectRegistration";

            SqlCommand command = new SqlCommand(teststr, con);
            command.CommandType = CommandType.StoredProcedure;
            Session["UserName"] = txtUserName.Text.ToString().Trim();
            command.Parameters.AddWithValue("@username", txtUserName.Text.ToString().Trim());
            command.Parameters.AddWithValue("@userpassword", txtPassword.Text.ToString().Trim());
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);

            int result = command.ExecuteNonQuery();

            if (dt.Rows.Count > 0)
            {
                Response.Redirect("/AimofTheStudy.aspx");   
            }

            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Incorrect Login Details. Please try again!!')", true);

            }

            con.Close();
            con.Dispose();
        }
    }
}