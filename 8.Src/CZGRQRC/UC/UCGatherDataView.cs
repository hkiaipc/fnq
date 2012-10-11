using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace FNGRQRC
{
    public partial class UCGatherDataGridView : UserControl
    {
        /// <summary>
        /// 
        /// </summary>
        public UCGatherDataGridView()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = false;
            this.dataGridView1.ReadOnly = false;

            this.dataGridView1.ColumnCount = 4;
            this.dataGridView1.Columns[0].Name = "Text";
            this.dataGridView1.Columns[0].DataPropertyName= "Text";
            this.dataGridView1.Columns[0].HeaderText = "名称";
            this.dataGridView1.Columns[0].Width = CalcWidth(8);

            this.dataGridView1.Columns[1].Name = "Max";
            this.dataGridView1.Columns[1].DataPropertyName = "Max";
            this.dataGridView1.Columns[1].HeaderText = "最大";
            this.dataGridView1.Columns[1].Width = CalcWidth(6);

            this.dataGridView1.Columns[2].Name = "Min";
            this.dataGridView1.Columns[2].DataPropertyName= "Min";
            this.dataGridView1.Columns[2].HeaderText = "最小";
            this.dataGridView1.Columns[2].Width = CalcWidth(6);

            this.dataGridView1.Columns[3].Name = "Avg";
            this.dataGridView1.Columns[3].DataPropertyName = "Avg";
            this.dataGridView1.Columns[3].HeaderText = "平均";
            this.dataGridView1.Columns[3].Width = CalcWidth(6);

            // width
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            // line space
            this.dataGridView1.RowHeadersVisible = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private int CalcWidth(int n)
        {
            return n * 8;
        }

        /// <summary>
        /// 
        /// </summary>
        public IList<GatherClass> GatherClasses
        {
            get { return _gatherClasses; }
            set 
            {
                _gatherClasses = value;
                Bind();
            }
        } private IList<GatherClass> _gatherClasses;

        /// <summary>
        /// 
        /// </summary>
        private void Bind()
        {
            this.dataGridView1.DataSource = _gatherClasses;
            this.dataGridView1.Refresh();
            
        }
    }
}
