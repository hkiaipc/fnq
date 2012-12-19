﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Xdgk.Common;

namespace K.Forms
{
    public partial class frmConfig :  NUnit.UiKit.SettingsDialogBase 
    {
        public frmConfig()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmConfig_Load(object sender, EventArgs e)
        {
            Config cfg = Config.Default ;
            this.dtpNormalTimeSpan.Value = DateTime.Parse("2000-1-1") + cfg.NormalTimeSpan;
            this.dtpLaterEarlyTimeSpan.Value = DateTime.Parse("2000-1-1") + cfg.LaterEarlyTimeSpan;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Config cfg = Config.Default;
            cfg.NormalTimeSpan = this.dtpNormalTimeSpan.Value.TimeOfDay;
            cfg.LaterEarlyTimeSpan = this.dtpLaterEarlyTimeSpan.Value.TimeOfDay;

            cfg.Save();

            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}