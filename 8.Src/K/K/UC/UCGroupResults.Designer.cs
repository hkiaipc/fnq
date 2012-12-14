namespace K.UC
{
    partial class UCGroupResults
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabGroupResults = new System.Windows.Forms.TabControl();
            this.SuspendLayout();
            // 
            // tabGroupResults
            // 
            this.tabGroupResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabGroupResults.Location = new System.Drawing.Point(0, 0);
            this.tabGroupResults.Name = "tabGroupResults";
            this.tabGroupResults.SelectedIndex = 0;
            this.tabGroupResults.Size = new System.Drawing.Size(565, 413);
            this.tabGroupResults.TabIndex = 0;
            // 
            // UCGroupResults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabGroupResults);
            this.Name = "UCGroupResults";
            this.Size = new System.Drawing.Size(565, 413);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabGroupResults;
    }
}
