using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Xingtong_NETFRAME.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 防止jquery的validtor错误
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            Panel1.Visible = false;
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            string ID = TextBox1.Text;
            string password = TextBox2.Text;
            // sql0 判断用户是否存在
            // sql1 判断用户密码是否正确
            // sql2 判断用户是否为工作人员(存在于worker表中)
            // sql3 获取用户的姓名 (从citizen表中)
            string sql0 = "SELECT * from user where user_citizenID = \'" + ID + "\'; ";
            string sql1 = "SELECT * from user where user_citizenID = \'" + ID + "\'and user_pwd = \'" + password + "\'; ";
            string sql2 = "SELECT * from worker where worker_citizenid = '" + ID + "'";
            string sql3 = "SELECT citizen_name from citizen where citizenID =  '" + ID + "'";


            var mt = new xingtong_netframe472.MysqlTOOLS();
            if (mt.sqlToBoolhave(sql0))
            {
                if (mt.sqlToBoolhave(sql1))
                {
                    if (mt.sqlToBoolhave(sql2))
                    {
                        MySqlDataReader rdr = mt.sqlToReader(sql3);
                        string username = "";
                        while (rdr.Read())
                        {
                            username = rdr[0].ToString();
                        }
                        rdr.Close();
                        Session["username"] = username;
                        Response.Write("<script>alert(\"" + $"欢迎{username}使用本系统" + "\")</script>");
                        Response.Redirect("Index.aspx");
                    }
                    else
                    {
                        Panel1.Visible = true;
                        Label1.Text = $"您是一个普通居民,本系统为内部系统不对外开放。";
                    }


                }
                else
                {
                    Panel1.Visible = true;
                    Label1.Text = $"您的密码不正确";
                }

            }
            else
            {
                Panel1.Visible = true;
                Label1.Text = $"您还没有注册过,请先去移动端注册";
            }

        }
    }
}