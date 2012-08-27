using System;
using System.Collections.Generic;
using System.Text;

namespace CZGRCommon
{
    /// <summary>
    /// 
    /// </summary>
    /// 
    [Serializable]
    public class LineConfig
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="w"></param>
        public LineConfig(int w)
        {
            if (w < 1)
                w = 1;
            this.Width = w;
        }

        public int Width = 1;
        //public Color Color = new Color();
    }
}
