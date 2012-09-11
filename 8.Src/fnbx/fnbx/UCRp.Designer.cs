namespace fnbx
{
    partial class UCRp
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
            this.dtpReceived = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateEnd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.txtWorker = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRpContent = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtOperatorName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dtpReceived
            // 
            this.dtpReceived.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpReceived.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpReceived.Location = new System.Drawing.Point(108, 3);
            this.dtpReceived.Name = "dtpReceived";
            this.dtpReceived.Size = new System.Drawing.Size(150, 21);
            this.dtpReceived.TabIndex = 51;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(2, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 50;
            this.label2.Text = "接单时间:";
            // 
            // dateEnd
            // 
            this.dateEnd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateEnd.Location = new System.Drawing.Point(108, 30);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Size = new System.Drawing.Size(150, 21);
            this.dateEnd.TabIndex = 53;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(2, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 52;
            this.label1.Text = "完成时间:";
            // 
            // txtWorker
            // 
            this.txtWorker.Location = new System.Drawing.Point(108, 57);
            this.txtWorker.Multiline = true;
            this.txtWorker.Name = "txtWorker";
            this.txtWorker.Size = new System.Drawing.Size(150, 20);
            this.txtWorker.TabIndex = 55;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(2, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 18);
            this.label5.TabIndex = 54;
            this.label5.Text = "完成人:";
            // 
            // txtRpContent
            // 
            this.txtRpContent.Location = new System.Drawing.Point(108, 109);
            this.txtRpContent.Multiline = true;
            this.txtRpContent.Name = "txtRpContent";
            this.txtRpContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtRpContent.Size = new System.Drawing.Size(448, 120);
            this.txtRpContent.TabIndex = 57;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(2, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 18);
            this.label7.TabIndex = 56;
            this.label7.Text = "完成内容:";
            // 
            // txtOperatorName
            // 
            this.txtOperatorName.Location = new System.Drawing.Point(108, 83);
            this.txtOperatorName.Multiline = true;
            this.txtOperatorName.Name = "txtOperatorName";
            this.txtOperatorName.ReadOnly = true;
            this.txtOperatorName.Size = new System.Drawing.Size(150, 20);
            this.txtOperatorName.TabIndex = 59;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(2, 83);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 18);
            this.label9.TabIndex = 58;
            this.label9.Text = "回单员:";
            // 
            // UCRp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtOperatorName);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtRpContent);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtWorker);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateEnd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpReceived);
            this.Controls.Add(this.label2);
            this.Name = "UCRp";
            this.Size = new System.Drawing.Size(586, 251);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpReceived;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtWorker;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRpContent;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtOperatorName;
        private System.Windows.Forms.Label label9;
    }
}
