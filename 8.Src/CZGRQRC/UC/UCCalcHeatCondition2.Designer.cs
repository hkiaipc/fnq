namespace FNGRQRC.UC
{
    partial class UCCalcHeatCondition2
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
            this.dtpEndDT = new System.Windows.Forms.DateTimePicker();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(5, 184);
            // 
            // dtpBeginTime
            // 
            this.dtpBeginTime.Location = new System.Drawing.Point(6, 59);
            this.dtpBeginTime.Value = new System.DateTime(2000, 1, 1, 8, 0, 0, 0);
            // 
            // dtpBegin
            // 
            this.dtpBegin.Value = new System.DateTime(2010, 1, 25, 0, 0, 0, 0);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(90, 184);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpEndTime);
            this.groupBox1.Controls.Add(this.dtpEndDT);
            this.groupBox1.Size = new System.Drawing.Size(163, 175);
            this.groupBox1.Controls.SetChildIndex(this.label3, 0);
            this.groupBox1.Controls.SetChildIndex(this.dtpEndDT, 0);
            this.groupBox1.Controls.SetChildIndex(this.dtpBegin, 0);
            this.groupBox1.Controls.SetChildIndex(this.dtpBeginTime, 0);
            this.groupBox1.Controls.SetChildIndex(this.label2, 0);
            this.groupBox1.Controls.SetChildIndex(this.dtpEndTime, 0);
            this.groupBox1.Controls.SetChildIndex(this.label1, 0);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(7, 83);
            this.label3.Visible = false;
            // 
            // label2
            // 
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.Text = "起始时间：";
            // 
            // dtpEndDT
            // 
            this.dtpEndDT.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDT.Location = new System.Drawing.Point(6, 119);
            this.dtpEndDT.Name = "dtpEndDT";
            this.dtpEndDT.Size = new System.Drawing.Size(151, 21);
            this.dtpEndDT.TabIndex = 6;
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpEndTime.Location = new System.Drawing.Point(6, 146);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.ShowUpDown = true;
            this.dtpEndTime.Size = new System.Drawing.Size(151, 21);
            this.dtpEndTime.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "结束时间：";
            // 
            // UCCalcHeatCondition2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "UCCalcHeatCondition2";
            this.Size = new System.Drawing.Size(174, 213);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.DateTimePicker dtpEndDT;
    }
}
