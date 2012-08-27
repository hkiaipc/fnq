using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace CZGRQRC
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBackForeColor
    {
        Color BackColor { get; set; }
        Color ForeColor { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public interface IDataGridViewFont
    {
        Font DataGridViewFont { get; set; }
    }
}
