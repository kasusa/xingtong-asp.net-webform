using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Xingtong_NETFRAME.Pages;
using xingtong_netframe472.moudle;

namespace xingtong_netframe472.Pages
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        LinkedList<citizen> ctznlist = new LinkedList<citizen>();
        public string outputtable = "请输入查询内容";
        protected void Page_Load(object sender, EventArgs e)
        {
            //panel1 : 成功数量提示
            //panel2 : 无消息提示
            Panel1.Visible = false;
            Panel2.Visible = false;
        }
        //返回html table格式的内容字符串
        public string get(string name, string id)
        {
            MysqlTOOLS mt = new MysqlTOOLS();
            string sql1 = "SELECT citizenID , citizen_name , citizen_gender\n" +
                "from citizen\n" +
                $"WHERE citizenID like '{id}%'\n" +
                $"and citizen_name like '%{name}%'";
            var rdr = mt.sqlToReader(sql1);
            while (rdr.Read())
            {
                var dumdum = new citizen();
                dumdum.citizenid = rdr[0].ToString();
                dumdum.name = rdr[1].ToString();
                dumdum.gender = rdr[2].ToString();
                ctznlist.AddLast(dumdum);
            }
            rdr.Close();
            mt.closeconnection();

            string contentstr = "";
            foreach (var item in ctznlist)
            {
                string addstr = $"<tr>\n" +
                $"<td>{item.name}</td>\n" +
                $"<td>{item.gender}</td>\n" +
                $"<td>{item.citizenid}</td>\n" +
                "</tr>";
                contentstr += addstr;
            }
          
            return contentstr;

        }
        //过滤按钮,调用get函数
        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = TextBox1.Text;
            string id = TextBox2.Text;
            outputtable = get(name, id);

            int count = ctznlist.Count;
            if (count > 0)
            {
                Label1.Text = count.ToString();
                Panel1.Visible = true;
            }
            else
                Panel2.Visible = true;

        }
        //清空输入按钮,清空textbox
        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
        }
    }
}