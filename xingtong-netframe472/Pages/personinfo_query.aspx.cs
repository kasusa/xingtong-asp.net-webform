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
        public string outputtable = "如果您不会使用,请先参考--如何使用过滤功能";
        bool do_getisworker = false;
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
        //返回html table格式的内容字符串
        public string get(string name, string id)
        {
            MysqlTOOLS mt = new MysqlTOOLS();
            string sql1 = 
                "SELECT citizen_name,citizen_gender, \n" +
                "\tuser_phone,user_avtarlink,user_email,user_note,\n" +
                "\t xiaoqu_name,buliding,unit,room,area_name,area_city,area_province,citizen.citizenID\n" +
                "FROM `user` , citizen , link  ,xiaoqu,area\n" +
                "WHERE link.citizenid = user_citizenID \n" +
                "and xiaoqu_area_id=areaID\n"+
                "AND  user_citizenID = citizen.citizenID AND link.xiaoquid = xiaoqu.xiaoquID " +
                 $"and citizen.citizenID like '{id}%'\n" +
                $"and citizen_name like '%{name}%'";
            var rdr = mt.sqlToReader(sql1);
            while (rdr.Read())
            {
                var dumdum = new citizen();
                dumdum.name = rdr[0].ToString();
                dumdum.gender = rdr[1].ToString();
                dumdum.phone = rdr[2].ToString();
                dumdum.avtarlink = rdr[3].ToString();
                dumdum.email = rdr[4].ToString();
                dumdum.note = rdr[5].ToString();
                dumdum.livIn.xiaoquname = rdr[6].ToString();
                dumdum.livIn.building = rdr[7].ToString();
                dumdum.livIn.unit = rdr[8].ToString();
                dumdum.livIn.room = rdr[9].ToString();
                dumdum.livarea.name = rdr[10].ToString();
                dumdum.livarea.city = rdr[11].ToString();
                dumdum.livarea.province = rdr[12].ToString();
                dumdum.citizenid = rdr[13].ToString();

                // 下面信息的计算和获取需要上述信息先存在
                dumdum.age = getAgeById(dumdum.citizenid);
                if (do_getisworker)
                {
                    dumdum.isworker = getIsworker(dumdum.citizenid);
                }

                ctznlist.AddLast(dumdum);
            }
            rdr.Close();
            mt.closeconnection();

            string contentstr = "";
            foreach (var item in ctznlist)
            {
                string addstr =
                "                    <tr data-toggle=\"collapse\" data-target=\"#_"+ item.citizenid + "\">\n" +
                $"                        <td>{item.name}</td>\n" +
                $"                        <td>{item.gender}</td>\n" +
                $"                        <td>{item.citizenid}</td>\n" +
                "                    </tr>\n" +
                "                    <tr>\n" +
                "                        <td class=\"table-active\" colspan=\"3\" style=\"padding:0; border: none;\">\n" +
                $"                            <div id=\"_{item.citizenid}\" class=\"collapse\">\n" +
                "                                <div class=\"row\">\n" +
                "                                    <div class=\"col-3\">\n" +
                "                                        <img style=\"border: 5px solid whitesmoke;\n" +
                "                                        margin-left: 9px;\n" +
                "                                        height: 185px;\n" +
                $"                                        box-shadow: 0 0 3px #000000ab;\" src=\"{item.avtarlink}\" alt=\"照片\">\n" +
                "                                    </div>\n" +
                "                                    <div class=\"col-9\">\n" +
                "                                        <table class=\" bg-light ml-auto\">\n" +
                "                                            <tr>\n" +
                $"                                                <td>居住区域</td>\n" +
                $"                                                <td>{item.livarea.province}省 {item.livarea.city}市 {item.livarea.name}</td>\n" +
                $"                                                <td>年龄</td>\n" +
                $"                                                <td>{item.age}</td>\n" +
                "                                            </tr>\n" +
                "                                            <tr>\n" +
                $"                                                <td>具体住址</td>\n" +
                $"                                                <td>{item.livIn.xiaoquname} {item.livIn.building}号楼 {item.livIn.room}室 </td>\n" +
                $"                                                <td>手机</td>\n" +
                $"                                                <td>{item.phone}</td>\n" +
                "                                            </tr>\n" +
                "                                            <tr>\n" +
                "                                                <td>工作人员</td>\n" +
                $"                                                <td>{item.isworker}</td>\n" +
                "                                                <td rowspan=\"2\">备注</td>\n" +
                $"                                                <td rowspan=\"2\">{item.note}</td>\n" +
                "                                            </tr>\n" +
                "                                            <tr>\n" +
                "                                                <td>email</td>\n" +
                $"                                                <td>{item.email}</td>\n" +
                "                                            </tr>\n" +
                "                                        </table>\n" +
                "                                    </div>\n" +
                "                                </div>\n" +
                "                            </div>\n" +
                "                        </td>\n" +
                "                    </tr>";


                contentstr += addstr;
            }
          
            return contentstr;

        }
        // 新建sql链接查看是否为worker
        public bool getIsworker(string citizenid)
        {
            var mt = new MysqlTOOLS();
            string sql =
                "SELECT * FROM `user`,worker\n" +
                "WHERE `user`.user_citizenID = worker.worker_citizenid\n" +
                $"and worker_citizenid = '{citizenid}'\n";
            bool ans = mt.sqlToBoolhave(sql);
            mt.closeconnection();
            return ans;
        }
        //计算年龄,通过身份证
        public int getAgeById(string id)
        {
            string s = id.Substring(6, 4);
            int now = DateTime.Now.Year;
            int me = Convert.ToInt32(s);

            return (now - me);
        }

        //过滤按钮,调用get函数
        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = TextBox1.Text;
            string id = TextBox2.Text;
            do_getisworker = CheckBox1.Checked;
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