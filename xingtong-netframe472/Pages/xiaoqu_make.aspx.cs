using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using xingtong_netframe472.moudle;

namespace xingtong_netframe472.Pages
{
    public partial class xiaoqu_make : System.Web.UI.Page
    {
        xiaoqu_item theXiaoqu = new xiaoqu_item();
        bool areaExist = false;
        string areaID = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            ////如果没有登录,跳转回主页
            string username = (string)(Session["username"]);
            if (username == null || username.Equals(""))
            {
                Response.Redirect("Index.aspx");
            }
            Panel1.Visible = false;
            Panel2.Visible = false;
            // 防止jquery的validtor错误
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void Button2_Click(object sender, EventArgs e)//保存按钮
        {
            theXiaoqu.name = TextBox1.Text;
            theXiaoqu.area.province = TextBox2.Text;
            theXiaoqu.area.city = TextBox3.Text;
            theXiaoqu.area.name = TextBox4.Text;
 
            areaExist = getareaExist(theXiaoqu.area);
            if(!areaExist)
                addarea(theXiaoqu.area);
            getareaExist(theXiaoqu.area);//如果存在将id放入 areaID 变量中
            addxiaoqu();

            Panel1.Visible = true;
            
            //Button2.Text = areaExist.ToString();
        }

        private void addxiaoqu()
        {
            MysqlTOOLS mt = new MysqlTOOLS();
            string sql = $"INSERT INTO xiaoqu (xiaoqu_name , xiaoqu_area_id , xiaoqu_management_id) VALUES('{theXiaoqu.name}','{areaID}','1')";
            mt.sqlToExec(sql);
        }

        private void addarea(area are)
        {
            MysqlTOOLS mt = new MysqlTOOLS();
            string sql = $"INSERT into area (area_name,area_city,area_province) VALUES('{are.name}','{are.city}','{are.province}')";
            //Button2.Text = sql;
            mt.sqlToExec(sql);
        }

        private bool getareaExist(area are)//确定area是否存在,返回真.假 如果存在将id放入 areaID 变量中
        {
            areaID = "";
            bool ans = false;
            MysqlTOOLS mt = new MysqlTOOLS();
            string sql = $"SELECT areaID FROM area WHERE area_name = '{are.name}' and area_city = '{are.city}' and area_province = '{are.province}'";
            var rdr = mt.sqlToReader(sql);
            while (rdr.Read())
            {
                ans = true;
                areaID = rdr[0].ToString();
            }

            rdr.Close();
            mt.closeconnection();
            return ans;
        }


    }
}