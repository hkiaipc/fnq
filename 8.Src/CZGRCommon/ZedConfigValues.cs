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
    public class ZedConfigValues
    {
        static public ZedConfigValues Default
        {
            get
            {
                if (s_default == null)
                {
                    SoapSerialize ss = new SoapSerialize("ZedConfigValues.xml");
                    object obj = ss.Deserialize();
                    if (obj == null)
                    {
                        s_default = new ZedConfigValues();
                        ss.Serialize(s_default);
                    }
                    else
                    {
                        s_default = obj as ZedConfigValues;
                    }
                }
                return s_default;
            }
        } static private ZedConfigValues s_default;


        /// <summary>
        /// 
        /// </summary>
        public ZedConfigValues()
        {
            TemperatureCurveConfig = new YAxisConfig();
            TemperatureCurveConfig.Min = 0;
            TemperatureCurveConfig.Max = 100;
            TemperatureCurveConfig.MajorStep = 5;
            TemperatureCurveConfig.MinorStep = 5;
            TemperatureCurveConfig.MajorGridVisible = true;
            TemperatureCurveConfig.MinorGridVisible = false;


            PressCurveConfig = new YAxisConfig();
            PressCurveConfig.Min = 0;
            PressCurveConfig.Max = 1.0;
            PressCurveConfig.MajorStep = 0.1;

            GT1Config = new LineConfig(1);
            BT1Config = new LineConfig(1);
            GT2Config = new LineConfig(1);
            BT2Config = new LineConfig(1);

            GP1Config = new LineConfig(1);
            BP1Config = new LineConfig(1);
            GP2Config = new LineConfig(1);
            BP2Config = new LineConfig(1);
        }

        /// <summary>
        /// 
        /// </summary>
        public YAxisConfig TemperatureCurveConfig;
        public YAxisConfig PressCurveConfig;

        public LineConfig GT1Config;
        public LineConfig BT1Config;
        public LineConfig GT2Config;
        public LineConfig BT2Config;

        public LineConfig GP1Config;
        public LineConfig BP1Config;
        public LineConfig GP2Config;
        public LineConfig BP2Config;

    }
}
