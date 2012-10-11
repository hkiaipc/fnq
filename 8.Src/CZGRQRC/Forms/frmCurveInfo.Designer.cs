namespace FNGRQRC
{
    partial class frmCurveInfo
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
            this.ucCurveSelectCondition1 = new FNGRQRC.UCCurveSelectCondition();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(21, 310);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(109, 310);
            // 
            // ucCurveSelectCondition1
            // 
            this.ucCurveSelectCondition1.Begin = new System.DateTime(2010, 10, 11, 0, 0, 0, 0);
            this.ucCurveSelectCondition1.ClientSize = new System.Drawing.Size(161, 265);
            this.ucCurveSelectCondition1.End = new System.DateTime(2010, 10, 12, 0, 0, 0, 0);
            this.ucCurveSelectCondition1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.ucCurveSelectCondition1.Location = new System.Drawing.Point(12, 12);
            this.ucCurveSelectCondition1.MaximizeBox = false;
            this.ucCurveSelectCondition1.MinimizeBox = false;
            this.ucCurveSelectCondition1.Name = "ucCurveSelectCondition1";
            this.ucCurveSelectCondition1.ShowInTaskbar = false;
            this.ucCurveSelectCondition1.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ucCurveSelectCondition1.StationName = "8632部队";
            this.ucCurveSelectCondition1.Text = "Settings";
            this.ucCurveSelectCondition1.Visible = false;
            this.ucCurveSelectCondition1.Load += new System.EventHandler(this.ucCurveSelectCondition1_Load);
            // 
            // frmCurveInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(198, 361);
            this.Name = "frmCurveInfo";
            this.Text = "frmCurveInfo";
            this.ResumeLayout(false);

        }

        #endregion

        private UCCurveSelectCondition ucCurveSelectCondition1;
    }
}