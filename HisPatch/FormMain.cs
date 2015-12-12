using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using Spire.Doc;

namespace HisPatch
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Document doc = new Document();
            doc.LoadFromFile("drugstore.doc", FileFormat.Doc);

            PrintPreviewDialog prDlg = new PrintPreviewDialog();
            prDlg.Document = doc.PrintDocument;
            prDlg.ShowDialog();



        }
    }
}
