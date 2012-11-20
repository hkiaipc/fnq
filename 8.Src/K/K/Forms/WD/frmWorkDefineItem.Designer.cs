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
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCycle = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(267, 460);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(355, 460);
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(19, 15);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(100, 23);
            this.lblName.TabIndex = 21;
            this.lblName.Text = "名称:";
            // 
            // txtGroupName
            // 
            this.txtGroupName.Location = new System.Drawing.Point(131, 12);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(150, 21);
            this.txtGroupName.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(19, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 23;
            this.label1.Text = "周期:";
            // 
            // cmbCycle
            // 
            this.cmbCycle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCycle.FormattingEnabled = true;
            this.cmbCycle.Items.AddRange(new object[] {
            "周",
            "自定义"});
            this.cmbCycle.Location = new System.Drawing.Point(131, 39);
            this.cmbCycle.Name = "cmbCycle";
            this.cmbCycle.Size = new System.Drawing.Size(150, 20);
            this.cmbCycle.TabIndex = 24;
            // 
            // frmWorkDefineItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 496);
            this.Controls.Add(this.cmbCycle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtGroupName);
            this.Name = "frmWorkDefineItem";
            this.Text = "frmWorkDefineItem";
            this.Controls.SetChildIndex(this.okButton, 0);
            this.Controls.SetChildIndex(this.cancelButton, 0);
            this.Controls.SetChildIndex(this.txtGroupName, 0);
            this.Controls.SetChildIndex(this.lblName, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmbCycle, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCycle;
    }
}