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
    public partial class FormPictureTest : Form
    {
        public FormPictureTest()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Printer.SingCertifyPrint obj = new Printer.SingCertifyPrint();
            CExamPerson pinfo = new CExamPerson();
            pinfo.PSN = "420300197612210911";
            pinfo.SignNumber = "4222249282005000001";
            pinfo.Avatar = Image.FromFile("head.jpg");
            pinfo.Name = "王大善";
            pinfo.Sex = "男";
            pinfo.Age = "41";
            pinfo.WorkType = "食品药品生产经营";
            pinfo.SignDate = DateTime.Now;

            //obj.DrawOneCard(pinfo, new Point(10, 10), this.pictureBox1.CreateGraphics());
            //obj.DrawOneCard(pinfo, new Point(105, 10), this.pictureBox1.CreateGraphics());
            //obj.DrawSingeInPhotoPaper6In(pinfo, string.Empty, true,true);
            
            List<CExamPerson> ls = new List<CExamPerson>();
            {
                for (int i = 1; i < 12; i++)
                {
                    pinfo = new CExamPerson();
                    pinfo.PSN = "420300197612210911";
                    pinfo.SignNumber = "4222249282005000001";
                    pinfo.Avatar = Image.FromFile("head.jpg");
                    pinfo.Name = "王大善"+i.ToString();
                    pinfo.Sex = "男";
                    pinfo.Age = i.ToString();
                    pinfo.WorkType = "食品药品生产经营";
                    pinfo.SignDate = DateTime.Now;

                    ls.Add(pinfo);
                }
            }
            obj.DrawManyInA4(ls, string.Empty, true,false);

            


        }
    }
}
