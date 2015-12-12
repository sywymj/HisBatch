namespace HisPatch
{
    partial class FormPersonInforEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPersonInforEdit));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonCam = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSelPic = new System.Windows.Forms.ToolStripButton();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxAvatar = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 429);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(620, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonCam,
            this.toolStripButtonSelPic});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(620, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonCam
            // 
            this.toolStripButtonCam.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCam.Image")));
            this.toolStripButtonCam.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCam.Name = "toolStripButtonCam";
            this.toolStripButtonCam.Size = new System.Drawing.Size(76, 22);
            this.toolStripButtonCam.Text = "采集头像";
            this.toolStripButtonCam.Click += new System.EventHandler(this.toolStripButtonCam_Click);
            // 
            // toolStripButtonSelPic
            // 
            this.toolStripButtonSelPic.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSelPic.Image")));
            this.toolStripButtonSelPic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSelPic.Name = "toolStripButtonSelPic";
            this.toolStripButtonSelPic.Size = new System.Drawing.Size(76, 22);
            this.toolStripButtonSelPic.Text = "选择照片";
            this.toolStripButtonSelPic.Click += new System.EventHandler(this.toolStripButtonSelPic_Click);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(3, 3);
            this.propertyGrid1.Name = "propertyGrid1";
            this.tableLayoutPanel1.SetRowSpan(this.propertyGrid1, 2);
            this.propertyGrid1.Size = new System.Drawing.Size(259, 398);
            this.propertyGrid1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 265F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.propertyGrid1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBoxAvatar, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(620, 404);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // pictureBoxAvatar
            // 
            this.pictureBoxAvatar.BackColor = System.Drawing.SystemColors.Info;
            this.pictureBoxAvatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxAvatar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxAvatar.Location = new System.Drawing.Point(268, 3);
            this.pictureBoxAvatar.Name = "pictureBoxAvatar";
            this.pictureBoxAvatar.Size = new System.Drawing.Size(349, 360);
            this.pictureBoxAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxAvatar.TabIndex = 1;
            this.pictureBoxAvatar.TabStop = false;
            this.pictureBoxAvatar.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxAvatar_Paint);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Jpeg|*.jpg|Png|*.png|Bmp|*.bmp";
            // 
            // FormPersonInforEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 451);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "FormPersonInforEdit";
            this.Text = "FormPersonInforEdit";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPersonInforEdit_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBoxAvatar;
        private System.Windows.Forms.ToolStripButton toolStripButtonCam;
        private System.Windows.Forms.ToolStripButton toolStripButtonSelPic;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}