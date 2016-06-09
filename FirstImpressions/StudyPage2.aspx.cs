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
using System.Collections;

namespace FirstImpressions
{
    public partial class StudyPage2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
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

                if (Convert.ToString(Session["Gender"]) == "Male")
                {
                    int currentUserId = Convert.ToInt32(Session["UserId"]);
                    SqlConnection con1 = new SqlConnection(str);
                    con1.Open();
                    string teststr1 = "spSelectPhoto3";
                    SqlCommand command1 = new SqlCommand(teststr1, con1);
                    command1.CommandType = CommandType.StoredProcedure;
                    command1.Parameters.AddWithValue("@userid", currentUserId);
                    SqlDataReader dataReader1;
                    dataReader1 = command1.ExecuteReader();
                    while (dataReader1.Read())
                    {
                        Session["Count"] = dataReader1["Count"].ToString().Trim();
                        Session["Condition"] = dataReader1["Condition"].ToString().Trim();
                        Session["NumberofPictures"] = dataReader1["NumberofPictures"].ToString().Trim();
                        Session["PictureName"] = dataReader1["PictureName"].ToString().Trim();
                        Session["PictureId"] = dataReader1["PictureId"].ToString().Trim();
                        Session["RaterSlot"] = dataReader1["RaterSlot"].ToString().Trim();
                    }

                    dataReader1.Close();
                    command1.Dispose();
                    con1.Close();

                    string pictureid = Session["PictureId"].ToString();
                    string raterslot = Session["RaterSlot"].ToString();
                    SqlConnection con2 = new SqlConnection(str);
                    con2.Open();
                    string teststr2 = "spSelectPicture";
                    SqlCommand command2 = new SqlCommand(teststr2, con2);
                    command2.CommandType = CommandType.StoredProcedure;
                    command2.Parameters.AddWithValue("@pictureid", pictureid);
                    SqlDataReader dataReader2;
                    dataReader2 = command2.ExecuteReader();

                    ArrayList PictureName = new ArrayList();
                    ArrayList Count = new ArrayList();
                    ArrayList Condition = new ArrayList();

                    if (dataReader2.HasRows)
                    {

                        while (dataReader2.Read())
                        {
                            PictureName.Add(Convert.ToString(dataReader2[0]));
                            Count.Add(Convert.ToInt32(dataReader2[1]));
                            Condition.Add(Convert.ToInt32(dataReader2[2]));
                        }

                    }
                    Session["PictureName"] = PictureName;
                    Session["Count"] = Count;
                    Session["Condition"] = Condition;

                    dataReader2.Close();
                    command2.Dispose();
                    con2.Close();

                    if (Convert.ToInt32(Session["NumberofPictures"]) == 1)
                    {
                        ArrayList PictureName1 = (ArrayList)Session["PictureName"];
                        ArrayList Count1 = (ArrayList)Session["Count"];
                        ArrayList Condition1 = (ArrayList)Session["Condition"];
                        string picturename = (string)PictureName1[0];
                        int conditions = (int)Condition1[0];
                        Image1.ImageUrl = Server.MapPath("../Pictures/" + picturename + ".jpg");

                        if (conditions == 1)
                        {
                            header1.Visible = false;
                            header2.Visible = false;
                            header3.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit1();</script>");

                            SqlConnection con3 = new SqlConnection(str);
                            con3.Open();
                            string teststr3 = "spUpdatePhoto4";
                            SqlCommand command3 = new SqlCommand(teststr3, con3);
                            command3.CommandType = CommandType.StoredProcedure;
                            command3.Parameters.AddWithValue("@picturename", picturename);
                            command3.Parameters.AddWithValue("@userid", currentUserId);
                            command3.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command3.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command3.Dispose();
                            con3.Close();
                        }

                        if (conditions == 2)
                        {
                            header1.Visible = false;
                            header2.Visible = false;
                            header3.Visible = false;
                            header1.Visible = false;
                            header2.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit2();</script>");

                            SqlConnection con4 = new SqlConnection(str);
                            con4.Open();
                            string teststr4 = "spUpdatePhoto4";
                            SqlCommand command4 = new SqlCommand(teststr4, con4);
                            command4.CommandType = CommandType.StoredProcedure;
                            command4.Parameters.AddWithValue("@picturename", picturename);
                            command4.Parameters.AddWithValue("@userid", currentUserId);
                            command4.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command4.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command4.Dispose();
                            con4.Close();
                        }

                        if (conditions == 3)
                        {
                            header1.Visible = false;
                            header2.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit3();</script>");

                            SqlConnection con5 = new SqlConnection(str);
                            con5.Open();
                            string teststr5 = "spUpdatePhoto4";
                            SqlCommand command5 = new SqlCommand(teststr5, con5);
                            command5.CommandType = CommandType.StoredProcedure;
                            command5.Parameters.AddWithValue("@picturename", picturename);
                            command5.Parameters.AddWithValue("@userid", currentUserId);
                            command5.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command5.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);
                            }

                            command5.Dispose();
                            con5.Close();
                        }

                        if (conditions == 4)
                        {
                            header1.Visible = false;
                            header2.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit4();</script>");

                            SqlConnection con6 = new SqlConnection(str);
                            con6.Open();
                            string teststr6 = "spUpdatePhoto4";
                            SqlCommand command6 = new SqlCommand(teststr6, con6);
                            command6.CommandType = CommandType.StoredProcedure;
                            command6.Parameters.AddWithValue("@picturename", picturename);
                            command6.Parameters.AddWithValue("@userid", currentUserId);
                            command6.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command6.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);
                            }

                            command6.Dispose();
                            con6.Close();
                        }

                    }


                    if (Convert.ToInt32(Session["NumberofPictures"]) == 2)
                    {
                        ArrayList PictureName2 = (ArrayList)Session["PictureName"];
                        ArrayList Count2 = (ArrayList)Session["Count"];
                        ArrayList Condition2 = (ArrayList)Session["Condition"];
                        string picturename = (string)PictureName2[0];
                        int conditions = (int)Condition2[0];
                        string picturename1 = (string)PictureName2[1];
                        int conditions1 = (int)Condition2[1];

                        Image2.ImageUrl = "http://firstimpressions.azurewebsites.net/Pictures/" + picturename + ".jpg";
                        Image3.ImageUrl = "http://firstimpressions.azurewebsites.net/Pictures/" + picturename1 + ".jpg";

                        if (conditions == 1 && conditions1 == 1)
                        {
                            header.Visible = false;
                            header2.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit5();</script>");

                            SqlConnection con7 = new SqlConnection(str);
                            con7.Open();
                            string teststr7 = "spUpdatePhoto5";
                            SqlCommand command7 = new SqlCommand(teststr7, con7);
                            command7.CommandType = CommandType.StoredProcedure;
                            command7.Parameters.AddWithValue("@picturename", picturename);
                            command7.Parameters.AddWithValue("@picturename1", picturename1);
                            command7.Parameters.AddWithValue("@userid", currentUserId);
                            command7.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command7.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command7.Dispose();
                            con7.Close();
                        }

                        if (conditions == 1 && conditions1 == 2)
                        {
                            header.Visible = false;
                            header2.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit6();</script>");

                            SqlConnection con8 = new SqlConnection(str);
                            con8.Open();
                            string teststr8 = "spUpdatePhoto5";
                            SqlCommand command8 = new SqlCommand(teststr8, con8);
                            command8.CommandType = CommandType.StoredProcedure;
                            command8.Parameters.AddWithValue("@picturename", picturename);
                            command8.Parameters.AddWithValue("@picturename1", picturename1);
                            command8.Parameters.AddWithValue("@userid", currentUserId);
                            command8.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command8.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command8.Dispose();
                            con8.Close();
                        }

                        if (conditions == 1 && conditions1 == 3)
                        {
                            header.Visible = false;
                            header2.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit7();</script>");


                            SqlConnection con9 = new SqlConnection(str);
                            con9.Open();
                            string teststr9 = "spUpdatePhoto5";
                            SqlCommand command9 = new SqlCommand(teststr9, con9);
                            command9.CommandType = CommandType.StoredProcedure;
                            command9.Parameters.AddWithValue("@picturename", picturename);
                            command9.Parameters.AddWithValue("@picturename1", picturename1);
                            command9.Parameters.AddWithValue("@userid", currentUserId);
                            command9.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command9.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command9.Dispose();
                            con9.Close();
                        }

                        if (conditions == 1 && conditions1 == 4)
                        {
                            header.Visible = false;
                            header2.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit8();</script>");

                            SqlConnection con10 = new SqlConnection(str);
                            con10.Open();
                            string teststr10 = "spUpdatePhoto5";
                            SqlCommand command10 = new SqlCommand(teststr10, con10);
                            command10.CommandType = CommandType.StoredProcedure;
                            command10.Parameters.AddWithValue("@picturename", picturename);
                            command10.Parameters.AddWithValue("@picturename1", picturename1);
                            command10.Parameters.AddWithValue("@userid", currentUserId);
                            command10.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command10.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command10.Dispose();
                            con10.Close();
                        }

                        if (conditions == 2 && conditions1 == 1)
                        {
                            header.Visible = false;
                            header2.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit9();</script>");

                            SqlConnection con11 = new SqlConnection(str);
                            con11.Open();
                            string teststr11 = "spUpdatePhoto5";
                            SqlCommand command11 = new SqlCommand(teststr11, con11);
                            command11.CommandType = CommandType.StoredProcedure;
                            command11.Parameters.AddWithValue("@picturename", picturename);
                            command11.Parameters.AddWithValue("@picturename1", picturename1);
                            command11.Parameters.AddWithValue("@userid", currentUserId);
                            command11.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command11.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command11.Dispose();
                            con11.Close();
                        }

                        if (conditions == 2 && conditions1 == 2)
                        {
                            header.Visible = false;
                            header2.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit10();</script>");

                            SqlConnection con12 = new SqlConnection(str);
                            con12.Open();
                            string teststr12 = "spUpdatePhoto5";
                            SqlCommand command12 = new SqlCommand(teststr12, con12);
                            command12.CommandType = CommandType.StoredProcedure;
                            command12.Parameters.AddWithValue("@picturename", picturename);
                            command12.Parameters.AddWithValue("@picturename1", picturename1);
                            command12.Parameters.AddWithValue("@userid", currentUserId);
                            command12.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command12.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command12.Dispose();
                            con12.Close();
                        }

                        if (conditions == 2 && conditions1 == 3)
                        {
                            header.Visible = false;
                            header2.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit11();</script>");

                            SqlConnection con13 = new SqlConnection(str);
                            con13.Open();
                            string teststr13 = "spUpdatePhoto5";
                            SqlCommand command13 = new SqlCommand(teststr13, con13);
                            command13.CommandType = CommandType.StoredProcedure;
                            command13.Parameters.AddWithValue("@picturename", picturename);
                            command13.Parameters.AddWithValue("@picturename1", picturename1);
                            command13.Parameters.AddWithValue("@userid", currentUserId);
                            command13.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command13.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command13.Dispose();
                            con13.Close();
                        }

                        if (conditions == 2 && conditions1 == 4)
                        {
                            header.Visible = false;
                            header2.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit12();</script>");

                            SqlConnection con14 = new SqlConnection(str);
                            con14.Open();
                            string teststr14 = "spUpdatePhoto5";
                            SqlCommand command14 = new SqlCommand(teststr14, con14);
                            command14.CommandType = CommandType.StoredProcedure;
                            command14.Parameters.AddWithValue("@picturename", picturename);
                            command14.Parameters.AddWithValue("@picturename1", picturename1);
                            command14.Parameters.AddWithValue("@userid", currentUserId);
                            command14.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command14.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command14.Dispose();
                            con14.Close();
                        }

                        if (conditions == 3 && conditions1 == 1)
                        {
                            header.Visible = false;
                            header2.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit13();</script>");

                            SqlConnection con15 = new SqlConnection(str);
                            con15.Open();
                            string teststr15 = "spUpdatePhoto5";
                            SqlCommand command15 = new SqlCommand(teststr15, con15);
                            command15.CommandType = CommandType.StoredProcedure;
                            command15.Parameters.AddWithValue("@picturename", picturename);
                            command15.Parameters.AddWithValue("@picturename1", picturename1);
                            command15.Parameters.AddWithValue("@userid", currentUserId);
                            command15.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command15.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command15.Dispose();
                            con15.Close();
                        }

                        if (conditions == 3 && conditions1 == 3)
                        {
                            header.Visible = false;
                            header2.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit14();</script>");


                            SqlConnection con16 = new SqlConnection(str);
                            con16.Open();
                            string teststr16 = "spUpdatePhoto5";
                            SqlCommand command16 = new SqlCommand(teststr16, con16);
                            command16.CommandType = CommandType.StoredProcedure;
                            command16.Parameters.AddWithValue("@picturename", picturename);
                            command16.Parameters.AddWithValue("@picturename1", picturename1);
                            command16.Parameters.AddWithValue("@userid", currentUserId);
                            command16.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command16.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command16.Dispose();
                            con16.Close();
                        }

                        if (conditions == 3 && conditions1 == 4)
                        {
                            header.Visible = false;
                            header2.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit15();</script>");


                            SqlConnection con17 = new SqlConnection(str);
                            con17.Open();
                            string teststr17 = "spUpdatePhoto5";
                            SqlCommand command17 = new SqlCommand(teststr17, con17);
                            command17.CommandType = CommandType.StoredProcedure;
                            command17.Parameters.AddWithValue("@picturename", picturename);
                            command17.Parameters.AddWithValue("@picturename1", picturename1);
                            command17.Parameters.AddWithValue("@userid", currentUserId);
                            command17.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command17.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command17.Dispose();
                            con17.Close();
                        }

                        if (conditions == 4 && conditions1 == 1)
                        {
                            header.Visible = false;
                            header2.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit16();</script>");

                            SqlConnection con18 = new SqlConnection(str);
                            con18.Open();
                            string teststr18 = "spUpdatePhoto5";
                            SqlCommand command18 = new SqlCommand(teststr18, con18);
                            command18.CommandType = CommandType.StoredProcedure;
                            command18.Parameters.AddWithValue("@picturename", picturename);
                            command18.Parameters.AddWithValue("@picturename1", picturename1);
                            command18.Parameters.AddWithValue("@userid", currentUserId);
                            command18.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command18.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command18.Dispose();
                            con18.Close();
                        }

                        if (conditions == 4 && conditions1 == 3)
                        {
                            header.Visible = false;
                            header2.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit17();</script>");


                            SqlConnection con19 = new SqlConnection(str);
                            con19.Open();
                            string teststr19 = "spUpdatePhoto5";
                            SqlCommand command19 = new SqlCommand(teststr19, con19);
                            command19.CommandType = CommandType.StoredProcedure;
                            command19.Parameters.AddWithValue("@picturename", picturename);
                            command19.Parameters.AddWithValue("@picturename1", picturename1);
                            command19.Parameters.AddWithValue("@userid", currentUserId);
                            command19.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command19.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command19.Dispose();
                            con19.Close();
                        }

                        if (conditions == 4 && conditions1 == 4)
                        {
                            header.Visible = false;
                            header2.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit18();</script>");


                            SqlConnection con20 = new SqlConnection(str);
                            con20.Open();
                            string teststr20 = "spUpdatePhoto5";
                            SqlCommand command20 = new SqlCommand(teststr20, con20);
                            command20.CommandType = CommandType.StoredProcedure;
                            command20.Parameters.AddWithValue("@picturename", picturename);
                            command20.Parameters.AddWithValue("@picturename1", picturename1);
                            command20.Parameters.AddWithValue("@userid", currentUserId);
                            command20.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command20.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command20.Dispose();
                            con20.Close();
                        }
                    }

                    if (Convert.ToInt32(Session["NumberofPictures"]) == 3)
                    {
                        ArrayList PictureName3 = (ArrayList)Session["PictureName"];
                        ArrayList Count3 = (ArrayList)Session["Count"];
                        ArrayList Condition3 = (ArrayList)Session["Condition"];
                        string picturename = (string)PictureName3[0];
                        int conditions = (int)Condition3[0];
                        string picturename1 = (string)PictureName3[1];
                        int conditions1 = (int)Condition3[1];
                        string picturename2 = (string)PictureName3[2];
                        int conditions2 = (int)Condition3[2];

                        Image4.ImageUrl = "http://firstimpressions.azurewebsites.net/Pictures/" + picturename + ".jpg";
                        Image5.ImageUrl = "http://firstimpressions.azurewebsites.net/Pictures/" + picturename1 + ".jpg";
                        Image6.ImageUrl = "http://firstimpressions.azurewebsites.net/Pictures/" + picturename2 + ".jpg";

                        if (conditions == 1 && conditions1 == 1 && conditions2 == 1)
                        {
                            header.Visible = false;
                            header1.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit19();</script>");

                            SqlConnection con21 = new SqlConnection(str);
                            con21.Open();
                            string teststr21 = "spUpdatePhoto6";
                            SqlCommand command21 = new SqlCommand(teststr21, con21);
                            command21.CommandType = CommandType.StoredProcedure;
                            command21.Parameters.AddWithValue("@picturename", picturename);
                            command21.Parameters.AddWithValue("@picturename1", picturename1);
                            command21.Parameters.AddWithValue("@picturename2", picturename2);
                            command21.Parameters.AddWithValue("@userid", currentUserId);
                            command21.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command21.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);
                            }

                            command21.Dispose();
                            con21.Close();
                        }

                        if (conditions == 1 && conditions1 == 1 && conditions2 == 4)
                        {
                            header.Visible = false;
                            header1.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit20();</script>");


                            SqlConnection con22 = new SqlConnection(str);
                            con22.Open();
                            string teststr22 = "spUpdatePhoto6";
                            SqlCommand command22 = new SqlCommand(teststr22, con22);
                            command22.CommandType = CommandType.StoredProcedure;
                            command22.Parameters.AddWithValue("@picturename", picturename);
                            command22.Parameters.AddWithValue("@picturename1", picturename1);
                            command22.Parameters.AddWithValue("@picturename2", picturename2);
                            command22.Parameters.AddWithValue("@userid", currentUserId);
                            command22.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command22.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command22.Dispose();
                            con22.Close();
                        }

                        if (conditions == 1 && conditions1 == 2 && conditions2 == 1)
                        {
                            header.Visible = false;
                            header1.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit21();</script>");

                            SqlConnection con23 = new SqlConnection(str);
                            con23.Open();
                            string teststr23 = "spUpdatePhoto6";
                            SqlCommand command23 = new SqlCommand(teststr23, con23);
                            command23.CommandType = CommandType.StoredProcedure;
                            command23.Parameters.AddWithValue("@picturename", picturename);
                            command23.Parameters.AddWithValue("@picturename1", picturename1);
                            command23.Parameters.AddWithValue("@picturename2", picturename2);
                            command23.Parameters.AddWithValue("@userid", currentUserId);
                            command23.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command23.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command23.Dispose();
                            con23.Close();
                        }

                        if (conditions == 1 && conditions1 == 3 && conditions2 == 1)
                        {
                            header.Visible = false;
                            header1.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit22();</script>");

                            SqlConnection con24 = new SqlConnection(str);
                            con24.Open();
                            string teststr24 = "spUpdatePhoto6";
                            SqlCommand command24 = new SqlCommand(teststr24, con24);
                            command24.CommandType = CommandType.StoredProcedure;
                            command24.Parameters.AddWithValue("@picturename", picturename);
                            command24.Parameters.AddWithValue("@picturename1", picturename1);
                            command24.Parameters.AddWithValue("@picturename2", picturename2);
                            command24.Parameters.AddWithValue("@userid", currentUserId);
                            command24.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command24.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command24.Dispose();
                            con24.Close();
                        }

                        if (conditions == 1 && conditions1 == 4 && conditions2 == 1)
                        {
                            header.Visible = false;
                            header1.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit23();</script>");

                            SqlConnection con25 = new SqlConnection(str);
                            con25.Open();
                            string teststr25 = "spUpdatePhoto6";
                            SqlCommand command25 = new SqlCommand(teststr25, con25);
                            command25.CommandType = CommandType.StoredProcedure;
                            command25.Parameters.AddWithValue("@picturename", picturename);
                            command25.Parameters.AddWithValue("@picturename1", picturename1);
                            command25.Parameters.AddWithValue("@picturename2", picturename2);
                            command25.Parameters.AddWithValue("@userid", currentUserId);
                            command25.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command25.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command25.Dispose();
                            con25.Close();
                        }
                        if (conditions == 1 && conditions1 == 4 && conditions2 == 3)
                        {
                            header.Visible = false;
                            header1.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit24();</script>");

                            SqlConnection con26 = new SqlConnection(str);
                            con26.Open();
                            string teststr26 = "spUpdatePhoto6";
                            SqlCommand command26 = new SqlCommand(teststr26, con26);
                            command26.CommandType = CommandType.StoredProcedure;
                            command26.Parameters.AddWithValue("@picturename", picturename);
                            command26.Parameters.AddWithValue("@picturename1", picturename1);
                            command26.Parameters.AddWithValue("@picturename2", picturename2);
                            command26.Parameters.AddWithValue("@userid", currentUserId);
                            command26.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command26.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command26.Dispose();
                            con26.Close();
                        }

                        if (conditions == 3 && conditions1 == 1 && conditions2 == 1)
                        {
                            header.Visible = false;
                            header1.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit25();</script>");

                            SqlConnection con27 = new SqlConnection(str);
                            con27.Open();
                            string teststr27 = "spUpdatePhoto6";
                            SqlCommand command27 = new SqlCommand(teststr27, con27);
                            command27.CommandType = CommandType.StoredProcedure;
                            command27.Parameters.AddWithValue("@picturename", picturename);
                            command27.Parameters.AddWithValue("@picturename1", picturename1);
                            command27.Parameters.AddWithValue("@picturename2", picturename2);
                            command27.Parameters.AddWithValue("@userid", currentUserId);
                            command27.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command27.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command27.Dispose();
                            con27.Close();
                        }

                        if (conditions == 3 && conditions1 == 1 && conditions2 == 4)
                        {
                            header.Visible = false;
                            header1.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit26();</script>");

                            SqlConnection con28 = new SqlConnection(str);
                            con28.Open();
                            string teststr28 = "spUpdatePhoto6";
                            SqlCommand command28 = new SqlCommand(teststr28, con28);
                            command28.CommandType = CommandType.StoredProcedure;
                            command28.Parameters.AddWithValue("@picturename", picturename);
                            command28.Parameters.AddWithValue("@picturename1", picturename1);
                            command28.Parameters.AddWithValue("@picturename2", picturename2);
                            command28.Parameters.AddWithValue("@userid", currentUserId);
                            command28.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command28.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command28.Dispose();
                            con28.Close();
                        }

                        if (conditions == 3 && conditions1 == 2 && conditions2 == 1)
                        {
                            header.Visible = false;
                            header1.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit27();</script>");

                            SqlConnection con29 = new SqlConnection(str);
                            con29.Open();
                            string teststr29 = "spUpdatePhoto6";
                            SqlCommand command29 = new SqlCommand(teststr29, con29);
                            command29.CommandType = CommandType.StoredProcedure;
                            command29.Parameters.AddWithValue("@picturename", picturename);
                            command29.Parameters.AddWithValue("@picturename1", picturename1);
                            command29.Parameters.AddWithValue("@picturename2", picturename2);
                            command29.Parameters.AddWithValue("@userid", currentUserId);
                            command29.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command29.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command29.Dispose();
                            con29.Close();
                        }

                        if (conditions == 4 && conditions1 == 1 && conditions2 == 1)
                        {
                            header.Visible = false;
                            header1.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit28();</script>");

                            SqlConnection con30 = new SqlConnection(str);
                            con30.Open();
                            string teststr30 = "spUpdatePhoto6";
                            SqlCommand command30 = new SqlCommand(teststr30, con30);
                            command30.CommandType = CommandType.StoredProcedure;
                            command30.Parameters.AddWithValue("@picturename", picturename);
                            command30.Parameters.AddWithValue("@picturename1", picturename1);
                            command30.Parameters.AddWithValue("@picturename2", picturename2);
                            command30.Parameters.AddWithValue("@userid", currentUserId);
                            command30.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command30.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command30.Dispose();
                            con30.Close();
                        }

                        if (conditions == 4 && conditions1 == 1 && conditions2 == 4)
                        {
                            header.Visible = false;
                            header1.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit29();</script>");

                            SqlConnection con31 = new SqlConnection(str);
                            con31.Open();
                            string teststr31 = "spUpdatePhoto6";
                            SqlCommand command31 = new SqlCommand(teststr31, con31);
                            command31.CommandType = CommandType.StoredProcedure;
                            command31.Parameters.AddWithValue("@picturename", picturename);
                            command31.Parameters.AddWithValue("@picturename1", picturename1);
                            command31.Parameters.AddWithValue("@picturename2", picturename2);
                            command31.Parameters.AddWithValue("@userid", currentUserId);
                            command31.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command31.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command31.Dispose();
                            con31.Close();
                        }

                        if (conditions == 4 && conditions1 == 2 && conditions2 == 1)
                        {
                            header.Visible = false;
                            header1.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit30();</script>");

                            SqlConnection con32 = new SqlConnection(str);
                            con32.Open();
                            string teststr32 = "spUpdatePhoto6";
                            SqlCommand command32 = new SqlCommand(teststr32, con32);
                            command32.CommandType = CommandType.StoredProcedure;
                            command32.Parameters.AddWithValue("@picturename", picturename);
                            command32.Parameters.AddWithValue("@picturename1", picturename1);
                            command32.Parameters.AddWithValue("@picturename2", picturename2);
                            command32.Parameters.AddWithValue("@userid", currentUserId);
                            command32.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command32.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command32.Dispose();
                            con32.Close();
                        }

                        if (conditions == 4 && conditions1 == 3 && conditions2 == 4)
                        {
                            header.Visible = false;
                            header1.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit31();</script>");

                            SqlConnection con33 = new SqlConnection(str);
                            con33.Open();
                            string teststr33 = "spUpdatePhoto6";
                            SqlCommand command33 = new SqlCommand(teststr33, con33);
                            command33.CommandType = CommandType.StoredProcedure;
                            command33.Parameters.AddWithValue("@picturename", picturename);
                            command33.Parameters.AddWithValue("@picturename1", picturename1);
                            command33.Parameters.AddWithValue("@picturename2", picturename2);
                            command33.Parameters.AddWithValue("@userid", currentUserId);
                            command33.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command33.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command33.Dispose();
                            con33.Close();
                        }
                        if (conditions == 4 && conditions1 == 4 && conditions2 == 4)
                        {
                            header.Visible = false;
                            header1.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit32();</script>");

                            SqlConnection con34 = new SqlConnection(str);
                            con34.Open();
                            string teststr34 = "spUpdatePhoto6";
                            SqlCommand command34 = new SqlCommand(teststr34, con34);
                            command34.CommandType = CommandType.StoredProcedure;
                            command34.Parameters.AddWithValue("@picturename", picturename);
                            command34.Parameters.AddWithValue("@picturename1", picturename1);
                            command34.Parameters.AddWithValue("@picturename2", picturename2);
                            command34.Parameters.AddWithValue("@userid", currentUserId);
                            command34.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command34.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command34.Dispose();
                            con34.Close();
                        }

                    }

                    if (Convert.ToInt32(Session["NumberofPictures"]) == 4)
                    {
                        ArrayList PictureName4 = (ArrayList)Session["PictureName"];
                        ArrayList Count4 = (ArrayList)Session["Count"];
                        ArrayList Condition4 = (ArrayList)Session["Condition"];
                        string picturename = (string)PictureName4[0];
                        int conditions = (int)Condition4[0];
                        string picturename1 = (string)PictureName4[1];
                        int conditions1 = (int)Condition4[1];
                        string picturename2 = (string)PictureName4[2];
                        int conditions2 = (int)Condition4[2];
                        string picturename3 = (string)PictureName4[3];
                        int conditions3 = (int)Condition4[3];
                        Image7.ImageUrl = "http://firstimpressions.azurewebsites.net/Pictures/" + picturename + ".jpg";
                        Image8.ImageUrl = "http://firstimpressions.azurewebsites.net/Pictures/" + picturename1 + ".jpg";
                        Image9.ImageUrl = "http://firstimpressions.azurewebsites.net/Pictures/" + picturename2 + ".jpg";
                        Image10.ImageUrl = "http://firstimpressions.azurewebsites.net/Pictures/" + picturename3 + ".jpg";

                        if (conditions == 1 && conditions1 == 1 && conditions2 == 1 && conditions3 == 1)
                        {
                            header.Visible = false;
                            header1.Visible = false;
                            header2.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit33();</script>");

                            SqlConnection con35 = new SqlConnection(str);
                            con35.Open();
                            string teststr35 = "spUpdatePhoto7";
                            SqlCommand command35 = new SqlCommand(teststr35, con35);
                            command35.CommandType = CommandType.StoredProcedure;
                            command35.Parameters.AddWithValue("@picturename", picturename);
                            command35.Parameters.AddWithValue("@picturename1", picturename1);
                            command35.Parameters.AddWithValue("@picturename2", picturename2);
                            command35.Parameters.AddWithValue("@picturename3", picturename3);
                            command35.Parameters.AddWithValue("@userid", currentUserId);
                            command35.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command35.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command35.Dispose();
                            con35.Close();
                        }
                        if (conditions == 1 && conditions1 == 1 && conditions2 == 3 && conditions3 == 1)
                        {
                            header.Visible = false;
                            header1.Visible = false;
                            header2.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit34();</script>");

                            SqlConnection con36 = new SqlConnection(str);
                            con36.Open();
                            string teststr36 = "spUpdatePhoto7";
                            SqlCommand command36 = new SqlCommand(teststr36, con36);
                            command36.CommandType = CommandType.StoredProcedure;
                            command36.Parameters.AddWithValue("@picturename", picturename);
                            command36.Parameters.AddWithValue("@picturename1", picturename1);
                            command36.Parameters.AddWithValue("@picturename2", picturename2);
                            command36.Parameters.AddWithValue("@picturename3", picturename3);
                            command36.Parameters.AddWithValue("@userid", currentUserId);
                            command36.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command36.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command36.Dispose();
                            con36.Close();
                        }

                        if (conditions == 1 && conditions1 == 4 && conditions2 == 1 && conditions3 == 1)
                        {
                            header.Visible = false;
                            header1.Visible = false;
                            header2.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit35();</script>");

                            SqlConnection con37 = new SqlConnection(str);
                            con37.Open();
                            string teststr37 = "spUpdatePhoto7";
                            SqlCommand command37 = new SqlCommand(teststr37, con37);
                            command37.CommandType = CommandType.StoredProcedure;
                            command37.Parameters.AddWithValue("@picturename", picturename);
                            command37.Parameters.AddWithValue("@picturename1", picturename1);
                            command37.Parameters.AddWithValue("@picturename2", picturename2);
                            command37.Parameters.AddWithValue("@picturename3", picturename3);
                            command37.Parameters.AddWithValue("@userid", currentUserId);
                            command37.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command37.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command37.Dispose();
                            con37.Close();
                        }
                        if (conditions == 1 && conditions1 == 4 && conditions2 == 1 && conditions3 == 4)
                        {
                            header.Visible = false;
                            header1.Visible = false;
                            header2.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit36();</script>");

                            SqlConnection con38 = new SqlConnection(str);
                            con38.Open();
                            string teststr38 = "spUpdatePhoto7";
                            SqlCommand command38 = new SqlCommand(teststr38, con38);
                            command38.CommandType = CommandType.StoredProcedure;
                            command38.Parameters.AddWithValue("@picturename", picturename);
                            command38.Parameters.AddWithValue("@picturename1", picturename1);
                            command38.Parameters.AddWithValue("@picturename2", picturename2);
                            command38.Parameters.AddWithValue("@picturename3", picturename3);
                            command38.Parameters.AddWithValue("@userid", currentUserId);
                            command38.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command38.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command38.Dispose();
                            con38.Close();
                        }
                        if (conditions == 4 && conditions1 == 1 && conditions2 == 1 && conditions3 == 1)
                        {
                            header.Visible = false;
                            header1.Visible = false;
                            header2.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit37();</script>");

                            SqlConnection con39 = new SqlConnection(str);
                            con39.Open();
                            string teststr39 = "spUpdatePhoto7";
                            SqlCommand command39 = new SqlCommand(teststr39, con39);
                            command39.CommandType = CommandType.StoredProcedure;
                            command39.Parameters.AddWithValue("@picturename", picturename);
                            command39.Parameters.AddWithValue("@picturename1", picturename1);
                            command39.Parameters.AddWithValue("@picturename2", picturename2);
                            command39.Parameters.AddWithValue("@picturename3", picturename3);
                            command39.Parameters.AddWithValue("@userid", currentUserId);
                            command39.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command39.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command39.Dispose();
                            con39.Close();
                        }

                        if (conditions == 4 && conditions1 == 1 && conditions2 == 3 && conditions3 == 1)
                        {
                            header.Visible = false;
                            header1.Visible = false;
                            header2.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit38();</script>");

                            SqlConnection con40 = new SqlConnection(str);
                            con40.Open();
                            string teststr40 = "spUpdatePhoto7";
                            SqlCommand command40 = new SqlCommand(teststr40, con40);
                            command40.CommandType = CommandType.StoredProcedure;
                            command40.Parameters.AddWithValue("@picturename", picturename);
                            command40.Parameters.AddWithValue("@picturename1", picturename1);
                            command40.Parameters.AddWithValue("@picturename2", picturename2);
                            command40.Parameters.AddWithValue("@picturename3", picturename3);
                            command40.Parameters.AddWithValue("@userid", currentUserId);
                            command40.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command40.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command40.Dispose();
                            con40.Close();
                        }

                        if (conditions == 4 && conditions1 == 2 && conditions2 == 1 && conditions3 == 4)
                        {
                            header.Visible = false;
                            header1.Visible = false;
                            header2.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit39();</script>");

                            SqlConnection con41 = new SqlConnection(str);
                            con41.Open();
                            string teststr41 = "spUpdatePhoto7";
                            SqlCommand command41 = new SqlCommand(teststr41, con41);
                            command41.CommandType = CommandType.StoredProcedure;
                            command41.Parameters.AddWithValue("@picturename", picturename);
                            command41.Parameters.AddWithValue("@picturename1", picturename1);
                            command41.Parameters.AddWithValue("@picturename2", picturename2);
                            command41.Parameters.AddWithValue("@picturename3", picturename3);
                            command41.Parameters.AddWithValue("@userid", currentUserId);
                            command41.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command41.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command41.Dispose();
                            con41.Close();
                        }

                        if (conditions == 4 && conditions1 == 3 && conditions2 == 1 && conditions3 == 1)
                        {
                            header.Visible = false;
                            header1.Visible = false;
                            header2.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit40();</script>");

                            SqlConnection con42 = new SqlConnection(str);
                            con42.Open();
                            string teststr42 = "spUpdatePhoto7";
                            SqlCommand command42 = new SqlCommand(teststr42, con42);
                            command42.CommandType = CommandType.StoredProcedure;
                            command42.Parameters.AddWithValue("@picturename", picturename);
                            command42.Parameters.AddWithValue("@picturename1", picturename1);
                            command42.Parameters.AddWithValue("@picturename2", picturename2);
                            command42.Parameters.AddWithValue("@picturename3", picturename3);
                            command42.Parameters.AddWithValue("@userid", currentUserId);
                            command42.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command42.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command42.Dispose();
                            con42.Close();
                        }


                        if (conditions == 4 && conditions1 == 4 && conditions2 == 1 && conditions3 == 4)
                        {
                            header.Visible = false;
                            header1.Visible = false;
                            header2.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit41();</script>");

                            SqlConnection con43 = new SqlConnection(str);
                            con43.Open();
                            string teststr43 = "spUpdatePhoto7";
                            SqlCommand command43 = new SqlCommand(teststr43, con43);
                            command43.CommandType = CommandType.StoredProcedure;
                            command43.Parameters.AddWithValue("@picturename", picturename);
                            command43.Parameters.AddWithValue("@picturename1", picturename1);
                            command43.Parameters.AddWithValue("@picturename2", picturename2);
                            command43.Parameters.AddWithValue("@picturename3", picturename3);
                            command43.Parameters.AddWithValue("@userid", currentUserId);
                            command43.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command43.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command43.Dispose();
                            con43.Close();
                        }


                        if (conditions == 4 && conditions1 == 4 && conditions2 == 4 && conditions3 == 4)
                        {
                            header.Visible = false;
                            header1.Visible = false;
                            header2.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit42();</script>");

                            SqlConnection con44 = new SqlConnection(str);
                            con44.Open();
                            string teststr44 = "spUpdatePhoto7";
                            SqlCommand command44 = new SqlCommand(teststr44, con44);
                            command44.CommandType = CommandType.StoredProcedure;
                            command44.Parameters.AddWithValue("@picturename", picturename);
                            command44.Parameters.AddWithValue("@picturename1", picturename1);
                            command44.Parameters.AddWithValue("@picturename2", picturename2);
                            command44.Parameters.AddWithValue("@picturename3", picturename3);
                            command44.Parameters.AddWithValue("@userid", currentUserId);
                            command44.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command44.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command44.Dispose();
                            con44.Close();
                        }
                    }

                }
                else
                {
                    int currentUserId = Convert.ToInt32(Session["UserId"]);
                    SqlConnection con1 = new SqlConnection(str);
                    con1.Open();
                    string teststr1 = "spSelectPhoto4";
                    SqlCommand command1 = new SqlCommand(teststr1, con1);
                    command1.CommandType = CommandType.StoredProcedure;
                    command1.Parameters.AddWithValue("@userid", currentUserId);
                    SqlDataReader dataReader1;
                    dataReader1 = command1.ExecuteReader();
                    while (dataReader1.Read())
                    {
                        Session["Count"] = dataReader1["Count"].ToString().Trim();
                        Session["Condition"] = dataReader1["Condition"].ToString().Trim();
                        Session["NumberofPictures"] = dataReader1["NumberofPictures"].ToString().Trim();
                        Session["PictureName"] = dataReader1["PictureName"].ToString().Trim();
                        Session["PictureId"] = dataReader1["PictureId"].ToString().Trim();
                        Session["RaterSlot"] = dataReader1["RaterSlot"].ToString().Trim();
                    }

                    dataReader1.Close();
                    command1.Dispose();
                    con1.Close();

                    string pictureid = Session["PictureId"].ToString();
                    string raterslot = Session["RaterSlot"].ToString();
                    SqlConnection con2 = new SqlConnection(str);
                    con2.Open();
                    string teststr2 = "spSelectPicture";
                    SqlCommand command2 = new SqlCommand(teststr2, con2);
                    command2.CommandType = CommandType.StoredProcedure;
                    command2.Parameters.AddWithValue("@pictureid", pictureid);
                    SqlDataReader dataReader2;
                    dataReader2 = command2.ExecuteReader();

                    ArrayList PictureName = new ArrayList();
                    ArrayList Count = new ArrayList();
                    ArrayList Condition = new ArrayList();

                    if (dataReader2.HasRows)
                    {

                        while (dataReader2.Read())
                        {
                            PictureName.Add(Convert.ToString(dataReader2[0]));
                            Count.Add(Convert.ToInt32(dataReader2[1]));
                            Condition.Add(Convert.ToInt32(dataReader2[2]));
                        }

                    }
                    Session["PictureName"] = PictureName;
                    Session["Count"] = Count;
                    Session["Condition"] = Condition;

                    dataReader2.Close();
                    command2.Dispose();
                    con2.Close();

                    if (Convert.ToInt32(Session["NumberofPictures"]) == 1)
                    {
                        ArrayList PictureName1 = (ArrayList)Session["PictureName"];
                        ArrayList Count1 = (ArrayList)Session["Count"];
                        ArrayList Condition1 = (ArrayList)Session["Condition"];
                        string picturename = (string)PictureName1[0];
                        int conditions = (int)Condition1[0];

                        Image1.ImageUrl = "http://firstimpressions.azurewebsites.net/Pictures/" + picturename + ".jpg";

                        if (conditions == 1)
                        {
                            header1.Visible = false;
                            header2.Visible = false;
                            header3.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit1();</script>");

                            SqlConnection con3 = new SqlConnection(str);
                            con3.Open();
                            string teststr3 = "spUpdatePhoto4";
                            SqlCommand command3 = new SqlCommand(teststr3, con3);
                            command3.CommandType = CommandType.StoredProcedure;
                            command3.Parameters.AddWithValue("@picturename", picturename);
                            command3.Parameters.AddWithValue("@userid", currentUserId);
                            command3.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command3.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command3.Dispose();
                            con3.Close();
                        }

                        if (conditions == 2)
                        {
                            header1.Visible = false;
                            header2.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit2();</script>");

                            SqlConnection con4 = new SqlConnection(str);
                            con4.Open();
                            string teststr4 = "spUpdatePhoto4";
                            SqlCommand command4 = new SqlCommand(teststr4, con4);
                            command4.CommandType = CommandType.StoredProcedure;
                            command4.Parameters.AddWithValue("@picturename", picturename);
                            command4.Parameters.AddWithValue("@userid", currentUserId);
                            command4.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command4.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command4.Dispose();
                            con4.Close();
                        }

                        if (conditions == 3)
                        {
                            header1.Visible = false;
                            header2.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit3();</script>");

                            SqlConnection con5 = new SqlConnection(str);
                            con5.Open();
                            string teststr5 = "spUpdatePhoto4";
                            SqlCommand command5 = new SqlCommand(teststr5, con5);
                            command5.CommandType = CommandType.StoredProcedure;
                            command5.Parameters.AddWithValue("@picturename", picturename);
                            command5.Parameters.AddWithValue("@userid", currentUserId);
                            command5.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command5.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);
                            }

                            command5.Dispose();
                            con5.Close();
                        }

                        if (conditions == 4)
                        {
                            header1.Visible = false;
                            header2.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit4();</script>");

                            SqlConnection con6 = new SqlConnection(str);
                            con6.Open();
                            string teststr6 = "spUpdatePhoto4";
                            SqlCommand command6 = new SqlCommand(teststr6, con6);
                            command6.CommandType = CommandType.StoredProcedure;
                            command6.Parameters.AddWithValue("@picturename", picturename);
                            command6.Parameters.AddWithValue("@userid", currentUserId);
                            command6.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command6.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);
                            }

                            command6.Dispose();
                            con6.Close();
                        }

                    }


                    if (Convert.ToInt32(Session["NumberofPictures"]) == 2)
                    {
                        ArrayList PictureName2 = (ArrayList)Session["PictureName"];
                        ArrayList Count2 = (ArrayList)Session["Count"];
                        ArrayList Condition2 = (ArrayList)Session["Condition"];
                        string picturename = (string)PictureName2[0];
                        int conditions = (int)Condition2[0];
                        string picturename1 = (string)PictureName2[1];
                        int conditions1 = (int)Condition2[1];

                        Image2.ImageUrl = "http://firstimpressions.azurewebsites.net/Pictures/" + picturename + ".jpg";
                        Image3.ImageUrl = "http://firstimpressions.azurewebsites.net/Pictures/" + picturename1 + ".jpg";

                        if (conditions == 1 && conditions1 == 1)
                        {
                            header.Visible = false;
                            header2.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit5();</script>");

                            SqlConnection con7 = new SqlConnection(str);
                            con7.Open();
                            string teststr7 = "spUpdatePhoto5";
                            SqlCommand command7 = new SqlCommand(teststr7, con7);
                            command7.CommandType = CommandType.StoredProcedure;
                            command7.Parameters.AddWithValue("@picturename", picturename);
                            command7.Parameters.AddWithValue("@picturename1", picturename1);
                            command7.Parameters.AddWithValue("@userid", currentUserId);
                            command7.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command7.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command7.Dispose();
                            con7.Close();
                        }

                        if (conditions == 1 && conditions1 == 2)
                        {
                            header.Visible = false;
                            header2.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit6();</script>");

                            SqlConnection con8 = new SqlConnection(str);
                            con8.Open();
                            string teststr8 = "spUpdatePhoto5";
                            SqlCommand command8 = new SqlCommand(teststr8, con8);
                            command8.CommandType = CommandType.StoredProcedure;
                            command8.Parameters.AddWithValue("@picturename", picturename);
                            command8.Parameters.AddWithValue("@picturename1", picturename1);
                            command8.Parameters.AddWithValue("@userid", currentUserId);
                            command8.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command8.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command8.Dispose();
                            con8.Close();
                        }

                        if (conditions == 1 && conditions1 == 3)
                        {
                            header.Visible = false;
                            header2.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit7();</script>");


                            SqlConnection con9 = new SqlConnection(str);
                            con9.Open();
                            string teststr9 = "spUpdatePhoto5";
                            SqlCommand command9 = new SqlCommand(teststr9, con9);
                            command9.CommandType = CommandType.StoredProcedure;
                            command9.Parameters.AddWithValue("@picturename", picturename);
                            command9.Parameters.AddWithValue("@picturename1", picturename1);
                            command9.Parameters.AddWithValue("@userid", currentUserId);
                            command9.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command9.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command9.Dispose();
                            con9.Close();
                        }

                        if (conditions == 1 && conditions1 == 4)
                        {
                            header.Visible = false;
                            header2.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit8();</script>");

                            SqlConnection con10 = new SqlConnection(str);
                            con10.Open();
                            string teststr10 = "spUpdatePhoto5";
                            SqlCommand command10 = new SqlCommand(teststr10, con10);
                            command10.CommandType = CommandType.StoredProcedure;
                            command10.Parameters.AddWithValue("@picturename", picturename);
                            command10.Parameters.AddWithValue("@picturename1", picturename1);
                            command10.Parameters.AddWithValue("@userid", currentUserId);
                            command10.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command10.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command10.Dispose();
                            con10.Close();
                        }

                        if (conditions == 2 && conditions1 == 1)
                        {
                            header.Visible = false;
                            header2.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit9();</script>");

                            SqlConnection con11 = new SqlConnection(str);
                            con11.Open();
                            string teststr11 = "spUpdatePhoto5";
                            SqlCommand command11 = new SqlCommand(teststr11, con11);
                            command11.CommandType = CommandType.StoredProcedure;
                            command11.Parameters.AddWithValue("@picturename", picturename);
                            command11.Parameters.AddWithValue("@picturename1", picturename1);
                            command11.Parameters.AddWithValue("@userid", currentUserId);
                            command11.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command11.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command11.Dispose();
                            con11.Close();
                        }

                        if (conditions == 2 && conditions1 == 2)
                        {
                            header.Visible = false;
                            header2.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit10();</script>");

                            SqlConnection con12 = new SqlConnection(str);
                            con12.Open();
                            string teststr12 = "spUpdatePhoto5";
                            SqlCommand command12 = new SqlCommand(teststr12, con12);
                            command12.CommandType = CommandType.StoredProcedure;
                            command12.Parameters.AddWithValue("@picturename", picturename);
                            command12.Parameters.AddWithValue("@picturename1", picturename1);
                            command12.Parameters.AddWithValue("@userid", currentUserId);
                            command12.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command12.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command12.Dispose();
                            con12.Close();
                        }

                        if (conditions == 2 && conditions1 == 3)
                        {
                            header.Visible = false;
                            header2.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit11();</script>");

                            SqlConnection con13 = new SqlConnection(str);
                            con13.Open();
                            string teststr13 = "spUpdatePhoto5";
                            SqlCommand command13 = new SqlCommand(teststr13, con13);
                            command13.CommandType = CommandType.StoredProcedure;
                            command13.Parameters.AddWithValue("@picturename", picturename);
                            command13.Parameters.AddWithValue("@picturename1", picturename1);
                            command13.Parameters.AddWithValue("@userid", currentUserId);
                            command13.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command13.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command13.Dispose();
                            con13.Close();
                        }

                        if (conditions == 2 && conditions1 == 4)
                        {
                            header.Visible = false;
                            header2.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit12();</script>");

                            SqlConnection con14 = new SqlConnection(str);
                            con14.Open();
                            string teststr14 = "spUpdatePhoto5";
                            SqlCommand command14 = new SqlCommand(teststr14, con14);
                            command14.CommandType = CommandType.StoredProcedure;
                            command14.Parameters.AddWithValue("@picturename", picturename);
                            command14.Parameters.AddWithValue("@picturename1", picturename1);
                            command14.Parameters.AddWithValue("@userid", currentUserId);
                            command14.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command14.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command14.Dispose();
                            con14.Close();
                        }

                        if (conditions == 3 && conditions1 == 1)
                        {
                            header.Visible = false;
                            header2.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit13();</script>");

                            SqlConnection con15 = new SqlConnection(str);
                            con15.Open();
                            string teststr15 = "spUpdatePhoto5";
                            SqlCommand command15 = new SqlCommand(teststr15, con15);
                            command15.CommandType = CommandType.StoredProcedure;
                            command15.Parameters.AddWithValue("@picturename", picturename);
                            command15.Parameters.AddWithValue("@picturename1", picturename1);
                            command15.Parameters.AddWithValue("@userid", currentUserId);
                            command15.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command15.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command15.Dispose();
                            con15.Close();
                        }

                        if (conditions == 3 && conditions1 == 3)
                        {
                            header.Visible = false;
                            header2.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit14();</script>");


                            SqlConnection con16 = new SqlConnection(str);
                            con16.Open();
                            string teststr16 = "spUpdatePhoto5";
                            SqlCommand command16 = new SqlCommand(teststr16, con16);
                            command16.CommandType = CommandType.StoredProcedure;
                            command16.Parameters.AddWithValue("@picturename", picturename);
                            command16.Parameters.AddWithValue("@picturename1", picturename1);
                            command16.Parameters.AddWithValue("@userid", currentUserId);
                            command16.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command16.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command16.Dispose();
                            con16.Close();
                        }

                        if (conditions == 3 && conditions1 == 4)
                        {
                            header.Visible = false;
                            header2.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit15();</script>");


                            SqlConnection con17 = new SqlConnection(str);
                            con17.Open();
                            string teststr17 = "spUpdatePhoto5";
                            SqlCommand command17 = new SqlCommand(teststr17, con17);
                            command17.CommandType = CommandType.StoredProcedure;
                            command17.Parameters.AddWithValue("@picturename", picturename);
                            command17.Parameters.AddWithValue("@picturename1", picturename1);
                            command17.Parameters.AddWithValue("@userid", currentUserId);
                            command17.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command17.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command17.Dispose();
                            con17.Close();
                        }

                        if (conditions == 4 && conditions1 == 1)
                        {
                            header.Visible = false;
                            header2.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit16();</script>");

                            SqlConnection con18 = new SqlConnection(str);
                            con18.Open();
                            string teststr18 = "spUpdatePhoto5";
                            SqlCommand command18 = new SqlCommand(teststr18, con18);
                            command18.CommandType = CommandType.StoredProcedure;
                            command18.Parameters.AddWithValue("@picturename", picturename);
                            command18.Parameters.AddWithValue("@picturename1", picturename1);
                            command18.Parameters.AddWithValue("@userid", currentUserId);
                            command18.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command18.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command18.Dispose();
                            con18.Close();
                        }

                        if (conditions == 4 && conditions1 == 3)
                        {
                            header.Visible = false;
                            header2.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit17();</script>");


                            SqlConnection con19 = new SqlConnection(str);
                            con19.Open();
                            string teststr19 = "spUpdatePhoto5";
                            SqlCommand command19 = new SqlCommand(teststr19, con19);
                            command19.CommandType = CommandType.StoredProcedure;
                            command19.Parameters.AddWithValue("@picturename", picturename);
                            command19.Parameters.AddWithValue("@picturename1", picturename1);
                            command19.Parameters.AddWithValue("@userid", currentUserId);
                            command19.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command19.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command19.Dispose();
                            con19.Close();
                        }

                        if (conditions == 4 && conditions1 == 4)
                        {
                            header.Visible = false;
                            header2.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit18();</script>");


                            SqlConnection con20 = new SqlConnection(str);
                            con20.Open();
                            string teststr20 = "spUpdatePhoto5";
                            SqlCommand command20 = new SqlCommand(teststr20, con20);
                            command20.CommandType = CommandType.StoredProcedure;
                            command20.Parameters.AddWithValue("@picturename", picturename);
                            command20.Parameters.AddWithValue("@picturename1", picturename1);
                            command20.Parameters.AddWithValue("@userid", currentUserId);
                            command20.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command20.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command20.Dispose();
                            con20.Close();
                        }
                    }

                    if (Convert.ToInt32(Session["NumberofPictures"]) == 3)
                    {
                        ArrayList PictureName3 = (ArrayList)Session["PictureName"];
                        ArrayList Count3 = (ArrayList)Session["Count"];
                        ArrayList Condition3 = (ArrayList)Session["Condition"];
                        string picturename = (string)PictureName3[0];
                        int conditions = (int)Condition3[0];
                        string picturename1 = (string)PictureName3[1];
                        int conditions1 = (int)Condition3[1];
                        string picturename2 = (string)PictureName3[2];
                        int conditions2 = (int)Condition3[2];

                        Image4.ImageUrl = "http://firstimpressions.azurewebsites.net/Pictures/" + picturename + ".jpg";
                        Image5.ImageUrl = "http://firstimpressions.azurewebsites.net/Pictures/" + picturename1 + ".jpg";
                        Image6.ImageUrl = "http://firstimpressions.azurewebsites.net/Pictures/" + picturename2 + ".jpg";

                        if (conditions == 1 && conditions1 == 1 && conditions2 == 1)
                        {
                            header.Visible = false;
                            header1.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit19();</script>");

                            SqlConnection con21 = new SqlConnection(str);
                            con21.Open();
                            string teststr21 = "spUpdatePhoto6";
                            SqlCommand command21 = new SqlCommand(teststr21, con21);
                            command21.CommandType = CommandType.StoredProcedure;
                            command21.Parameters.AddWithValue("@picturename", picturename);
                            command21.Parameters.AddWithValue("@picturename1", picturename1);
                            command21.Parameters.AddWithValue("@picturename2", picturename2);
                            command21.Parameters.AddWithValue("@userid", currentUserId);
                            command21.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command21.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);
                            }

                            command21.Dispose();
                            con21.Close();
                        }

                        if (conditions == 1 && conditions1 == 1 && conditions2 == 4)
                        {
                            header.Visible = false;
                            header1.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit20();</script>");


                            SqlConnection con22 = new SqlConnection(str);
                            con22.Open();
                            string teststr22 = "spUpdatePhoto6";
                            SqlCommand command22 = new SqlCommand(teststr22, con22);
                            command22.CommandType = CommandType.StoredProcedure;
                            command22.Parameters.AddWithValue("@picturename", picturename);
                            command22.Parameters.AddWithValue("@picturename1", picturename1);
                            command22.Parameters.AddWithValue("@picturename2", picturename2);
                            command22.Parameters.AddWithValue("@userid", currentUserId);
                            command22.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command22.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command22.Dispose();
                            con22.Close();
                        }

                        if (conditions == 1 && conditions1 == 2 && conditions2 == 1)
                        {
                            header.Visible = false;
                            header1.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit21();</script>");

                            SqlConnection con23 = new SqlConnection(str);
                            con23.Open();
                            string teststr23 = "spUpdatePhoto6";
                            SqlCommand command23 = new SqlCommand(teststr23, con23);
                            command23.CommandType = CommandType.StoredProcedure;
                            command23.Parameters.AddWithValue("@picturename", picturename);
                            command23.Parameters.AddWithValue("@picturename1", picturename1);
                            command23.Parameters.AddWithValue("@picturename2", picturename2);
                            command23.Parameters.AddWithValue("@userid", currentUserId);
                            command23.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command23.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command23.Dispose();
                            con23.Close();
                        }

                        if (conditions == 1 && conditions1 == 3 && conditions2 == 1)
                        {
                            header.Visible = false;
                            header1.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit22();</script>");

                            SqlConnection con24 = new SqlConnection(str);
                            con24.Open();
                            string teststr24 = "spUpdatePhoto6";
                            SqlCommand command24 = new SqlCommand(teststr24, con24);
                            command24.CommandType = CommandType.StoredProcedure;
                            command24.Parameters.AddWithValue("@picturename", picturename);
                            command24.Parameters.AddWithValue("@picturename1", picturename1);
                            command24.Parameters.AddWithValue("@picturename2", picturename2);
                            command24.Parameters.AddWithValue("@userid", currentUserId);
                            command24.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command24.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command24.Dispose();
                            con24.Close();
                        }

                        if (conditions == 1 && conditions1 == 4 && conditions2 == 1)
                        {
                            header.Visible = false;
                            header1.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit23();</script>");

                            SqlConnection con25 = new SqlConnection(str);
                            con25.Open();
                            string teststr25 = "spUpdatePhoto6";
                            SqlCommand command25 = new SqlCommand(teststr25, con25);
                            command25.CommandType = CommandType.StoredProcedure;
                            command25.Parameters.AddWithValue("@picturename", picturename);
                            command25.Parameters.AddWithValue("@picturename1", picturename1);
                            command25.Parameters.AddWithValue("@picturename2", picturename2);
                            command25.Parameters.AddWithValue("@userid", currentUserId);
                            command25.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command25.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command25.Dispose();
                            con25.Close();
                        }
                        if (conditions == 1 && conditions1 == 4 && conditions2 == 3)
                        {
                            header.Visible = false;
                            header1.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit24();</script>");

                            SqlConnection con26 = new SqlConnection(str);
                            con26.Open();
                            string teststr26 = "spUpdatePhoto6";
                            SqlCommand command26 = new SqlCommand(teststr26, con26);
                            command26.CommandType = CommandType.StoredProcedure;
                            command26.Parameters.AddWithValue("@picturename", picturename);
                            command26.Parameters.AddWithValue("@picturename1", picturename1);
                            command26.Parameters.AddWithValue("@picturename2", picturename2);
                            command26.Parameters.AddWithValue("@userid", currentUserId);
                            command26.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command26.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command26.Dispose();
                            con26.Close();
                        }

                        if (conditions == 3 && conditions1 == 1 && conditions2 == 1)
                        {
                            header.Visible = false;
                            header1.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit25();</script>");

                            SqlConnection con27 = new SqlConnection(str);
                            con27.Open();
                            string teststr27 = "spUpdatePhoto6";
                            SqlCommand command27 = new SqlCommand(teststr27, con27);
                            command27.CommandType = CommandType.StoredProcedure;
                            command27.Parameters.AddWithValue("@picturename", picturename);
                            command27.Parameters.AddWithValue("@picturename1", picturename1);
                            command27.Parameters.AddWithValue("@picturename2", picturename2);
                            command27.Parameters.AddWithValue("@userid", currentUserId);
                            command27.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command27.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command27.Dispose();
                            con27.Close();
                        }

                        if (conditions == 3 && conditions1 == 1 && conditions2 == 4)
                        {
                            header.Visible = false;
                            header1.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit26();</script>");

                            SqlConnection con28 = new SqlConnection(str);
                            con28.Open();
                            string teststr28 = "spUpdatePhoto6";
                            SqlCommand command28 = new SqlCommand(teststr28, con28);
                            command28.CommandType = CommandType.StoredProcedure;
                            command28.Parameters.AddWithValue("@picturename", picturename);
                            command28.Parameters.AddWithValue("@picturename1", picturename1);
                            command28.Parameters.AddWithValue("@picturename2", picturename2);
                            command28.Parameters.AddWithValue("@userid", currentUserId);
                            command28.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command28.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command28.Dispose();
                            con28.Close();
                        }

                        if (conditions == 3 && conditions1 == 2 && conditions2 == 1)
                        {
                            header.Visible = false;
                            header1.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit27();</script>");

                            SqlConnection con29 = new SqlConnection(str);
                            con29.Open();
                            string teststr29 = "spUpdatePhoto6";
                            SqlCommand command29 = new SqlCommand(teststr29, con29);
                            command29.CommandType = CommandType.StoredProcedure;
                            command29.Parameters.AddWithValue("@picturename", picturename);
                            command29.Parameters.AddWithValue("@picturename1", picturename1);
                            command29.Parameters.AddWithValue("@picturename2", picturename2);
                            command29.Parameters.AddWithValue("@userid", currentUserId);
                            command29.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command29.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command29.Dispose();
                            con29.Close();
                        }

                        if (conditions == 4 && conditions1 == 1 && conditions2 == 1)
                        {
                            header.Visible = false;
                            header1.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit28();</script>");

                            SqlConnection con30 = new SqlConnection(str);
                            con30.Open();
                            string teststr30 = "spUpdatePhoto6";
                            SqlCommand command30 = new SqlCommand(teststr30, con30);
                            command30.CommandType = CommandType.StoredProcedure;
                            command30.Parameters.AddWithValue("@picturename", picturename);
                            command30.Parameters.AddWithValue("@picturename1", picturename1);
                            command30.Parameters.AddWithValue("@picturename2", picturename2);
                            command30.Parameters.AddWithValue("@userid", currentUserId);
                            command30.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command30.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command30.Dispose();
                            con30.Close();
                        }

                        if (conditions == 4 && conditions1 == 1 && conditions2 == 4)
                        {
                            header.Visible = false;
                            header1.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit29();</script>");

                            SqlConnection con31 = new SqlConnection(str);
                            con31.Open();
                            string teststr31 = "spUpdatePhoto6";
                            SqlCommand command31 = new SqlCommand(teststr31, con31);
                            command31.CommandType = CommandType.StoredProcedure;
                            command31.Parameters.AddWithValue("@picturename", picturename);
                            command31.Parameters.AddWithValue("@picturename1", picturename1);
                            command31.Parameters.AddWithValue("@picturename2", picturename2);
                            command31.Parameters.AddWithValue("@userid", currentUserId);
                            command31.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command31.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command31.Dispose();
                            con31.Close();
                        }

                        if (conditions == 4 && conditions1 == 2 && conditions2 == 1)
                        {
                            header.Visible = false;
                            header1.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit30();</script>");

                            SqlConnection con32 = new SqlConnection(str);
                            con32.Open();
                            string teststr32 = "spUpdatePhoto6";
                            SqlCommand command32 = new SqlCommand(teststr32, con32);
                            command32.CommandType = CommandType.StoredProcedure;
                            command32.Parameters.AddWithValue("@picturename", picturename);
                            command32.Parameters.AddWithValue("@picturename1", picturename1);
                            command32.Parameters.AddWithValue("@picturename2", picturename2);
                            command32.Parameters.AddWithValue("@userid", currentUserId);
                            command32.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command32.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command32.Dispose();
                            con32.Close();
                        }

                        if (conditions == 4 && conditions1 == 3 && conditions2 == 4)
                        {
                            header.Visible = false;
                            header1.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit31();</script>");

                            SqlConnection con33 = new SqlConnection(str);
                            con33.Open();
                            string teststr33 = "spUpdatePhoto6";
                            SqlCommand command33 = new SqlCommand(teststr33, con33);
                            command33.CommandType = CommandType.StoredProcedure;
                            command33.Parameters.AddWithValue("@picturename", picturename);
                            command33.Parameters.AddWithValue("@picturename1", picturename1);
                            command33.Parameters.AddWithValue("@picturename2", picturename2);
                            command33.Parameters.AddWithValue("@userid", currentUserId);
                            command33.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command33.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command33.Dispose();
                            con33.Close();
                        }
                        if (conditions == 4 && conditions1 == 4 && conditions2 == 4)
                        {
                            header.Visible = false;
                            header1.Visible = false;
                            header3.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit32();</script>");

                            SqlConnection con34 = new SqlConnection(str);
                            con34.Open();
                            string teststr34 = "spUpdatePhoto6";
                            SqlCommand command34 = new SqlCommand(teststr34, con34);
                            command34.CommandType = CommandType.StoredProcedure;
                            command34.Parameters.AddWithValue("@picturename", picturename);
                            command34.Parameters.AddWithValue("@picturename1", picturename1);
                            command34.Parameters.AddWithValue("@picturename2", picturename2);
                            command34.Parameters.AddWithValue("@userid", currentUserId);
                            command34.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command34.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command34.Dispose();
                            con34.Close();
                        }

                    }

                    if (Convert.ToInt32(Session["NumberofPictures"]) == 4)
                    {
                        ArrayList PictureName4 = (ArrayList)Session["PictureName"];
                        ArrayList Count4 = (ArrayList)Session["Count"];
                        ArrayList Condition4 = (ArrayList)Session["Condition"];
                        string picturename = (string)PictureName4[0];
                        int conditions = (int)Condition4[0];
                        string picturename1 = (string)PictureName4[1];
                        int conditions1 = (int)Condition4[1];
                        string picturename2 = (string)PictureName4[2];
                        int conditions2 = (int)Condition4[2];
                        string picturename3 = (string)PictureName4[3];
                        int conditions3 = (int)Condition4[3];
                        Image7.ImageUrl = "http://firstimpressions.azurewebsites.net/Pictures/" + picturename + ".jpg";
                        Image8.ImageUrl = "http://firstimpressions.azurewebsites.net/Pictures/" + picturename1 + ".jpg";
                        Image9.ImageUrl = "http://firstimpressions.azurewebsites.net/Pictures/" + picturename2 + ".jpg";
                        Image10.ImageUrl = "http://firstimpressions.azurewebsites.net/Pictures/" + picturename3 + ".jpg";

                        if (conditions == 1 && conditions1 == 1 && conditions2 == 1 && conditions3 == 1)
                        {
                            header.Visible = false;
                            header1.Visible = false;
                            header2.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit33();</script>");

                            SqlConnection con35 = new SqlConnection(str);
                            con35.Open();
                            string teststr35 = "spUpdatePhoto7";
                            SqlCommand command35 = new SqlCommand(teststr35, con35);
                            command35.CommandType = CommandType.StoredProcedure;
                            command35.Parameters.AddWithValue("@picturename", picturename);
                            command35.Parameters.AddWithValue("@picturename1", picturename1);
                            command35.Parameters.AddWithValue("@picturename2", picturename2);
                            command35.Parameters.AddWithValue("@picturename3", picturename3);
                            command35.Parameters.AddWithValue("@userid", currentUserId);
                            command35.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command35.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command35.Dispose();
                            con35.Close();
                        }
                        if (conditions == 1 && conditions1 == 1 && conditions2 == 3 && conditions3 == 1)
                        {
                            header.Visible = false;
                            header1.Visible = false;
                            header2.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit34();</script>");

                            SqlConnection con36 = new SqlConnection(str);
                            con36.Open();
                            string teststr36 = "spUpdatePhoto7";
                            SqlCommand command36 = new SqlCommand(teststr36, con36);
                            command36.CommandType = CommandType.StoredProcedure;
                            command36.Parameters.AddWithValue("@picturename", picturename);
                            command36.Parameters.AddWithValue("@picturename1", picturename1);
                            command36.Parameters.AddWithValue("@picturename2", picturename2);
                            command36.Parameters.AddWithValue("@picturename3", picturename3);
                            command36.Parameters.AddWithValue("@userid", currentUserId);
                            command36.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command36.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command36.Dispose();
                            con36.Close();
                        }

                        if (conditions == 1 && conditions1 == 4 && conditions2 == 1 && conditions3 == 1)
                        {
                            header.Visible = false;
                            header1.Visible = false;
                            header2.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit35();</script>");

                            SqlConnection con37 = new SqlConnection(str);
                            con37.Open();
                            string teststr37 = "spUpdatePhoto7";
                            SqlCommand command37 = new SqlCommand(teststr37, con37);
                            command37.CommandType = CommandType.StoredProcedure;
                            command37.Parameters.AddWithValue("@picturename", picturename);
                            command37.Parameters.AddWithValue("@picturename1", picturename1);
                            command37.Parameters.AddWithValue("@picturename2", picturename2);
                            command37.Parameters.AddWithValue("@picturename3", picturename3);
                            command37.Parameters.AddWithValue("@userid", currentUserId);
                            command37.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command37.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command37.Dispose();
                            con37.Close();
                        }
                        if (conditions == 1 && conditions1 == 4 && conditions2 == 1 && conditions3 == 4)
                        {
                            header.Visible = false;
                            header1.Visible = false;
                            header2.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit36();</script>");

                            SqlConnection con38 = new SqlConnection(str);
                            con38.Open();
                            string teststr38 = "spUpdatePhoto7";
                            SqlCommand command38 = new SqlCommand(teststr38, con38);
                            command38.CommandType = CommandType.StoredProcedure;
                            command38.Parameters.AddWithValue("@picturename", picturename);
                            command38.Parameters.AddWithValue("@picturename1", picturename1);
                            command38.Parameters.AddWithValue("@picturename2", picturename2);
                            command38.Parameters.AddWithValue("@picturename3", picturename3);
                            command38.Parameters.AddWithValue("@userid", currentUserId);
                            command38.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command38.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command38.Dispose();
                            con38.Close();
                        }
                        if (conditions == 4 && conditions1 == 1 && conditions2 == 1 && conditions3 == 1)
                        {
                            header.Visible = false;
                            header1.Visible = false;
                            header2.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit37();</script>");

                            SqlConnection con39 = new SqlConnection(str);
                            con39.Open();
                            string teststr39 = "spUpdatePhoto7";
                            SqlCommand command39 = new SqlCommand(teststr39, con39);
                            command39.CommandType = CommandType.StoredProcedure;
                            command39.Parameters.AddWithValue("@picturename", picturename);
                            command39.Parameters.AddWithValue("@picturename1", picturename1);
                            command39.Parameters.AddWithValue("@picturename2", picturename2);
                            command39.Parameters.AddWithValue("@picturename3", picturename3);
                            command39.Parameters.AddWithValue("@userid", currentUserId);
                            command39.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command39.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command39.Dispose();
                            con39.Close();
                        }

                        if (conditions == 4 && conditions1 == 1 && conditions2 == 3 && conditions3 == 1)
                        {
                            header.Visible = false;
                            header1.Visible = false;
                            header2.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit38();</script>");

                            SqlConnection con40 = new SqlConnection(str);
                            con40.Open();
                            string teststr40 = "spUpdatePhoto7";
                            SqlCommand command40 = new SqlCommand(teststr40, con40);
                            command40.CommandType = CommandType.StoredProcedure;
                            command40.Parameters.AddWithValue("@picturename", picturename);
                            command40.Parameters.AddWithValue("@picturename1", picturename1);
                            command40.Parameters.AddWithValue("@picturename2", picturename2);
                            command40.Parameters.AddWithValue("@picturename3", picturename3);
                            command40.Parameters.AddWithValue("@userid", currentUserId);
                            command40.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command40.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command40.Dispose();
                            con40.Close();
                        }

                        if (conditions == 4 && conditions1 == 2 && conditions2 == 1 && conditions3 == 4)
                        {
                            header.Visible = false;
                            header1.Visible = false;
                            header2.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit39();</script>");

                            SqlConnection con41 = new SqlConnection(str);
                            con41.Open();
                            string teststr41 = "spUpdatePhoto7";
                            SqlCommand command41 = new SqlCommand(teststr41, con41);
                            command41.CommandType = CommandType.StoredProcedure;
                            command41.Parameters.AddWithValue("@picturename", picturename);
                            command41.Parameters.AddWithValue("@picturename1", picturename1);
                            command41.Parameters.AddWithValue("@picturename2", picturename2);
                            command41.Parameters.AddWithValue("@picturename3", picturename3);
                            command41.Parameters.AddWithValue("@userid", currentUserId);
                            command41.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command41.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command41.Dispose();
                            con41.Close();
                        }

                        if (conditions == 4 && conditions1 == 3 && conditions2 == 1 && conditions3 == 1)
                        {
                            header.Visible = false;
                            header1.Visible = false;
                            header2.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition41.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit40();</script>");

                            SqlConnection con42 = new SqlConnection(str);
                            con42.Open();
                            string teststr42 = "spUpdatePhoto7";
                            SqlCommand command42 = new SqlCommand(teststr42, con42);
                            command42.CommandType = CommandType.StoredProcedure;
                            command42.Parameters.AddWithValue("@picturename", picturename);
                            command42.Parameters.AddWithValue("@picturename1", picturename1);
                            command42.Parameters.AddWithValue("@picturename2", picturename2);
                            command42.Parameters.AddWithValue("@picturename3", picturename3);
                            command42.Parameters.AddWithValue("@userid", currentUserId);
                            command42.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command42.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command42.Dispose();
                            con42.Close();
                        }


                        if (conditions == 4 && conditions1 == 4 && conditions2 == 1 && conditions3 == 4)
                        {
                            header.Visible = false;
                            header1.Visible = false;
                            header2.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition42.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit41();</script>");

                            SqlConnection con43 = new SqlConnection(str);
                            con43.Open();
                            string teststr43 = "spUpdatePhoto7";
                            SqlCommand command43 = new SqlCommand(teststr43, con43);
                            command43.CommandType = CommandType.StoredProcedure;
                            command43.Parameters.AddWithValue("@picturename", picturename);
                            command43.Parameters.AddWithValue("@picturename1", picturename1);
                            command43.Parameters.AddWithValue("@picturename2", picturename2);
                            command43.Parameters.AddWithValue("@picturename3", picturename3);
                            command43.Parameters.AddWithValue("@userid", currentUserId);
                            command43.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command43.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command43.Dispose();
                            con43.Close();
                        }


                        if (conditions == 4 && conditions1 == 4 && conditions2 == 4 && conditions3 == 4)
                        {
                            header.Visible = false;
                            header1.Visible = false;
                            header2.Visible = false;
                            condition1.Visible = false;
                            condition2.Visible = false;
                            condition3.Visible = false;
                            condition4.Visible = false;
                            condition5.Visible = false;
                            condition6.Visible = false;
                            condition7.Visible = false;
                            condition8.Visible = false;
                            condition9.Visible = false;
                            condition10.Visible = false;
                            condition11.Visible = false;
                            condition12.Visible = false;
                            condition13.Visible = false;
                            condition14.Visible = false;
                            condition15.Visible = false;
                            condition16.Visible = false;
                            condition17.Visible = false;
                            condition18.Visible = false;
                            condition19.Visible = false;
                            condition20.Visible = false;
                            condition21.Visible = false;
                            condition22.Visible = false;
                            condition23.Visible = false;
                            condition24.Visible = false;
                            condition25.Visible = false;
                            condition26.Visible = false;
                            condition27.Visible = false;
                            condition28.Visible = false;
                            condition29.Visible = false;
                            condition30.Visible = false;
                            condition31.Visible = false;
                            condition32.Visible = false;
                            condition33.Visible = false;
                            condition34.Visible = false;
                            condition35.Visible = false;
                            condition36.Visible = false;
                            condition37.Visible = false;
                            condition38.Visible = false;
                            condition39.Visible = false;
                            condition40.Visible = false;
                            condition41.Visible = false;
                            ClientScript.RegisterStartupScript(this.GetType(), "Script1", "<script type='text/javascript'>initSubmit42();</script>");

                            SqlConnection con44 = new SqlConnection(str);
                            con44.Open();
                            string teststr44 = "spUpdatePhoto7";
                            SqlCommand command44 = new SqlCommand(teststr44, con44);
                            command44.CommandType = CommandType.StoredProcedure;
                            command44.Parameters.AddWithValue("@picturename", picturename);
                            command44.Parameters.AddWithValue("@picturename1", picturename1);
                            command44.Parameters.AddWithValue("@picturename2", picturename2);
                            command44.Parameters.AddWithValue("@picturename3", picturename3);
                            command44.Parameters.AddWithValue("@userid", currentUserId);
                            command44.Parameters.AddWithValue("@raterslot", raterslot);
                            int result = command44.ExecuteNonQuery();
                            if (result == 1)
                            {
                                // ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Data Updated Succesfully')", true);

                            }

                            command44.Dispose();
                            con44.Close();
                        }
                    }

                }

            }
        }


   public string getConnectionString()
    {
    string constr = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
    return constr;
    }

   protected void btnSubmit1_Click(object sender, EventArgs e)
    {
      string str = getConnectionString();
      string UserId = Session["UserId"].ToString();
      int pictureid = Convert.ToInt32(Session["PictureId"]);    
      SqlConnection con = new SqlConnection(str);
      con.Open();
      string teststr = "spInsertTrustRatings1";
      SqlCommand command = new SqlCommand(teststr, con);
      command.CommandType = CommandType.StoredProcedure;

      command.Parameters.AddWithValue("@userid", Convert.ToInt32(UserId));
      command.Parameters.AddWithValue("@pictureid", pictureid);
      command.Parameters.AddWithValue("@trustlist1a", RadioButtonList1.Text.ToString().Trim());
      command.Parameters.AddWithValue("@creditlist1a", RadioButtonList2.Text.ToString().Trim());
      int result = command.ExecuteNonQuery();
      if (result == 1)
      {
          ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Your ratings have been successfully submitted.');location.href='StudyPage1.aspx'", true);
       }
     }

   protected void btnSubmit2_Click(object sender, EventArgs e)
   {
       string str = getConnectionString();
       string UserId = Session["UserId"].ToString();
       int pictureid = Convert.ToInt32(Session["PictureId"]);    
       SqlConnection con = new SqlConnection(str);
       con.Open();
       string teststr = "spInsertTrustRatings1";
       SqlCommand command = new SqlCommand(teststr, con);
       command.CommandType = CommandType.StoredProcedure;

       command.Parameters.AddWithValue("@userid", Convert.ToInt32(UserId));
       command.Parameters.AddWithValue("@pictureid", pictureid);
       command.Parameters.AddWithValue("@trustlist1a", RadioButtonList3.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist1a", RadioButtonList4.Text.ToString().Trim());
       int result = command.ExecuteNonQuery();
       if (result == 1)
       {
           ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Your ratings have been successfully submitted.');location.href='StudyPage1.aspx'", true);
       }
   }

   protected void btnSubmit3_Click(object sender, EventArgs e)
   {
       string str = getConnectionString();
       string UserId = Session["UserId"].ToString();
       int pictureid = Convert.ToInt32(Session["PictureId"]);    
       SqlConnection con = new SqlConnection(str);
       con.Open();
       string teststr = "spInsertTrustRatings1";
       SqlCommand command = new SqlCommand(teststr, con);
       command.CommandType = CommandType.StoredProcedure;

       command.Parameters.AddWithValue("@userid", Convert.ToInt32(UserId));
       command.Parameters.AddWithValue("@pictureid", pictureid);
       command.Parameters.AddWithValue("@trustlist1a", RadioButtonList5.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist1a", RadioButtonList6.Text.ToString().Trim());
       int result = command.ExecuteNonQuery();
       if (result == 1)
       {
           ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Your ratings have been successfully submitted.');location.href='StudyPage1.aspx'", true);
       }
   }

   protected void btnSubmit4_Click(object sender, EventArgs e)
   {
       string str = getConnectionString();
       string UserId = Session["UserId"].ToString();
       int pictureid = Convert.ToInt32(Session["PictureId"]);    
       SqlConnection con = new SqlConnection(str);
       con.Open();
       string teststr = "spInsertTrustRatings1";
       SqlCommand command = new SqlCommand(teststr, con);
       command.CommandType = CommandType.StoredProcedure;

       command.Parameters.AddWithValue("@userid", Convert.ToInt32(UserId));
       command.Parameters.AddWithValue("@pictureid", pictureid);
       command.Parameters.AddWithValue("@trustlist1a", RadioButtonList7.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist1a", RadioButtonList8.Text.ToString().Trim());
       int result = command.ExecuteNonQuery();
       if (result == 1)
       {
           ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Your ratings have been successfully submitted.');location.href='StudyPage1.aspx'", true);
       }
   }

   protected void btnSubmit5_Click(object sender, EventArgs e)
   {
       string str = getConnectionString();
       string UserId = Session["UserId"].ToString();
       int pictureid = Convert.ToInt32(Session["PictureId"]);    
       SqlConnection con = new SqlConnection(str);
       con.Open();
       string teststr = "spInsertTrustRatings2";
       SqlCommand command = new SqlCommand(teststr, con);
       command.CommandType = CommandType.StoredProcedure;

       command.Parameters.AddWithValue("@userid", Convert.ToInt32(UserId));
       command.Parameters.AddWithValue("@pictureid", pictureid);
       command.Parameters.AddWithValue("@trustlist1a", RadioButtonList9.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist1a", RadioButtonList10.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist2a", RadioButtonList11.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist2a", RadioButtonList12.Text.ToString().Trim());
       int result = command.ExecuteNonQuery();
       if (result == 1)
       {
           ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Your ratings have been successfully submitted.');location.href='StudyPage1.aspx'", true);
       }
   }

   protected void btnSubmit6_Click(object sender, EventArgs e)
   {
       string str = getConnectionString();
       string UserId = Session["UserId"].ToString();
       int pictureid = Convert.ToInt32(Session["PictureId"]);    
       SqlConnection con = new SqlConnection(str);
       con.Open();
       string teststr = "spInsertTrustRatings2";
       SqlCommand command = new SqlCommand(teststr, con);
       command.CommandType = CommandType.StoredProcedure;

       command.Parameters.AddWithValue("@userid", Convert.ToInt32(UserId));
       command.Parameters.AddWithValue("@pictureid", pictureid);
       command.Parameters.AddWithValue("@trustlist1a", RadioButtonList13.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist1a", RadioButtonList14.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist2a", RadioButtonList15.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist2a", RadioButtonList16.Text.ToString().Trim());
       int result = command.ExecuteNonQuery();
       if (result == 1)
       {
           ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Your ratings have been successfully submitted.');location.href='StudyPage1.aspx'", true);
       }
   }

   protected void btnSubmit7_Click(object sender, EventArgs e)
   {
       string str = getConnectionString();
       string UserId = Session["UserId"].ToString();
       int pictureid = Convert.ToInt32(Session["PictureId"]);    
       SqlConnection con = new SqlConnection(str);
       con.Open();
       string teststr = "spInsertTrustRatings2";
       SqlCommand command = new SqlCommand(teststr, con);
       command.CommandType = CommandType.StoredProcedure;

       command.Parameters.AddWithValue("@userid", Convert.ToInt32(UserId));
       command.Parameters.AddWithValue("@pictureid", pictureid);
       command.Parameters.AddWithValue("@trustlist1a", RadioButtonList17.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist1a", RadioButtonList18.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist2a", RadioButtonList19.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist2a", RadioButtonList20.Text.ToString().Trim());
       int result = command.ExecuteNonQuery();
       if (result == 1)
       {
           ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Your ratings have been successfully submitted.');location.href='StudyPage1.aspx'", true);
       }
   }

   protected void btnSubmit8_Click(object sender, EventArgs e)
   {
       string str = getConnectionString();
       string UserId = Session["UserId"].ToString();
       int pictureid = Convert.ToInt32(Session["PictureId"]);    
       SqlConnection con = new SqlConnection(str);
       con.Open();
       string teststr = "spInsertTrustRatings2";
       SqlCommand command = new SqlCommand(teststr, con);
       command.CommandType = CommandType.StoredProcedure;

       command.Parameters.AddWithValue("@userid", Convert.ToInt32(UserId));
       command.Parameters.AddWithValue("@pictureid", pictureid);
       command.Parameters.AddWithValue("@trustlist1a", RadioButtonList21.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist1a", RadioButtonList22.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist2a", RadioButtonList23.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist2a", RadioButtonList24.Text.ToString().Trim());
       int result = command.ExecuteNonQuery();
       if (result == 1)
       {
           ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Your ratings have been successfully submitted.');location.href='StudyPage1.aspx'", true);
       }
   }

   protected void btnSubmit9_Click(object sender, EventArgs e)
   {
       string str = getConnectionString();
       string UserId = Session["UserId"].ToString();
       int pictureid = Convert.ToInt32(Session["PictureId"]);    
       SqlConnection con = new SqlConnection(str);
       con.Open();
       string teststr = "spInsertTrustRatings2";
       SqlCommand command = new SqlCommand(teststr, con);
       command.CommandType = CommandType.StoredProcedure;

       command.Parameters.AddWithValue("@userid", Convert.ToInt32(UserId));
       command.Parameters.AddWithValue("@pictureid", pictureid);
       command.Parameters.AddWithValue("@trustlist1a", RadioButtonList25.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist1a", RadioButtonList26.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist2a", RadioButtonList27.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist2a", RadioButtonList28.Text.ToString().Trim());
       int result = command.ExecuteNonQuery();
       if (result == 1)
       {
           ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Your ratings have been successfully submitted.');location.href='StudyPage1.aspx'", true);
       }
   }

   protected void btnSubmit10_Click(object sender, EventArgs e)
   {
       string str = getConnectionString();
       string UserId = Session["UserId"].ToString();
       int pictureid = Convert.ToInt32(Session["PictureId"]);    
       SqlConnection con = new SqlConnection(str);
       con.Open();
       string teststr = "spInsertTrustRatings2";
       SqlCommand command = new SqlCommand(teststr, con);
       command.CommandType = CommandType.StoredProcedure;

       command.Parameters.AddWithValue("@userid", Convert.ToInt32(UserId));
       command.Parameters.AddWithValue("@pictureid", pictureid);
       command.Parameters.AddWithValue("@trustlist1a", RadioButtonList29.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist1a", RadioButtonList30.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist2a", RadioButtonList31.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist2a", RadioButtonList32.Text.ToString().Trim());
       int result = command.ExecuteNonQuery();
       if (result == 1)
       {
           ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Your ratings have been successfully submitted.');location.href='StudyPage1.aspx'", true);
       }
   }

   protected void btnSubmit11_Click(object sender, EventArgs e)
   {
       string str = getConnectionString();
       string UserId = Session["UserId"].ToString();
       int pictureid = Convert.ToInt32(Session["PictureId"]);    
       SqlConnection con = new SqlConnection(str);
       con.Open();
       string teststr = "spInsertTrustRatings2";
       SqlCommand command = new SqlCommand(teststr, con);
       command.CommandType = CommandType.StoredProcedure;

       command.Parameters.AddWithValue("@userid", Convert.ToInt32(UserId));
       command.Parameters.AddWithValue("@pictureid", pictureid);
       command.Parameters.AddWithValue("@trustlist1a", RadioButtonList33.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist1a", RadioButtonList34.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist2a", RadioButtonList35.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist2a", RadioButtonList36.Text.ToString().Trim());
       int result = command.ExecuteNonQuery();
       if (result == 1)
       {
           ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Your ratings have been successfully submitted.');location.href='StudyPage1.aspx'", true);
       }
   }

   protected void btnSubmit12_Click(object sender, EventArgs e)
   {
       string str = getConnectionString();
       string UserId = Session["UserId"].ToString();
       int pictureid = Convert.ToInt32(Session["PictureId"]);    
       SqlConnection con = new SqlConnection(str);
       con.Open();
       string teststr = "spInsertTrustRatings2";
       SqlCommand command = new SqlCommand(teststr, con);
       command.CommandType = CommandType.StoredProcedure;

       command.Parameters.AddWithValue("@userid", Convert.ToInt32(UserId));
       command.Parameters.AddWithValue("@pictureid", pictureid);
       command.Parameters.AddWithValue("@trustlist1a", RadioButtonList37.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist1a", RadioButtonList38.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist2a", RadioButtonList39.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist2a", RadioButtonList40.Text.ToString().Trim());
       int result = command.ExecuteNonQuery();
       if (result == 1)
       {
           ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Your ratings have been successfully submitted.');location.href='StudyPage1.aspx'", true);
       }
   }

   protected void btnSubmit13_Click(object sender, EventArgs e)
   {
       string str = getConnectionString();
       string UserId = Session["UserId"].ToString();
       int pictureid = Convert.ToInt32(Session["PictureId"]);    
       SqlConnection con = new SqlConnection(str);
       con.Open();
       string teststr = "spInsertTrustRatings2";
       SqlCommand command = new SqlCommand(teststr, con);
       command.CommandType = CommandType.StoredProcedure;

       command.Parameters.AddWithValue("@userid", Convert.ToInt32(UserId));
       command.Parameters.AddWithValue("@pictureid", pictureid);
       command.Parameters.AddWithValue("@trustlist1a", RadioButtonList41.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist1a", RadioButtonList42.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist2a", RadioButtonList43.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist2a", RadioButtonList44.Text.ToString().Trim());
       int result = command.ExecuteNonQuery();
       if (result == 1)
       {
           ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Your ratings have been successfully submitted.');location.href='StudyPage1.aspx'", true);
       }
   }

   protected void btnSubmit14_Click(object sender, EventArgs e)
   {
       string str = getConnectionString();
       string UserId = Session["UserId"].ToString();
       int pictureid = Convert.ToInt32(Session["PictureId"]);    
       SqlConnection con = new SqlConnection(str);
       con.Open();
       string teststr = "spInsertTrustRatings2";
       SqlCommand command = new SqlCommand(teststr, con);
       command.CommandType = CommandType.StoredProcedure;

       command.Parameters.AddWithValue("@userid", Convert.ToInt32(UserId));
       command.Parameters.AddWithValue("@pictureid", pictureid);
       command.Parameters.AddWithValue("@trustlist1a", RadioButtonList45.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist1a", RadioButtonList46.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist2a", RadioButtonList47.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist2a", RadioButtonList48.Text.ToString().Trim());
       int result = command.ExecuteNonQuery();
       if (result == 1)
       {
           ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Your ratings have been successfully submitted.');location.href='StudyPage1.aspx'", true);
       }
   }

   protected void btnSubmit15_Click(object sender, EventArgs e)
   {
       string str = getConnectionString();
       string UserId = Session["UserId"].ToString();
       int pictureid = Convert.ToInt32(Session["PictureId"]);    
       SqlConnection con = new SqlConnection(str);
       con.Open();
       string teststr = "spInsertTrustRatings2";
       SqlCommand command = new SqlCommand(teststr, con);
       command.CommandType = CommandType.StoredProcedure;

       command.Parameters.AddWithValue("@userid", Convert.ToInt32(UserId));
       command.Parameters.AddWithValue("@pictureid", pictureid);
       command.Parameters.AddWithValue("@trustlist1a", RadioButtonList49.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist1a", RadioButtonList50.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist2a", RadioButtonList51.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist2a", RadioButtonList52.Text.ToString().Trim());
       int result = command.ExecuteNonQuery();
       if (result == 1)
       {
           ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Your ratings have been successfully submitted.');location.href='StudyPage1.aspx'", true);
       }
   }

   protected void btnSubmit16_Click(object sender, EventArgs e)
   {
       string str = getConnectionString();
       string UserId = Session["UserId"].ToString();
       int pictureid = Convert.ToInt32(Session["PictureId"]);    
       SqlConnection con = new SqlConnection(str);
       con.Open();
       string teststr = "spInsertTrustRatings2";
       SqlCommand command = new SqlCommand(teststr, con);
       command.CommandType = CommandType.StoredProcedure;

       command.Parameters.AddWithValue("@userid", Convert.ToInt32(UserId));
       command.Parameters.AddWithValue("@pictureid", pictureid);
       command.Parameters.AddWithValue("@trustlist1a", RadioButtonList53.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist1a", RadioButtonList54.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist2a", RadioButtonList55.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist2a", RadioButtonList56.Text.ToString().Trim());
       int result = command.ExecuteNonQuery();
       if (result == 1)
       {
           ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Your ratings have been successfully submitted.');location.href='StudyPage1.aspx'", true);
       }
   }

   protected void btnSubmit17_Click(object sender, EventArgs e)
   {
       string str = getConnectionString();
       string UserId = Session["UserId"].ToString();
       int pictureid = Convert.ToInt32(Session["PictureId"]);    
       SqlConnection con = new SqlConnection(str);
       con.Open();
       string teststr = "spInsertTrustRatings2";
       SqlCommand command = new SqlCommand(teststr, con);
       command.CommandType = CommandType.StoredProcedure;

       command.Parameters.AddWithValue("@userid", Convert.ToInt32(UserId));
       command.Parameters.AddWithValue("@pictureid", pictureid);
       command.Parameters.AddWithValue("@trustlist1a", RadioButtonList57.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist1a", RadioButtonList58.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist2a", RadioButtonList59.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist2a", RadioButtonList60.Text.ToString().Trim());
       int result = command.ExecuteNonQuery();
       if (result == 1)
       {
           ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Your ratings have been successfully submitted.');location.href='StudyPage1.aspx'", true);
       }
   }

   protected void btnSubmit18_Click(object sender, EventArgs e)
   {
       string str = getConnectionString();
       string UserId = Session["UserId"].ToString();
       int pictureid = Convert.ToInt32(Session["PictureId"]);    
       SqlConnection con = new SqlConnection(str);
       con.Open();
       string teststr = "spInsertTrustRatings2";
       SqlCommand command = new SqlCommand(teststr, con);
       command.CommandType = CommandType.StoredProcedure;

       command.Parameters.AddWithValue("@userid", Convert.ToInt32(UserId));
       command.Parameters.AddWithValue("@pictureid", pictureid);
       command.Parameters.AddWithValue("@trustlist1a", RadioButtonList61.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist1a", RadioButtonList62.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist2a", RadioButtonList63.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist2a", RadioButtonList64.Text.ToString().Trim());
       int result = command.ExecuteNonQuery();
       if (result == 1)
       {
           ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Your ratings have been successfully submitted.');location.href='StudyPage1.aspx'", true);
       }
   }

   protected void btnSubmit19_Click(object sender, EventArgs e)
   {
       string str = getConnectionString();
       string UserId = Session["UserId"].ToString();
       int pictureid = Convert.ToInt32(Session["PictureId"]);    
       SqlConnection con = new SqlConnection(str);
       con.Open();
       string teststr = "spInsertTrustRatings3";
       SqlCommand command = new SqlCommand(teststr, con);
       command.CommandType = CommandType.StoredProcedure;

       command.Parameters.AddWithValue("@userid", Convert.ToInt32(UserId));
       command.Parameters.AddWithValue("@pictureid", pictureid);
       command.Parameters.AddWithValue("@trustlist1a", RadioButtonList65.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist1a", RadioButtonList66.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist2a", RadioButtonList67.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist2a", RadioButtonList68.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist3a", RadioButtonList69.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist3a", RadioButtonList70.Text.ToString().Trim());
       int result = command.ExecuteNonQuery();
       if (result == 1)
       {
           ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Your ratings have been successfully submitted.');location.href='StudyPage1.aspx'", true);
       }
   }

   protected void btnSubmit20_Click(object sender, EventArgs e)
   {
       string str = getConnectionString();
       string UserId = Session["UserId"].ToString();
       int pictureid = Convert.ToInt32(Session["PictureId"]);    
       SqlConnection con = new SqlConnection(str);
       con.Open();
       string teststr = "spInsertTrustRatings3";
       SqlCommand command = new SqlCommand(teststr, con);
       command.CommandType = CommandType.StoredProcedure;

       command.Parameters.AddWithValue("@userid", Convert.ToInt32(UserId));
       command.Parameters.AddWithValue("@pictureid", pictureid);
       command.Parameters.AddWithValue("@trustlist1a", RadioButtonList71.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist1a", RadioButtonList72.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist2a", RadioButtonList73.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist2a", RadioButtonList74.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist3a", RadioButtonList75.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist3a", RadioButtonList76.Text.ToString().Trim());
       int result = command.ExecuteNonQuery();
       if (result == 1)
       {
           ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Your ratings have been successfully submitted.');location.href='StudyPage1.aspx'", true);
       }
   }

   protected void btnSubmit21_Click(object sender, EventArgs e)
   {
       string str = getConnectionString();
       string UserId = Session["UserId"].ToString();
       int pictureid = Convert.ToInt32(Session["PictureId"]);    
       SqlConnection con = new SqlConnection(str);
       con.Open();
       string teststr = "spInsertTrustRatings3";
       SqlCommand command = new SqlCommand(teststr, con);
       command.CommandType = CommandType.StoredProcedure;

       command.Parameters.AddWithValue("@userid", Convert.ToInt32(UserId));
       command.Parameters.AddWithValue("@pictureid", pictureid);
       command.Parameters.AddWithValue("@trustlist1a", RadioButtonList77.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist1a", RadioButtonList78.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist2a", RadioButtonList79.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist2a", RadioButtonList80.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist3a", RadioButtonList81.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist3a", RadioButtonList82.Text.ToString().Trim());
       int result = command.ExecuteNonQuery();
       if (result == 1)
       {
           ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Your ratings have been successfully submitted.');location.href='StudyPage1.aspx'", true);
       }
   }

   protected void btnSubmit22_Click(object sender, EventArgs e)
   {
       string str = getConnectionString();
       string UserId = Session["UserId"].ToString();
       int pictureid = Convert.ToInt32(Session["PictureId"]);    
       SqlConnection con = new SqlConnection(str);
       con.Open();
       string teststr = "spInsertTrustRatings3";
       SqlCommand command = new SqlCommand(teststr, con);
       command.CommandType = CommandType.StoredProcedure;

       command.Parameters.AddWithValue("@userid", Convert.ToInt32(UserId));
       command.Parameters.AddWithValue("@pictureid", pictureid);
       command.Parameters.AddWithValue("@trustlist1a", RadioButtonList83.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist1a", RadioButtonList84.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist2a", RadioButtonList85.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist2a", RadioButtonList86.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist3a", RadioButtonList87.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist3a", RadioButtonList88.Text.ToString().Trim());
       int result = command.ExecuteNonQuery();
       if (result == 1)
       {
           ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Your ratings have been successfully submitted.');location.href='StudyPage1.aspx'", true);
       }
   }

   protected void btnSubmit23_Click(object sender, EventArgs e)
   {
       string str = getConnectionString();
       string UserId = Session["UserId"].ToString();
       int pictureid = Convert.ToInt32(Session["PictureId"]);    
       SqlConnection con = new SqlConnection(str);
       con.Open();
       string teststr = "spInsertTrustRatings3";
       SqlCommand command = new SqlCommand(teststr, con);
       command.CommandType = CommandType.StoredProcedure;

       command.Parameters.AddWithValue("@userid", Convert.ToInt32(UserId));
       command.Parameters.AddWithValue("@pictureid", pictureid);
       command.Parameters.AddWithValue("@trustlist1a", RadioButtonList89.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist1a", RadioButtonList90.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist2a", RadioButtonList91.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist2a", RadioButtonList92.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist3a", RadioButtonList93.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist3a", RadioButtonList94.Text.ToString().Trim());
       int result = command.ExecuteNonQuery();
       if (result == 1)
       {
           ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Your ratings have been successfully submitted.');location.href='StudyPage1.aspx'", true);
       }
   }

   protected void btnSubmit24_Click(object sender, EventArgs e)
   {
       string str = getConnectionString();
       string UserId = Session["UserId"].ToString();
       int pictureid = Convert.ToInt32(Session["PictureId"]);    
       SqlConnection con = new SqlConnection(str);
       con.Open();
       string teststr = "spInsertTrustRatings3";
       SqlCommand command = new SqlCommand(teststr, con);
       command.CommandType = CommandType.StoredProcedure;

       command.Parameters.AddWithValue("@userid", Convert.ToInt32(UserId));
       command.Parameters.AddWithValue("@pictureid", pictureid);
       command.Parameters.AddWithValue("@trustlist1a", RadioButtonList95.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist1a", RadioButtonList96.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist2a", RadioButtonList97.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist2a", RadioButtonList98.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist3a", RadioButtonList99.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist3a", RadioButtonList100.Text.ToString().Trim());
       int result = command.ExecuteNonQuery();
       if (result == 1)
       {
           ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Your ratings have been successfully submitted.');location.href='StudyPage1.aspx'", true);
       }
   }

   protected void btnSubmit25_Click(object sender, EventArgs e)
   {
       string str = getConnectionString();
       string UserId = Session["UserId"].ToString();
       int pictureid = Convert.ToInt32(Session["PictureId"]);    
       SqlConnection con = new SqlConnection(str);
       con.Open();
       string teststr = "spInsertTrustRatings3";
       SqlCommand command = new SqlCommand(teststr, con);
       command.CommandType = CommandType.StoredProcedure;

       command.Parameters.AddWithValue("@userid", Convert.ToInt32(UserId));
       command.Parameters.AddWithValue("@pictureid", pictureid);
       command.Parameters.AddWithValue("@trustlist1a", RadioButtonList101.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist1a", RadioButtonList102.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist2a", RadioButtonList103.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist2a", RadioButtonList104.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist3a", RadioButtonList105.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist3a", RadioButtonList106.Text.ToString().Trim());
       int result = command.ExecuteNonQuery();
       if (result == 1)
       {
           ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Your ratings have been successfully submitted.');location.href='StudyPage1.aspx'", true);
       }
   }

   protected void btnSubmit26_Click(object sender, EventArgs e)
   {
       string str = getConnectionString();
       string UserId = Session["UserId"].ToString();
       int pictureid = Convert.ToInt32(Session["PictureId"]);    
       SqlConnection con = new SqlConnection(str);
       con.Open();
       string teststr = "spInsertTrustRatings3";
       SqlCommand command = new SqlCommand(teststr, con);
       command.CommandType = CommandType.StoredProcedure;

       command.Parameters.AddWithValue("@userid", Convert.ToInt32(UserId));
       command.Parameters.AddWithValue("@pictureid", pictureid);
       command.Parameters.AddWithValue("@trustlist1a", RadioButtonList107.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist1a", RadioButtonList108.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist2a", RadioButtonList109.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist2a", RadioButtonList110.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist3a", RadioButtonList111.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist3a", RadioButtonList112.Text.ToString().Trim());
       int result = command.ExecuteNonQuery();
       if (result == 1)
       {
           ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Your ratings have been successfully submitted.');location.href='StudyPage1.aspx'", true);
       }
   }

   protected void btnSubmit27_Click(object sender, EventArgs e)
   {
       string str = getConnectionString();
       string UserId = Session["UserId"].ToString();
       int pictureid = Convert.ToInt32(Session["PictureId"]);    
       SqlConnection con = new SqlConnection(str);
       con.Open();
       string teststr = "spInsertTrustRatings3";
       SqlCommand command = new SqlCommand(teststr, con);
       command.CommandType = CommandType.StoredProcedure;

       command.Parameters.AddWithValue("@userid", Convert.ToInt32(UserId));
       command.Parameters.AddWithValue("@pictureid", pictureid);
       command.Parameters.AddWithValue("@trustlist1a", RadioButtonList113.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist1a", RadioButtonList114.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist2a", RadioButtonList115.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist2a", RadioButtonList116.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist3a", RadioButtonList117.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist3a", RadioButtonList118.Text.ToString().Trim());
       int result = command.ExecuteNonQuery();
       if (result == 1)
       {
           ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Your ratings have been successfully submitted.');location.href='StudyPage1.aspx'", true);
       }
   }

   protected void btnSubmit28_Click(object sender, EventArgs e)
   {
       string str = getConnectionString();
       string UserId = Session["UserId"].ToString();
       int pictureid = Convert.ToInt32(Session["PictureId"]);    
       SqlConnection con = new SqlConnection(str);
       con.Open();
       string teststr = "spInsertTrustRatings3";
       SqlCommand command = new SqlCommand(teststr, con);
       command.CommandType = CommandType.StoredProcedure;

       command.Parameters.AddWithValue("@userid", Convert.ToInt32(UserId));
       command.Parameters.AddWithValue("@pictureid", pictureid);
       command.Parameters.AddWithValue("@trustlist1a", RadioButtonList119.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist1a", RadioButtonList120.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist2a", RadioButtonList121.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist2a", RadioButtonList122.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist3a", RadioButtonList123.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist3a", RadioButtonList124.Text.ToString().Trim());
       int result = command.ExecuteNonQuery();
       if (result == 1)
       {
           ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Your ratings have been successfully submitted.');location.href='StudyPage1.aspx'", true);
       }
   }

   protected void btnSubmit29_Click(object sender, EventArgs e)
   {
       string str = getConnectionString();
       string UserId = Session["UserId"].ToString();
       int pictureid = Convert.ToInt32(Session["PictureId"]);    
       SqlConnection con = new SqlConnection(str);
       con.Open();
       string teststr = "spInsertTrustRatings3";
       SqlCommand command = new SqlCommand(teststr, con);
       command.CommandType = CommandType.StoredProcedure;

       command.Parameters.AddWithValue("@userid", Convert.ToInt32(UserId));
       command.Parameters.AddWithValue("@pictureid", pictureid);
       command.Parameters.AddWithValue("@trustlist1a", RadioButtonList125.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist1a", RadioButtonList126.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist2a", RadioButtonList127.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist2a", RadioButtonList128.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist3a", RadioButtonList129.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist3a", RadioButtonList130.Text.ToString().Trim());
       int result = command.ExecuteNonQuery();
       if (result == 1)
       {
           ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Your ratings have been successfully submitted.');location.href='StudyPage1.aspx'", true);
       }
   }

   protected void btnSubmit30_Click(object sender, EventArgs e)
   {
       string str = getConnectionString();
       string UserId = Session["UserId"].ToString();
       int pictureid = Convert.ToInt32(Session["PictureId"]);    
       SqlConnection con = new SqlConnection(str);
       con.Open();
       string teststr = "spInsertTrustRatings3";
       SqlCommand command = new SqlCommand(teststr, con);
       command.CommandType = CommandType.StoredProcedure;

       command.Parameters.AddWithValue("@userid", Convert.ToInt32(UserId));
       command.Parameters.AddWithValue("@pictureid", pictureid);
       command.Parameters.AddWithValue("@trustlist1a", RadioButtonList131.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist1a", RadioButtonList132.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist2a", RadioButtonList133.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist2a", RadioButtonList134.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist3a", RadioButtonList135.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist3a", RadioButtonList136.Text.ToString().Trim());
       int result = command.ExecuteNonQuery();
       if (result == 1)
       {
           ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Your ratings have been successfully submitted.');location.href='StudyPage1.aspx'", true);
       }
   }

   protected void btnSubmit31_Click(object sender, EventArgs e)
   {
       string str = getConnectionString();
       string UserId = Session["UserId"].ToString();
       int pictureid = Convert.ToInt32(Session["PictureId"]);    
       SqlConnection con = new SqlConnection(str);
       con.Open();
       string teststr = "spInsertTrustRatings3";
       SqlCommand command = new SqlCommand(teststr, con);
       command.CommandType = CommandType.StoredProcedure;

       command.Parameters.AddWithValue("@userid", Convert.ToInt32(UserId));
       command.Parameters.AddWithValue("@pictureid", pictureid);
       command.Parameters.AddWithValue("@trustlist1a", RadioButtonList137.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist1a", RadioButtonList138.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist2a", RadioButtonList139.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist2a", RadioButtonList140.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist3a", RadioButtonList141.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist3a", RadioButtonList142.Text.ToString().Trim());
       int result = command.ExecuteNonQuery();
       if (result == 1)
       {
           ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Your ratings have been successfully submitted.');location.href='StudyPage1.aspx'", true);
       }
   }

   protected void btnSubmit32_Click(object sender, EventArgs e)
   {
       string str = getConnectionString();
       string UserId = Session["UserId"].ToString();
       int pictureid = Convert.ToInt32(Session["PictureId"]);    
       SqlConnection con = new SqlConnection(str);
       con.Open();
       string teststr = "spInsertTrustRatings3";
       SqlCommand command = new SqlCommand(teststr, con);
       command.CommandType = CommandType.StoredProcedure;

       command.Parameters.AddWithValue("@userid", Convert.ToInt32(UserId));
       command.Parameters.AddWithValue("@pictureid", pictureid);
       command.Parameters.AddWithValue("@trustlist1a", RadioButtonList143.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist1a", RadioButtonList144.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist2a", RadioButtonList145.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist2a", RadioButtonList146.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist3a", RadioButtonList147.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist3a", RadioButtonList148.Text.ToString().Trim());
       int result = command.ExecuteNonQuery();
       if (result == 1)
       {
           ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Your ratings have been successfully submitted.');location.href='StudyPage1.aspx'", true);
       }
   }

   protected void btnSubmit33_Click(object sender, EventArgs e)
   {
       string str = getConnectionString();
       string UserId = Session["UserId"].ToString();
       int pictureid = Convert.ToInt32(Session["PictureId"]);    
       SqlConnection con = new SqlConnection(str);
       con.Open();
       string teststr = "spInsertTrustRatings4";
       SqlCommand command = new SqlCommand(teststr, con);
       command.CommandType = CommandType.StoredProcedure;

       command.Parameters.AddWithValue("@userid", Convert.ToInt32(UserId));
       command.Parameters.AddWithValue("@pictureid", pictureid);
       command.Parameters.AddWithValue("@trustlist1a", RadioButtonList149.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist1a", RadioButtonList150.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist2a", RadioButtonList151.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist2a", RadioButtonList152.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist3a", RadioButtonList153.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist3a", RadioButtonList154.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist4a", RadioButtonList155.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist4a", RadioButtonList156.Text.ToString().Trim());
       int result = command.ExecuteNonQuery();
       if (result == 1)
       {
           ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Your ratings have been successfully submitted.');location.href='StudyPage1.aspx'", true);
       }
   }

   protected void btnSubmit34_Click(object sender, EventArgs e)
   {
       string str = getConnectionString();
       string UserId = Session["UserId"].ToString();
       int pictureid = Convert.ToInt32(Session["PictureId"]);    
       SqlConnection con = new SqlConnection(str);
       con.Open();
       string teststr = "spInsertTrustRatings4";
       SqlCommand command = new SqlCommand(teststr, con);
       command.CommandType = CommandType.StoredProcedure;

       command.Parameters.AddWithValue("@userid", Convert.ToInt32(UserId));
       command.Parameters.AddWithValue("@pictureid", pictureid);
       command.Parameters.AddWithValue("@trustlist1a", RadioButtonList157.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist1a", RadioButtonList158.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist2a", RadioButtonList159.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist2a", RadioButtonList160.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist3a", RadioButtonList161.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist3a", RadioButtonList162.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist4a", RadioButtonList163.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist4a", RadioButtonList164.Text.ToString().Trim());
       int result = command.ExecuteNonQuery();
       if (result == 1)
       {
           ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Your ratings have been successfully submitted.');location.href='StudyPage1.aspx'", true);
       }
   }

   protected void btnSubmit35_Click(object sender, EventArgs e)
   {
       string str = getConnectionString();
       string UserId = Session["UserId"].ToString();
       int pictureid = Convert.ToInt32(Session["PictureId"]);    
       SqlConnection con = new SqlConnection(str);
       con.Open();
       string teststr = "spInsertTrustRatings4";
       SqlCommand command = new SqlCommand(teststr, con);
       command.CommandType = CommandType.StoredProcedure;

       command.Parameters.AddWithValue("@userid", Convert.ToInt32(UserId));
       command.Parameters.AddWithValue("@pictureid", pictureid);
       command.Parameters.AddWithValue("@trustlist1a", RadioButtonList165.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist1a", RadioButtonList166.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist2a", RadioButtonList167.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist2a", RadioButtonList168.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist3a", RadioButtonList169.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist3a", RadioButtonList170.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist4a", RadioButtonList171.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist4a", RadioButtonList172.Text.ToString().Trim());
       int result = command.ExecuteNonQuery();
       if (result == 1)
       {
           ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Your ratings have been successfully submitted.');location.href='StudyPage1.aspx'", true);
       }
   }

   protected void btnSubmit36_Click(object sender, EventArgs e)
   {
       string str = getConnectionString();
       string UserId = Session["UserId"].ToString();
       int pictureid = Convert.ToInt32(Session["PictureId"]);    
       SqlConnection con = new SqlConnection(str);
       con.Open();
       string teststr = "spInsertTrustRatings4";
       SqlCommand command = new SqlCommand(teststr, con);
       command.CommandType = CommandType.StoredProcedure;

       command.Parameters.AddWithValue("@userid", Convert.ToInt32(UserId));
       command.Parameters.AddWithValue("@pictureid", pictureid);
       command.Parameters.AddWithValue("@trustlist1a", RadioButtonList173.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist1a", RadioButtonList174.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist2a", RadioButtonList175.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist2a", RadioButtonList176.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist3a", RadioButtonList177.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist3a", RadioButtonList178.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist4a", RadioButtonList179.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist4a", RadioButtonList180.Text.ToString().Trim());
       int result = command.ExecuteNonQuery();
       if (result == 1)
       {
           ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Your ratings have been successfully submitted.');location.href='StudyPage1.aspx'", true);
       }
   }

   protected void btnSubmit37_Click(object sender, EventArgs e)
   {
       string str = getConnectionString();
       string UserId = Session["UserId"].ToString();
       int pictureid = Convert.ToInt32(Session["PictureId"]);    
       SqlConnection con = new SqlConnection(str);
       con.Open();
       string teststr = "spInsertTrustRatings4";
       SqlCommand command = new SqlCommand(teststr, con);
       command.CommandType = CommandType.StoredProcedure;

       command.Parameters.AddWithValue("@userid", Convert.ToInt32(UserId));
       command.Parameters.AddWithValue("@pictureid", pictureid);
       command.Parameters.AddWithValue("@trustlist1a", RadioButtonList181.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist1a", RadioButtonList182.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist2a", RadioButtonList183.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist2a", RadioButtonList184.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist3a", RadioButtonList185.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist3a", RadioButtonList186.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist4a", RadioButtonList187.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist4a", RadioButtonList188.Text.ToString().Trim());
       int result = command.ExecuteNonQuery();
       if (result == 1)
       {
           ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Your ratings have been successfully submitted.');location.href='StudyPage1.aspx'", true);
       }
   }

   protected void btnSubmit38_Click(object sender, EventArgs e)
   {
       string str = getConnectionString();
       string UserId = Session["UserId"].ToString();
       int pictureid = Convert.ToInt32(Session["PictureId"]);    
       SqlConnection con = new SqlConnection(str);
       con.Open();
       string teststr = "spInsertTrustRatings4";
       SqlCommand command = new SqlCommand(teststr, con);
       command.CommandType = CommandType.StoredProcedure;

       command.Parameters.AddWithValue("@userid", Convert.ToInt32(UserId));
       command.Parameters.AddWithValue("@pictureid", pictureid);
       command.Parameters.AddWithValue("@trustlist1a", RadioButtonList189.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist1a", RadioButtonList190.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist2a", RadioButtonList191.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist2a", RadioButtonList192.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist3a", RadioButtonList193.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist3a", RadioButtonList194.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist4a", RadioButtonList195.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist4a", RadioButtonList196.Text.ToString().Trim());
       int result = command.ExecuteNonQuery();
       if (result == 1)
       {
           ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Your ratings have been successfully submitted.');location.href='StudyPage1.aspx'", true);
       }
   }

   protected void btnSubmit39_Click(object sender, EventArgs e)
   {
       string str = getConnectionString();
       string UserId = Session["UserId"].ToString();
       int pictureid = Convert.ToInt32(Session["PictureId"]);    
       SqlConnection con = new SqlConnection(str);
       con.Open();
       string teststr = "spInsertTrustRatings4";
       SqlCommand command = new SqlCommand(teststr, con);
       command.CommandType = CommandType.StoredProcedure;

       command.Parameters.AddWithValue("@userid", Convert.ToInt32(UserId));
       command.Parameters.AddWithValue("@pictureid", pictureid);
       command.Parameters.AddWithValue("@trustlist1a", RadioButtonList197.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist1a", RadioButtonList198.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist2a", RadioButtonList199.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist2a", RadioButtonList200.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist3a", RadioButtonList201.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist3a", RadioButtonList202.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist4a", RadioButtonList203.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist4a", RadioButtonList204.Text.ToString().Trim());
       int result = command.ExecuteNonQuery();
       if (result == 1)
       {
           ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Your ratings have been successfully submitted.');location.href='StudyPage1.aspx'", true);
       }
   }

   protected void btnSubmit40_Click(object sender, EventArgs e)
   {
       string str = getConnectionString();
       string UserId = Session["UserId"].ToString();
       int pictureid = Convert.ToInt32(Session["PictureId"]);    
       SqlConnection con = new SqlConnection(str);
       con.Open();
       string teststr = "spInsertTrustRatings4";
       SqlCommand command = new SqlCommand(teststr, con);
       command.CommandType = CommandType.StoredProcedure;

       command.Parameters.AddWithValue("@userid", Convert.ToInt32(UserId));
       command.Parameters.AddWithValue("@pictureid", pictureid);
       command.Parameters.AddWithValue("@trustlist1a", RadioButtonList205.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist1a", RadioButtonList206.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist2a", RadioButtonList207.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist2a", RadioButtonList208.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist3a", RadioButtonList209.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist3a", RadioButtonList210.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist4a", RadioButtonList211.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist4a", RadioButtonList212.Text.ToString().Trim());
       int result = command.ExecuteNonQuery();
       if (result == 1)
       {
           ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Your ratings have been successfully submitted.');location.href='StudyPage1.aspx'", true);
       }
   }

   protected void btnSubmit41_Click(object sender, EventArgs e)
   {
       string str = getConnectionString();
       string UserId = Session["UserId"].ToString();
       int pictureid = Convert.ToInt32(Session["PictureId"]);    
       SqlConnection con = new SqlConnection(str);
       con.Open();
       string teststr = "spInsertTrustRatings4";
       SqlCommand command = new SqlCommand(teststr, con);
       command.CommandType = CommandType.StoredProcedure;

       command.Parameters.AddWithValue("@userid", Convert.ToInt32(UserId));
       command.Parameters.AddWithValue("@pictureid", pictureid);
       command.Parameters.AddWithValue("@trustlist1a", RadioButtonList213.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist1a", RadioButtonList214.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist2a", RadioButtonList215.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist2a", RadioButtonList216.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist3a", RadioButtonList217.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist3a", RadioButtonList218.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist4a", RadioButtonList219.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist4a", RadioButtonList220.Text.ToString().Trim());
       int result = command.ExecuteNonQuery();
       if (result == 1)
       {
           ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Your ratings have been successfully submitted.');location.href='StudyPage1.aspx'", true);
       }
   }

   protected void btnSubmit42_Click(object sender, EventArgs e)
   {
       string str = getConnectionString();
       string UserId = Session["UserId"].ToString();
       int pictureid = Convert.ToInt32(Session["PictureId"]);    
       SqlConnection con = new SqlConnection(str);
       con.Open();
       string teststr = "spInsertTrustRatings4";
       SqlCommand command = new SqlCommand(teststr, con);
       command.CommandType = CommandType.StoredProcedure;

       command.Parameters.AddWithValue("@userid", Convert.ToInt32(UserId));
       command.Parameters.AddWithValue("@pictureid", pictureid);
       command.Parameters.AddWithValue("@trustlist1a", RadioButtonList221.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist1a", RadioButtonList222.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist2a", RadioButtonList223.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist2a", RadioButtonList224.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist3a", RadioButtonList225.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist3a", RadioButtonList226.Text.ToString().Trim());
       command.Parameters.AddWithValue("@trustlist4a", RadioButtonList227.Text.ToString().Trim());
       command.Parameters.AddWithValue("@creditlist4a", RadioButtonList228.Text.ToString().Trim());
       int result = command.ExecuteNonQuery();
       if (result == 1)
       {
           ScriptManager.RegisterStartupScript(this, GetType(), "showAlert", "alert('Your ratings have been successfully submitted.');location.href='StudyPage1.aspx'", true);
       }
   }

   }
}