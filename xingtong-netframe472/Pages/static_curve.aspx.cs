using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using xingtong_netframe472.moudle;

namespace xingtong_netframe472.Pages
{
    public partial class static_curve : System.Web.UI.Page
    {
        public string chartstyle = "";
        public int chartdots = 0;
        public string xiaoqu_id = "";
        public string charttitle = "";

        public List<string> bottomTextlist = new List<string>();
        public List<string> datalist = new List<string>();
        public List<chart_time_item> fulldatalist = new List<chart_time_item>();

        protected void Page_Load(object sender, EventArgs e)
        {
            string username = (string)(Session["username"]);
            if (username == null || username.Equals(""))
            {
                Response.Redirect("Index.aspx");
            }
            //直接获得默认配置的10天柱状图的统计数据
            getGrapicsettings_query();
            charttitle = "出入总数统计";
            //Label1.Text = ListToString(datalist);
            Panel1.Visible = false;
            Panel2.Visible = false;
            Label1.Text = Label2.Text = "";
        }

        private void getGrapicsettings_query()
        {
            xiaoqu_id = TextBox1.Text;
           
            //获取用户选择的日期数量/显示方式
            chartdots = Convert.ToInt32(RadioButtonList1.SelectedValue);
            chartstyle = RadioButtonList2.SelectedValue;
            //获取需要的所有日期数据
            for (int i = 0; i <= chartdots; i++)
            {
                string a = DateTime.Now.AddDays(-chartdots+i).ToShortDateString();
                bottomTextlist.Add(a);
            }
            //获取数据库内容
            var mt = new MysqlTOOLS();
            string sql = "";
            if (xiaoqu_id.Equals(""))
                sql = "SELECT citizen_id,xiaoqu_id , action_time from in_and_out ";
            else
                sql = $"SELECT citizen_id,xiaoqu_id , action_time from in_and_out WHERE xiaoqu_id = '{xiaoqu_id}'";
            var rdr = mt.sqlToReader(sql);
            while (rdr.Read())
            {
                var item = new chart_time_item();
                item.citizenid = rdr[0].ToString();
                item.xiaoqu_id = rdr[1].ToString();
                item.action_time = rdr[2].ToString();
                // 通过substring得到较短的时间格式
                item.action_time_short = item.action_time.Substring(0, 10);

                fulldatalist.Add(item);
            }
            //从数据库所有内容中获取每个对应日期的出入次数
            foreach (var item in bottomTextlist)
            {
                int counter = 0;
                foreach (var t in fulldatalist)
                {
                    if (t.action_time_short == item) counter++;
                }
                datalist.Add(counter.ToString());
            }
            Panel1.Visible = true;


        }

        public string xiaoquExist_andgetname()
        {
            string ans = "";
            var mt = new MysqlTOOLS();
            string sql = $"SELECT xiaoqu_name FROM xiaoqu WHERE xiaoquid = '{xiaoqu_id}'";
            var rdr = mt.sqlToReader(sql);
            try
            {
                rdr.Read();
                ans = rdr[0].ToString();
            }catch
            {

            }
            rdr.Close();
            mt.closeconnection();
            return ans;
        }

        public string ListToString(List<string> l)
        {
            string ans = "";
            foreach (var item in l)
            {
                ans += $",'{item}'";
            }
            return ans.Substring(1, ans.Length - 1);//去掉第一个逗号,这样的结果可以用于js代码
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void Button_filter_Click(object sender, EventArgs e)
        {
            if (xiaoqu_id.Equals(""))
            {
                Panel1.Visible = true;
                charttitle = "出入总数统计";
            }
            else
            {
                string xiaoqu_name = xiaoquExist_andgetname();
                if (xiaoqu_name.Equals(""))
                {
                    Panel2.Visible = true;
                    Label2.Text = "小区不存在";
                }
                else
                {
                    
                    charttitle = $"{xiaoqu_name} 小区出入统计";
                }
            }
        }
    }
}