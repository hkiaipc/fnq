using System;
using System.Collections.Generic;
using System.Text;

namespace CZGRQRC
{
    /// <summary>
    /// 
    /// </summary>
    public class StationDevice
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stationName"></param>
        /// <param name="deviceName"></param>
        public StationDevice(string stationName, string deviceName)
        {
            this.StationName = stationName;
            this.DeviceName = deviceName;
        }

        #region Members
        private string _deviceName;
        private string _stationName;
        #endregion //Members


        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public string DisplayName
        {
            get { return this.StationName + this.DeviceName; }
        }

        #region DeviceName
        /// <summary>
        /// 获取或设置
        /// </summary>
        public string DeviceName
        {
            get
            {
                if (_deviceName == null)
                    _deviceName = string.Empty;
                return _deviceName;
            }
            set 
            {
                if (value != null)
                    value = value.Trim();
                _deviceName = value;
                Console.WriteLine(_deviceName );
            }
        }
        #endregion //DeviceName

        #region StationName
        /// <summary>
        /// 获取或设置
        /// </summary>
        public string StationName
        {
            get { return _stationName; }
            set { _stationName = value; }
        }
        #endregion //StationName

        /// <summary>
        /// kj
        /// </summary>
        public StationDevice This
        {
            get { return this; }
        }
        #endregion //Properties

        #region Methods
        #endregion //Methods
    }
}
