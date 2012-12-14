using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace K.UC
{
    public partial class UCPersonResults : UserControl
    {
        public UCPersonResults()
        {
            InitializeComponent();
        }
        public TabControl TabC
        {
            get
            {
                return this.tabPersonResult;
            }
        }
    }
}
