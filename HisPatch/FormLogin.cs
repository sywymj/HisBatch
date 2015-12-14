using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HisPatch
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }


        DataUtil.IDbHelper dbHelper = null;
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        private string Decry(string encryStr)
        {
            StringBuilder sb = new StringBuilder();
            int iSi = 0xa;
            try
            {
                for (int i = 0; i < encryStr.Length / 2; i++)
                {
                    int ival = Convert.ToInt32(encryStr.Substring(i * 2, 2), 16);

                    int dVal = (int)(0xff & (ival ^ (iSi >> 8)));
                    sb.Append((char)dVal);

                    iSi = (int)(((ival + iSi) * 0xb + 0xc) & 0xffff);
                }
                string dStr = sb.ToString();
                sb = new StringBuilder();
                sb.Append(dStr.Substring(0x15 - 1, 1));
                sb.Append(dStr.Substring(0x20 - 1, 1));
                sb.Append(dStr.Substring(0x25 - 1, 1));
                sb.Append(dStr.Substring(0x2a - 1, dStr.Length - 0x35));


            }
            catch (System.Exception)
            {
            }
            return sb.ToString();
        }

        public string gAccount = string.Empty;
        public string gUserName = string.Empty;

        private void buttonLoggin_Click(object sender, EventArgs e)
        {
            string account = this.textBoxAccount.Text.Trim();
            string password = this.textBoxPassword.Text.Trim();
            string userName = string.Empty;

            string cmdStr = string.Empty;
            try
            {
                cmdStr = string.Format(@"select * from zg where (zgxm=@incode or pym=@incode) and sfjy=0");
                DataTable dtUsers=dbHelper.GetDataTable(cmdStr,new SqlParameter[]{new SqlParameter("incode",account)});
                //DataTable dtUsers = null;
                if (dtUsers==null || dtUsers.Rows.Count<=0)
                {
                    throw new Exception("not find user");
                }
                if (Decry(dtUsers.Rows[0]["MM"].ToString())!=password)
                {
                    throw new Exception("password error");
                }

                gAccount = dtUsers.Rows[0]["zgdm"].ToString();
                gUserName = dtUsers.Rows[0]["zgxm"].ToString();

                GSetting.OperatorID = Convert.ToInt32(gAccount);
                GSetting.OperatorName = gUserName;

                this.DialogResult = DialogResult.OK;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("用户名或者密码错误！");
            }

        }

        private void textBoxAccount_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void textBoxPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            dbHelper = new DataUtil.SqlServerHelper(BatchProvideDrugForm.hisConnStr);
        }
    }
}
