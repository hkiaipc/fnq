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
    }
}
