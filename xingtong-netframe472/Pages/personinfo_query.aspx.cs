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
            string sql1 = 
                "SELECT citizen_name,citizen_gender, \n" +
                "\tuser_phone,user_avtarlink,user_email,user_note,\n" +
                "\t xiaoqu_name,buliding,unit,room,area_name,area_city,area_province\n" +
                "FROM `user` , citizen , link  ,xiaoqu,area\n" +
                "WHERE link.citizenid = user_citizenID \n" +
                "and xiaoqu_area_id=areaID\n"+
                "AND  user_citizenID = citizen.citizenID AND link.xiaoquid = xiaoqu.xiaoquID " +
                 $"WHERE citizenID like '{id}%'\n" +
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

                ctznlist.AddLast(dumdum);
            }
            rdr.Close();
            mt.closeconnection();

            string contentstr = "";
            foreach (var item in ctznlist)
            {
                string addstr =
                    "                    <tr data-toggle=\"collapse\" data-target=\"#___changetoid\">\n" +
                "                        <td>姓名</td>\n" +
                "                        <td>性别</td>\n" +
                "                        <td>身份证</td>\n" +
                "                    </tr>\n" +
                "                    <tr>\n" +
                "                        <td class=\"table-active\" colspan=\"3\" style=\"padding:0; border: none;\">\n" +
                "                            <div id=\"___changetoid\" class=\"collapse\">\n" +
                "                                <div class=\"row\">\n" +
                "                                    <div class=\"col-sm-4\">\n" +
                "                                        <img style=\"border: 5px solid whitesmoke;\n" +
                "                                        margin: 6px 20px;\n" +
                "                                        height: 185px;\n" +
                "                                        box-shadow: 0 0 3px #000000ab;\" src=\"http://img3.imgtn.bdimg.com/it/u=3439706172,2676282241&fm=26&gp=0.jpg\" alt=\"照片\">\n" +
                "                                    </div>\n" +
                "                                    <div class=\"col-sm-8\">\n" +
                "                                        <table class=\" bg-light\">\n" +
                "                                            <tr>\n" +
                "                                                <td>居住区域</td>\n" +
                "                                                <td>黑龙江 大庆 让胡路区</td>\n" +
                "                                                <td>年龄</td>\n" +
                "                                                <td>20</td>\n" +
                "                                            </tr>\n" +
                "                                            <tr>\n" +
                "                                                <td>具体住址</td>\n" +
                "                                                <td>新潮建材城 4-5 601</td>\n" +
                "                                                <td>手机</td>\n" +
                "                                                <td>18816528960</td>\n" +
                "                                            </tr>\n" +
                "                                            <tr>\n" +
                "                                                <td>工作人员</td>\n" +
                "                                                <td>是</td>\n" +
                "                                                <td rowspan=\"2\">备注</td>\n" +
                "                                                <td rowspan=\"2\">阿斯顿发斯蒂芬 asdsad 黑龙江 大庆 让胡路区</td>\n" +
                "                                            </tr>\n" +
                "                                            <tr>\n" +
                "                                                <td>email</td>\n" +
                "                                                <td>kasusaland@gmail.com</td>\n" +
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