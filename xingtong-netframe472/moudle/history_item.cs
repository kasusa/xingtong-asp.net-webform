using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace xingtong_netframe472.moudle
{
    public class history_item
    {
        public history_item()
        {
            this.area = new area();
        }

        public string citizenid { get; set; }
        public area area { get; set; }
        public string xiaoqu { get; set; }
        public string fangxiang { get; set; }
        public string time { get; set; }
        public bool in_ {get; set;}
        public bool out_ {get; set; }
    }
}