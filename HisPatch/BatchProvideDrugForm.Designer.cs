namespace HisPatch
{
    partial class BatchProvideDrugForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BatchProvideDrugForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonQueryValidHjdByDepart = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonBatchPut = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPutDrugRecordQuery = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridViewOutline = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBoxDepart = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewDetail = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOutline)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 459);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(864, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonQueryValidHjdByDepart,
            this.toolStripButtonBatchPut,
            this.toolStripButtonPutDrugRecordQuery});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(864, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonQueryValidHjdByDepart
            // 
            this.toolStripButtonQueryValidHjdByDepart.Image = global::HisPatch.Properties.Resources.CF_Red___Fonts;
            this.toolStripButtonQueryValidHjdByDepart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonQueryValidHjdByDepart.Name = "toolStripButtonQueryValidHjdByDepart";
            this.toolStripButtonQueryValidHjdByDepart.Size = new System.Drawing.Size(52, 22);
            this.toolStripButtonQueryValidHjdByDepart.Text = "查询";
            this.toolStripButtonQueryValidHjdByDepart.Click += new System.EventHandler(this.toolStripButtonQueryValidHjdByDepart_Click);
            // 
            // toolStripButtonBatchPut
            // 
            this.toolStripButtonBatchPut.Image = global::HisPatch.Properties.Resources.CF_Red___Config;
            this.toolStripButtonBatchPut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonBatchPut.Name = "toolStripButtonBatchPut";
            this.toolStripButtonBatchPut.Size = new System.Drawing.Size(76, 22);
            this.toolStripButtonBatchPut.Text = "批量发药";
            this.toolStripButtonBatchPut.Click += new System.EventHandler(this.toolStripButtonBatchPut_Click);
            // 
            // toolStripButtonPutDrugRecordQuery
            // 
            this.toolStripButtonPutDrugRecordQuery.Image = global::HisPatch.Properties.Resources.CF_Red___CD;
            this.toolStripButtonPutDrugRecordQuery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPutDrugRecordQuery.Name = "toolStripButtonPutDrugRecordQuery";
            this.toolStripButtonPutDrugRecordQuery.Size = new System.Drawing.Size(88, 22);
            this.toolStripButtonPutDrugRecordQuery.Text = "发药单查询";
            this.toolStripButtonPutDrugRecordQuery.Click += new System.EventHandler(this.toolStripButtonPutDrugRecordQuery_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridViewOutline);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridViewDetail);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(864, 434);
            this.splitContainer1.SplitterDistance = 258;
            this.splitContainer1.TabIndex = 2;
            // 
            // dataGridViewOutline
            // 
            this.dataGridViewOutline.AllowUserToAddRows = false;
            this.dataGridViewOutline.AllowUserToDeleteRows = false;
            this.dataGridViewOutline.AllowUserToOrderColumns = true;
            this.dataGridViewOutline.AllowUserToResizeRows = false;
            this.dataGridViewOutline.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewOutline.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewOutline.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOutline.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewOutline.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewOutline.Name = "dataGridViewOutline";
            this.dataGridViewOutline.ReadOnly = true;
            this.dataGridViewOutline.RowHeadersWidth = 5;
            this.dataGridViewOutline.RowTemplate.Height = 23;
            this.dataGridViewOutline.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewOutline.Size = new System.Drawing.Size(256, 320);
            this.dataGridViewOutline.TabIndex = 1;
            this.dataGridViewOutline.SelectionChanged += new System.EventHandler(this.dataGridViewOutline_SelectionChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Info;
            this.panel1.Controls.Add(this.comboBoxDepart);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 320);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(256, 112);
            this.panel1.TabIndex = 0;
            // 
            // comboBoxDepart
            // 
            this.comboBoxDepart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDepart.FormattingEnabled = true;
            this.comboBoxDepart.Location = new System.Drawing.Point(77, 3);
            this.comboBoxDepart.Name = "comboBoxDepart";
            this.comboBoxDepart.Size = new System.Drawing.Size(172, 20);
            this.comboBoxDepart.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "开药科室：";
            // 
            // dataGridViewDetail
            // 
            this.dataGridViewDetail.AllowUserToAddRows = false;
            this.dataGridViewDetail.AllowUserToDeleteRows = false;
            this.dataGridViewDetail.AllowUserToOrderColumns = true;
            this.dataGridViewDetail.AllowUserToResizeRows = false;
            this.dataGridViewDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewDetail.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDetail.Location = new System.Drawing.Point(0, 84);
            this.dataGridViewDetail.Name = "dataGridViewDetail";
            this.dataGridViewDetail.ReadOnly = true;
            this.dataGridViewDetail.RowHeadersWidth = 5;
            this.dataGridViewDetail.RowTemplate.Height = 23;
            this.dataGridViewDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDetail.Size = new System.Drawing.Size(600, 348);
            this.dataGridViewDetail.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Info;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(600, 84);
            this.panel2.TabIndex = 1;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoSize = false;
            this.toolStripStatusLabel1.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(200, 17);
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BatchProvideDrugForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 481);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BatchProvideDrugForm";
            this.Text = "住院药房批量发药（HisTool Version1.0 Program By Tianmimi）";
            this.Load += new System.EventHandler(this.BatchProvideDrugForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOutline)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridViewOutline;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewDetail;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripButton toolStripButtonQueryValidHjdByDepart;
        private System.Windows.Forms.ToolStripButton toolStripButtonBatchPut;
        private System.Windows.Forms.ComboBox comboBoxDepart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton toolStripButtonPutDrugRecordQuery;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}