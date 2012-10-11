using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace FNGRQRC
{

    /// <summary>
    /// 
    /// </summary>
    public class StationNameFiller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stationCombox"></param>
        /// <param name="isAddAll"></param>
        /// <param name="deviceTypes"></param>
        static public void FillStationName(ComboBox stationCombox, bool isAddAll)
        {
            FillStationName(stationCombox, isAddAll, null);
        }

        /// <summary>
        /// 
        /// </summary>
        static public void FillStationName(ComboBox stationCombox, bool isAddAll, string[] deviceTypes)
        {
            DataTable tbl;
            if (deviceTypes == null || deviceTypes.Length == 0)
            {
                tbl = CZGRQRCApp.Default.DBI.ExecuteStationName();
            }
            else
            {
                tbl = CZGRQRCApp.Default.DBI.ExecuteStationName(deviceTypes);
            }

            StationDeviceCollection sds = CreateStationDeviceArray(tbl);
            if (isAddAll)
            {
                sds.Insert(0, new StationDevice(strings.All, ""));
            }

            stationCombox.DataSource = sds;
            stationCombox.DisplayMember = "StationName";
            stationCombox.ValueMember = "This";
        }

        #region CreateStationDeviceArray
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tbl"></param>
        /// <returns></returns>
        static private StationDeviceCollection CreateStationDeviceArray(DataTable tbl)
        {
            StationDeviceCollection sds = new StationDeviceCollection();
            foreach (DataRow row in tbl.Rows)
            {
                sds.Add(new StationDevice(row[DataColumnNames.StationName].ToString(), row[DataColumnNames.DeviceName].ToString()));
            }
            return sds;
        }
        #endregion //CreateStationDeviceArray
    }
}
