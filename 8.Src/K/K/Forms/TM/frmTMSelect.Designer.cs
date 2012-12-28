namespace K.Forms.TM
{
    partial class frmTMSelect
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(14, 214);
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(102, 214);
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // lvPerson
            // 
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.Name = "lvPerson";
            this.listView1.Size = new System.Drawing.Size(200, 196);
            this.listView1.TabIndex = 20;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.List;
            // 
            // frmTMSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 246);
            this.Controls.Add(this.listView1);
            this.Name = "frmTMSelect";
            this.Text = "TM卡选择";
            this.Load += new System.EventHandler(this.frmTMSelect_Load);
            this.Controls.SetChildIndex(this.okButton, 0);
            this.Controls.SetChildIndex(this.cancelButton, 0);
            this.Controls.SetChildIndex(this.listView1, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
    }
}