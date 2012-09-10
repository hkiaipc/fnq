namespace fnbx
{
    partial class frmML
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ucReplyHL = new fnbx.UCTimespan();
            this.ucArriveHL = new fnbx.UCTimespan();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(141, 132);
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(229, 132);
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.White;
            this.txtName.Location = new System.Drawing.Point(115, 6);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(120, 21);
            this.txtName.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 12);
            this.label1.TabIndex = 20;
            this.label1.Text = "名称:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // ucReplyHL
            // 
            this.ucReplyHL.LabelText = "回单时限:";
            this.ucReplyHL.Location = new System.Drawing.Point(12, 67);
            this.ucReplyHL.Name = "ucReplyHL";
            this.ucReplyHL.Size = new System.Drawing.Size(391, 28);
            this.ucReplyHL.TabIndex = 21;
            this.ucReplyHL.Value = 0;
            // 
            // ucArriveHL
            // 
            this.ucArriveHL.LabelText = "到达时限:";
            this.ucArriveHL.Location = new System.Drawing.Point(12, 33);
            this.ucArriveHL.Name = "ucArriveHL";
            this.ucArriveHL.Size = new System.Drawing.Size(391, 28);
            this.ucArriveHL.TabIndex = 22;
            this.ucArriveHL.Value = 0;
            // 
            // frmML
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 168);
            this.Controls.Add(this.ucArriveHL);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.ucReplyHL);
            this.Name = "frmML";
            this.Text = "报修等级";
            this.Load += new System.EventHandler(this.frmML_Load);
            this.Controls.SetChildIndex(this.ucReplyHL, 0);
            this.Controls.SetChildIndex(this.txtName, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.okButton, 0);
            this.Controls.SetChildIndex(this.cancelButton, 0);
            this.Controls.SetChildIndex(this.ucArriveHL, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private UCTimespan ucReplyHL;
        private UCTimespan ucArriveHL;
    }
}