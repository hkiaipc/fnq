namespace K.Forms.WD
{
    partial class frmWorkDefineItem
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
            this.lblName = new System.Windows.Forms.Label();
            this.txtWorkDefineName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCycleType = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.cmbCycleDayCount = new System.Windows.Forms.ComboBox();
            this.lblStart = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(392, 572);
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(480, 572);
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(19, 15);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(100, 23);
            this.lblName.TabIndex = 21;
            this.lblName.Text = "名称:";
            // 
            // txtWorkDefineName
            // 
            this.txtWorkDefineName.Location = new System.Drawing.Point(131, 12);
            this.txtWorkDefineName.Name = "txtWorkDefineName";
            this.txtWorkDefineName.Size = new System.Drawing.Size(150, 21);
            this.txtWorkDefineName.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(19, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 23;
            this.label1.Text = "周期:";
            // 
            // cmbCycleTyp
            // 
            this.cmbCycleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCycleType.FormattingEnabled = true;
            this.cmbCycleType.Location = new System.Drawing.Point(131, 39);
            this.cmbCycleType.Name = "cmbCycleTyp";
            this.cmbCycleType.Size = new System.Drawing.Size(150, 20);
            this.cmbCycleType.TabIndex = 24;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(596, 102);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 26;
            this.btnAdd.Text = "添加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(19, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 27;
            this.label2.Text = "详细:";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(128, 102);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(462, 464);
            this.flowLayoutPanel1.TabIndex = 28;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(596, 131);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 29;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // cmbCycleDayCount
            // 
            this.cmbCycleDayCount.DropDownHeight = 140;
            this.cmbCycleDayCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCycleDayCount.FormattingEnabled = true;
            this.cmbCycleDayCount.IntegralHeight = false;
            this.cmbCycleDayCount.Items.AddRange(new object[] {
            "周",
            "自定义"});
            this.cmbCycleDayCount.Location = new System.Drawing.Point(287, 39);
            this.cmbCycleDayCount.Name = "cmbCycleDayCount";
            this.cmbCycleDayCount.Size = new System.Drawing.Size(100, 20);
            this.cmbCycleDayCount.TabIndex = 30;
            // 
            // lblStart
            // 
            this.lblStart.Location = new System.Drawing.Point(19, 71);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(100, 23);
            this.lblStart.TabIndex = 31;
            this.lblStart.Text = "开始时间:";
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(131, 67);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(150, 21);
            this.dtpStart.TabIndex = 32;
            this.dtpStart.Value = new System.DateTime(2012, 11, 1, 0, 0, 0, 0);
            // 
            // frmWorkDefineItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 608);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.cmbCycleDayCount);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cmbCycleType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtWorkDefineName);
            this.Name = "frmWorkDefineItem";
            this.Text = "frmWorkDefineItem";
            this.Load += new System.EventHandler(this.frmWorkDefineItem_Load);
            this.Controls.SetChildIndex(this.okButton, 0);
            this.Controls.SetChildIndex(this.cancelButton, 0);
            this.Controls.SetChildIndex(this.txtWorkDefineName, 0);
            this.Controls.SetChildIndex(this.lblName, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmbCycleType, 0);
            this.Controls.SetChildIndex(this.btnAdd, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.btnDelete, 0);
            this.Controls.SetChildIndex(this.flowLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.cmbCycleDayCount, 0);
            this.Controls.SetChildIndex(this.lblStart, 0);
            this.Controls.SetChildIndex(this.dtpStart, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtWorkDefineName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCycleType;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ComboBox cmbCycleDayCount;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.DateTimePicker dtpStart;
    }
}