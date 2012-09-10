using System;
using System.Collections.Generic;
using System.Text;
using Xdgk.Common;
namespace CZGRQRC
{
    /// <summary>
    /// 
    /// </summary>
    public class DGVColumnConfigs
    {
        #region Members
        /// <summary>
        /// 
        /// </summary>
        static string noFormat = string.Empty;
        static string floatFormat = "f2";
        #endregion //Members

        #region Alarm
        /// <summary>
        /// 
        /// </summary>
        static public DGVColumnConfigCollection Alarm
        {
            get
            {
                if (_alarm == null)
                {
                    _alarm = new DGVColumnConfigCollection();
                    //_alarm.Add(new DGVColumnConfig("Street", noFormat, "街道"));
                    _alarm.Add(new DGVColumnConfig("StationName", noFormat, "站名"));
                    _alarm.Add(new DGVColumnConfig("DT", noFormat, "时间"));
                    _alarm.Add(new DGVColumnConfig("Content", noFormat, "报警"));
                }
                return _alarm;
            }
        } static private DGVColumnConfigCollection _alarm;
        #endregion //Alarm

        //#region EM
        ///// <summary>
        ///// 
        ///// </summary>
        //static public DGVColumnConfigCollection EM
        //{
        //    get 
        //    {
        //        if (_em == null)
        //        {
        //            _em = new DGVColumnConfigCollection();
        //            //_em.Add(new DGVColumnConfig("Street", noFormat, "街道"));
        //            _em.Add(new DGVColumnConfig("StationName", noFormat, "站名"));
        //            _em.Add(new DGVColumnConfig("DT", noFormat, "时间"));
        //            _em.Add (new DGVColumnConfig ("ElectricValue", noFormat , "电量"));
        //        }
        //        return _em;
        //    }
        //} static private DGVColumnConfigCollection _em;
        //#endregion //EM


        #region Recruit
        /// <summary>
        /// 
        /// </summary>
        static public DGVColumnConfigCollection Recruit
        {
            get 
            {
                if (_recruit == null)
                {
                    _recruit = new DGVColumnConfigCollection();
                    //_recruit.Add(new DGVColumnConfig("Street", noFormat, "街道"));
                    _recruit.Add(new DGVColumnConfig("StationName", noFormat, "站名"));
                    _recruit.Add(new DGVColumnConfig("DT", noFormat, "时间"));
                    _recruit.Add(new DGVColumnConfig("IR", floatFormat, "补水瞬时流量"));
                    _recruit.Add(new DGVColumnConfig("SR", noFormat, "补水累计流量"));
                }
                return _recruit;
            }
        } static private DGVColumnConfigCollection _recruit;
        #endregion //Recruit

        #region XG
        /// <summary>
        /// 
        /// </summary>
        static public DGVColumnConfigCollection XG
        {
            get
            {
                if (_xg == null)
                {
                    _xg = new DGVColumnConfigCollection();
                    _xg.Add(new DGVColumnConfig("Street", noFormat, "街道"));
                    _xg.Add(new DGVColumnConfig("Name", noFormat, "站名"));
                    _xg.Add(new DGVColumnConfig("DT", noFormat, "时间"));
                    _xg.Add(new DGVColumnConfig("SN", noFormat, "卡号"));
                    _xg.Add(new DGVColumnConfig("Person", noFormat, "人员"));
                }
                return _xg;
            }
        } static private DGVColumnConfigCollection _xg;
        #endregion //XG

        #region GR
        /// <summary>
        /// 
        /// </summary>
        static public DGVColumnConfigCollection GR
        {
            get
            {
                if (_gr == null)
                {
                    _gr = new DGVColumnConfigCollection();

                    //_gr.Add(new DGVColumnConfig("Street", noFormat, "街道"));
                    _gr.Add(new DGVColumnConfig("StationName", noFormat, "站名"));
                    _gr.Add(new DGVColumnConfig("DT", noFormat, "时间"));

                    _gr.Add(new DGVColumnConfig("GT1", floatFormat, "一次供温"));
                    _gr.Add(new DGVColumnConfig("BT1", floatFormat, "一次回温"));

                    _gr.Add(new DGVColumnConfig("GT2", floatFormat, "二次供温"));
                    _gr.Add(new DGVColumnConfig("BT2", floatFormat, "二次回温"));

                    //_gr.Add(new DGVColumnConfig("GTBase2", floatFormat, "二次供温基准"));

                    _gr.Add(new DGVColumnConfig("GP1", floatFormat, "一次供压"));
                    _gr.Add(new DGVColumnConfig("BP1", floatFormat, "一次回压"));

                    _gr.Add(new DGVColumnConfig("GP2", floatFormat, "二次供压"));
                    _gr.Add(new DGVColumnConfig("BP2", floatFormat, "二次回压"));


                    _gr.Add(new DGVColumnConfig("I1", floatFormat, "一次瞬时流量"));
                    _gr.Add(new DGVColumnConfig("S1", noFormat, "一次累计流量"));

                    _gr.Add(new DGVColumnConfig("I2", floatFormat, "二次瞬时流量"));
                    _gr.Add(new DGVColumnConfig("S2", noFormat, "二次累计流量"));

                    _gr.Add(new DGVColumnConfig("IR", floatFormat, "补水瞬时流量"));
                    _gr.Add(new DGVColumnConfig("SR", noFormat, "补水累积流量"));

                    _gr.Add(new DGVColumnConfig("OT", floatFormat , "室外温度"));
                    _gr.Add(new DGVColumnConfig("OD", floatFormat , "阀门开度"));
                    _gr.Add(new DGVColumnConfig("WL", floatFormat, "水箱水位"));
                    _gr.Add(new DGVColumnConfig("CM1", noFormat, "循环泵1"));
                    // _gr.Add(new DGVColumnConfig("CM1HZ", floatFormat, "循环泵1频率"));
                    // _gr.Add(new DGVColumnConfig("CM1Ampere", floatFormat, "循环泵1电流"));

                    _gr.Add(new DGVColumnConfig("CM2", noFormat, "循环泵2"));
                    // _gr.Add(new DGVColumnConfig("CM2HZ", floatFormat, "循环泵2频率"));
                    // _gr.Add(new DGVColumnConfig("CM2Ampere", floatFormat, "循环泵2电流"));

                    // _gr.Add(new DGVColumnConfig("CMBusPress", floatFormat, "循环泵母管压力"));
                    // _gr.Add(new DGVColumnConfig("BusVolt", floatFormat, "母线电压"));

                    _gr.Add(new DGVColumnConfig("RM1", noFormat, "补水泵1"));
                    _gr.Add(new DGVColumnConfig("RM2", noFormat, "补水泵2"));
                    //_gr.Add(new DGVColumnConfig("HZSum", noFormat, "汇中累计流量"));

                }
                return _gr;
            }
        } static private DGVColumnConfigCollection _gr;
        #endregion //GR

        #region GRHistory
        /// <summary>
        /// 
        /// </summary>
        static public DGVColumnConfigCollection GRHistory
        {
            get
            {
                return GR;
                /*
                                if (_grHistory  == null)
                                {

                                    _grHistory = new DGVColumnConfigCollection();

                                    _grHistory.Add(new DGVColumnConfig("Street", noFormat, "街道"));
                                    _grHistory.Add(new DGVColumnConfig("StationName", noFormat, "站名"));
                                    _grHistory.Add(new DGVColumnConfig("DT", noFormat, "时间"));

                                    _grHistory.Add(new DGVColumnConfig("GT1", floatFormat, "一次供温"));
                                    _grHistory.Add(new DGVColumnConfig("BT1", floatFormat, "一次回温"));
                                    //_grHistory.Add(new DGVColumnConfig("DiffT1", floatFormat, "一次温差"));

                                    _grHistory.Add(new DGVColumnConfig("GT2", floatFormat, "二次供温"));
                                    _grHistory.Add(new DGVColumnConfig("BT2", floatFormat, "二次回温"));
                                    //_grHistory.Add(new DGVColumnConfig("DiffT2", floatFormat, "二次温差"));
                                    //_grHistory.Add(new DGVColumnConfig("DiffBT1GT2", floatFormat, "一回二供温差"));

                                    //_grHistory.Add(new DGVColumnConfig("OT", floatFormat, "室外温度"));
                                    //_grHistory.Add(new DGVColumnConfig("GTBase2", floatFormat, "二次供温基准"));

                                    _grHistory.Add(new DGVColumnConfig("GP1", floatFormat, "一次供压"));
                                    _grHistory.Add(new DGVColumnConfig("BP1", floatFormat, "一次回压"));
                                    //_grHistory.Add(new DGVColumnConfig("DiffP1", floatFormat, "一次压差"));

                                    //_grHistory.Add(new DGVColumnConfig("WL", floatFormat, "水箱水位"));
                                    _grHistory.Add(new DGVColumnConfig("GP2", floatFormat, "二次供压"));
                                    _grHistory.Add(new DGVColumnConfig("BP2", floatFormat, "二次回压"));
                                    //_grHistory.Add(new DGVColumnConfig("DiffP2", floatFormat, "二次压差"));

                                    _grHistory.Add(new DGVColumnConfig("I1", floatFormat, "一次瞬时流量"));
                                    _grHistory.Add(new DGVColumnConfig("S1", noFormat, "一次累计流量"));

                                    //_grHistory.Add(new DGVColumnConfig("PI1", floatFormat, "理论瞬时流量"));
                                    //_grHistory.Add(new DGVColumnConfig("DPQ", floatFormat, "日计划耗热量"));


                                    //_grHistory.Add(new DGVColumnConfig("IR", floatFormat, "补水瞬时流量"));
                                    //_grHistory.Add(new DGVColumnConfig("SR", noFormat, "补水累积流量"));
                                    //_grHistory.Add(new DGVColumnConfig("OD", noFormat, "阀门开度"));
                                    //_grHistory.Add(new DGVColumnConfig("PA2", noFormat, "二次压差"));

                                    //_grHistory.Add(new DGVColumnConfig("RegisteredArea", floatFormat, "入网面积"));
                                    //_grHistory.Add(new DGVColumnConfig("SupportArea", floatFormat, "实供面积"));

                                    _grHistory.Add(new DGVColumnConfig("CM1", noFormat, "循环泵1"));
                                    _grHistory.Add(new DGVColumnConfig("CM2", noFormat, "循环泵2"));
                                    _grHistory.Add(new DGVColumnConfig("RM1", noFormat, "补水泵1"));
                                    _grHistory.Add(new DGVColumnConfig("RM2", noFormat, "补水泵2"));

                                }
                                return _grHistory;
                 */
            }
        } static private DGVColumnConfigCollection _grHistory;
        #endregion //GRHistory

        //#region Heat
        ///// <summary>
        ///// 
        ///// </summary>
        //static public DGVColumnConfigCollection Heat
        //{
        //    get
        //    {
        //        if (_heat == null)
        //        {
        //            _heat = new DGVColumnConfigCollection();
        //            //_heat.Add(new DGVColumnConfig(DataColumnNames.Street, noFormat, "街道"));
        //            _heat.Add(new DGVColumnConfig(DataColumnNames.StationName, noFormat, "站名"));
        //            _heat.Add(new DGVColumnConfig(DataColumnNames.DTBegin, noFormat, "起始时间"));
        //            _heat.Add(new DGVColumnConfig(DataColumnNames.DTEnd, noFormat, "结束时间"));

        //            _heat.Add(new DGVColumnConfig(DataColumnNames.GT1, floatFormat, "一次供温"));
        //            _heat.Add(new DGVColumnConfig(DataColumnNames.BT1, floatFormat, "一次回温"));

        //            _heat.Add(new DGVColumnConfig(DataColumnNames.GT2, floatFormat, "二次供温"));
        //            _heat.Add(new DGVColumnConfig(DataColumnNames.BT2, floatFormat, "二次回温"));

        //            _heat.Add(new DGVColumnConfig(DataColumnNames.GP1, floatFormat, "一次供压"));
        //            _heat.Add(new DGVColumnConfig(DataColumnNames.BP1, floatFormat, "一次回压"));
        //            _heat.Add(new DGVColumnConfig(DataColumnNames.GP2, floatFormat, "二次供压"));
        //            _heat.Add(new DGVColumnConfig(DataColumnNames.BP2, floatFormat, "二次回压"));

        //            DGVColumnConfig dgvcc = new DGVColumnConfig(DataColumnNames.S1Begin, noFormat, "起始流量");
        //            dgvcc.Visible = false;
        //            _heat.Add(dgvcc);

        //            dgvcc = new DGVColumnConfig(DataColumnNames.S1End, noFormat, "结束流量");
        //            dgvcc.Visible = false;
        //            _heat.Add(dgvcc);
        //            //_heat.Add(new DGVColumnConfig(DataColumnNames.S1, noFormat, "阶段流量"));
        //            _heat.Add(new DGVColumnConfig(DataColumnNames.RegisteredArea, floatFormat, "入网面积"));
        //            _heat.Add(new DGVColumnConfig(DataColumnNames.SupportArea, floatFormat, "实供面积"));
        //            _heat.Add(new DGVColumnConfig(DataColumnNames.I1, floatFormat, "瞬时流量"));

        //            _heat.Add(new DGVColumnConfig(DataColumnNames.Heat, floatFormat, "日耗热量"));
        //            //_heat.Add(new DGVColumnConfig(DataColumnNames.InstantHeat, floatFormat, "瞬时耗热量" ));
        //            _heat.Add(new DGVColumnConfig(DataColumnNames.PlanHeat, floatFormat, "日计划耗热量"));
        //            _heat.Add(new DGVColumnConfig(DataColumnNames.ItemHeat, floatFormat, "单位耗热量"));
        //            //_heat.Add(new DGVColumnConfig("haodianliang", floatFormat , "耗电量"));
        //            _heat.Add(new DGVColumnConfig("em", floatFormat , "耗电量"));

        //            //_heat.Add(new DGVColumnConfig("shishuiliang", floatFormat, "失水量"));
        //            _heat.Add(new DGVColumnConfig(DataColumnNames.ShiShuiLiang, noFormat, "失水量"));
        //        }
        //        return _heat;
        //    }
        //} static private DGVColumnConfigCollection _heat;
        //#endregion //Heat

        //#region StationHeat
        ///// <summary>
        ///// 
        ///// </summary>
        //static public DGVColumnConfigCollection StationHeat
        //{
        //    get
        //    {
        //        if (_stationHeat == null)
        //        {
        //            _stationHeat = new DGVColumnConfigCollection();
        //            _stationHeat.Add(new DGVColumnConfig(DataColumnNames.Street, noFormat, "街道"));
        //            _stationHeat.Add(new DGVColumnConfig(DataColumnNames.StationName, noFormat, "站名"));
        //            _stationHeat.Add(new DGVColumnConfig(DataColumnNames.DTBegin, noFormat, "起始时间"));
        //            _stationHeat.Add(new DGVColumnConfig(DataColumnNames.DTEnd, noFormat, "结束时间"));

        //            _stationHeat.Add(new DGVColumnConfig(DataColumnNames.GT1, floatFormat, "一次供温"));
        //            _stationHeat.Add(new DGVColumnConfig(DataColumnNames.BT1, floatFormat, "一次回温"));

        //            _stationHeat.Add(new DGVColumnConfig(DataColumnNames.GT2, floatFormat, "二次供温"));
        //            _stationHeat.Add(new DGVColumnConfig(DataColumnNames.BT2, floatFormat, "二次回温"));

        //            _stationHeat.Add(new DGVColumnConfig(DataColumnNames.GP1, floatFormat, "一次供压"));
        //            _stationHeat.Add(new DGVColumnConfig(DataColumnNames.BP1, floatFormat, "一次回压"));
        //            _stationHeat.Add(new DGVColumnConfig(DataColumnNames.GP2, floatFormat, "二次供压"));
        //            _stationHeat.Add(new DGVColumnConfig(DataColumnNames.BP2, floatFormat, "二次回压"));

        //            DGVColumnConfig dgvcc = new DGVColumnConfig(DataColumnNames.S1Begin, noFormat, "起始流量");
        //            dgvcc.Visible = false;
        //            _stationHeat.Add(dgvcc);

        //            dgvcc = new DGVColumnConfig(DataColumnNames.S1End, noFormat, "结束流量");
        //            dgvcc.Visible = false;
        //            _stationHeat.Add(dgvcc);
        //            //_stationHeat.Add(new DGVColumnConfig(DataColumnNames.S1, noFormat, "阶段流量"));
        //            _stationHeat.Add(new DGVColumnConfig(DataColumnNames.RegisteredArea, floatFormat, "入网面积"));
        //            _stationHeat.Add(new DGVColumnConfig(DataColumnNames.SupportArea, floatFormat, "实供面积"));
        //            //_stationHeat.Add(new DGVColumnConfig(DataColumnNames.I1, floatFormat, "瞬时流量"));

        //            _stationHeat.Add(new DGVColumnConfig(DataColumnNames.Heat, floatFormat, "日耗热量"));
        //            //_stationHeat.Add(new DGVColumnConfig(DataColumnNames.InstantHeat, floatFormat, "瞬时耗热量" ));
        //            _stationHeat.Add(new DGVColumnConfig(DataColumnNames.PlanHeat, floatFormat, "日计划耗热量"));
        //            //_stationHeat.Add(new DGVColumnConfig(DataColumnNames.ItemHeat, floatFormat, "单位耗热量"));
        //            //_stationHeat.Add(new DGVColumnConfig("shishuiliang", floatFormat, "失水量"));
        //            //_stationHeat.Add(new DGVColumnConfig("haodianliang", floatFormat , "耗电量"));
        //        }
        //        return _stationHeat;
        //    }
        //} static private DGVColumnConfigCollection _stationHeat;
        //#endregion //StationHeat



        #region OT
        /// <summary>
        /// 
        /// </summary>
        static public DGVColumnConfigCollection OT
        {
            get
            {
                if (_ot == null)
                {
                    _ot = new DGVColumnConfigCollection();
                    _ot.Add(new DGVColumnConfig(DataColumnNames.DT, noFormat, "时间"));
                    _ot.Add(new DGVColumnConfig(DataColumnNames.OT, floatFormat, "室外温度"));
                }
                return _ot;
            }
        } static private DGVColumnConfigCollection _ot;
        #endregion //OT


    }
}
