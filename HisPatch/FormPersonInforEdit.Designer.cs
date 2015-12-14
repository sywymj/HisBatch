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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPersonInforEdit));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelCurOper = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonCam = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSelPic = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSaveReg = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDel = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonQuery = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonGetApplyTable = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxAvatar = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelCurOper});
            this.statusStrip1.Location = new System.Drawing.Point(0, 429);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(745, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelCurOper
            // 
            this.toolStripStatusLabelCurOper.AutoSize = false;
            this.toolStripStatusLabelCurOper.Name = "toolStripStatusLabelCurOper";
            this.toolStripStatusLabelCurOper.Size = new System.Drawing.Size(200, 17);
            this.toolStripStatusLabelCurOper.Text = "当前用户：";
            this.toolStripStatusLabelCurOper.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonCam,
            this.toolStripButtonSelPic,
            this.toolStripButtonSaveReg,
            this.toolStripButtonDel,
            this.toolStripButtonQuery,
            this.toolStripButtonGetApplyTable,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(745, 25);
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
            // toolStripButtonSaveReg
            // 
            this.toolStripButtonSaveReg.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSaveReg.Image")));
            this.toolStripButtonSaveReg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSaveReg.Name = "toolStripButtonSaveReg";
            this.toolStripButtonSaveReg.Size = new System.Drawing.Size(52, 22);
            this.toolStripButtonSaveReg.Text = "保存";
            this.toolStripButtonSaveReg.Click += new System.EventHandler(this.toolStripButtonSaveReg_Click);
            // 
            // toolStripButtonDel
            // 
            this.toolStripButtonDel.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDel.Image")));
            this.toolStripButtonDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDel.Name = "toolStripButtonDel";
            this.toolStripButtonDel.Size = new System.Drawing.Size(100, 22);
            this.toolStripButtonDel.Text = "删除登记信息";
            // 
            // toolStripButtonQuery
            // 
            this.toolStripButtonQuery.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonQuery.Image")));
            this.toolStripButtonQuery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonQuery.Name = "toolStripButtonQuery";
            this.toolStripButtonQuery.Size = new System.Drawing.Size(52, 22);
            this.toolStripButtonQuery.Text = "查询";
            this.toolStripButtonQuery.Click += new System.EventHandler(this.toolStripButtonQuery_Click);
            // 
            // toolStripButtonGetApplyTable
            // 
            this.toolStripButtonGetApplyTable.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonGetApplyTable.Image")));
            this.toolStripButtonGetApplyTable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonGetApplyTable.Name = "toolStripButtonGetApplyTable";
            this.toolStripButtonGetApplyTable.Size = new System.Drawing.Size(112, 22);
            this.toolStripButtonGetApplyTable.Text = "打印健康检查表";
            this.toolStripButtonGetApplyTable.Click += new System.EventHandler(this.toolStripButtonGetApplyTable_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(112, 22);
            this.toolStripButton1.Text = "签发健康合格证";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(3, 3);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.tableLayoutPanel1.SetRowSpan(this.propertyGrid1, 2);
            this.propertyGrid1.Size = new System.Drawing.Size(259, 398);
            this.propertyGrid1.TabIndex = 0;
            this.propertyGrid1.ToolbarVisible = false;
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(745, 404);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // pictureBoxAvatar
            // 
            this.pictureBoxAvatar.BackColor = System.Drawing.SystemColors.Info;
            this.pictureBoxAvatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxAvatar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxAvatar.Location = new System.Drawing.Point(268, 3);
            this.pictureBoxAvatar.Name = "pictureBoxAvatar";
            this.pictureBoxAvatar.Size = new System.Drawing.Size(474, 360);
            this.pictureBoxAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxAvatar.TabIndex = 1;
            this.pictureBoxAvatar.TabStop = false;
            this.pictureBoxAvatar.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxAvatar_Paint);
            this.pictureBoxAvatar.DoubleClick += new System.EventHandler(this.pictureBoxAvatar_DoubleClick);
            this.pictureBoxAvatar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxAvatar_MouseDown);
            this.pictureBoxAvatar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxAvatar_MouseMove);
            this.pictureBoxAvatar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxAvatar_MouseUp);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Jpeg|*.jpg|Png|*.png|Bmp|*.bmp";
            // 
            // FormPersonInforEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 451);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormPersonInforEdit";
            this.Text = "湖北省从业人员预防性健康检查管理软件 V1.0 Program By Tianmimi";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPersonInforEdit_FormClosing);
            this.Load += new System.EventHandler(this.FormPersonInforEdit_Load);
            this.Resize += new System.EventHandler(this.FormPersonInforEdit_Resize);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
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
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripButton toolStripButtonSaveReg;
        private System.Windows.Forms.ToolStripButton toolStripButtonDel;
        private System.Windows.Forms.ToolStripButton toolStripButtonQuery;
        private System.Windows.Forms.ToolStripButton toolStripButtonGetApplyTable;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelCurOper;
    }
}