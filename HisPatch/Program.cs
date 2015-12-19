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

            //FormPersonInforEdit formPersonEdit = new FormPersonInforEdit();
            //Application.Run(formPersonEdit);



            FormLogin formLogin = new FormLogin();
            if (formLogin.ShowDialog() == DialogResult.OK)
            {
                FormPersonInforEdit formPersonEdit = new FormPersonInforEdit();
                Application.Run(formPersonEdit);
            }

        }
    }
}
