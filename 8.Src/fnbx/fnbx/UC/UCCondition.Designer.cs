namespace fnbx
{
    partial class UCCondition
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
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.chkTime = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbIt = new System.Windows.Forms.ComboBox();
            this.dtpEnd = new fnbx.UCDateTimePicker();
            this.dtpBegin = new fnbx.UCDateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkIT = new System.Windows.Forms.CheckBox();
            this.chkStatus = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(6, 42);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(200, 20);
            this.cmbStatus.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(9, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "至:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(141, 271);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "查询";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // chkTime
            // 
            this.chkTime.AutoSize = true;
            this.chkTime.Location = new System.Drawing.Point(6, 83);
            this.chkTime.Name = "chkTime";
            this.chkTime.Size = new System.Drawing.Size(54, 16);
            this.chkTime.TabIndex = 7;
            this.chkTime.Text = "时间:";
            this.chkTime.UseVisualStyleBackColor = true;
            this.chkTime.CheckedChanged += new System.EventHandler(this.chkTime_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(9, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 8;
            this.label2.Text = "从:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // cmbIt
            // 
            this.cmbIt.FormattingEnabled = true;
            this.cmbIt.Location = new System.Drawing.Point(6, 233);
            this.cmbIt.Name = "cmbIt";
            this.cmbIt.Size = new System.Drawing.Size(200, 20);
            this.cmbIt.TabIndex = 10;
            // 
            // dtpEnd
            // 
            this.dtpEnd.Location = new System.Drawing.Point(6, 174);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Readonly = false;
            this.dtpEnd.Size = new System.Drawing.Size(200, 21);
            this.dtpEnd.TabIndex = 4;
            this.dtpEnd.Value = new System.DateTime(2012, 9, 24, 10, 48, 50, 0);
            // 
            // dtpBegin
            // 
            this.dtpBegin.Location = new System.Drawing.Point(6, 124);
            this.dtpBegin.Name = "dtpBegin";
            this.dtpBegin.Readonly = false;
            this.dtpBegin.Size = new System.Drawing.Size(200, 21);
            this.dtpBegin.TabIndex = 2;
            this.dtpBegin.Value = new System.DateTime(2012, 9, 24, 10, 48, 50, 0);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkIT);
            this.groupBox1.Controls.Add(this.chkStatus);
            this.groupBox1.Controls.Add(this.chkTime);
            this.groupBox1.Controls.Add(this.cmbIt);
            this.groupBox1.Controls.Add(this.cmbStatus);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpBegin);
            this.groupBox1.Controls.Add(this.dtpEnd);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(213, 262);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "条件";
            // 
            // chkIT
            // 
            this.chkIT.AutoSize = true;
            this.chkIT.Location = new System.Drawing.Point(6, 211);
            this.chkIT.Name = "chkIT";
            this.chkIT.Size = new System.Drawing.Size(66, 16);
            this.chkIT.TabIndex = 12;
            this.chkIT.Text = "联系人:";
            this.chkIT.UseVisualStyleBackColor = true;
            this.chkIT.CheckedChanged += new System.EventHandler(this.chkIT_CheckedChanged);
            // 
            // chkStatus
            // 
            this.chkStatus.AutoSize = true;
            this.chkStatus.Location = new System.Drawing.Point(6, 20);
            this.chkStatus.Name = "chkStatus";
            this.chkStatus.Size = new System.Drawing.Size(54, 16);
            this.chkStatus.TabIndex = 11;
            this.chkStatus.Text = "状态:";
            this.chkStatus.UseVisualStyleBackColor = true;
            this.chkStatus.CheckedChanged += new System.EventHandler(this.chkStatus_CheckedChanged);
            // 
            // UCCondition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOK);
            this.Name = "UCCondition";
            this.Size = new System.Drawing.Size(220, 324);
            this.Load += new System.EventHandler(this.UCCondition_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbStatus;
        private UCDateTimePicker dtpBegin;
        private System.Windows.Forms.Label label3;
        private UCDateTimePicker dtpEnd;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.CheckBox chkTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbIt;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkIT;
        private System.Windows.Forms.CheckBox chkStatus;
    }
}
