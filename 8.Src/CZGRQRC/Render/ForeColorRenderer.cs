using System;
using System.Collections.Generic;
using System.Text;

namespace FNGRQRC
{
    /// <summary>
    /// 
    /// </summary>
    public class ForeColorRenderer : Renderer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="backForeColor"></param>
        /// <param name="compareResult"></param>
        /// <param name="colorConfig"></param>
        public override void Render(IBackForeColor backForeColor, CompareResult compareResult, ColorConfig colorConfig)
        {
            if (compareResult.IsNormal)
            {
                backForeColor.ForeColor = colorConfig.NormalColor;
            }
            else
            {
                backForeColor.ForeColor = colorConfig.ExceptionColor;
            }
        }
    }
}
