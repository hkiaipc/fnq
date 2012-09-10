using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace fnbx
{
    public partial class UCTimespan : UserControl
    {
        public UCTimespan()
        {
            InitializeComponent();
            this.comboBox1.Text = this.comboBox1.Text = comboBox1.Items[0].ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCTimespan_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public string LabelText
        {
            get { return this.label4.Text; }
            set { this.label4.Text = value; }
        }

        /// <summary>
        /// 分钟
        /// </summary>
        public int Value
        {
            get
            {
                if (this.comboBox1.Text == "分钟")
                {
                    return (int)this.numValue.Value;
                }
                if (this.comboBox1.Text == "小时")
                {
                    return (int)(this.numValue.Value * 60);
                }
                else
                {
                    return -1;
                }
                //throw new NotImplementedException();
            }
            set
            {

                if (value >= 60 && value % 60 == 0)
                {
                    this.comboBox1.Text = "小时";
                    this.numValue.Value = value / 60;
                }
                else
                {
                    this.comboBox1.Text = "分钟";
                    this.numValue.Value = value;
                }
            }
        }
    }
}
