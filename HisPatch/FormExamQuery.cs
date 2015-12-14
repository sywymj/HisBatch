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
                                    where _p.IsFail == 0 && _p.RegDate >= dtBegin && _p.RegDate <= dtFinish && (_p.PersonName.Contains(QueryKey) || QueryKey == string.Empty)
                                    select new CQueryRegInfo()
                                    {
                                        regID=_p.ID.ToString(),
                                        regDate=_p.RegDate.Value,
                                        regName=_p.PersonName,
                                        sex=_p.Sex,
                                        psn=_p.PSN,
                                        signSerail=_p.T2,
                                        regOperator=_p.RegOperName
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

    }
}
