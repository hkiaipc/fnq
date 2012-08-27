using System;
using System.Collections.Generic;
using System.Text;

namespace CZGRCommon
{

    /// <summary>
    /// command line arg: /data:{0}
    /// </summary>
    public class DataValue
    {
        public const string GR = "gr";
        public const string GRTemp = "grtemp";
        public const string GRPress = "grpress";
        public const string GRAlarm = "gralarm";

        public const string XG = "xg";
    }

    /// <summary>
    /// 
    /// </summary>
    public class AppearanceValue
    {
        public const string Query = "query";
        public const string Curve = "curve";
    }

    /// <summary>
    /// 
    /// </summary>
    public class ArgumentName
    {
        public const string StationName = "stationname";
        public const string Data = "data";
        public const string Appearance = "appearance";
    }

    /// <summary>
    /// 
    /// </summary>
    public class CZGRQRCConfig
    {
        public const string CommandLineFormat = "/{0}:\"{1}\" /{2}:{3} /{4}:{5}";
        public const string ExecuteFileName = "..\\czgrqrc\\czgrqrc.exe";
    }

    /// <summary>
    /// 
    /// </summary>
    public class DeviceTypes
    {
        public class Item
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="type"></param>
            /// <param name="text"></param>
            internal Item(string type, string text)
            {
                Type = type;
                Text = text;
            }
            /// <summary>
            /// 
            /// </summary>
            public string Type
            {
                get { return _type; }
                set { _type = value; }
            } private string _type;

            /// <summary>
            /// 
            /// </summary>
            public string Text
            {
                get { return _text; }
                set { _text = value; }
            } private string _text;
        }

        static public readonly string GRDevice = "grdevice";
        static public readonly string XGDevice = "xgdevice";
        static public readonly string EMDevice = "emdevice";
        static public readonly string GRDeviceModus = "grdevicemodbus";
        static public readonly string XD100E = "xd100e";
        static public readonly string SCL6 = "SCL6";
        static public readonly string SCL61D = "SCL61d";
        static public readonly string CRLGxL = "CRLGxL";
        static public readonly string CRLGxLModbus = "CRLGxLModbus";

        /// <summary>
        /// 
        /// </summary>
        static public Item[] Items
        {
            get { return s_items; }
        }

        /// <summary>
        /// 
        /// </summary>
        static private Item[] s_items = new Item[]
        {
            new Item( GRDevice, "供热控制器" ),
            new Item( XGDevice, "巡更控制器" ),
            new Item(EMDevice, "电表"),
            new Item(GRDeviceModus ,"供热控制器Modbus"),
            new Item(XD100E,"扩展模块"),
            new Item (SCL6, "汇中流量计"),
        };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deviceType"></param>
        /// <returns></returns>
        static public string GetText(string deviceType)
        {
            deviceType = deviceType.Trim();
            foreach (Item item in Items)
            {
                if (string.Compare(item.Type, deviceType, true) == 0)
                {
                    return item.Text;
                }
            }
            return deviceType;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        static public string GetDeviceType( string text )
        {
            text = text.Trim();
            foreach (Item item in Items)
            {
                if (string.Compare(item.Text, text, true) == 0)
                {
                    return item.Type;
                }
            }
            throw new ArgumentException("Not find deviceType text: " + text );
            //return text;
        }
    }
}
