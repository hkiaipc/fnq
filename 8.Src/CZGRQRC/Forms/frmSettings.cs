using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Xdgk.Common;

namespace FNGRQRC.Forms
{
    public partial class frmSettings : NUnit.UiKit.SettingsDialogBase
    {
        /// <summary>
        /// 
        /// </summary>
        public frmSettings()
        {
            InitializeComponent();
            this.InitDataGird();
        }

        /// <summary>
        /// 
        /// </summary>
        private DGVColumnConfigCollection ColumnConfigs
        {
            get 
            {
                if (_columnConfigs == null)
                {
                    _columnConfigs = new DGVColumnConfigCollection();
                    _columnConfigs.Add(new DGVColumnConfig("Text", "","名称"));
                    _columnConfigs.Add(new DGVColumnConfig("Min", "", "低限报警值"));
                    _columnConfigs.Add(new DGVColumnConfig("Max", "", "高限报警值"));
                }
                return _columnConfigs;
            }
        } private DGVColumnConfigCollection _columnConfigs;


        /// <summary>
        /// 
        /// </summary>
        private void InitDataGird()
        {
            this.dataGridView1.AutoGenerateColumns = false;
            //foreach (DGVColumnConfig c in this.ColumnConfigs)
            //{
            //    datagridview
            //}
            foreach (DGVColumnConfig cc in this.ColumnConfigs )
            {
                DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                column.Name = cc.DataPropertyName;
                column.HeaderText = cc.Text;
                column.DataPropertyName = cc.DataPropertyName;
                column.DefaultCellStyle.Format = cc.Format;
                //column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                this.dataGridView1.Columns.Add(column);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmSettings_Load(object sender, EventArgs e)
        {
            this.clrUPAlarm.BackColor = Config.Default.ColorConifg.HighColor;
            this.clrLowAlarm.BackColor = Config.Default.ColorConifg.LowColor;
            this.clrNormal.BackColor = Config.Default.ColorConifg.NormalColor;


            //this.dataGridView1.DataSource = Config.Default.AlarmDefineCollection;
            this.dataGridView1.DataSource = this.RangeAlarmDefineList;
        }


        /// <summary>
        /// 
        /// </summary>
        private List<RangeAlarmDefine> RangeAlarmDefineList
        {
            get
            {
                List<RangeAlarmDefine> list = new List<RangeAlarmDefine>();
                foreach (AlarmDefine ad in Config.Default.AlarmDefineCollection)
                {
                    RangeAlarmDefine rad = ad as RangeAlarmDefine;
                    if (rad != null)
                    {
                        list.Add(rad);
                    }
                }
                return list;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clrUPAlarm_Click(object sender, EventArgs e)
        {
            SetColor(sender as Label, "HighAlarm");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clrLowAlarm_Click(object sender, EventArgs e)
        {
            SetColor(sender as Label, "LowAlarm");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clrNormal_Click(object sender, EventArgs e)
        {
            SetColor(sender as Label, "Normal");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lbl"></param>
        private void SetColor(Label lbl, string propertyName)
        {
            this.colorDialog1.Color = lbl.BackColor;
            DialogResult dr = this.colorDialog1.ShowDialog();

            if (dr == DialogResult.OK)
            {
                lbl.BackColor = this.colorDialog1.Color;
                // property value
                //
                if (propertyName == "LowAlarm")
                {
                    Config.Default.ColorConifg.LowColor = lbl.BackColor;
                }
                else if( propertyName == "Normal" )
                {
                    Config.Default.ColorConifg.NormalColor = lbl.BackColor;
                }
                else if (propertyName == "HighAlarm")
                {
                    Config.Default.ColorConifg.HighColor = lbl.BackColor;
                }
            }
        }
    }
}
