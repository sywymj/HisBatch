using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
            if (formCamera==null || formCamera.IsDisposed)
            {
                formCamera = new FormCamera();
            }
            formCamera.ShowDialog();
            this.pictureBoxAvatar.Image=GSetting.Avatar;
            this.pictureBoxAvatar.Update();
        }

        private void FormPersonInforEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void toolStripButtonSelPic_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog()!=DialogResult.OK)
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
        private void FormPersonInforEdit_Load(object sender, EventArgs e)
        {
            rect = new Rectangle(3, 3, AvatarRectWidth,AvatarRectHeight);
            
            pointPen = new Pen(Color.Black, 1);
            bordPen = new Pen(Color.Blue, 1);
            bordPen.DashStyle = DashStyle.Custom;
            bordPen.DashPattern = new float[] { 4f, 4f };
        }
        private void DrawRect(Graphics g)
        {
            g.DrawRectangle(bordPen, rect);
            g.DrawRectangle(pointPen, rect.X - 3, rect.Y - 3, 5, 5);
            g.DrawRectangle(pointPen, rect.X + rect.Width / 2 - 3, rect.Y - 3, 5, 5);
            g.DrawRectangle(pointPen, rect.X + rect.Width - 3, rect.Y - 3, 5, 5);

            g.DrawRectangle(pointPen, rect.X - 3, rect.Y + rect.Height - 3, 5, 5);
            g.DrawRectangle(pointPen, rect.X + rect.Width / 2 - 3, rect.Y + rect.Height  - 3, 5, 5);
            g.DrawRectangle(pointPen, rect.X + rect.Width - 3, rect.Y + rect.Height - 3, 5, 5);

            g.DrawRectangle(pointPen, rect.X  - 3, rect.Y + rect.Height / 2 - 3, 5, 5);
            g.DrawRectangle(pointPen, rect.X + rect.Width- 3, rect.Y + rect.Height / 2 - 3, 5, 5);
        }

        private void pictureBoxAvatar_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button==MouseButtons.Left)
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
                Rectangle newRect=new Rectangle();
                if (this.pictureBoxAvatar.Cursor==Cursors.Hand)
                {
                    newRect = new Rectangle(rect.X + e.Location.X - preLocation.X, rect.Y + e.Location.Y - preLocation.Y, rect.Width, rect.Height);
                } 
                if (this.pictureBoxAvatar.Cursor==Cursors.VSplit)
                {
                    //求出X的值和Width
                    newRect = new Rectangle();
                    if (varCaptureType==EnMousePos.Xleft)
                    {
                        newRect.X = e.Location.X;
                        newRect.Width = rect.X - e.Location.X + rect.Width;                        
                    }
                    else
                    {
                        newRect.X = rect.X;
                        newRect.Width = e.Location.X-preLocation.X+rect.Width ;
                        //Console.WriteLine(newRect);
                    }
                    newRect.Y = rect.Y;
                    newRect.Height = newRect.Width * AvatarRectHeight / AvatarRectWidth;                        
                }
                if (this.pictureBoxAvatar.Cursor==Cursors.HSplit)
                {
                    newRect = new Rectangle();
                    if (varCaptureType==EnMousePos.Ytop)
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

                
                Rectangle clientRect = new Rectangle(3, 3, this.pictureBoxAvatar.Width-8, this.pictureBoxAvatar.Height-8);

                if (clientRect.Contains(newRect) && newRect.Width>=AvatarRectWidth && newRect.Height>=AvatarRectHeight)
                {
                    rect = newRect;
                    preLocation = new Point(e.Location.X, e.Location.Y);                    
                }        
            } 
            else
            {
                varCaptureType=detectionMousePos(e.Location);
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
            Rectangle xl = new Rectangle(rect.X - 3, rect.Y + 20, 5, rect.Height -40);
            Rectangle xr = new Rectangle(rect.X + rect.Width - 3, rect.Y + 20, 5, rect.Height -40);

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
            if (e.Button==MouseButtons.Left)
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

            bmp = new Bitmap(rect.Width, rect.Height);
            g = Graphics.FromImage(bmp);

            dc1 = g.GetHdc();
            dc2 = this.pictureBoxAvatar.CreateGraphics().GetHdc();
            WinapiWrap.BitBlt(dc1, 0, 0, bmp.Width-6, bmp.Height-6, dc2, rect.X+4, rect.Y+4, TernaryRasterOperations.SRCCOPY);

            g.ReleaseHdc(dc1);
            WinapiWrap.ReleaseDC(this.pictureBoxAvatar.Handle, dc2);

            this.pictureBoxAvatar.Image = bmp;
            this.pictureBoxAvatar.Update();
        }

        private void FormPersonInforEdit_Resize(object sender, EventArgs e)
        {
            rect = new Rectangle(3, 3, AvatarRectWidth, AvatarRectHeight);
        }
    }

    enum EnMousePos
    {
        Xleft,Xright,Ytop,Ybuttom,center,other
    }
}
