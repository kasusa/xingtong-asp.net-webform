using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using xingtong_netframe472.moudle;

namespace xingtong_netframe472.Pages
{
    public partial class xiaoqu_edit : System.Web.UI.Page
    {
        xiaoqu_item theXiaoqu = new xiaoqu_item();
        bool xiaoquExist = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            //如果没有登录,跳转回主页
            string username = (string)(Session["username"]);
            if (username == null || username.Equals(""))
            {
                Response.Redirect("Index.aspx");
            }
            Panel1.Visible = false;
            Panel2.Visible = false;
            Panel3.Visible = false;

        }

        protected void Button1_Click(object sender, EventArgs e)//查询按钮
        {
            if (TextBox1.Text.Equals(""))
            {
                Panel2.Visible = true;
                Label_error.Text = "您没有输入小区编号";
            }
            else
            {
                //内容传入调用mysql的函数
                string xiaoquid = TextBox1.Text;
                get_xiaoqu(xiaoquid);

                //获取一共取得的项目数量

                if (xiaoquExist)
                {
                    Panel3.Visible = true;
                }
                else
                {
                    Label_error.Text = "查询不到这个小区,请检查编号是否正确";
                    Panel2.Visible = true;
                }
            }

        }

        private void get_xiaoqu(string xiaoquid)
        {
            xiaoquExist = false;
            MysqlTOOLS mt = new MysqlTOOLS();
            string sql = "SELECT area_name , area_city , area_province,xiaoquid,xiaoqu_name from area,xiaoqu WHERE xiaoqu_area_id = areaID\n" +
            $"and xiaoquID = '{xiaoquid}'\n" ;
            var rdr = mt.sqlToReader(sql);
            while (rdr.Read())
            {
                xiaoquExist = true;
                var tmpitem = new xiaoqu_item();
                tmpitem.area.name = rdr[0].ToString();
                tmpitem.area.city = rdr[1].ToString();
                tmpitem.area.province = rdr[2].ToString();
                tmpitem.id = rdr[3].ToString();
                tmpitem.name = rdr[4].ToString();

                theXiaoqu = tmpitem;
            }

            TextBox2.Text = theXiaoqu.name;
            TextBox3.Text = theXiaoqu.area.province;
            TextBox4.Text = theXiaoqu.area.city;
            TextBox5.Text = theXiaoqu.area.name;
            rdr.Close();
            mt.closeconnection();
        }
        
        protected void Button2_Click(object sender, EventArgs e)// 保存按钮
        {
            saveXiaoqu();
            Panel1.Visible = true;
            Panel3.Visible = true;
        }

        private void saveXiaoqu()
        {
            theXiaoqu.name = TextBox2.Text;
            theXiaoqu.area.province = TextBox3.Text;
            theXiaoqu.area.city = TextBox4.Text;
            theXiaoqu.area.name = TextBox5.Text;
            theXiaoqu.id = TextBox1.Text;
            MysqlTOOLS mt = new MysqlTOOLS();
            string sql = $"UPDATE xiaoqu SET xiaoqu_name = '{theXiaoqu.name}' WHERE xiaoquID = '{theXiaoqu.id}'";
            //Button2.Text = sql;
            mt.sqlToExec(sql);
        }
    }
}