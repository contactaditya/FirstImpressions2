using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstImpressions
{
    public partial class Test1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int currentUserId = Convert.ToInt32(Session["UserId"]);
            int pictureid = Convert.ToInt32(Session["PictureId"]);
            string raterslot = Session["RaterSlot"].ToString();
            string gender = Session["Gender"].ToString();
            int counter = Convert.ToInt32(Session["Counter"]);
            TextBox1.Text = currentUserId.ToString();
            TextBox2.Text = pictureid.ToString();
            TextBox3.Text = raterslot.ToString();
            TextBox4.Text = gender.ToString();
            TextBox5.Text = counter.ToString();
        }
    }
}