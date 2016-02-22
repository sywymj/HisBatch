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
        //internal static string connStr = "server=192.0.2.3;database=examination;uid=cbsoft;pwd=cbsoft.cbhis";


        internal static string TjconnStr = "server=.;database=TjData;uid=sa;pwd=11003";
        internal static string connStr = "server=.;database=examination;uid=sa;pwd=11003";
        

        public static PointF PaperSize6InOffset = new PointF(0, 0);
        public static string PaperSize6InPrinterName = string.Empty;
        public static PointF PaperSizeA4Offset = new PointF(0, 0);
        public static string PaperSizeA4PrinterName = string.Empty;
        public static string PrinterHighQualityResultionName = string.Empty;
    }
}
