using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HisPatch
{
    public partial class FormDrugPutRecordQuery : Form
    {
        public FormDrugPutRecordQuery()
        {
            InitializeComponent();
        }


        DateTimePicker dp1 = null;
        DateTimePicker dp2 = null;
        ComboBox comboxDepart = null;
        public DataTable gDtDepart = null;

        DataUtil.IDbHelper dbHelper = null;
        private void FormDrugPutRecordQuery_Load(object sender, EventArgs e)
        {
            dp1 = new DateTimePicker();
            dp2 = new DateTimePicker();
            dp1.Width = 125;
            dp2.Width = 125;

            this.toolStrip1.Items.Insert(this.toolStrip1.Items.IndexOf(this.toolStripLabel1)+1, new ToolStripControlHost(dp1));
            this.toolStrip1.Items.Insert(this.toolStrip1.Items.IndexOf(this.toolStripLabel2) + 1, new ToolStripControlHost(dp2));

            gDtDepart.Rows.Add(new object[] { 0, "全部科室", "all" });

            comboxDepart = new ComboBox();
            comboxDepart.DropDownStyle = ComboBoxStyle.DropDownList;
            comboxDepart.DataSource = gDtDepart;
            comboxDepart.DisplayMember = "bmmc";
            comboxDepart.ValueMember = "bmdm";
            this.toolStrip1.Items.Insert(this.toolStrip1.Items.IndexOf(this.toolStripLabel3) + 1, new ToolStripControlHost(comboxDepart));
            comboxDepart.SelectedIndex = 0;
            
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
                flexGrid.Columns[flexGrid.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //flexGrid.Cols["check"].AllowEditing = true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }



        }

        string[] capRecords = new string[] {"发药时间","开单科室","发药单金额","司药","发药单编号" };
        private void toolStripButtonQuery_Click(object sender, EventArgs e)
        {
            dbHelper = new DataUtil.SqlServerHelper(BatchProvideDrugForm.hisConnStr);
            string cmdStr = string.Empty;
            try
            {
                cmdStr = string.Format(@"select a.putdate,c.bmmc,a.fairsum,d.zgxm,a.id from wybatchputdrugrecord a left join bm c on a.departid=c.bmdm left join zg d on a.operatorid=d.zgdm where a.putdate>='{0}' and a.putdate<='{1}' and (c.bmdm={2} or 0={2})  and fairsum>0 order by putdate,bmmc",
                    dp1.Value.ToString("yyyy-MM-dd 00:00:00"),
                    dp2.Value.ToString("yyyy-MM-dd 23:59:59"),
                    this.comboxDepart.SelectedValue
                    );
                DataTable dt = dbHelper.GetDataTable(cmdStr);
                //this.dataGridViewOutline.DataSource = dt;
                gridBind(this.dataGridViewOutline, dt, capRecords);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (this.dataGridViewOutline.SelectedRows==null || this.dataGridViewOutline.SelectedRows.Count<=0)
            {
                return;
            }
            FormBatchPutDrugReportView fpv = new FormBatchPutDrugReportView();
            fpv.RID = this.dataGridViewOutline.SelectedRows[0].Cells["id"].Value.ToString();
            fpv.ShowDialog();
            fpv.Dispose();
        }
    }
}
