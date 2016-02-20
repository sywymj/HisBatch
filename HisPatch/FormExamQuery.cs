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
    public partial class FormExamQuery : Form
    {
        public FormExamQuery()
        {
            InitializeComponent();
        }

        DateTimePicker dp1 = null;
        DateTimePicker dp2 = null;

        public string QueryHr { get; set; }
        private void FormExamQuery_Load(object sender, EventArgs e)
        {
            dp1 = new DateTimePicker();
            dp2 = new DateTimePicker();
            dp1.Width = 125;
            dp2.Width = 125;

            this.toolStrip1.Items.Insert(this.toolStrip1.Items.IndexOf(this.toolStripLabel1) + 1, new ToolStripControlHost(dp1));
            this.toolStrip1.Items.Insert(this.toolStrip1.Items.IndexOf(this.toolStripLabel2) + 1, new ToolStripControlHost(dp2));
        }

        private void toolStripButtonQuery_Click(object sender, EventArgs e)
        {

            DateTime dtBegin = DateTime.Parse(dp1.Value.ToShortDateString());
            DateTime dtFinish = DateTime.Parse(dp2.Value.AddDays(1).ToShortDateString());
            string QueryKey=this.toolStripTextBoxQueryName.Text;
            try
            {
                using (DataClassExamDataContext db = new DataClassExamDataContext(GSetting.connStr))
                {
                    var regInfos = (from _p in db.PersonReg
                                    where _p.IsFail == 0 && _p.RegDate >= dtBegin && _p.RegDate <= dtFinish && (_p.PersonName.Contains(QueryKey) || QueryKey == string.Empty || _p.T3.Contains(QueryKey))
                                    orderby _p.RegDate descending 
                                    select new CQueryRegInfo()
                                    {
                                        regID=_p.ID.ToString(),
                                        regDate=_p.RegDate.Value,
                                        regName=_p.PersonName,
                                        sex=_p.Sex,
                                        psn=_p.PSN,
                                        signSerail=_p.T2,
                                        regOperator=_p.RegOperName,
                                        job=_p.T3,
                                        sel=false
                                    } 
                                      );
                    
                    this.dataGridViewOutline.DataSource = regInfos.ToList();
                    this.dataGridViewOutline.Columns["regID"].Visible = false;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewOutline_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.QueryHr=this.dataGridViewOutline.SelectedRows[0].Cells["regID"].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void dataGridViewOutline_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            int selcount = 0;
            foreach (DataGridViewRow gr in this.dataGridViewOutline.Rows)
            {
                if ((bool)gr.Cells["sel"].EditedFormattedValue)
                {
                    selcount++;
                }

            }
            this.toolStripStatusLabelSelCount.Text = string.Format(@"已选择【{0}】条记录", selcount);
        }

        private void toolStripButtonBatchSign_Click(object sender, EventArgs e)
        {
            string msg = string.Empty;
            try
            {
                List<CExamPerson> lsExamPerson = new List<CExamPerson>();
                List<CQueryRegInfo> lsQrinfo = (List<CQueryRegInfo>)this.dataGridViewOutline.DataSource;

                var a = from _p in lsQrinfo where _p.sel select _p.regID;
                if (a.Count()<=0)
                {
                    return;
                }
                //lsExamPerson = (from _p in a select _a => FormPersonInforEdit.PID2ExamPerson(new Guid(_a))).ToList();
               lsExamPerson=a.Select(__a => FormPersonInforEdit.PID2ExamPerson(new Guid(__a))).ToList();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

       
        
    }

    public class CQueryRegInfo
    {
        //[Browsable(false)]
        public string regID { get; set; }
        [DisplayName("登记时间")]
        public DateTime regDate { get; set; }
        [DisplayName("姓名")]
        public string regName { get; set; }
        [DisplayName("性别")]
        public string sex { get; set; }
        [DisplayName("身份证号")]
        public string psn { get; set; }
        [DisplayName("合格证号")]
        public string signSerail { get; set; }
        [DisplayName("登记人员")]
        public string regOperator { get; set; }
        [DisplayName("工作单位")]
        public string job { get; set; }
        [DisplayName("选择")]
        public bool sel { get; set; }
    }
}
