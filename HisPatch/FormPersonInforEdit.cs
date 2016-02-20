using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CVR100A;

namespace HisPatch
{
    public partial class FormPersonInforEdit : Form
    {
        public FormPersonInforEdit()
        {
            InitializeComponent();
        }

        FormCamera formCamera = null;
        private void toolStripButtonCam_Click(object sender, EventArgs e)
        {
            if (formCamera == null || formCamera.IsDisposed)
            {
                formCamera = new FormCamera();
            }
            formCamera.ShowDialog();
            if (GSetting.Avatar!=null)
            {
                this.pictureBoxAvatar.Image = GSetting.Avatar;
                this.pictureBoxAvatar.Update();
            }

           
        }

        private void FormPersonInforEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                CVRSDK.CVR_CloseComm();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripButtonSelPic_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            try
            {
                Image image = Bitmap.FromFile(this.openFileDialog1.FileName);
                this.pictureBoxAvatar.Image = image;
                this.pictureBoxAvatar.Update();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBoxAvatar_Paint(object sender, PaintEventArgs e)
        {
            DrawRect(e.Graphics);
        }

        Brush bordBrush = null;
        Pen bordPen = null;
        Pen pointPen = null;
        Rectangle rect;
        const int AvatarRectWidth = 150;
        const int AvatarRectHeight = 200;

        public Guid CurPersonID { get; set; }
        CExamPerson CurPersonReg = null;

        int iRetUSB = 0, iRetCOM = 0;
        private void FormPersonInforEdit_Load(object sender, EventArgs e)
        {
            //this.CurPersonID = new Guid("0CFAEF94-BD65-4D58-B2CD-9B80D0F8DA87");

            rect = new Rectangle(3, 3, AvatarRectWidth, AvatarRectHeight);

            pointPen = new Pen(Color.Black, 1);
            bordPen = new Pen(Color.Blue, 1);
            bordPen.DashStyle = DashStyle.Custom;
            bordPen.DashPattern = new float[] { 4f, 4f };

            this.toolStripStatusLabelCurOper.Text = "当前用户：" + GSetting.OperatorName;
            RefreshCurReginfo();
            try
            {

                int iPort;
                for (iPort = 1001; iPort <= 1016; iPort++)
                {
                    iRetUSB = CVRSDK.CVR_InitComm(iPort);
                    if (iRetUSB == 1)
                    {
                        break;
                    }
                }
                if (iRetUSB != 1)
                {
                    for (iPort = 1; iPort <= 4; iPort++)
                    {
                        iRetCOM = CVRSDK.CVR_InitComm(iPort);
                        if (iRetCOM == 1)
                        {
                            break;
                        }
                    }
                }

                if ((iRetCOM == 1) || (iRetUSB == 1))
                {
                    this.LabelPsnStatus.Text = "身份证读卡器连接成功";
                }
                else
                {
                    this.LabelPsnStatus.Text= "身份证读卡器连接失败";
                    this.toolStripButtonReadPsnCard.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }

        private void RefreshCurReginfo()
        {
            CurPersonReg=PID2ExamPerson(CurPersonID);
            this.pictureBoxAvatar.Image = CurPersonReg.Avatar;
            this.pictureBoxAvatar.Update();

            this.propertyGrid1.SelectedObject = CurPersonReg;
        }

        public static CExamPerson PID2ExamPerson(Guid pid)
        {
            CExamPerson __CurPersonReg = null;
            try
            {
                using (DataClassExamDataContext db = new DataClassExamDataContext(GSetting.connStr))
                {
                    var _p = (from __p in db.PersonReg
                              where __p.ID == pid && __p.IsFail == 0
                              select __p).FirstOrDefault();
                    if (_p == null)
                    {
                        __CurPersonReg = new CExamPerson();
                    }
                    else
                    {
                        __CurPersonReg = new CExamPerson()
                        {
                            ID = _p.ID,
                            RegDate = _p.RegDate.Value,
                            Serail = _p.Serial.ToString(),
                            PSN = _p.PSN,
                            Name = _p.PersonName,
                            Sex = _p.Sex,
                            Age = _p.Age,
                            Nation = _p.Nation,
                            WorkType = _p.WorkType,
                            Conclusion = _p.Conclusion,
                            IsLocked = _p.T1 == "T" ? true : false,
                            SignNumber = _p.T2,
                            Job = _p.T3
                        };
                        QualifiedSign signInfo = _p.QualifiedSign.FirstOrDefault();
                        if (signInfo != null)
                        {
                            __CurPersonReg.SignDate = signInfo.SignDate ?? DateTime.Now;
                        }
                        //读取照片
                        __CurPersonReg.Avatar = bytesToImage(_p.Avatar.ToArray());

                        
                    }


                }

                return __CurPersonReg;

                
            }
            catch (System.Exception ex)
            {
                //MessageBox.Show(ex.Message);
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        private Image bytesToImage(byte[] buf)
        {
            try
            {
                if (buf == null || buf.Length <= 0)
                {
                    throw new ArgumentException();
                }
                using (MemoryStream ms = new MemoryStream(buf))
                {
                    return new Bitmap(Image.FromStream(ms)) ;
                }
            }
            catch (System.Exception ex)
            {
                return null;
            }
        }

        private void DrawRect(Graphics g)
        {
            g.DrawRectangle(bordPen, rect);
            g.DrawRectangle(pointPen, rect.X - 3, rect.Y - 3, 5, 5);
            g.DrawRectangle(pointPen, rect.X + rect.Width / 2 - 3, rect.Y - 3, 5, 5);
            g.DrawRectangle(pointPen, rect.X + rect.Width - 3, rect.Y - 3, 5, 5);

            g.DrawRectangle(pointPen, rect.X - 3, rect.Y + rect.Height - 3, 5, 5);
            g.DrawRectangle(pointPen, rect.X + rect.Width / 2 - 3, rect.Y + rect.Height - 3, 5, 5);
            g.DrawRectangle(pointPen, rect.X + rect.Width - 3, rect.Y + rect.Height - 3, 5, 5);

            g.DrawRectangle(pointPen, rect.X - 3, rect.Y + rect.Height / 2 - 3, 5, 5);
            g.DrawRectangle(pointPen, rect.X + rect.Width - 3, rect.Y + rect.Height / 2 - 3, 5, 5);
        }

        private void pictureBoxAvatar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MouseIsCapture = true;
                preLocation = new Point(e.Location.X, e.Location.Y);
            }
        }

        bool MouseIsCapture = false;
        Point preLocation;

        EnMousePos varCaptureType = EnMousePos.other;
        private void pictureBoxAvatar_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseIsCapture)
            {
                Rectangle newRect = new Rectangle();
                if (this.pictureBoxAvatar.Cursor == Cursors.Hand)
                {
                    newRect = new Rectangle(rect.X + e.Location.X - preLocation.X, rect.Y + e.Location.Y - preLocation.Y, rect.Width, rect.Height);
                }
                if (this.pictureBoxAvatar.Cursor == Cursors.VSplit)
                {
                    //求出X的值和Width
                    newRect = new Rectangle();
                    if (varCaptureType == EnMousePos.Xleft)
                    {
                        newRect.X = e.Location.X;
                        newRect.Width = rect.X - e.Location.X + rect.Width;
                    }
                    else
                    {
                        newRect.X = rect.X;
                        newRect.Width = e.Location.X - preLocation.X + rect.Width;
                        //Console.WriteLine(newRect);
                    }
                    newRect.Y = rect.Y;
                    newRect.Height = newRect.Width * AvatarRectHeight / AvatarRectWidth;
                }
                if (this.pictureBoxAvatar.Cursor == Cursors.HSplit)
                {
                    newRect = new Rectangle();
                    if (varCaptureType == EnMousePos.Ytop)
                    {
                        newRect.Y = e.Location.Y;
                        newRect.Height = rect.Y - e.Location.Y + rect.Height;
                    }
                    else
                    {
                        newRect.Y = rect.Y;
                        newRect.Height = e.Location.Y - preLocation.Y + rect.Height;
                    }

                    newRect.X = rect.X;
                    newRect.Width = newRect.Height * AvatarRectWidth / AvatarRectHeight;
                }


                Rectangle clientRect = new Rectangle(3, 3, this.pictureBoxAvatar.Width - 8, this.pictureBoxAvatar.Height - 8);

                if (clientRect.Contains(newRect) && newRect.Width >= AvatarRectWidth && newRect.Height >= AvatarRectHeight)
                {
                    rect = newRect;
                    preLocation = new Point(e.Location.X, e.Location.Y);
                }
            }
            else
            {
                varCaptureType = detectionMousePos(e.Location);
                switch (varCaptureType)
                {
                    case EnMousePos.Xleft:
                    case EnMousePos.Xright:
                        this.pictureBoxAvatar.Cursor = Cursors.VSplit;
                        break;
                    case EnMousePos.Ytop:
                    case EnMousePos.Ybuttom:
                        this.pictureBoxAvatar.Cursor = Cursors.HSplit;
                        break;
                    case EnMousePos.center:
                        this.pictureBoxAvatar.Cursor = Cursors.Hand;
                        break;
                    default:
                        this.pictureBoxAvatar.Cursor = Cursors.Default;
                        break;
                }
            }

            this.pictureBoxAvatar.Refresh();

        }

        private EnMousePos detectionMousePos(Point p)
        {
            Rectangle xl = new Rectangle(rect.X - 3, rect.Y + 20, 5, rect.Height - 40);
            Rectangle xr = new Rectangle(rect.X + rect.Width - 3, rect.Y + 20, 5, rect.Height - 40);

            Rectangle yt = new Rectangle(rect.X + 20, rect.Y - 3, rect.Width - 40, 5);
            Rectangle yb = new Rectangle(rect.X + 20, rect.Y + rect.Height - 3, rect.Width - 40, 5);

            Rectangle center = new Rectangle(rect.X + rect.Width / 2 - 50, rect.Y + rect.Height / 2 - 50, 100, 100);

            if (xl.Contains(p))
            {
                return EnMousePos.Xleft;
            }
            if (xr.Contains(p))
            {
                return EnMousePos.Xright;
            }
            if (yt.Contains(p))
            {
                return EnMousePos.Ytop;
            }
            if (yb.Contains(p))
            {
                return EnMousePos.Ybuttom;
            }
            if (center.Contains(p))
            {
                return EnMousePos.center;
            }
            return EnMousePos.other;
        }

        private void pictureBoxAvatar_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MouseIsCapture = false;
            }
        }

        private void pictureBoxAvatar_DoubleClick(object sender, EventArgs e)
        {
            Bitmap bmp;
            IntPtr dc1;
            IntPtr dc2;
            Graphics g;

            bmp = new Bitmap(rect.Width - 4, rect.Height - 4);
            g = Graphics.FromImage(bmp);

            dc1 = g.GetHdc();
            dc2 = this.pictureBoxAvatar.CreateGraphics().GetHdc();
            WinapiWrap.BitBlt(dc1, 0, 0, bmp.Width, bmp.Height, dc2, rect.X + 4, rect.Y + 4, TernaryRasterOperations.SRCCOPY);

            g.ReleaseHdc(dc1);
            WinapiWrap.ReleaseDC(this.pictureBoxAvatar.Handle, dc2);

            rect = new Rectangle(3, 3, AvatarRectWidth, AvatarRectHeight);
            this.pictureBoxAvatar.Image = bmp;
            this.pictureBoxAvatar.Update();
            bmp.Save("1.jpg", ImageFormat.Jpeg);
        }

        private void FormPersonInforEdit_Resize(object sender, EventArgs e)
        {
            rect = new Rectangle(3, 3, AvatarRectWidth, AvatarRectHeight);
        }

        private void toolStripButtonSaveReg_Click(object sender, EventArgs e)
        {
           

            CurPersonReg.Avatar = this.pictureBoxAvatar.Image;

            try
            {
                if (CurPersonReg == null || CurPersonReg.IsLocked)
                {
                    throw new Exception("登记参数错误或者该登记信息已锁定！");
                }
                if (MessageBox.Show("您确认要保存该登记信息吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                {
                    return;
                }
                using (DataClassExamDataContext db = new DataClassExamDataContext(GSetting.connStr))
                {
                    var pp = (from _p in db.PersonReg where _p.ID == CurPersonReg.ID && _p.T1 != "T" && _p.IsFail==0 select _p).FirstOrDefault();
                    if (pp == null)
                    {
                        pp = new PersonReg();
                    }
                    pp.PSN = CurPersonReg.PSN;
                    pp.PersonName = CurPersonReg.Name;
                    pp.Sex = CurPersonReg.Sex;
                    pp.Age = CurPersonReg.Age;
                    pp.Nation = CurPersonReg.Nation;
                    pp.WorkType = CurPersonReg.WorkType;
                    if (CurPersonReg.Avatar != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            CurPersonReg.Avatar.Save(ms, ImageFormat.Jpeg);
                            pp.Avatar = new System.Data.Linq.Binary(ms.ToArray());
                        }
                    }
                    pp.Conclusion = CurPersonReg.Conclusion;
                    pp.RegOperID = GSetting.OperatorID.ToString();
                    pp.RegOperName = GSetting.OperatorName;
                    pp.IsFail = 0;
                    pp.T1 = "F";
                    pp.T3 = CurPersonReg.Job;

                    if (pp.ID == Guid.Empty)
                    {
                        pp.ID = CurPersonReg.ID;
                        db.PersonReg.InsertOnSubmit(pp);
                    }
                    db.SubmitChanges();
                }

                MessageBox.Show("保存成功！！");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "保存登记信息错误");
            }
        }

        private void toolStripButtonGetApplyTable_Click(object sender, EventArgs e)
        {
            try
            {
                Document doc = MakeApplyTableDoc(CurPersonReg);
                if (doc==null)
                {
                    throw new Exception("生成表格失败！");
                }
                FormBatchPutDrugReportView rv = new FormBatchPutDrugReportView();
                rv.DispDoc = doc;
                rv.ShowDialog();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "生成表格失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private Document MakeSignTableDoc(Guid ID)
        {
            Document doc = null;

            PersonReg pRegInfo = null;
            QualifiedSign pSignInfo = null;
            using (DataClassExamDataContext db = new DataClassExamDataContext(GSetting.connStr))
            {
                pRegInfo = (from _p in db.PersonReg where _p.ID ==ID && _p.IsFail == 0 && _p.T1=="T" select _p).FirstOrDefault();
                if (pRegInfo == null)
                {
                    throw new Exception("人员信息有误或者没有保存登记信息！！ ");
                }
                pSignInfo = pRegInfo.QualifiedSign.FirstOrDefault();
            }
            



            Image bmpAvatar = null;
            MemoryStream ms = new MemoryStream(pRegInfo.Avatar.ToArray());

            bmpAvatar = Image.FromStream(ms, true, true);

            doc = new Document();
            doc.LoadFromStream(new MemoryStream(Properties.Resources.SignN), FileFormat.Docx);

            

            Spire.Doc.Collections.DocumentObjectCollection oc = doc.Document.Sections[0].Tables[0].Rows[2].Cells[1].Paragraphs[0].ChildObjects;
            foreach (var obj in oc)
            {
                Console.WriteLine(obj.GetType().ToString());
                if (obj is DocPicture)
                {
                    DocPicture docPic = obj as DocPicture;
                    docPic.LoadImage(bmpAvatar);
                    float sca = (98 / docPic.Height);
                    docPic.Height = 98;
                    docPic.Width = docPic.Width * sca;
                }
            }

            //Spire.Doc.Fields.TextBox Tb = doc.TextBoxes[0];
            //Tb.Format.HorizontalOrigin = HorizontalOrigin.InnerMarginArea;
            //Tb.Format.HorizontalPosition = 0;
            //Tb.Format.VerticalOrigin = VerticalOrigin.InnerMarginArea;
            //Tb.Format.VerticalPosition = 0;


            Table docTable = (Table)doc.Document.Sections[0].Tables[0];
            docTable.Rows[1].Cells[1].Paragraphs[0].Text += pRegInfo.PSN;
            docTable.Rows[1].Cells[2].Paragraphs[0].Text += pSignInfo.SignNumber;
            docTable.Rows[2].Cells[2].Paragraphs[0].Text += pRegInfo.PersonName;
            docTable.Rows[2].Cells[3].Paragraphs[0].Text += pRegInfo.Sex;
            docTable.Rows[3].Cells[2].Paragraphs[0].Text += pRegInfo.Age;
            docTable.Rows[3].Cells[3].Paragraphs[0].Text += pRegInfo.WorkType;

            docTable.Rows[4].Cells[2].Paragraphs[0].Text += pSignInfo.SignDate.Value.ToString("yyyy年MM月dd日");
            docTable.Rows[5].Cells[2].Paragraphs[0].Text += pSignInfo.ExpireDate.Value.ToString("yyyy年MM月dd日");
            return doc;
        }

        private Document MakeApplyTableDoc(CExamPerson pInfo)
        {
            Document doc = null;

            PersonReg pRegInfo = null;
            using (DataClassExamDataContext db = new DataClassExamDataContext(GSetting.connStr))
            {
                pRegInfo = (from _p in db.PersonReg where _p.ID == pInfo.ID && _p.IsFail==0 select _p).FirstOrDefault();
                if (pRegInfo == null)
                {
                    throw new Exception("人员信息有误或者没有保存登记信息！！ ");
                }
            }
            Image bmpAvatar = null;
            MemoryStream ms = new MemoryStream(pRegInfo.Avatar.ToArray());
            
            bmpAvatar = Image.FromStream(ms,true,true);
            
            doc = new Document();
            doc.LoadFromStream(new MemoryStream(Properties.Resources.health), FileFormat.Docx);


            Spire.Doc.Collections.DocumentObjectCollection oc = doc.Document.Sections[0].Tables[0].Rows[0].Cells[1].Paragraphs[0].ChildObjects;
            foreach (var obj in oc)
            {
                Console.WriteLine(obj.GetType().ToString());
                if (obj is DocPicture)
                {
                    DocPicture docPic = obj as DocPicture;
                    docPic.LoadImage(bmpAvatar);
                    float sca = (110 / docPic.Height);
                    docPic.Height = 110;
                    docPic.Width = docPic.Width * sca;
                }
            }
            Table docTable = (Table)doc.Document.Sections[0].Tables[0];
            docTable.Rows[1].Cells[0].Paragraphs[0].AppendText(pRegInfo.RegDate.Value.ToString("yyyy年MM月dd日"));
            docTable.Rows[1].Cells[1].Paragraphs[0].AppendText(pRegInfo.PSN);

            docTable.Rows[2].Cells[0].Paragraphs[0].Text += pRegInfo.PersonName;
            docTable.Rows[2].Cells[1].Paragraphs[0].Text += pRegInfo.Sex;
            docTable.Rows[2].Cells[2].Paragraphs[0].Text +=pRegInfo.Age;
            docTable.Rows[2].Cells[3].Paragraphs[0].Text +=pRegInfo.Nation;
            docTable.Rows[2].Cells[4].Paragraphs[0].Text += pRegInfo.WorkType;

            return doc;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this,"合格证明签发后，信息将不能修改\r\n您确定要签发合格证明吗？","签发合格证明",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)!=DialogResult.OK)
            {
                return;
            }
            if (HisPatch.Printer.SingCertifyPrint.QualifiedSign(CurPersonReg))
            {
                RefreshCurReginfo();

                Printer.SingCertifyPrint obj = new Printer.SingCertifyPrint();
                obj.DrawSingeInPhotoPaper6In(CurPersonReg, GSetting.PaperSize6InPrinterName, true, false);
            }
            else
            {
                MessageBox.Show("签发失败，请联系管理员！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        
        private void toolStripButtonQuery_Click(object sender, EventArgs e)
        {
            FormExamQuery examQuery=new FormExamQuery();
            if (examQuery.ShowDialog()!=DialogResult.OK)
            {
                return;
            }
            this.CurPersonID = new Guid(examQuery.QueryHr);
            RefreshCurReginfo();
        }

        private void 新建NToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearBoard();
        }

        private void ClearBoard()
        {
            CurPersonReg = new CExamPerson();
            this.propertyGrid1.SelectedObject = CurPersonReg;
            GSetting.Avatar = null;
            this.pictureBoxAvatar.Image = null;
            this.pictureBoxAvatar.Update();
        }

        private void toolStripMenuItemPraining_Click(object sender, EventArgs e)
        {
            FormBatchPutDrugReportView rv = new FormBatchPutDrugReportView();
            Document doc = new Document(new MemoryStream(Properties.Resources.Training));

            rv.DispDoc = doc;
            rv.WindowState = FormWindowState.Normal;
            rv.ShowDialog();
        }

        private void toolStripButtonReadPsnCard_Click(object sender, EventArgs e)
        {
            try
            {
                ClearBoard();

                int authenticate = CVRSDK.CVR_Authenticate();
                if (authenticate == 1)
                {
                    int readContent = CVRSDK.CVR_Read_Content(4);
                    if (readContent == 1)
                    {
                        StringBuilder sb = null;
                        int strLen=-1;

                        sb = new StringBuilder(128);
                        CVRSDK.GetPeopelName(sb, ref strLen);
                        CurPersonReg.Name = sb.ToString();
                        Console.WriteLine(sb.ToString());

                        sb = new StringBuilder(128);
                        CVRSDK.GetPeopleIDCode(sb, ref strLen);
                        CurPersonReg.PSN = sb.ToString();

                        sb = new StringBuilder(128);
                        CVRSDK.GetPeopleNation(sb,ref strLen);
                        CurPersonReg.Nation=sb.ToString()+"族";

                        sb = new StringBuilder(128);
                        CVRSDK.GetPeopleSex(sb, ref strLen);
                        CurPersonReg.Sex = sb.ToString();

                        if (File.Exists("zp.bmp"))
                        {
                            this.pictureBoxAvatar.Image = Image.FromFile("zp.bmp");
                        }

                        this.pictureBoxAvatar.Update();
                        this.propertyGrid1.Refresh();
                    }
                    else
                    {
                        throw new Exception("读卡操作失败！");
                    }
                }
                else
                {
                    throw new Exception("未放卡或卡片放置不正确");
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripButtonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurPersonReg == null || CurPersonReg.IsLocked)
                {
                    throw new Exception("登记参数错误或者该登记信息已锁定！");
                }
                if (MessageBox.Show("您确认要删除该登记信息吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                {
                    return;
                }

                using (DataClassExamDataContext db = new DataClassExamDataContext(GSetting.connStr))
                {
                    var pp = (from _p in db.PersonReg where _p.ID == CurPersonReg.ID && _p.T1 != "T" && _p.IsFail == 0 select _p).FirstOrDefault();
                    if (pp!=null)
                    {
                        pp.IsFail = 1;
                        db.SubmitChanges();
                    }

                }
                ClearBoard();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message, "删除登记信息错误");
            }
        }

    }

    enum EnMousePos
    {
        Xleft, Xright, Ytop, Ybuttom, center, other
    }
}
