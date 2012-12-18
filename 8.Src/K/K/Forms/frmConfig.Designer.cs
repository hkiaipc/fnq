namespace K.Forms
{
    partial class frmConfig
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
            this.dtpNormalTimeSpan = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpLaterEarlyTimeSpan = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(11, 128);
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(99, 128);
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // dtpNormalTimeSpan
            // 
            this.dtpNormalTimeSpan.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpNormalTimeSpan.Location = new System.Drawing.Point(12, 31);
            this.dtpNormalTimeSpan.Name = "dtpNormalTimeSpan";
            this.dtpNormalTimeSpan.Size = new System.Drawing.Size(150, 21);
            this.dtpNormalTimeSpan.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 12);
            this.label1.TabIndex = 20;
            this.label1.Text = "正常上(下)班时间范围:";
            // 
            // dtpLaterEarlyTimeSpan
            // 
            this.dtpLaterEarlyTimeSpan.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpLaterEarlyTimeSpan.Location = new System.Drawing.Point(12, 84);
            this.dtpLaterEarlyTimeSpan.Name = "dtpLaterEarlyTimeSpan";
            this.dtpLaterEarlyTimeSpan.Size = new System.Drawing.Size(150, 21);
            this.dtpLaterEarlyTimeSpan.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 12);
            this.label2.TabIndex = 22;
            this.label2.Text = "迟到(早退)时间范围:";
            // 
            // frmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(183, 167);
            this.Controls.Add(this.dtpLaterEarlyTimeSpan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpNormalTimeSpan);
            this.Controls.Add(this.label1);
            this.Name = "frmConfig";
            this.Text = "选项";
            this.Load += new System.EventHandler(this.frmConfig_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.dtpNormalTimeSpan, 0);
            this.Controls.SetChildIndex(this.okButton, 0);
            this.Controls.SetChildIndex(this.cancelButton, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.dtpLaterEarlyTimeSpan, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpNormalTimeSpan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpLaterEarlyTimeSpan;
        private System.Windows.Forms.Label label2;
    }
}