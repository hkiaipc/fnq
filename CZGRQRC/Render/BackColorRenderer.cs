using System;
using System.Collections.Generic;
using System.Text;

namespace CZGRQRC
{
    /// <summary>
    /// 
    /// </summary>
    public class BackColorRenderer : Renderer
    {
        public override void Render(IBackForeColor backForeColor, CompareResult compareResult, ColorConfig colorConfig)
        {
            if (compareResult.IsNormal)
            {
                backForeColor.BackColor = colorConfig.NormalColor;
            }
            else
            {
                backForeColor.BackColor = colorConfig.ExceptionColor;
            }
        }
    }
}
