using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace FirstImpressions
{
    public partial class Instructions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string getConnectionString()
        {
            string constr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            return constr;
        }

        protected void btnStart_Click(object sender, EventArgs e)
        {
            string str = getConnectionString();
            string currentUserName = Session["UserName"].ToString();
            SqlConnection con = new SqlConnection(str);
            con.Open();
            string teststr = "spCurrentUserName";
            SqlCommand command = new SqlCommand(teststr, con);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@username", currentUserName);
            SqlDataReader dataReader;
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                Session["Gender"] = dataReader["Gender"].ToString().Trim();
                Session["UserId"] = dataReader["UserId"].ToString().Trim();
            }

            dataReader.Close();
            command.Dispose();
            con.Close();

            int currentUserId = Convert.ToInt32(Session["UserId"]);               
            SqlConnection con1 = new SqlConnection(str);
            con1.Open();
            string teststr1 = "spCheckIfUserHasSeenButNotYetRated";

            SqlCommand command1 = new SqlCommand(teststr1, con1);
            command1.CommandType = CommandType.StoredProcedure;
            command1.Parameters.AddWithValue("@userid", currentUserId);
            SqlDataAdapter da = new SqlDataAdapter(command1);
            DataTable dt = new DataTable();
            da.Fill(dt);

            int result = command1.ExecuteNonQuery();

            if (dt.Rows.Count > 0)
            {
                command1.Dispose();
                con1.Close();
                Session["Counter"] = 2;

                foreach (DataRow row in dt.Rows)
                {
                    Session["PictureId"] = row["PictureId"].ToString();
                    Session["RaterSlot"] = row["RaterSlot"].ToString();
                }

                Response.Redirect("StudyPage2.aspx");
            }

            SqlConnection con2 = new SqlConnection(str);
            con2.Open();
            string teststr2 = "spCheckIfUserHasSeenButNotYetRated1";

            SqlCommand command2 = new SqlCommand(teststr2, con2);
            command2.CommandType = CommandType.StoredProcedure;
            command2.Parameters.AddWithValue("@userid", currentUserId);
            SqlDataAdapter da1 = new SqlDataAdapter(command2);
            DataTable dt1 = new DataTable();
            da.Fill(dt1);

            int result1 = command2.ExecuteNonQuery();

            if (dt1.Rows.Count > 0)
            {
                command2.Dispose();
                con2.Close();
                Session["Counter"] = 2;

                foreach (DataRow row in dt1.Rows)
                {
                    Session["PictureId"] = row["PictureId"].ToString();
                    Session["RaterSlot"] = row["RaterSlot"].ToString();
                }

                Response.Redirect("StudyPage1.aspx");
            }


                Random rnd = new Random();
                string[] PageNames = { "StudyPage1.aspx", "StudyPage2.aspx" };

                int pageIndex = rnd.Next(0, PageNames.Length);
                Session["Counter"] = 1;
                Response.Redirect(PageNames[pageIndex]);     
        }
    }
}