using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Xingtong_NETFRAME.Pages
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string username = (string)(Session["username"]);
            if (username == null || username.Equals(""))
                lableLoginOrUsername.Text = "登录";
            else
                lableLoginOrUsername.Text = username;
        }

    }
}