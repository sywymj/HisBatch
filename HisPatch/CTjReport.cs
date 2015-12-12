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
using DataUtil;

namespace HisPatch
{
    public class CTjReport
    {
        IDbHelper DbHelper = null;
        public CTjReport(IDbHelper _dbHelper)
        {
            this.DbHelper = _dbHelper;
        }

        public Document GetWordDocObjByTjID(string tjbh,string tjcs)
        {
            string cmdStr = string.Empty;
           
            try
            {
                cmdStr = string.Format(@"select a.tjbh,a.tjcs,a.djlsh,a.xm,a.xb,nl,b.mc,tjrq,djrq,zs,jy,jcrq,isnull(c.xm,jcys),csnyr from tj_tjdjb a left join hydwdmb b on a.dwbh=b.bh  left join gzry c on a.jcys=c.gkhm where a.tjbh='{0}' and a.tjcs={1}",tjbh,tjcs);
                DataTable dtTjdj = DbHelper.GetDataTable(cmdStr);
                var vTjdj =( from x in dtTjdj.AsEnumerable()
                            select new
                            {
                                tjbh = x.Field<string>("tjbh"),
                                tjcs = x.Field<int>("tjcs"),
                               djlsh = x.Field<string>("djlsh"),
                                sex=x.Field<string>("xb")
                            }).First();

                cmdStr = string.Format(@"SELECT  TJ_TJJLB.LXBH ,
tj_tjlxb.mc as lxmc,
           TJ_TJJLB.TJXMBH ,
	tj_zhxm_hd.mc as zhxmmc,
		     CONVERT(TEXT,TJ_TJJLB.XJ) AS XJ, 
           TJ_TJJLB.JCRQ ,
           TJ_TJJLB.JCYS ,
isnull(gzry.xm,tj_tjjlb.jcys) as jcysxm,
           TJ_TJLXB.XSLX ,
           TJ_TJJLMXB.JG ,
tj_tjjlmxb.sfyx,
           TJ_TJXMB.TJXM ,
           TJ_TJXMB.MC as tjxmmc ,
           TJ_TJXMB.DW ,
           TJ_TJXMB.CKXX ,
           TJ_TJXMB.CKSX ,
           TJ_TJXMB.ZCTS ,
           TJ_TJXMB.PDTS ,
           TJ_TJXMB.PGTS ,
           TJ_TJXMB.DISP_ORDER 
            
        FROM TJ_TJDJB ,
           TJ_TJJLB ,
           TJ_TJJLMXB ,
           TJ_TJXMB ,
           TJ_TJLXB ,
           TJ_ZHXM_HD,
	gzry   
        WHERE ( TJ_TJDJB.TJBH = TJ_TJJLB.TJBH ) and          ( TJ_TJDJB.TJCS = TJ_TJJLB.TJCS ) and          ( TJ_TJJLB.XH = TJ_TJJLMXB.XH ) and          ( TJ_TJJLB.LXBH = TJ_TJLXB.LXBH ) and          ( TJ_TJJLB.LXBH = TJ_TJXMB.LXBH ) and          ( TJ_TJXMB.TJXM = TJ_TJJLMXB.TJXM ) and          ( TJ_TJJLB.TJXMBH = TJ_ZHXM_HD.BH ) and          ( TJ_TJDJB.TJBH = '{0}') and          ( TJ_TJDJB.TJCS = {1}) and          ( TJ_TJXMB.XB in ('{2}',
'%') ) and          ( TJ_TJJLB.ISOVER = '1') and          ( TJ_TJJLB.XMLX = '1') and tj_tjjlb.jcys=gzry.gkhm
	order by tj_tjjlb.lxbh,tjxmbh,tj_tjxmb.disp_order ", tjbh, tjcs, vTjdj.sex);
                DataTable dtTjItems = DbHelper.GetDataTable(cmdStr);

                Document doc = new Document();
                doc.LoadFromFile("tj.docx");
                Section secMx = doc.Sections[0];
                Section secZj = doc.Sections[1];

               
                Table tableMx = secMx.Tables[0] as Table;
                Paragraph pXj = secMx.Paragraphs[0];

                TableRow trLxHeader = tableMx.Rows[0];
                TableRow trZhHeader = tableMx.Rows[1];
                TableRow trXmHeader = tableMx.Rows[2];
                TableRow trXmValue = tableMx.Rows[3];
                TableRow trZhXj = tableMx.Rows[4];
                TableRow trEmpty = tableMx.Rows[5];


                secMx.Tables.Remove(tableMx);
                secMx.Paragraphs.Clear();

                string preLx = string.Empty;
                string preZhxm = string.Empty;
                string preZhXj = string.Empty;

                Table curTable = secMx.AddTable(false);
                int i =0;
                foreach (DataRow _row in dtTjItems.Rows)
                {
                    string curLx = _row["lxmc"].ToString();
                    string curZh = _row["zhxmmc"].ToString();

                    TableRow _workRow = null;

                    if (curLx!=preLx )
                    {
                        preLx = curLx;
                       

                        if (i>0)
                        {
                            _workRow = trZhXj.Clone();
                            _workRow.Cells[1].Paragraphs[0].Text =preZhXj;
                            curTable.Rows.Add(_workRow);
                            curTable.Rows.Add(trEmpty.Clone());
                        }

                        

                        //添加科室header
                        _workRow = trLxHeader.Clone();
                        _workRow.Cells[0].Paragraphs[0].Text = curLx;
                        curTable.Rows.Add(_workRow);
                    }
                    if (curZh!=preZhxm)
                    {
                        preZhxm = curZh;

                        _workRow = trZhHeader.Clone();
                        _workRow.Cells[0].Paragraphs[0].Text = curZh;
                        _workRow.Cells[1].Paragraphs[0].Text = string.Format(@"检查日期：{0}",((DateTime) _row["jcrq"]).ToString("yyyy/MM/dd"));
                        _workRow.Cells[4].Paragraphs[0].Text = string.Format(@"{0}", _row["jcysxm"]);
                        curTable.Rows.Add(_workRow);
                        curTable.Rows.Add(trXmHeader.Clone());

                    }

                    _workRow = trXmValue.Clone();
                    _workRow.RowFormat.Borders.ClearFormatting();
                    _workRow.Cells[0].Paragraphs[0].Text=_row["tjxmmc"].ToString();
                     _workRow.Cells[1].Paragraphs[0].Text=_row["jg"].ToString();
                     _workRow.Cells[2].Paragraphs[0].Text=_row["dw"].ToString();
                     _workRow.Cells[3].Paragraphs[0].Text = string.Format(@"{0}-{1}", _row["ckxx"], _row["cksx"]);
                     _workRow.Cells[4].Paragraphs[0].Text = string.Empty;
                     curTable.Rows.Add(_workRow);
                     i++;
                    //if (i>5)
                    //{
                    //    break;
                    //}
                     preZhXj = _row["xj"].ToString();
                }



                doc.SaveToFile("tjt1.docx", FileFormat.Docx);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            

            return null;
        }
    }
}
