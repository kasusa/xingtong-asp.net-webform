using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace xingtong_netframe472.moudle
{
    public class area
    {
        public string name { get; set; }
        public string city { get; set; }
        public string province { get; set; }

        public override string ToString()
        {
            return $"{province}省 {city}市 {name}";
        }
    }
}