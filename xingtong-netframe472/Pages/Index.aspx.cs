using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Xingtong_NETFRAME.Pages
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            Panel2.Visible = false;

            string username = (string)(Session["username"]);
            if (username == null || username.Equals(""))
                Panel1.Visible = true;
            else
                Panel2.Visible = true;
            Label1.Text = DateTime.Now.ToString();

        }
    }
}