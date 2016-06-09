using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstImpressions
{
    public partial class Instructions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnStart_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            string[] PageNames = {"StudyPage1.aspx", "StudyPage2.aspx"};

            int pageIndex = rnd.Next(0, PageNames.Length);

            Response.Redirect(PageNames[pageIndex]);
        }
    }
}