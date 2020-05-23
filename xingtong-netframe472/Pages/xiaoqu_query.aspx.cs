using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using xingtong_netframe472.moudle;

namespace xingtong_netframe472.Pages
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        LinkedList<xiaoqu_item> xxxlist = new LinkedList<xiaoqu_item>();
        public string outputtable = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            string username = (string)(Session["username"]);
            if (username == null || username.Equals(""))
            {
                Response.Redirect("Index.aspx");
            }
            //panel1 : 成功数量提示
            //panel2 : 无消息提示
            Panel1.Visible = false;
            Panel2.Visible = false;


        }
        //这个按钮的功能是获取输入内容,生成表格
        protected void Button1_Click(object sender, EventArgs e)
        {
            //内容传入调用mysql的函数
            string  xiaoqu_id = TextBox1.Text;
            string  xiaoqu_name = TextBox2.Text;
            string  province = TextBox3.Text;
            string  city = TextBox4.Text;
            string  qu = TextBox5.Text;

            outputtable = get(xiaoqu_id,xiaoqu_name,province,city,qu);

            //获取一共取得的项目数量
            int count = xxxlist.Count;
            if (count > 0)
            {
                Label1.Text = count.ToString();
                Panel1.Visible = true;
            }
            else
                Panel2.Visible = true;
        }

        //这个按钮的功能是清空输入框根据具体情况填写
        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
        }
        public string get(string xiaoqu_id,
            string xiaoqu_name,
            string province,
            string city,
            string qu)
        {
            MysqlTOOLS mt = new MysqlTOOLS();
            string sql =
                "SELECT area_name , area_city , area_province,xiaoquid,xiaoqu_name from area,xiaoqu WHERE xiaoqu_area_id = areaID\n" +
        $"and xiaoquID like '{xiaoqu_id}%'\n" +
        $"and xiaoqu_name like '%{xiaoqu_name}%'\n" +
        $"and area_name like '%{qu}%'\n" +
        $"and area_city like '%{city}%'\n" +
        $"and area_province like '%{province}%'";
            var rdr = mt.sqlToReader(sql);
            while (rdr.Read())
            {
                // tmpitem,可是专门设计的类,也可以是有足够信息的实体类.
                // 通过reader 获取信息
                var tmpitem = new xiaoqu_item();
                tmpitem.area.name = rdr[0].ToString();
                tmpitem.area.city = rdr[1].ToString();
                tmpitem.area.province = rdr[2].ToString();
                tmpitem.id = rdr[3].ToString();
                tmpitem.name = rdr[4].ToString();


                xxxlist.AddLast(tmpitem);
            }
            rdr.Close();
            mt.closeconnection();
            string contentstr = "";
            foreach (var item in xxxlist)
            {
                // 每一行表格的html代码
                string addstr =
                "                    <tr>\n" +
                $"                        <td>{item.id}</td>\n" +
                $"                        <td>{item.name}</td>\n" +
                $"                        <td>{item.area.ToString()}</td>\n" +
                "                    </tr>";
                contentstr += addstr;
            }

            return contentstr;

        }
    }
}