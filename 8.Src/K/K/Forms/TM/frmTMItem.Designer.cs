﻿namespace K.Forms.TM
{
    partial class frmTMItem
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
            this.txtTM = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(110, 129);
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(198, 129);
            // 
            // txtTM
            // 
            this.txtTM.Location = new System.Drawing.Point(120, 12);
            this.txtTM.Name = "txtTM";
            this.txtTM.Size = new System.Drawing.Size(150, 21);
            this.txtTM.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(14, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 27;
            this.label1.Text = "卡号:";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(120, 39);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(150, 84);
            this.txtRemark.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(14, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 29;
            this.label2.Text = "备注:";
            // 
            // frmTMItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 164);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTM);
            this.Controls.Add(this.label1);
            this.Name = "frmTMItem";
            this.Text = "TM卡";
            this.Load += new System.EventHandler(this.frmTMItem_Load);
            this.Controls.SetChildIndex(this.okButton, 0);
            this.Controls.SetChildIndex(this.cancelButton, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtTM, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtRemark, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label2;
    }
}