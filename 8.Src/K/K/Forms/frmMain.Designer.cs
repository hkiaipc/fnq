namespace K
{
    partial class Form1
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
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOption = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPerson = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTM = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWorkDefine = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuKResult = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQuery = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuOption,
            this.mnuHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(434, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(57, 20);
            this.mnuFile.Text = "文件(&F)";
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(152, 22);
            this.mnuExit.Text = "退出(&X)";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // mnuOption
            // 
            this.mnuOption.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuGroup,
            this.mnuPerson,
            this.mnuTM,
            this.mnuWorkDefine,
            this.mnuKResult});
            this.mnuOption.Name = "mnuOption";
            this.mnuOption.Size = new System.Drawing.Size(43, 20);
            this.mnuOption.Text = "操作";
            // 
            // mnuGroup
            // 
            this.mnuGroup.Name = "mnuGroup";
            this.mnuGroup.Size = new System.Drawing.Size(152, 22);
            this.mnuGroup.Text = "部门";
            this.mnuGroup.Click += new System.EventHandler(this.mnuGroup_Click);
            // 
            // mnuPerson
            // 
            this.mnuPerson.Name = "mnuPerson";
            this.mnuPerson.Size = new System.Drawing.Size(152, 22);
            this.mnuPerson.Text = "人员";
            this.mnuPerson.Click += new System.EventHandler(this.mnuPerson_Click);
            // 
            // mnuTM
            // 
            this.mnuTM.Name = "mnuTM";
            this.mnuTM.Size = new System.Drawing.Size(152, 22);
            this.mnuTM.Text = "TM卡";
            this.mnuTM.Click += new System.EventHandler(this.mnuTM_Click);
            // 
            // mnuWorkDefine
            // 
            this.mnuWorkDefine.Name = "mnuWorkDefine";
            this.mnuWorkDefine.Size = new System.Drawing.Size(152, 22);
            this.mnuWorkDefine.Text = "班次";
            this.mnuWorkDefine.Click += new System.EventHandler(this.mnuWorkDefine_Click);
            // 
            // mnuKResult
            // 
            this.mnuKResult.Name = "mnuKResult";
            this.mnuKResult.Size = new System.Drawing.Size(152, 22);
            this.mnuKResult.Text = "KResult";
            this.mnuKResult.Click += new System.EventHandler(this.mnuKResult_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAbout,
            this.mnuQuery});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(58, 20);
            this.mnuHelp.Text = "帮助(&H)";
            // 
            // mnuAbout
            // 
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(113, 22);
            this.mnuAbout.Text = "关于(&A)";
            // 
            // mnuQuery
            // 
            this.mnuQuery.Name = "mnuQuery";
            this.mnuQuery.Size = new System.Drawing.Size(113, 22);
            this.mnuQuery.Text = "Query";
            this.mnuQuery.Click += new System.EventHandler(this.mnuQuery_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 424);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.ToolStripMenuItem mnuOption;
        private System.Windows.Forms.ToolStripMenuItem mnuGroup;
        private System.Windows.Forms.ToolStripMenuItem mnuPerson;
        private System.Windows.Forms.ToolStripMenuItem mnuTM;
        private System.Windows.Forms.ToolStripMenuItem mnuWorkDefine;
        private System.Windows.Forms.ToolStripMenuItem mnuKResult;
        private System.Windows.Forms.ToolStripMenuItem mnuQuery;
    }
}

