using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace xingtong_netframe472
{
    public static class toast
    {
        public static string title = "";
        public static string content = "";

        public static void clear()
        {
            title = "";
            content = "";
        }
    }
}