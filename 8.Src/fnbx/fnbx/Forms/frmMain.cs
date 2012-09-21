using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace fnbx
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //frmML f = new frmML();
            //frmMLList f = new frmMLList();
            //frmOperatorList f = new frmOperatorList();
            frmFlowList f = new frmFlowList();
            f.ShowDialog();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            RefreshLoginStatus();

            mnuMTQuery_Click(null, null); 
        }

        /// <summary>
        /// 
        /// </summary>
        private void RefreshLoginStatus()
        {
            //
            //
            this.tssLogin.Text = "当前用户: " + App.Default.LoginOperator.op_name +
                string.Format("({0})", App.Default.GetLoginOperatorRight().ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuMTQuery_Click(object sender, EventArgs e)
        {
            frmFlowList f = GetFrmMtList();
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private frmFlowList GetFrmMtList()
        {
            frmFlowList r = null;
            foreach (Form c in this.MdiChildren)
            {
                if (c is frmFlowList)
                {
                    r = c as frmFlowList;
                }
            }

            if (r == null)
            {
                r = new frmFlowList();
                r.MdiParent = this;
                r.Activate();
            }
            return r;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuRelogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin f = new frmLogin();
            if (f.ShowDialog() == DialogResult.OK)
            {
                this.Show();
                this.RefreshLoginStatus();
            }
        }

        private void mnuAbout_Click(object sender, EventArgs e)
        {
        }
    }
}
