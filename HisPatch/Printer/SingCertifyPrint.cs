using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace HisPatch.Printer
{
    public class SingCertifyPrint
    {
        private CExamPerson curPersonInfo = null;
        private CExamPerson[] curPersonInfoArray = null;
        private int curDrawPos = 0;
        private PointF paperA4Line = new PointF(10, 12);
        private SizeF cardSize = new SizeF(85.6f, 54);
        private Action<CExamPerson, PointF, Graphics> handleDraw;
        public PointF OffSetPoint { get; set; }
        public SingCertifyPrint()
        {
            OffSetPoint = new PointF(0, 0);
        }

        public static bool QualifiedSign(CExamPerson _CurPersonReg)
        {
            try
            {
                //Guid pRegInfo_ID = Guid.Empty;
                using (DataClassExamDataContext db = new DataClassExamDataContext(GSetting.connStr))
                {
                    var pRegInfo = (from _p in db.PersonReg where _p.ID == _CurPersonReg.ID && _p.IsFail == 0 select _p).FirstOrDefault();
                    if (pRegInfo == null)
                    {
                        throw new Exception("人员信息有误或者没有保存登记信息！！ ");
                    }
                    var qualifiedSign = (from _p in pRegInfo.QualifiedSign where _p.IsFail == 0 select _p).FirstOrDefault();
                    if (qualifiedSign == null)
                    {
                        var serverDate = db.ExecuteQuery<DateTime>("select getdate() ").FirstOrDefault();
                        int serial = db.ExecuteQuery<int>("select ISNULL(max(serail),0)+1 from qualifiedsign").FirstOrDefault();


                        qualifiedSign = new QualifiedSign();
                        qualifiedSign.ID = Guid.NewGuid();
                        qualifiedSign.PersonID = new Guid(pRegInfo.ID.ToString());
                        qualifiedSign.Serail = serial;
                        qualifiedSign.Year = serverDate.Year.ToString();
                        qualifiedSign.SignOperID = GSetting.OperatorID;
                        qualifiedSign.SignOperName = GSetting.OperatorName;
                        qualifiedSign.IsFail = 0;
                        qualifiedSign.SignNumber = string.Format(@"422224928{1}{0:D6}", serial, qualifiedSign.Year);
                        qualifiedSign.ExpireDate = serverDate.AddYears(1).AddDays(-1);

                        pRegInfo.T1 = "T";
                        pRegInfo.T2 = qualifiedSign.SignNumber;

                        //pRegInfo_ID = new Guid(pRegInfo.ID.ToString());

                        db.QualifiedSign.InsertOnSubmit(qualifiedSign);

                        db.SubmitChanges();
                    }

                }

                //Document doc = MakeSignTableDoc(pRegInfo_ID);

                //FormBatchPutDrugReportView rv = new FormBatchPutDrugReportView();
                //rv.DispDoc = doc;
                //rv.WindowState = FormWindowState.Normal;
                //rv.ShowDialog();

                return true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }



        public void DrawManyInA4(IEnumerable<CExamPerson> pIEnumPersonInfo, string printerName, bool IsPreview,bool IsBack)
        {
            if (pIEnumPersonInfo==null || (curPersonInfoArray=pIEnumPersonInfo.ToArray()).Length<=0)
            {
                return;
            }
            if (IsBack)
            {
                handleDraw = DrawOneBack;
            } 
            else
            {
                handleDraw = DrawOneCard;
            }


            curDrawPos = 0;

            PrintDocument pdA4 = new PrintDocument();
            PaperSize pa4 = null;
            foreach (PaperSize _p in pdA4.PrinterSettings.PaperSizes)
            {
                if (_p.PaperName.Equals("A4"))
                {
                    pdA4.DefaultPageSettings.PaperSize = _p;
                }
            }

            pdA4.DefaultPageSettings.Margins.Top = 0;
            pdA4.DefaultPageSettings.Margins.Bottom = 0;
            pdA4.DefaultPageSettings.Margins.Left = 0;
            pdA4.DefaultPageSettings.Margins.Right = 0;

            pdA4.DefaultPageSettings.Landscape = false;

            if (!string.IsNullOrEmpty(printerName))
            {
                pdA4.DefaultPageSettings.PrinterSettings.PrinterName = printerName;
                Console.WriteLine(pdA4.DefaultPageSettings.PrinterResolution.Kind.ToString());
                foreach (PrinterResolution _pr in  pdA4.DefaultPageSettings.PrinterSettings.PrinterResolutions)
                {
                    Console.WriteLine(_pr.Kind.ToString());
                }
            }

            pdA4.PrintPage += pdA4_PrintPage;
            pdA4.BeginPrint += pdA4_BeginPrint;
             
            if (IsPreview)
            {
                PrintPreviewDialog pvDlg = new PrintPreviewDialog();
                pvDlg.Document = pdA4;
                pvDlg.ShowDialog();
            }
            else
            {
                pdA4.Print();
            }

        }

        void pdA4_BeginPrint(object sender, PrintEventArgs e)
        {
            //throw new NotImplementedException();
            curDrawPos = 0;
        }

        void pdA4_PrintPage(object sender, PrintPageEventArgs e)
        {
            //throw new NotImplementedException();
            int curRow = 0; int curCol = 0; int countPerPage = 0;
            while (curDrawPos < curPersonInfoArray.Length && countPerPage<9)
            {
                
                curRow = ((curDrawPos % 8) / 2);
                curCol = curDrawPos % 2;

                PointF __drawPoint=new PointF((curCol+1)*paperA4Line.X+curCol*cardSize.Width,(curRow+1)*paperA4Line.Y+curRow*cardSize.Height);

                handleDraw(curPersonInfoArray[curDrawPos], __drawPoint, e.Graphics);                
                curDrawPos++;
                countPerPage++;
            }
            if (curDrawPos<curPersonInfoArray.Length)
            {
                e.HasMorePages = true;
            } 
            else
            {
                e.HasMorePages = false;
            }
        }


        public void DrawSingeInPhotoPaper6In(CExamPerson pInfo,string printerName,bool IsPreview,bool IsBack)
        {
            if (pInfo==null)
            {
                return;
            }
            if (IsBack)
            {
                handleDraw = DrawOneBack;
            }
            else
            {
                handleDraw = DrawOneCard;
            }
            curPersonInfo = pInfo;
            PrintDocument pd = new PrintDocument();
            PaperSize ps6in = new PaperSize("ps6in",Convert.ToInt32( 1020 / 2.54), Convert.ToInt32(1520/ 2.54));

            pd.DefaultPageSettings.Margins.Top = 0;
            pd.DefaultPageSettings.Margins.Bottom = 0;
            pd.DefaultPageSettings.Margins.Left = 0;
            pd.DefaultPageSettings.Margins.Right = 0;
            pd.DefaultPageSettings.PaperSize = ps6in;

            //pd.DefaultPageSettings.Landscape = true;
            //PrintDialog pdd = new PrintDialog();
            //pdd.ShowDialog();
            //PrinterResolution prr = new PrinterResolution();
            //prr.Kind=PrinterResolutionKind.Low;

            if (!string.IsNullOrEmpty(printerName))
            {
                pd.DefaultPageSettings.PrinterSettings.PrinterName = printerName;
                //pd.DefaultPageSettings.PrinterResolution = prr;
                
               
            }
            pd.PrintPage += pd_PrintPage;
            if (IsPreview)
            {
                PrintPreviewDialog pvDlg = new PrintPreviewDialog();
                pvDlg.Document = pd;
                pvDlg.ShowDialog();
            }
            else
            {
                pd.Print();
            }


        }

        void pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            //throw new NotImplementedException();
            handleDraw(curPersonInfo, new PointF(8.2f,5f), e.Graphics);
        }
        [DllImport("gdi32.dll")]
        public static extern int SetTextCharacterExtra(IntPtr hdc, int nCharExtra);

        private void DrawOneBack(CExamPerson pInfo, PointF originPoint, Graphics g)
        {
            try
            {
                g.PageUnit = GraphicsUnit.Millimeter;
                g.ResetTransform();
                g.TranslateTransform(originPoint.X+OffSetPoint.X, originPoint.Y+OffSetPoint.Y);
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.CompositingMode = CompositingMode.SourceOver;
                g.CompositingQuality = CompositingQuality.HighQuality;

                float lineHeight = 7f;
                PointF posAvatar = new PointF(3, 16);
                PointF posContent = new PointF(28, 17);
                PointF posSign = new PointF(7, 14);

                

                Pen _penDash = new Pen(Color.Gray, 0.02f);
                //_penDash.DashStyle = DashStyle.DashDot;
                Font _fontTitle = new Font("宋体", 4f, FontStyle.Bold, GraphicsUnit.Millimeter);
                Font _fontTitle1 = new Font("宋体", 9f, FontStyle.Bold, GraphicsUnit.Millimeter);
                Font _fontTitle2 = new Font("黑体", 3.1f, FontStyle.Regular, GraphicsUnit.Millimeter);
                

                SolidBrush _brushBlack = new SolidBrush(Color.Black);
                SolidBrush _brushGreen=new SolidBrush(Color.Green);
                StringFormat _sf1 = new StringFormat();
                _sf1.Alignment = StringAlignment.Center;
                StringFormat _sf2 = new StringFormat();
                _sf2.Alignment = StringAlignment.Near;
                

                //g.DrawRectangle(_penDash, 0, 0, cardSize.Width, cardSize.Height);
                g.DrawLine(_penDash, cardSize.Width / 2, 0, cardSize.Width / 2, cardSize.Height);
                

                Matrix oldMatrix = g.Transform.Clone();
                Matrix strechMatrix = g.Transform.Clone();
                strechMatrix.Scale(1, 1.3f);
                g.Transform = strechMatrix;
                g.DrawString("卫生知识培训合格证", _fontTitle, _brushGreen, new RectangleF(0,8/1.3f,42.8f,10), _sf1);
                g.Transform = oldMatrix;

                g.DrawString("合格证", _fontTitle1, _brushGreen, new RectangleF(0, 25f, 42.8f, 30), _sf1);

                g.DrawImage(Properties.Resources.SignTj, posSign.X, posSign.Y, 32, 32);
                g.DrawImage(Properties.Resources.SignTj, posSign.X, posSign.Y, 32, 32);

                g.DrawString("说  明",new Font("黑体", 4f, FontStyle.Regular, GraphicsUnit.Millimeter), _brushBlack, new RectangleF(cardSize.Width/2f, 8f, cardSize.Width/2f, 10), _sf1);

                
                string instruction = "（1）从业人员必须持有效证件上岗，自觉接受相关监督部门检查\r（2）本证涂改、严重破损、无章迹或章迹不清无效。";

                int _dsLine=0;int _dsLineSpace=6;
                float _dsOx=cardSize.Width/2f+3;
                float _dsOy=16;
                PointF _dsPoint=new PointF(_dsOx,_dsOy);
                foreach (char _char in instruction.ToCharArray())
                {
                    if (_char==(char)13)
                    {
                        _dsLine++;
                        _dsPoint.X = _dsOx;
                        _dsPoint.Y = _dsOy + _dsLine * _dsLineSpace;
                        continue;
                    }

                    SizeF _charSize=g.MeasureString(_char.ToString(),_fontTitle2);
                    if (_charSize.Width+_dsPoint.X>83)
                    {
                        _dsLine++;
                        _dsPoint.X = _dsOx;
                        _dsPoint.Y = _dsOy+_dsLine * _dsLineSpace;
                    }
                    g.DrawString(_char.ToString(), _fontTitle2, _brushBlack, _dsPoint);
                    _dsPoint.X += _charSize.Width-1;

                }

                //g.DrawString(instruction, _fontTitle2, _brushBlack, new RectangleF(cardSize.Width / 2f, 18f, cardSize.Width / 2f, 40));

            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        private void DrawOneCard(CExamPerson pInfo, PointF originPoint,Graphics g)
        {
            
            try
            {
                g.PageUnit = GraphicsUnit.Millimeter;                
                g.ResetTransform();
                g.TranslateTransform(originPoint.X+OffSetPoint.X, originPoint.Y+OffSetPoint.Y);
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.CompositingMode = CompositingMode.SourceOver;
                g.CompositingQuality = CompositingQuality.HighQuality;
                
                float lineHeight = 7f;
                PointF posAvatar=new PointF(3,16);
                PointF posContent=new PointF(28,17);
                PointF posSign = new PointF(50, 22);

                Pen _penDash = new Pen(Color.Gray,0.02f);
                _penDash.DashStyle = DashStyle.DashDot;
                Font _fontTitle = new Font("黑体", 2.8f ,FontStyle.Regular, GraphicsUnit.Millimeter);
                Font _fontTitle2 = new Font("黑体", 3.1f, FontStyle.Regular, GraphicsUnit.Millimeter);
                SolidBrush _brushBlack=new SolidBrush(Color.Black);
                StringFormat _sf1 = new StringFormat();
                _sf1.Trimming = StringTrimming.EllipsisCharacter;
                _sf1.FormatFlags = StringFormatFlags.NoWrap;
                
                g.DrawRectangle(_penDash, 0, 0, cardSize.Width, cardSize.Height);

                g.DrawImage(Properties.Resources.SignTj, posSign.X, posSign.Y, 32, 32);
                g.DrawImage(Properties.Resources.SignTj, posSign.X, posSign.Y, 32, 32);

                g.DrawString("湖北省从业人员预防性健康检查合格证明",new Font("黑体",4.35f,FontStyle.Bold,GraphicsUnit.Millimeter),new SolidBrush(Color.Black),2f,5);
                g.DrawString("身份证号：" + pInfo.PSN, _fontTitle, _brushBlack, 3, 11);
                g.DrawString("编号：" + pInfo.SignNumber, _fontTitle, _brushBlack, 47, 11);

                float avtarH;
                float avtarW;
                if (pInfo.Avatar.Width>pInfo.Avatar.Height)
                {
                    avtarW = 24.75f;
                    avtarH = 24.75f *((float)pInfo.Avatar.Height / pInfo.Avatar.Width);
                } 
                else
                {
                    avtarH = 33f;
                    avtarW = 33f *( (float)pInfo.Avatar.Width/ pInfo.Avatar.Height);
                }
                
                g.DrawImage(pInfo.Avatar, posAvatar.X, posAvatar.Y, avtarW, avtarH);
                g.DrawString("姓名：" + pInfo.Name, _fontTitle2, _brushBlack, posContent.X, posContent.Y);
                g.DrawString("性别：" + pInfo.Sex, _fontTitle2, _brushBlack, posContent.X+25, posContent.Y);

                posContent.Y += lineHeight;
                g.DrawString("年龄：" + pInfo.Age, _fontTitle2, _brushBlack, posContent.X, posContent.Y);
                g.DrawString("从业范围：" + pInfo.WorkType, _fontTitle, _brushBlack, new RectangleF(posContent.X + 14, posContent.Y,42,lineHeight),_sf1);

                posContent.Y += lineHeight;
                g.DrawString("体检日期：" + pInfo.SignDate.ToString("yyyy年MM月dd日"), _fontTitle2, _brushBlack, posContent.X, posContent.Y);
                posContent.Y += lineHeight;
                g.DrawString("有效期止：" + pInfo.SignDate.AddYears(1).AddDays(-1).ToString("yyyy年MM月dd日"), _fontTitle2, _brushBlack, posContent.X, posContent.Y);
                posContent.Y += lineHeight;
                g.DrawString("健康检查机构（盖章）茅箭区人民医院", _fontTitle2, _brushBlack, posContent.X, posContent.Y);

                
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
