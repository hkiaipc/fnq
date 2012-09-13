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
            frmMTList f = new frmMTList();
            f.ShowDialog();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //
            //
            this.tssLogin.Text = "当前用户: " + App.Default.LoginOperator.op_name + 
                string.Format ("({0})",App.Default.GetLoginOperatorRight().ToString());

            mnuMTQuery_Click(null, null); 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuMTQuery_Click(object sender, EventArgs e)
        {
            frmMTList f = GetFrmMtList();
            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private frmMTList GetFrmMtList()
        {
            frmMTList r = null;
            foreach (Form c in this.MdiChildren)
            {
                if (c is frmMTList)
                {
                    r = c as frmMTList;
                }
            }

            if (r == null)
            {
                r = new frmMTList();
                r.MdiParent = this;
                r.Activate();
            }
            return r;
        }
    }
}
