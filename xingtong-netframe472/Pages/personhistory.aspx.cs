using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using xingtong_netframe472.moudle;

namespace xingtong_netframe472.Pages
{
    public partial class personhistory : System.Web.UI.Page
    {
        LinkedList<history_item> hislist = new LinkedList<history_item>();
        public string outputtable = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //如果没有登录,跳转回主页
            string username = (string)(Session["username"]);
            if (username == null || username.Equals(""))
            {
                Response.Redirect("Index.aspx");
            }
            //panel1 : 成功数量提示
            //panel2 : 无消息提示
            Panel1.Visible = false;
            Panel2.Visible = false;
            // 防止jquery的validtor错误
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

        }
        public string get(string id)
        {
            MysqlTOOLS mt = new MysqlTOOLS();
            string sql = "SELECT area_name ,area_city ,area_province ,xiaoqu_name,`in`,`out`,action_time\n" +
                "FROM area,in_and_out,xiaoqu\n" +
                "WHERE xiaoqu.xiaoqu_area_id = areaID\n" +
                "and xiaoqu_id = xiaoquID\n" +
                $"and in_and_out.citizen_id = '{id}'";
            var rdr = mt.sqlToReader(sql);
            while (rdr.Read())
            {
                var hisinfo = new history_item();
                hisinfo.area.name = rdr[0].ToString();
                hisinfo.area.city = rdr[1].ToString();
                hisinfo.area.province = rdr[2].ToString();
                hisinfo.xiaoqu = rdr[3].ToString();
                hisinfo.in_ = Convert.ToBoolean( rdr[4]);
                hisinfo.out_ = Convert.ToBoolean(rdr[5]);

                hisinfo.time = rdr[6].ToString();
                if (hisinfo.in_)
                    hisinfo.fangxiang = "进入";
                else
                    hisinfo.fangxiang = "离开";
                hislist.AddLast(hisinfo);
            }
            rdr.Close();
            mt.closeconnection();
            string contentstr = "";
            foreach (var item in hislist)
            {
                string addstr =
                "                    <tr>\n" +
                $"                        <td>{item.area.ToString()}</td>\n" +
                $"                        <td>{item.xiaoqu}</td>\n" +
                $"                        <td>{item.fangxiang}</td>\n" +
                $"                        <td>{item.time}</td>\n" +
                "                    </tr>";
                contentstr += addstr;
            }

            return contentstr;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string id = TextBox1.Text;
            outputtable = get(id);

            int count = hislist.Count;
            if (count > 0)
            {
                Label1.Text = count.ToString();
                Panel1.Visible = true;
            }
            else
                Panel2.Visible = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
                TextBox1.Text = "";
        }
    }
}