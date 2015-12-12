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
            e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.Green)), 0, 0, 300, 300);
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(40,200, 100, 100)), 100, 100, 100, 100);
        }
    }
}
