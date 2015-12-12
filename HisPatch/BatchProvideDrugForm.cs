using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataUtil;

namespace HisPatch
{
    public partial class BatchProvideDrugForm : Form
    {
        public BatchProvideDrugForm()
        {
            InitializeComponent();
        }

        public static string hisConnStr = string.Format(@"server=192.0.2.252;database=cbhis;uid=cbsoft;pwd=cbsoft.cbhis");
        IDbHelper hisDbhelper = null;
        string drugStoreCode = "57";
        public string operatorCode = "74";
        public string UserName = string.Empty;
        string curSelDepID = string.Empty;

        string[] capOutLine = new string[] {"划价单号","记账单号","住院号","患者姓名","","金额" };
        string[] capDetail = new string[] { "药品名称", "规格", "剂型", "单位", "数量", "金额", "厂家" };

        public static DialogResult wyMessagebox(string msg, int msgType)
        {
            DialogResult dr = DialogResult.None;
            switch (msgType)
            {
                //提示信息
                case 0:
                    {
                        dr=MessageBox.Show(msg, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                //错误信息
                case 1:
                    {
                       dr=MessageBox.Show(msg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                default:
                    {
                        dr=MessageBox.Show(msg);
                        break;
                    }
            }
            return dr;
        }

        DataTable gDtDepart = null;
        private void BatchProvideDrugForm_Load(object sender, EventArgs e)
        {
            string cmdStr = string.Empty;
            try
            {
                hisDbhelper = new SqlServerHelper(hisConnStr);
                cmdStr = @"select bmdm,bmmc,pym from bm where kslbdm=2 and sfky=1";
                DataTable dt = hisDbhelper.GetDataTable(cmdStr);
                gDtDepart = dt;
                this.comboBoxDepart.DataSource = dt;
                this.comboBoxDepart.DisplayMember = "bmmc";
                this.comboBoxDepart.ValueMember = "bmdm";

                this.toolStripStatusLabel1.Text = string.Format(@"当前登录用户：{0}", this.UserName);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void toolStripButtonQueryValidHjdByDepart_Click(object sender, EventArgs e)
        {
            if (this.comboBoxDepart.SelectedIndex<0)
            {
                return;
            }
            


            string departID = this.comboBoxDepart.SelectedValue.ToString();
            curSelDepID = departID;
            string cmdStr = string.Format(@"EXEC SP_药品管理_取未发药处方_批量 57,{0},1",departID);
            try
            {
                DataTable dt = hisDbhelper.GetDataTable(cmdStr);
                //this.dataGridViewOutline.DataSource = dt;
                gridBind(this.dataGridViewOutline, dt, capOutLine);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        private void dataGridViewOutline_SelectionChanged(object sender, EventArgs e)
        {
            
            System.Text.StringBuilder sb = new StringBuilder();
            sb.Append("exec 药房_处方药品汇总清单 '");
            try
            {
                foreach (DataGridViewRow dgRow in ((DataGridView)sender).SelectedRows)
                {
                    sb.Append(dgRow.Cells["hjdh"].Value.ToString());
                    sb.Append(",");
                }
               if (sb.ToString().EndsWith(","))
               {
                   sb.Remove(sb.Length - 1, 1);
               }
                sb.Append("'");
                DataTable dt = hisDbhelper.GetDataTable(sb.ToString());
                //this.dataGridViewDetail.DataSource = dt;
                gridBind(this.dataGridViewDetail, dt, capDetail);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        delegate void delegateGridBind(DataGridView flexGrid, DataTable dt, string[] captionArray);
        void gridBind(DataGridView flexGrid, DataTable dt, string[] captionArray)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new delegateGridBind(gridBind), new object[] { flexGrid, dt, captionArray });
                return;
            }

            try
            {
                flexGrid.DataSource = dt.DefaultView;
                for (int i = 0; i < captionArray.Length; i++)
                {
                    if (string.IsNullOrEmpty(captionArray[i]))
                    {
                        flexGrid.Columns[i].Visible = false;
                    }
                    else
                    {
                        flexGrid.Columns[i].HeaderText = captionArray[i];
                    }

                }
                flexGrid.AutoResizeColumns();
                flexGrid.Columns[flexGrid.Columns.Count-1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //flexGrid.Cols["check"].AllowEditing = true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }



        }
        private void toolStripButtonBatchPut_Click(object sender, EventArgs e)
        {
            if (this.dataGridViewOutline.SelectedRows==null || this.dataGridViewOutline.SelectedRows.Count<=0)
            {
                return;
            }

            if (MessageBox.Show(this,"您确定要批量发药吗？","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question)!=DialogResult.Yes)
            {
                return;
            }
            //List<string> lsHjdh = new List<string>();
            string cmdStr = string.Empty;
            DateTime curDate=DateTime.Now;
            try
            {
                cmdStr=@"select getdate()";
                curDate=(DateTime)hisDbhelper.ExecuteScalar(cmdStr) ;

                string guid = Guid.NewGuid().ToString("N");
                cmdStr = string.Format(@"insert into wyBatchPutDrugRecord (id,putDate,departId,drugStoreId,fairSum,operatorId) values ('{0}','{1}',{2},{3},0,{4})",
                    guid,
                    curDate,
                    curSelDepID,
                    drugStoreCode,
                    operatorCode
                    );
                int hr = hisDbhelper.ExecuteNonQuery(cmdStr);
                if (hr<=0)
                {
                    throw new Exception("生成批量发药但错误！");
                }


                int putRecipelCount = 0;
                foreach (DataGridViewRow row in this.dataGridViewOutline.SelectedRows)
                {
                    try
                    {
                        hr = 0;
                        string _hjdh = row.Cells["hjdh"].Value.ToString();
                        cmdStr = string.Format(@"SELECT SUM(b.JE*ISNULL(a.FS,1))	FROM HJD   a JOIN    HJDMX b ON   a.HJDH = b.HJDH	WHERE a.RYH IS NOT NULL  AND     a.YFDM={0} AND a.ZT=1 AND     ZF=0 and a.hjdh={1} GROUP BY a.HJDH,a.JZDH,a.RYH,a.BRXM,a.HDR",drugStoreCode,_hjdh);
                        DataTable dtZyhCheck=hisDbhelper.GetDataTable(cmdStr);
                        if (dtZyhCheck==null || dtZyhCheck.Rows.Count<=0)
                        {
                            throw new Exception("hjdh check error!");
                        }

                        hisDbhelper.BeginTransaction();
                        cmdStr = string.Format(@"exec SP_药品划价_计算库存 @hjdh={0}, @zt=2, @ypinfo=''",_hjdh);
                        hisDbhelper.ExecuteNonQuery(cmdStr);
                        cmdStr = string.Format(@"UPDATE HJD SET ZT=2,FYRQ=GetDate(),FYCZY={0} WHERE HJDH={1}",operatorCode,_hjdh);
                        hisDbhelper.ExecuteNonQuery(cmdStr);
                        cmdStr = string.Format(@"update wybatchputdrugrecord set fairsum=fairsum+{0} where id='{1}'", dtZyhCheck.Rows[0][0],guid);
                        hisDbhelper.ExecuteNonQuery(cmdStr);
                        cmdStr = string.Format(@"insert into wybatchputdruglink (putdrugrecordid,hjdh) values('{0}',{1})", guid, _hjdh);
                        hisDbhelper.ExecuteNonQuery(cmdStr);
                        hisDbhelper.Commit();

                        putRecipelCount++;
                    }
                    catch (System.Exception ex)
                    {
                        hisDbhelper.Rollback();
                        Console.WriteLine(ex.Message);
                    }

                    
                }
                if ( MessageBox.Show("发药完成，是否打印当前发药单？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Spire.Doc.Document wordDoc =new FormBatchPutDrugReportView().GetDocByDrugPutRID(guid);
                    if (wordDoc!=null)
                    {
                        wordDoc.PrintDocument.Print();
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
            this.toolStripButtonQueryValidHjdByDepart.PerformClick();
        }

        private void toolStripButtonPutDrugRecordQuery_Click(object sender, EventArgs e)
        {
            FormDrugPutRecordQuery fdprq = new FormDrugPutRecordQuery();
            fdprq.gDtDepart = gDtDepart.Copy();
            fdprq.ShowDialog();
            fdprq.Dispose();
        }
    }
}
