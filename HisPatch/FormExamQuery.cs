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
            this.dataGridViewOutline.EndEdit();
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
                if (MessageBox.Show(string.Format("您确定要批签发【{0}】人的合格证吗？",a.Count()), "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
                {
                    return;
                }

                //lsExamPerson = (from _p in a select _a => FormPersonInforEdit.PID2ExamPerson(new Guid(_a))).ToList();
               lsExamPerson=a.Select(__a => FormPersonInforEdit.PID2ExamPerson(new Guid(__a))).ToList();
                foreach (CExamPerson _item in lsExamPerson)
                {
                    if (Printer.SingCertifyPrint.QualifiedSign(_item))
                    {
                        msg += string.Format("√{0}签发成功\r\n", _item.Name);
                    } 
                    else
                    {
                        msg += string.Format("×××{0}签发失败！！！！\r\n", _item.Name);
                    }
                        
                    
                }
                MessageBox.Show(msg);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void toolStripButtonBatchPrint_Click(object sender, EventArgs e)
        {
            this.dataGridViewOutline.EndEdit();
            string msg = string.Empty;
            try
            {
                List<CExamPerson> lsExamPerson = new List<CExamPerson>();
                List<CQueryRegInfo> lsQrinfo = (List<CQueryRegInfo>)this.dataGridViewOutline.DataSource;

                var a = from _p in lsQrinfo where _p.sel && !string.IsNullOrEmpty(_p.signSerail) select _p.regID;
                if (a.Count() <= 0)
                {
                    return;
                }
               

                if (MessageBox.Show(string.Format("您确定要打印【{0}】人的合格证吗？", a.Count()), "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
                {
                    return;
                }

                //lsExamPerson = (from _p in a select _a => FormPersonInforEdit.PID2ExamPerson(new Guid(_a))).ToList();
                lsExamPerson = a.Select(__a => FormPersonInforEdit.PID2ExamPerson(new Guid(__a))).ToList();

                Printer.SingCertifyPrint prnObj = new Printer.SingCertifyPrint(GSetting.PaperSizeA4Offset);
                prnObj.DrawManyInA4(lsExamPerson, GSetting.PaperSizeA4PrinterName, true, false);

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewOutline_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            
        }

        private void toolStripButtonBatchBack_Click(object sender, EventArgs e)
        {
            string printCount="1";
            if (Umaaz.User.InputBox.Show("提示","请输入打印张数","1",out printCount)!=DialogResult.OK)
            {
                return;
            }
            int _prnCount = 0;
            if (!int.TryParse(printCount,out _prnCount))
            {
                return;
            }
            Printer.SingCertifyPrint printObj = new Printer.SingCertifyPrint(GSetting.PaperSizeA4Offset);
            List<CExamPerson> lsEp = new List<CExamPerson>();
            for (int i = 0; i < _prnCount;i++ )
            {
                lsEp.Add(new CExamPerson());
            }
            printObj.DrawManyInA4(lsEp, GSetting.PaperSizeA4PrinterName, true, true);

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
