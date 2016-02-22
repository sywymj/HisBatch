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
                    var query = from _p in db.TJ_TJDJB where _p.DJRQ>=this.dateTimePickerBegin.Value && _p.DJRQ<=this.dateTimePickerFinish.Value select _p;
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

                    this.dataGridViewOutline.DataSource = query.ToArray();

                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

    public class UIObjTjData
    {
        public bool sel { get; set; }
        public string djlsh { get; set; }
        public string name { get; set; }
        public string sex { get; set; }
        public string age { get; set; }
        public DateTime? tjDate { get; set; }
        public string job { get; set; }
        public string djh { get; set; }
        public int tjcs { get; set; }
        public string psn { get; set; }
    }
}
