using System;
using System.Collections.Generic;
using System.Text;

namespace FNGRQRC
{
    /// <summary>
    /// 
    /// </summary>
    abstract public class Renderer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="backForeColor"></param>
        abstract public void Render(IBackForeColor backForeColor, CompareResult compareResult, ColorConfig colorConfig);
    }
}
