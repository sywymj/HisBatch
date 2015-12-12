using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HisPatch
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FormMain());

            DataUtil.IDbHelper dbHelper = new DataUtil.SqlServerHelper("server=192.0.2.3;database=tjdata;uid=tjuser;pwd=tjuser");
            CTjReport obj = new CTjReport(dbHelper);
            obj.GetWordDocObjByTjID("00010022","1");


            FormLogin formLogin=new FormLogin();
            if (formLogin.ShowDialog()==DialogResult.OK)
            {
                BatchProvideDrugForm workForm = new BatchProvideDrugForm();
                workForm.operatorCode = formLogin.gAccount;
                workForm.UserName = formLogin.gUserName;
                Application.Run(workForm);
            }

            
            //Application.Run(new FormBatchPutDrugReportView());
        }
    }
}
