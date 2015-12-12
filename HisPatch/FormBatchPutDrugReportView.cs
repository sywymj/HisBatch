using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Spire.DocViewer.Forms;
using Spire.Doc.Documents;
using Spire.Doc;
using Spire.Doc.Fields;



namespace HisPatch
{
    public partial class FormBatchPutDrugReportView : Form
    {
        public FormBatchPutDrugReportView()
        {
            InitializeComponent();
        }


        private string hjdhs = string.Empty;
        public string RID = string.Empty;
        private DataTable dtFairItems = null;

        public Document GetDocByDrugPutRID(string recordId)
        {
            Document wordDoc= new Document();
            DataUtil.IDbHelper dbHelper = null;
            try
            {

                dbHelper = new DataUtil.SqlServerHelper(BatchProvideDrugForm.hisConnStr);
                string cmdStr = string.Empty;
                cmdStr = string.Format(@"select a.id,a.putdate,c.bmmc,d.zgxm,b.hjdh from wybatchputdrugrecord a join wybatchputdruglink b on a.id=b.putdrugrecordid left join bm c on a.departid=c.bmdm left join zg d on a.operatorid=d.zgdm where a.id='{0}'",recordId);
                DataTable dtHjdhs = dbHelper.GetDataTable(cmdStr);
                hjdhs=string.Join(",",(from x in dtHjdhs.AsEnumerable() select x.Field<int>("hjdh").ToString()).ToArray()) ;
                
                
                cmdStr=string.Format(@"exec 药房_处方药品汇总清单  '{0}'", hjdhs);
                dtFairItems = dbHelper.GetDataTable(cmdStr);

                //wordDoc.LoadFromFile("drugstore.docx", FileFormat.Docx);
                wordDoc.LoadFromStream(new MemoryStream(Properties.Resources.drugStore),FileFormat.Docx);
                Section sec = wordDoc.Sections[0];

                Table dtHeader = sec.HeadersFooters.Header.Tables[0] as Table;
                dtHeader.Rows[1].Cells[0].Paragraphs[0].AppendText(dtHjdhs.Rows[0]["putdate"].ToString());
                dtHeader.Rows[1].Cells[2].Paragraphs[0].AppendText("打印时间："+dbHelper.ExecuteScalar("select getdate()").ToString());
                dtHeader.Rows[2].Cells[0].Paragraphs[0].AppendText(dtHjdhs.Rows[0]["id"].ToString());
                dtHeader.Rows[2].Cells[1].Paragraphs[0].AppendText(dtHjdhs.Rows[0]["bmmc"].ToString());

                decimal fairSum = 0;

                Table dtBody = sec.Tables[0] as Table;
                TableRow _workRow = dtBody.Rows[0];
                _workRow.IsHeader = true;
               
                _workRow = dtBody.Rows[1];
                dtBody.Rows.Remove(_workRow);
                foreach (DataRow _item in dtFairItems.Rows)
                {
                    fairSum += (decimal)_item["zje"];
                    dtBody.Rows.Insert(1, _workRow);
                    //_workRow.RowFormat.Paddings.All = 2;
                    _workRow.Cells[0].CellFormat.VerticalAlignment = VerticalAlignment.Middle;
                    _workRow.Cells[0].Paragraphs[0].Text = _item["ypmc"].ToString();

                    _workRow.Cells[1].CellFormat.VerticalAlignment = VerticalAlignment.Middle;
                    _workRow.Cells[1].Paragraphs[0].Text = _item["ypggmc"].ToString();

                    _workRow.Cells[2].CellFormat.VerticalAlignment = VerticalAlignment.Middle;
                    _workRow.Cells[2].Paragraphs[0].Text = _item["ypjxmc"].ToString();

                    _workRow.Cells[3].CellFormat.VerticalAlignment = VerticalAlignment.Middle;
                    _workRow.Cells[3].Paragraphs[0].Text = _item["ypdwmc"].ToString();

                    //_workRow.Cells[4].CellFormat.VerticalAlignment = VerticalAlignment.Middle;
                    _workRow.Cells[4].Paragraphs[0].Text = ((decimal)_item["sl"]).ToString("F1");

                    _workRow.Cells[5].CellFormat.VerticalAlignment = VerticalAlignment.Middle;
                    _workRow.Cells[5].Paragraphs[0].Text = ((decimal)_item["zje"]).ToString("F2");

                    //_workRow.Cells[6].CellFormat.VerticalAlignment = VerticalAlignment.Middle;
                    _workRow.Cells[6].Paragraphs[0].Text =string.Empty;

                    //_workRow.Cells[7].CellFormat.VerticalAlignment = VerticalAlignment.Middle;
                    _workRow.Cells[7].Paragraphs[0].Text =string.Empty;
                    _workRow = _workRow.Clone();
                }

                dtBody.Rows[dtBody.Rows.Count - 2].Cells[5].Paragraphs[0].AppendText(fairSum.ToString("F2"));


            }
            catch (System.Exception ex)
            {
                wordDoc = null;
                Console.WriteLine(ex.Message);
            }
            return wordDoc;
        }

        DocViewer dv = null;
        
        private void FormBatchPutDrugReportView_Load(object sender, EventArgs e)
        {

            Document wordDoc = null;
            dv = new DocViewer();
            dv.Dock = DockStyle.Fill;
            dv.IsToolBarVisible = false;

            //RID = "e2149a0e004c4a98aaf9bec017710fd6";
            //RID = "92bde21aa95c470e86a30f91ef9d712c";
            this.Controls.Add(dv);

            try
            {
                //wordDoc = GetDocByDrugPutRID(RID);
                wordDoc = new Document("health.docx");
                //wordDoc.LoadFromFile();

                MemoryStream ms = new MemoryStream();
                wordDoc.SaveToStream(ms, FileFormat.Docx);
                //wordDoc.SaveToFile("t1.docx", FileFormat.Docx);
                //dv.LoadFromFile("t1.docx");
                dv.LoadFromStream(ms, FileFormat.Docx);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        private void toolStripButtonPrint_Click(object sender, EventArgs e)
        {
            try
            {
                dv.Print();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void FormBatchPutDrugReportView_FormClosing(object sender, FormClosingEventArgs e)
        {
            dv.CloseDocument();
            dv.Dispose();
        }
    }
}
