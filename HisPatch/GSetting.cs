using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace HisPatch
{
    public static class GSetting
    {
        public static Image Avatar { get; set; }
        public static int OperatorID { get; set; }
        public static string OperatorName { get; set; }
        internal static string connStr = "server=.;database=examination;uid=cbsoft;pwd=cbsoft.cbhis";
    }
}
