using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace xingtong_netframe472.moudle
{
    public class xiaoqu_item
    {
        public xiaoqu_item()
        {
            this.area = new area();
        }

        public area area { get; set; }
        public string name { get; set; }
         
        public string id { get; set; }
    }
}