namespace FNGRQRC.Forms
{
    partial class frmSettings
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
            this.lblUPAlarmColor = new System.Windows.Forms.Label();
            this.lblLowAlarmcolor = new System.Windows.Forms.Label();
            this.lblNormalColor = new System.Windows.Forms.Label();
            this.clrUPAlarm = new System.Windows.Forms.Label();
            this.clrLowAlarm = new System.Windows.Forms.Label();
            this.clrNormal = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(295, 370);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(383, 370);
            // 
            // lblUPAlarmColor
            // 
            this.lblUPAlarmColor.AutoSize = true;
            this.lblUPAlarmColor.Location = new System.Drawing.Point(12, 16);
            this.lblUPAlarmColor.Name = "lblUPAlarmColor";
            this.lblUPAlarmColor.Size = new System.Drawing.Size(71, 12);
            this.lblUPAlarmColor.TabIndex = 19;
            this.lblUPAlarmColor.Text = "超限报警色:";
            // 
            // lblLowAlarmcolor
            // 
            this.lblLowAlarmcolor.AutoSize = true;
            this.lblLowAlarmcolor.Location = new System.Drawing.Point(12, 45);
            this.lblLowAlarmcolor.Name = "lblLowAlarmcolor";
            this.lblLowAlarmcolor.Size = new System.Drawing.Size(71, 12);
            this.lblLowAlarmcolor.TabIndex = 20;
            this.lblLowAlarmcolor.Text = "低限报警色:";
            // 
            // lblNormalColor
            // 
            this.lblNormalColor.AutoSize = true;
            this.lblNormalColor.Location = new System.Drawing.Point(12, 76);
            this.lblNormalColor.Name = "lblNormalColor";
            this.lblNormalColor.Size = new System.Drawing.Size(47, 12);
            this.lblNormalColor.TabIndex = 21;
            this.lblNormalColor.Text = "正常色:";
            // 
            // clrUPAlarm
            // 
            this.clrUPAlarm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.clrUPAlarm.Location = new System.Drawing.Point(104, 15);
            this.clrUPAlarm.Name = "clrUPAlarm";
            this.clrUPAlarm.Size = new System.Drawing.Size(23, 23);
            this.clrUPAlarm.TabIndex = 23;
            this.clrUPAlarm.Click += new System.EventHandler(this.clrUPAlarm_Click);
            // 
            // clrLowAlarm
            // 
            this.clrLowAlarm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.clrLowAlarm.Location = new System.Drawing.Point(104, 44);
            this.clrLowAlarm.Name = "clrLowAlarm";
            this.clrLowAlarm.Size = new System.Drawing.Size(23, 23);
            this.clrLowAlarm.TabIndex = 24;
            this.clrLowAlarm.Click += new System.EventHandler(this.clrLowAlarm_Click);
            // 
            // clrNormal
            // 
            this.clrNormal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.clrNormal.Location = new System.Drawing.Point(104, 75);
            this.clrNormal.Name = "clrNormal";
            this.clrNormal.Size = new System.Drawing.Size(23, 23);
            this.clrNormal.TabIndex = 25;
            this.clrNormal.Click += new System.EventHandler(this.clrNormal_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(14, 116);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(441, 248);
            this.dataGridView1.TabIndex = 26;
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 407);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.clrNormal);
            this.Controls.Add(this.clrLowAlarm);
            this.Controls.Add(this.clrUPAlarm);
            this.Controls.Add(this.lblNormalColor);
            this.Controls.Add(this.lblUPAlarmColor);
            this.Controls.Add(this.lblLowAlarmcolor);
            this.Name = "frmSettings";
            this.Text = "报警设定";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.Controls.SetChildIndex(this.lblLowAlarmcolor, 0);
            this.Controls.SetChildIndex(this.lblUPAlarmColor, 0);
            this.Controls.SetChildIndex(this.okButton, 0);
            this.Controls.SetChildIndex(this.cancelButton, 0);
            this.Controls.SetChildIndex(this.lblNormalColor, 0);
            this.Controls.SetChildIndex(this.clrUPAlarm, 0);
            this.Controls.SetChildIndex(this.clrLowAlarm, 0);
            this.Controls.SetChildIndex(this.clrNormal, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUPAlarmColor;
        private System.Windows.Forms.Label lblLowAlarmcolor;
        private System.Windows.Forms.Label lblNormalColor;
        private System.Windows.Forms.Label clrUPAlarm;
        private System.Windows.Forms.Label clrLowAlarm;
        private System.Windows.Forms.Label clrNormal;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}