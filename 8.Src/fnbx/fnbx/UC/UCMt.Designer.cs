namespace fnbx
{
    partial class UCMt
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
            this.txtOperatorName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.cmbML = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpPose = new fnbx.UCDateTimePicker();
            this.dtpBegin = new fnbx.UCDateTimePicker();
            this.dtpTimeout = new fnbx.UCDateTimePicker();
            this.SuspendLayout();
            // 
            // txtOperatorName
            // 
            this.txtOperatorName.Location = new System.Drawing.Point(109, 120);
            this.txtOperatorName.Multiline = true;
            this.txtOperatorName.Name = "txtOperatorName";
            this.txtOperatorName.ReadOnly = true;
            this.txtOperatorName.Size = new System.Drawing.Size(198, 20);
            this.txtOperatorName.TabIndex = 55;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(3, 120);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 18);
            this.label9.TabIndex = 54;
            this.label9.Text = "接线员:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(109, 146);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtContent.Size = new System.Drawing.Size(496, 111);
            this.txtContent.TabIndex = 52;
            // 
            // cmbML
            // 
            this.cmbML.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbML.FormattingEnabled = true;
            this.cmbML.Location = new System.Drawing.Point(108, 59);
            this.cmbML.Name = "cmbML";
            this.cmbML.Size = new System.Drawing.Size(199, 20);
            this.cmbML.TabIndex = 47;
            this.cmbML.SelectedIndexChanged += new System.EventHandler(this.cmbML_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(3, 146);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 18);
            this.label7.TabIndex = 45;
            this.label7.Text = "报修内容:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 18);
            this.label4.TabIndex = 42;
            this.label4.Text = "报修等级:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 21);
            this.label3.TabIndex = 41;
            this.label3.Text = "维修时间:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 40;
            this.label2.Text = "报修时间:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(3, 85);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 21);
            this.label10.TabIndex = 56;
            this.label10.Text = "超时时间:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpPose
            // 
            this.dtpPose.Location = new System.Drawing.Point(109, 5);
            this.dtpPose.Name = "dtpPose";
            this.dtpPose.Readonly = false;
            this.dtpPose.Size = new System.Drawing.Size(200, 21);
            this.dtpPose.TabIndex = 60;
            this.dtpPose.Value = new System.DateTime(2012, 9, 12, 14, 23, 39, 0);
            // 
            // dtpBegin
            // 
            this.dtpBegin.Location = new System.Drawing.Point(109, 32);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.Readonly = false;
            this.dtpBegin.Size = new System.Drawing.Size(200, 21);
            this.dtpBegin.TabIndex = 59;
            this.dtpBegin.Value = new System.DateTime(2012, 9, 12, 14, 23, 24, 0);
            this.dtpBegin.ValueChanged += new System.EventHandler(this.dtpBegin_ValueChanged);
            // 
            // dtpTimeout
            // 
            this.dtpTimeout.Location = new System.Drawing.Point(109, 85);
            this.dtpTimeout.Name = "dtpTimeout";
            this.dtpTimeout.Readonly = false;
            this.dtpTimeout.Size = new System.Drawing.Size(200, 21);
            this.dtpTimeout.TabIndex = 58;
            this.dtpTimeout.Value = new System.DateTime(2012, 9, 12, 14, 22, 47, 0);
            // 
            // UCMt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dtpPose);
            this.Controls.Add(this.dtpBegin);
            this.Controls.Add(this.dtpTimeout);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtOperatorName);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.cmbML);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "UCMt";
            this.Size = new System.Drawing.Size(621, 279);
            this.Load += new System.EventHandler(this.UCMt_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOperatorName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.ComboBox cmbML;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label10;
        private UCDateTimePicker dtpTimeout;
        private UCDateTimePicker dtpBegin;
        private UCDateTimePicker dtpPose;
    }
}
