using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace xingtong_netframe472.moudle
{
    public class citizen
    {
        public string name { get; set; }
        public string gender { get; set; }
        public string citizenid { get; set; }
        public string email { get; set; }
        //area 生活地区 如黑龙江省 大庆市 萨尔图区
        public area livarea { get; set; }
        //livingIn 具体小区名字 单元 房间号
        public livingIn livIn { get; set; }

        public string phone { get; set; }
        public string avtarlink { get; set; }
        public string note { get; set; }
        public bool isworker { get; set; }

        
    }
}