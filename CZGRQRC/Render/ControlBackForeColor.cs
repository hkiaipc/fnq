using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace CZGRQRC
{
    /// <summary>
    /// 
    /// </summary>
    public class ControlBackForeColor : IBackForeColor
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        public ControlBackForeColor(Control control)
        {
            this.Control = control;
        }

        /// <summary>
        /// 
        /// </summary>
        public Control Control
        {
            get { return _control; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Control");
                _control = value;
            }
        } private Control _control;


        /// <summary>
        /// 
        /// </summary>
        public Color BackColor
        {
            get { return _control.BackColor; }
            set { _control.BackColor = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public Color ForeColor
        {
            get { return _control.ForeColor; }
            set { _control.ForeColor = value; }
        }
    }
}
