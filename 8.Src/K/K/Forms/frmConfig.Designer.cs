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
            this.dtpNormalStartWorkTimeSpan = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpLaterEarlyTimeSpan = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpNormalStopWorkTimeSpan = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(10, 56);
            this.okButton.TabIndex = 6;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(97, 56);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // dtpNormalStartWorkTimeSpan
            // 
            this.dtpNormalStartWorkTimeSpan.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpNormalStartWorkTimeSpan.Location = new System.Drawing.Point(12, 246);
            this.dtpNormalStartWorkTimeSpan.Name = "dtpNormalStartWorkTimeSpan";
            this.dtpNormalStartWorkTimeSpan.Size = new System.Drawing.Size(159, 21);
            this.dtpNormalStartWorkTimeSpan.TabIndex = 1;
            this.dtpNormalStartWorkTimeSpan.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 231);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "正常上班时间范围:";
            this.label1.Visible = false;
            // 
            // dtpLaterEarlyTimeSpan
            // 
            this.dtpLaterEarlyTimeSpan.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpLaterEarlyTimeSpan.Location = new System.Drawing.Point(11, 29);
            this.dtpLaterEarlyTimeSpan.Name = "dtpLaterEarlyTimeSpan";
            this.dtpLaterEarlyTimeSpan.Size = new System.Drawing.Size(159, 21);
            this.dtpLaterEarlyTimeSpan.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "迟到(早退)时间范围:";
            // 
            // dtpNormalStopWorkTimeSpan
            // 
            this.dtpNormalStopWorkTimeSpan.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpNormalStopWorkTimeSpan.Location = new System.Drawing.Point(11, 295);
            this.dtpNormalStopWorkTimeSpan.Name = "dtpNormalStopWorkTimeSpan";
            this.dtpNormalStopWorkTimeSpan.Size = new System.Drawing.Size(159, 21);
            this.dtpNormalStopWorkTimeSpan.TabIndex = 3;
            this.dtpNormalStopWorkTimeSpan.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 280);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "正常下班时间范围:";
            this.label3.Visible = false;
            // 
            // frmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(180, 89);
            this.Controls.Add(this.dtpNormalStopWorkTimeSpan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpLaterEarlyTimeSpan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpNormalStartWorkTimeSpan);
            this.Controls.Add(this.label1);
            this.Name = "frmConfig";
            this.Text = "选项";
            this.Load += new System.EventHandler(this.frmConfig_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.dtpNormalStartWorkTimeSpan, 0);
            this.Controls.SetChildIndex(this.okButton, 0);
            this.Controls.SetChildIndex(this.cancelButton, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.dtpLaterEarlyTimeSpan, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.dtpNormalStopWorkTimeSpan, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpNormalStartWorkTimeSpan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpLaterEarlyTimeSpan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpNormalStopWorkTimeSpan;
        private System.Windows.Forms.Label label3;
    }
}