using Microsoft.Reporting.WinForms;
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
    public partial class FrmTjQuery : Form
    {
        public FrmTjQuery()
        {
            InitializeComponent();
        }

        
        private void FrmTjQuery_Load(object sender, EventArgs e)
        {
            try
            {
                

                using (DataClassesTjDataContext db = new DataClassesTjDataContext(GSetting.TjconnStr))
                {
                    var hydws = (from _p in db.HYDWDMB where (_p.QYBZ ?? 'e') == '1' select new { dwbh = _p.BH, dwmc = _p.MC }).ToList();
                    this.comboBoxTjDW.DataSource = hydws;
                    this.comboBoxTjDW.DisplayMember = "dwmc";
                    this.comboBoxTjDW.ValueMember = "dwbh";
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        
        private void toolStripButtonQuery_Click(object sender, EventArgs e)
        {
            try
            {
                using (DataClassesTjDataContext db = new DataClassesTjDataContext(GSetting.TjconnStr))
                {
                    var query = from _p in db.TJ_TJDJB where _p.DJRQ>=this.dateTimePickerBegin.Value && _p.DJRQ<=this.dateTimePickerFinish.Value  && _p.SUMOVER=='1' select _p;
                    if (this.comboBoxTjDW.SelectedIndex>=0)
                    {
                        query=from _p in query where _p.DWBH==this.comboBoxTjDW.SelectedValue.ToString() select _p;
                    }
                    if (!string.IsNullOrEmpty(this.textBoxLsh.Text.Trim()))
                    {
                        query = from _p in query where _p.DJLSH == this.textBoxLsh.Text.Trim() select _p;
                    }
                    if (!string.IsNullOrEmpty(this.textBoxName.Text.Trim()))
                    {
                        query = from _p in query where _p.XM.ToLower().Contains(this.textBoxName.Text.Trim().ToLower()) select _p;
                    }

                    this.dataGridViewOutline.DataSource = (from _p in query
                                                           select new UIObjTjData()
                                                           {
                                                               sel=false,
                                                               djlsh=_p.DJLSH,
                                                               name=_p.XM,
                                                               sex=(_p.XB??' ')=='1'?"男":(_p.XB??' ')=='0'?"女":string.Empty,
                                                               age=_p.NL.ToString(),
                                                               tjDate=_p.DJRQ,
                                                               job=_p.HYDWDMB.MC,
                                                               djh=_p.TJBH,
                                                               tjcs=_p.TJCS,
                                                               psn=_p.SFZH,
                                                               tj_zs=_p.ZS,
                                                               tj_jy=_p.JY

                                                           }).ToArray();

                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridViewOutline_SelectionChanged(object sender, EventArgs e)
        {
            Console.WriteLine(this.dataGridViewOutline.SelectedRows.Count.ToString());
            foreach (DataGridViewRow grRow in this.dataGridViewOutline.Rows)
            {
                if (grRow.Selected)
                {
                    grRow.Cells["sel"].Value = true;
                } 
                else
                {
                    grRow.Cells["sel"].Value = false;
                }
            }
            
        }

        private void toolStripButtonPrnZjjl_Click(object sender, EventArgs e)
        {
            if (this.dataGridViewOutline.DataSource==null)
            {
                return;
            }

            var _rsObjs=(from _p in ((UIObjTjData[])this.dataGridViewOutline.DataSource) where _p.sel select _p);
            if (_rsObjs==null)
            {
                return;
            }

            Form prnForm = new Form();
            prnForm.WindowState = FormWindowState.Maximized;
            ReportViewer reportView = new ReportViewer();

            reportView.ProcessingMode = ProcessingMode.Local;
            reportView.LocalReport.ReportEmbeddedResource = "HisPatch.ReportTjZjjl.rdlc";
            //reportView.LocalReport.ReportPath = "ReportTjZjjl.rdlc";
            //reportView.LocalReport.SetParameters(new ReportParameter("paramAddtionMsg", "r"));
            

            reportView.Dock = DockStyle.Fill;
            prnForm.Controls.Add(reportView);
            reportView.SetDisplayMode(DisplayMode.PrintLayout);
            reportView.ZoomMode = ZoomMode.Percent;
            reportView.ZoomPercent = 100;
            reportView.LocalReport.DataSources.Add(new ReportDataSource("DsTjData",_rsObjs.ToList()));

            reportView.LocalReport.SetParameters(new ReportParameter("paraFootMsg", HisPatch.Properties.Settings.Default.ReportZjFootMsg));

            reportView.RefreshReport();
            
            prnForm.ShowDialog();
            prnForm.Close();
            prnForm.Dispose();

        }

        private void FrmTjQuery_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //prnForm.Close();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }

    public class UIObjTjData
    {
        [DisplayName("选择")]
        public bool sel { get; set; }
        [DisplayName("登记流水号")]
        public string djlsh { get; set; }
        [DisplayName("姓名")]
        public string name { get; set; }
        [DisplayName("性别")]
        public string sex { get; set; }
        [DisplayName("年龄")]
        public string age { get; set; }
        [DisplayName("总检时间")]
        public DateTime? tjDate { get; set; }
        [DisplayName("所在单位")]
        public string job { get; set; }
        [DisplayName("档案号")]
        public string djh { get; set; }
        [DisplayName("体检次数")]
        public int tjcs { get; set; }
        [DisplayName("身份证号")]
        public string psn { get; set; }

        [Browsable(false)]
        public string tj_zs { get; set; }
        [Browsable(false)]
        public string tj_jy { get; set; }
    }
}
