
using System;
using System.Collections.Generic;
using System.Data;
using CZGRWEBDBI;


namespace FNGRQRC.Forms
{
    internal class ReportHelper
    {
        static public int DotNumber = 2;
        static public DBI GetDBI()
        {
            if (_dbi == null)
            {
                //_dbi = CZGRWEBDBI.DBI.Default;
                _dbi = CZGRQRCApp.Default.DBI;
            }
            return _dbi;

        } static private DBI _dbi;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="b"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        static public double GetAvgOT(DateTime b, DateTime e)
        {
            string s = string.Format(
                    "select avg(ot) from tblgrdata where ot > -49 and dt >= '{0}' and dt <= '{1}'",
                    b, e);
            object obj = GetDBI().ExecuteScalar(s);
            if (obj != DBNull.Value)
            {
                double ot = Convert.ToDouble(obj);
                ot = Math.Round(ot, DotNumber);
                return ot;
            }
            return 0d;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="b"></param>
        /// <param name="e"></param>
        /// <returns>double[]: gt1, bt1, i1</returns>
        static public double[] GetAvgValues(DateTime b, DateTime e)
        {
            string s = string.Format(
                    @"select avg(gt1) as gt1, avg(bt1) as bt1, avg(i1) as i1 
                    from tblgrdata 
                    where gt1 > -90 and dt >='{0}' and dt < '{1}'",
                    b, e);

            DataTable tbl = GetDBI().ExecuteDataTable(s);
            List<double> list = new List<double>();
            DataRow r = tbl.Rows[0];
            list.Add(Math.Round(ConvertToDoubleSafe(r["gt1"]), DotNumber));
            list.Add(Math.Round(ConvertToDoubleSafe(r["bt1"]), DotNumber));
            list.Add(Math.Round(ConvertToDoubleSafe(r["i1"]), DotNumber));

            return list.ToArray();
        }

        static double ConvertToDoubleSafe(object obj)
        {
            double r = 0d;
            if (obj != null && obj != DBNull.Value)
            {
                r = Convert.ToDouble(obj);
            }
            return r;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tbl"></param>
        /// <returns></returns>
        static public DataTable CreateStationDetail(DataTable tbl)
        {
            // add calc column
            //
            //
            return tbl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="b"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        static public DataTable GetStationData(DateTime b, DateTime e)
        {
            string s = string.Format(
                    @"select street, stationname, 
                    avg(gt1) as gt1, avg(bt1) as bt1, 
                    avg(gt2) as gt2, avg(bt2) as bt2, 
                    avg(gp1) as gp1, avg(bp1) as bp1, 
                    avg(gp2) as gp2, avg(bp2) as bp2, 	
        		    avg(i1) as i1,
        		    avg(od) as od,
                    max(s1) as maxs1, min(s1) as mins1,
                    max(sr) as maxsr, min(sr) as minsr
                    from vgrdata 
                    where dt >= '{0}' and dt < '{1}' 
                    group by street, stationname 
                    order by street, stationname",
                    b, e);

            return GetDBI().ExecuteDataTable(s);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_b"></param>
        /// <param name="_e"></param>
        /// <returns>double[]: gt1, bt1, i1</returns>
        internal static double[] GetFirstValues(DateTime _b, DateTime _e)
        {
            string s = string.Format(
                    @"select avg (ai1 ) as gt1 , avg(ai2) as bt1, avg(ai5) as i1
                    from tblxd100edata 
                    where dt >= '{0}' and dt < '{1}'",
                    _b, _e);

            DataTable tbl = GetDBI().ExecuteDataTable(s);
            DataRow row = tbl.Rows[0];
            List<double> list = new List<double>();
            list.Add(Math.Round(ConvertToDoubleSafe(row["gt1"]), DotNumber));
            list.Add(Math.Round(ConvertToDoubleSafe(row["bt1"]), DotNumber));
            list.Add(Math.Round(ConvertToDoubleSafe(row["i1"]), DotNumber));
            return list.ToArray ();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="b"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        internal static DataTable GetFirstStationAvgDataTable(DateTime b, DateTime e)
        {
            string s = string.Format(
                @"select stationname, avg (ai1 ) as gt1 , avg(ai2) as bt1,
                	avg(ai3) as gp1, avg(ai4) bp1, avg(ai5) as i1
                from vxd100edata 
                where dt >= '{0}' and dt < '{1}'
                group by stationname
                order by stationname",
                b, e);

            DataTable tbl = GetDBI().ExecuteDataTable(s);
            return tbl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="b"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        internal static DataTable GetFirstRecuriteDataTable(DateTime b, DateTime e)
        {
            string s = string.Format (
                    @"select stationname, max(sr) as maxsr, min(sr) as minsr, max(sr) - min(sr) as usedr
                    from vXd100eData
                    where dt >= '{0}' and dt < = '{1}'
                    group by stationname
                    order by stationName",
                    b,e );

            return GetDBI().ExecuteDataTable(s);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="b"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        internal static DataTable GetFirstStationDataTable(DateTime b, DateTime e)
        {
            string s =
                @"select stationname, avg(ai1) as gt1, avg(ai2) as bt1, avg(ai3) as gp1, avg(ai4) as bp1,
                avg(ir) as ir,  max(sr) as sr, avg(if1) as if1, max(sf1) as sf1, '' as remark
                from vXd100eData
                where dt >= '{0}' and dt < '{1}' 
                group by stationName";

            s = string.Format(s, b, e);


            return GetDBI().ExecuteDataTable(s);
                    
        }

    }

}
