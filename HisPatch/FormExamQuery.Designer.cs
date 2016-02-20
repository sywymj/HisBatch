namespace HisPatch
{
    partial class FormExamQuery
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormExamQuery));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBoxQueryName = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonQuery = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelSelCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridViewOutline = new System.Windows.Forms.DataGridView();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonBatchSign = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonBatchPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonBatchBack = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOutline)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.CanOverflow = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripSeparator1,
            this.toolStripLabel2,
            this.toolStripSeparator2,
            this.toolStripLabel3,
            this.toolStripTextBoxQueryName,
            this.toolStripSeparator3,
            this.toolStripButtonQuery,
            this.toolStripSeparator4,
            this.toolStripButtonBatchSign,
            this.toolStripButtonBatchPrint,
            this.toolStripButtonBatchBack});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(709, 25);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(56, 22);
            this.toolStripLabel1.Text = "开始时间";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(56, 22);
            this.toolStripLabel2.Text = "结束时间";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(107, 22);
            this.toolStripLabel3.Text = "姓名（工作单位）:";
            // 
            // toolStripTextBoxQueryName
            // 
            this.toolStripTextBoxQueryName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStripTextBoxQueryName.Name = "toolStripTextBoxQueryName";
            this.toolStripTextBoxQueryName.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonQuery
            // 
            this.toolStripButtonQuery.Image = global::HisPatch.Properties.Resources.CF_Red___Games;
            this.toolStripButtonQuery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonQuery.Name = "toolStripButtonQuery";
            this.toolStripButtonQuery.Size = new System.Drawing.Size(52, 22);
            this.toolStripButtonQuery.Text = "查询";
            this.toolStripButtonQuery.Click += new System.EventHandler(this.toolStripButtonQuery_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelSelCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 339);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(709, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelSelCount
            // 
            this.toolStripStatusLabelSelCount.AutoSize = false;
            this.toolStripStatusLabelSelCount.Name = "toolStripStatusLabelSelCount";
            this.toolStripStatusLabelSelCount.Size = new System.Drawing.Size(200, 17);
            this.toolStripStatusLabelSelCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.dataGridViewOutline.Location = new System.Drawing.Point(0, 25);
            this.dataGridViewOutline.MultiSelect = false;
            this.dataGridViewOutline.Name = "dataGridViewOutline";
            this.dataGridViewOutline.RowHeadersWidth = 5;
            this.dataGridViewOutline.RowTemplate.Height = 23;
            this.dataGridViewOutline.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewOutline.Size = new System.Drawing.Size(709, 314);
            this.dataGridViewOutline.TabIndex = 3;
            this.dataGridViewOutline.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewOutline_CellDoubleClick);
            this.dataGridViewOutline.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewOutline_CellMouseUp);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonBatchSign
            // 
            this.toolStripButtonBatchSign.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonBatchSign.Image")));
            this.toolStripButtonBatchSign.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonBatchSign.Name = "toolStripButtonBatchSign";
            this.toolStripButtonBatchSign.Size = new System.Drawing.Size(64, 22);
            this.toolStripButtonBatchSign.Text = "批签发";
            this.toolStripButtonBatchSign.Click += new System.EventHandler(this.toolStripButtonBatchSign_Click);
            // 
            // toolStripButtonBatchPrint
            // 
            this.toolStripButtonBatchPrint.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonBatchPrint.Image")));
            this.toolStripButtonBatchPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonBatchPrint.Name = "toolStripButtonBatchPrint";
            this.toolStripButtonBatchPrint.Size = new System.Drawing.Size(76, 22);
            this.toolStripButtonBatchPrint.Text = "批打印正";
            // 
            // toolStripButtonBatchBack
            // 
            this.toolStripButtonBatchBack.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonBatchBack.Image")));
            this.toolStripButtonBatchBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonBatchBack.Name = "toolStripButtonBatchBack";
            this.toolStripButtonBatchBack.Size = new System.Drawing.Size(76, 22);
            this.toolStripButtonBatchBack.Text = "批打印反";
            // 
            // FormExamQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 361);
            this.Controls.Add(this.dataGridViewOutline);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormExamQuery";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormExamQuery";
            this.Load += new System.EventHandler(this.FormExamQuery_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOutline)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonQuery;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.DataGridView dataGridViewOutline;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxQueryName;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelSelCount;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButtonBatchSign;
        private System.Windows.Forms.ToolStripButton toolStripButtonBatchPrint;
        private System.Windows.Forms.ToolStripButton toolStripButtonBatchBack;
    }
}