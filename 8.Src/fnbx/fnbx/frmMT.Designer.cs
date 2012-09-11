namespace fnbx
{
    partial class frmMT
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
            this.lblStatus = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnModifyStatus = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTMStatus = new System.Windows.Forms.TextBox();
            this.ucMt1 = new fnbx.UCMt();
            this.ucRp1 = new fnbx.UCRp();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(463, 415);
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(551, 415);
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStatus.Location = new System.Drawing.Point(0, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(635, 18);
            this.lblStatus.TabIndex = 38;
            this.lblStatus.Text = "状态 ...";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(2, 21);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(633, 388);
            this.tabControl1.TabIndex = 39;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ucMt1);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(625, 363);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ucRp1);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(625, 363);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnModifyStatus
            // 
            this.btnModifyStatus.Location = new System.Drawing.Point(211, 415);
            this.btnModifyStatus.Name = "btnModifyStatus";
            this.btnModifyStatus.Size = new System.Drawing.Size(75, 23);
            this.btnModifyStatus.TabIndex = 40;
            this.btnModifyStatus.Text = "*";
            this.btnModifyStatus.UseVisualStyleBackColor = true;
            this.btnModifyStatus.Click += new System.EventHandler(this.btnModifyStatus_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 421);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 41;
            this.label1.Text = "label1";
            // 
            // txtTMStatus
            // 
            this.txtTMStatus.Location = new System.Drawing.Point(59, 417);
            this.txtTMStatus.Name = "txtTMStatus";
            this.txtTMStatus.Size = new System.Drawing.Size(146, 21);
            this.txtTMStatus.TabIndex = 42;
            // 
            // ucMt1
            // 
            this.ucMt1.Location = new System.Drawing.Point(6, 6);
            this.ucMt1.Maintain = null;
            this.ucMt1.Name = "ucMt1";
            this.ucMt1.Size = new System.Drawing.Size(573, 331);
            this.ucMt1.TabIndex = 0;
            // 
            // ucRp1
            // 
            this.ucRp1.Location = new System.Drawing.Point(6, 6);
            this.ucRp1.Name = "ucRp1";
            this.ucRp1.Size = new System.Drawing.Size(586, 251);
            this.ucRp1.TabIndex = 0;
            // 
            // frmMT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 451);
            this.Controls.Add(this.txtTMStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnModifyStatus);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblStatus);
            this.Name = "frmMT";
            this.Text = "报修";
            this.Load += new System.EventHandler(this.frmMT_Load);
            this.Controls.SetChildIndex(this.okButton, 0);
            this.Controls.SetChildIndex(this.cancelButton, 0);
            this.Controls.SetChildIndex(this.lblStatus, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.btnModifyStatus, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.txtTMStatus, 0);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private UCMt ucMt1;
        private UCRp ucRp1;
        private System.Windows.Forms.Button btnModifyStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTMStatus;
    }
}