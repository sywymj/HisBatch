namespace HisPatch
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.药剂科ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.住院药房ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.住院药房批量发药ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.药剂科ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(883, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 463);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(883, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // 药剂科ToolStripMenuItem
            // 
            this.药剂科ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.住院药房ToolStripMenuItem});
            this.药剂科ToolStripMenuItem.Name = "药剂科ToolStripMenuItem";
            this.药剂科ToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.药剂科ToolStripMenuItem.Text = "药剂科";
            // 
            // 住院药房ToolStripMenuItem
            // 
            this.住院药房ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.住院药房批量发药ToolStripMenuItem});
            this.住院药房ToolStripMenuItem.Name = "住院药房ToolStripMenuItem";
            this.住院药房ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.住院药房ToolStripMenuItem.Text = "住院药房";
            // 
            // 住院药房批量发药ToolStripMenuItem
            // 
            this.住院药房批量发药ToolStripMenuItem.Name = "住院药房批量发药ToolStripMenuItem";
            this.住院药房批量发药ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.住院药房批量发药ToolStripMenuItem.Text = "住院药房批量发药";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 485);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "HisTools(Program by Tianmimi Verson1.0)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem 药剂科ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 住院药房ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 住院药房批量发药ToolStripMenuItem;
    }
}

