using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace K.Forms
{
    public partial class frmGather : Form
    {
        private DataTable _tbl;
        public frmGather(DataTable tbl)
        {
            InitializeComponent();
            _tbl = tbl;
        }

        private void frmGather_Load(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = _tbl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            DateTime month = (DateTime)_tbl.ExtendedProperties["month"];
            new DataTableExporter(month, _tbl).Export();
        }
    }
}
