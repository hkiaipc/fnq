namespace K.Forms
{
    partial class frmPersonItem
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
            this.txtPersonName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTM = new System.Windows.Forms.TextBox();
            this.btnTmSelect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(186, 95);
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(274, 95);
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(12, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(100, 23);
            this.lblName.TabIndex = 21;
            this.lblName.Text = "名称:";
            // 
            // txtPersonName
            // 
            this.txtPersonName.Location = new System.Drawing.Point(118, 6);
            this.txtPersonName.Name = "txtPersonName";
            this.txtPersonName.Size = new System.Drawing.Size(150, 21);
            this.txtPersonName.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 23;
            this.label1.Text = "TM卡:";
            // 
            // txtTM
            // 
            this.txtTM.BackColor = System.Drawing.Color.White;
            this.txtTM.Location = new System.Drawing.Point(118, 33);
            this.txtTM.Name = "txtTM";
            this.txtTM.ReadOnly = true;
            this.txtTM.Size = new System.Drawing.Size(150, 21);
            this.txtTM.TabIndex = 24;
            // 
            // btnTmSelect
            // 
            this.btnTmSelect.Location = new System.Drawing.Point(274, 31);
            this.btnTmSelect.Name = "btnTmSelect";
            this.btnTmSelect.Size = new System.Drawing.Size(75, 23);
            this.btnTmSelect.TabIndex = 25;
            this.btnTmSelect.Text = "选择...";
            this.btnTmSelect.UseVisualStyleBackColor = true;
            this.btnTmSelect.Click += new System.EventHandler(this.btnTmSelect_Click);
            // 
            // frmPersonItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 129);
            this.Controls.Add(this.btnTmSelect);
            this.Controls.Add(this.txtTM);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtPersonName);
            this.Name = "frmPersonItem";
            this.Text = "人员";
            this.Load += new System.EventHandler(this.frmPersonItem_Load);
            this.Controls.SetChildIndex(this.okButton, 0);
            this.Controls.SetChildIndex(this.cancelButton, 0);
            this.Controls.SetChildIndex(this.txtPersonName, 0);
            this.Controls.SetChildIndex(this.lblName, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtTM, 0);
            this.Controls.SetChildIndex(this.btnTmSelect, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtPersonName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTM;
        private System.Windows.Forms.Button btnTmSelect;
    }
}