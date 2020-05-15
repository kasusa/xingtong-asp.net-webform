using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using xingtong_netframe472;

namespace Xingtong_NETFRAME.Pages
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //登录检查
            string username = (string)(Session["username"]);
            if (username == null || username.Equals(""))
                Button1.Text = "登录";
            else
                Button1.Text = username;

            //通知检查
            if ( !toast.title.Equals(""))
            {
                Panel1.Visible = true;
                Label_alert_title.Text = toast.title;
                Label_alert_content.Text = toast.content;
                toast.clear();
            }
            else
            {
                Panel1.Visible = false;
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Button1.Text.Equals("登录"))
            {
                Response.Redirect("Login.aspx");
            }else
                Response.Redirect("Logout.aspx");

        }
    }
}