namespace K.UC
{
    partial class UCTimeDefine
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
            this.dtpBegin = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDayOffset = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpEndTimeSpan = new System.Windows.Forms.DateTimePicker();
            this.dtpBeginTimeSpan = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // dtpBegin
            // 
            this.dtpBegin.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpBegin.Location = new System.Drawing.Point(194, 3);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.ShowUpDown = true;
            this.dtpBegin.Size = new System.Drawing.Size(97, 21);
            this.dtpBegin.TabIndex = 0;
            this.dtpBegin.Value = new System.DateTime(2012, 11, 21, 8, 0, 0, 0);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpEnd.Location = new System.Drawing.Point(336, 3);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.ShowUpDown = true;
            this.dtpEnd.Size = new System.Drawing.Size(97, 21);
            this.dtpEnd.TabIndex = 1;
            this.dtpEnd.Value = new System.DateTime(2012, 11, 21, 18, 0, 0, 0);
            this.dtpEnd.ValueChanged += new System.EventHandler(this.dtpEnd_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(159, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "从";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(301, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "至";
            // 
            // cmbDayOffset
            // 
            this.cmbDayOffset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDayOffset.FormattingEnabled = true;
            this.cmbDayOffset.Location = new System.Drawing.Point(0, 4);
            this.cmbDayOffset.Name = "cmbDayOffset";
            this.cmbDayOffset.Size = new System.Drawing.Size(150, 20);
            this.cmbDayOffset.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(301, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "延后";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(159, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "提前";
            // 
            // dtpEndTimeSpan
            // 
            this.dtpEndTimeSpan.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpEndTimeSpan.Location = new System.Drawing.Point(336, 30);
            this.dtpEndTimeSpan.Name = "dtpEndTimeSpan";
            this.dtpEndTimeSpan.ShowUpDown = true;
            this.dtpEndTimeSpan.Size = new System.Drawing.Size(97, 21);
            this.dtpEndTimeSpan.TabIndex = 6;
            this.dtpEndTimeSpan.Value = new System.DateTime(2012, 11, 21, 0, 30, 0, 0);
            // 
            // dtpBeginTimeSpan
            // 
            this.dtpBeginTimeSpan.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpBeginTimeSpan.Location = new System.Drawing.Point(194, 30);
            this.dtpBeginTimeSpan.Name = "dtpBeginTimeSpan";
            this.dtpBeginTimeSpan.ShowUpDown = true;
            this.dtpBeginTimeSpan.Size = new System.Drawing.Size(97, 21);
            this.dtpBeginTimeSpan.TabIndex = 5;
            this.dtpBeginTimeSpan.Value = new System.DateTime(2012, 11, 21, 0, 30, 0, 0);
            // 
            // UCTimeDefine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpEndTimeSpan);
            this.Controls.Add(this.dtpBeginTimeSpan);
            this.Controls.Add(this.cmbDayOffset);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.dtpBegin);
            this.Name = "UCTimeDefine";
            this.Size = new System.Drawing.Size(436, 55);
            this.Load += new System.EventHandler(this.UCTimeDefine_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpBegin;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbDayOffset;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpEndTimeSpan;
        private System.Windows.Forms.DateTimePicker dtpBeginTimeSpan;
    }
}
