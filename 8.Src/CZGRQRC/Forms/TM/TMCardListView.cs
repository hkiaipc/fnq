using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace FNGRQRC
{
    internal class TMCardListView : ListView
    {
        private ColumnHeader chCardSN;
        private ColumnHeader chPerson;
        private ColumnHeader chRemark;
        private System.ComponentModel.IContainer components;

        /// <summary>
        /// 
        /// </summary>
        public TMCardListView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitializeComponent()
        {
            this.chCardSN = new System.Windows.Forms.ColumnHeader();
            this.chPerson = new System.Windows.Forms.ColumnHeader();
            this.chRemark = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // chCardSN
            // 
            this.chCardSN.Text = "卡号";
            this.chCardSN.Width = 120;
            // 
            // chPerson
            // 
            this.chPerson.Text = "人员";
            this.chPerson.Width = 90;
            // 
            // chRemark
            // 
            this.chRemark.Text = "备注";
            this.chRemark.Width = 120;
            // 
            // TMCardListView
            // 
            this.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chCardSN,
            this.chPerson,
            this.chRemark});
            this.FullRowSelect = true;
            this.ResumeLayout(false);

        }
    }
}
