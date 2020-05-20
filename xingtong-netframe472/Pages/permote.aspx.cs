using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using xingtong_netframe472.moudle;

namespace xingtong_netframe472.Pages
{
    public partial class permote : System.Web.UI.Page
    {
        public string id = "";

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
            // 防止jquery的validtor错误
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }


        private string getIsworker(string id)
        {
            var mt = new MysqlTOOLS();
            string sql =
                "SELECT * FROM `user`,worker\n" +
                "WHERE `user`.user_citizenID = worker.worker_citizenid\n" +
                $"and worker_citizenid = '{id}'\n";
            bool ans = mt.sqlToBoolhave(sql);
            mt.closeconnection();
            if (ans)
            {
                return "是";
            }
            else return "不是";
        }

        private string getname(string id)
        {
            string ans = "";
            MysqlTOOLS mt = new MysqlTOOLS();
            string sql1 = $"SELECT citizen_name from citizen WHERE citizenID = '{id}'";

            var rdr = mt.sqlToReader(sql1);
            while (rdr.Read())
            {
                ans = rdr[0].ToString();
            }
            rdr.Close();
            mt.closeconnection();

            return ans;
        }

        protected void Button2_Click(object sender, EventArgs e)//升级/降级的按钮
        {
            id = TextBox1.Text;

            if (Label_isworker.Text.Equals("是"))
            {
                //降级
                MysqlTOOLS mt = new MysqlTOOLS();
                string sql = $"DELETE FROM worker WHERE worker.worker_citizenid = '{id}'";
                mt.sqlToExec(sql);
                mt.closeconnection();
                Label_success.Text = $"成功降级{Label_name.Text }为普通人员";
            }
            else
            {
                //升级
                MysqlTOOLS mt = new MysqlTOOLS();
                string sql = $"INSERT INTO worker VALUES('{id}', '1','default')";
                mt.sqlToExec(sql);
                mt.closeconnection();

                Label_success.Text = $"成功提升{Label_name.Text }为管理员";

            }
            Panel1.Visible = true;
            Panel3.Visible = true;

            Label_name.Text = getname(id);
            Label_isworker.Text = getIsworker(id);
            // 判断提供升级还是降级的功能
            if (Label_isworker.Text.Equals("是"))
            {
                Button2.Text = "降级为普通人员";
            }
            else
                Button2.Text = "提升为管理人员";
        }



        protected void Button1_Click(object sender, EventArgs e)//查询按钮
        {
            id= TextBox1.Text;
            Label_name.Text = getname(id);
            Label_isworker.Text = getIsworker(id);
            if (Label_name.Text.Equals(""))
            {
                Label_error.Text = "查询不到这个人,请重新确认身份证号码";
                Panel2.Visible = true;
            }
            else
            {
                Panel3.Visible = true;

            }
            // 判断提供升级还是降级的功能
            if (Label_isworker.Text.Equals("是"))
            {
                Button2.Text = "降级为普通人员";
            }else
                Button2.Text = "提升为管理人员";

        }
    }
}