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
    public class YAxisConfig
    {
        public double Min = 0;
        public double Max = 100;
        public double MajorStep = 10;
        public double MinorStep = 5;
        public bool MajorGridVisible = true;
        public bool MinorGridVisible = false;
    }
}
