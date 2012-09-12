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
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.cmdFee = new System.Windows.Forms.ComboBox();
            this.cmbML = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIntroducerName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpTimeout = new fnbx.UCDateTimePicker();
            this.dtpBegin = new fnbx.UCDateTimePicker();
            this.dtpPose = new fnbx.UCDateTimePicker();
            this.SuspendLayout();
            // 
            // txtOperatorName
            // 
            this.txtOperatorName.Location = new System.Drawing.Point(406, 118);
            this.txtOperatorName.Multiline = true;
            this.txtOperatorName.Name = "txtOperatorName";
            this.txtOperatorName.ReadOnly = true;
            this.txtOperatorName.Size = new System.Drawing.Size(198, 20);
            this.txtOperatorName.TabIndex = 55;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(300, 118);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 18);
            this.label9.TabIndex = 54;
            this.label9.Text = "接线员:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(108, 57);
            this.txtPhone.Multiline = true;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(150, 20);
            this.txtPhone.TabIndex = 53;
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(108, 244);
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtContent.Size = new System.Drawing.Size(496, 120);
            this.txtContent.TabIndex = 52;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(108, 178);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAddress.Size = new System.Drawing.Size(496, 60);
            this.txtAddress.TabIndex = 51;
            // 
            // cmdFee
            // 
            this.cmdFee.FormattingEnabled = true;
            this.cmdFee.Location = new System.Drawing.Point(108, 30);
            this.cmdFee.Name = "cmdFee";
            this.cmdFee.Size = new System.Drawing.Size(150, 20);
            this.cmdFee.TabIndex = 50;
            // 
            // cmbML
            // 
            this.cmbML.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbML.FormattingEnabled = true;
            this.cmbML.Location = new System.Drawing.Point(405, 57);
            this.cmbML.Name = "cmbML";
            this.cmbML.Size = new System.Drawing.Size(199, 20);
            this.cmbML.TabIndex = 47;
            this.cmbML.SelectedIndexChanged += new System.EventHandler(this.cmbML_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(2, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 18);
            this.label8.TabIndex = 46;
            this.label8.Text = "缴费情况:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(2, 244);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 18);
            this.label7.TabIndex = 45;
            this.label7.Text = "报修内容:";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(2, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 18);
            this.label6.TabIndex = 44;
            this.label6.Text = "联系地址:";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(2, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 18);
            this.label5.TabIndex = 43;
            this.label5.Text = "联系电话:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(300, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 18);
            this.label4.TabIndex = 42;
            this.label4.Text = "报修等级:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(300, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 21);
            this.label3.TabIndex = 41;
            this.label3.Text = "维修时间:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(300, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 40;
            this.label2.Text = "报修时间:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(2, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 18);
            this.label1.TabIndex = 39;
            this.label1.Text = "联系人:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtIntroducerName
            // 
            this.txtIntroducerName.Location = new System.Drawing.Point(108, 2);
            this.txtIntroducerName.Name = "txtIntroducerName";
            this.txtIntroducerName.Size = new System.Drawing.Size(150, 21);
            this.txtIntroducerName.TabIndex = 38;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(300, 83);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 21);
            this.label10.TabIndex = 56;
            this.label10.Text = "超时时间:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpTimeout
            // 
            this.dtpTimeout.Location = new System.Drawing.Point(406, 83);
            this.dtpTimeout.Name = "dtpTimeout";
            this.dtpTimeout.Size = new System.Drawing.Size(200, 21);
            this.dtpTimeout.TabIndex = 58;
            this.dtpTimeout.Value = new System.DateTime(2012, 9, 12, 14, 22, 47, 0);
            // 
            // dtpBegin
            // 
            this.dtpBegin.Location = new System.Drawing.Point(406, 30);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.Size = new System.Drawing.Size(200, 21);
            this.dtpBegin.TabIndex = 59;
            this.dtpBegin.Value = new System.DateTime(2012, 9, 12, 14, 23, 24, 0);
            // 
            // dtpPose
            // 
            this.dtpPose.Location = new System.Drawing.Point(406, 3);
            this.dtpPose.Name = "dtpPose";
            this.dtpPose.Size = new System.Drawing.Size(200, 21);
            this.dtpPose.TabIndex = 60;
            this.dtpPose.Value = new System.DateTime(2012, 9, 12, 14, 23, 39, 0);
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
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.cmdFee);
            this.Controls.Add(this.cmbML);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIntroducerName);
            this.Name = "UCMt";
            this.Size = new System.Drawing.Size(681, 493);
            this.Load += new System.EventHandler(this.UCMt_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOperatorName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.ComboBox cmdFee;
        private System.Windows.Forms.ComboBox cmbML;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIntroducerName;
        private System.Windows.Forms.Label label10;
        private UCDateTimePicker dtpTimeout;
        private UCDateTimePicker dtpBegin;
        private UCDateTimePicker dtpPose;
    }
}
