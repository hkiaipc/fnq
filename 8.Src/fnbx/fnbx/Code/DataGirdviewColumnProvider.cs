using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Xdgk.Common;

namespace fnbx
{
    public class DataGirdviewColumnProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static public Xdgk.Common.DGVColumnConfigCollection GetFlowDgvColumnConfigs()
        {
            if (_flowDgvColumnConfigs == null)
            {
                _flowDgvColumnConfigs = new DGVColumnConfigCollection();
                //_flowDgvColumnConfigs.Add ( new DGVColumnConfig(

                DGVColumnConfig[] configArray = new DGVColumnConfig[]{
                    new DGVColumnConfig("ItName", "", Strings.ItName),
                    new DGVColumnConfig("ItAddress", "", Strings.ItAddress),
                    new DGVColumnConfig("ItPhone", "", Strings.ItPhone),
                    //new DGVColumnConfig("ItRemark", "", Strings.ItRemark),
                    new DGVColumnConfig("MtPoseDT", "", Strings.MtPoseDT),
                    //new DGVColumnConfig("CreateDT", "", Strings.CreateDT),
                    new DGVColumnConfig("MtBeginDT", "", Strings.MtBeginDT),
                    new DGVColumnConfig("MtTimeoutDT", "", Strings.MtTimeoutDT),
                    new DGVColumnConfig("MtLocation", "", Strings.MtLocation),
                    new DGVColumnConfig("MtContent", "", Strings.MtContent),
                    //new DGVColumnConfig("MtRemark", "", Strings.MtRemark),
                    new DGVColumnConfig("MtLevel", "", Strings.MtLevel),
                    new DGVColumnConfig("MtOperatorName", "", Strings.MtOperatorName),
                    new DGVColumnConfig("RcDT", "", Strings.RcDT),
                    new DGVColumnConfig("RcOperatorName", "", Strings.RcOperatorName),
                    new DGVColumnConfig("RpContent", "", Strings.RpContent),
                    //new DGVColumnConfig("RpRemark", "", Strings.RpRemark),
                    new DGVColumnConfig("RpEndDT", "", Strings.RpEndDT),
                    new DGVColumnConfig("RpWorker", "", Strings.RpWorker),
                    new DGVColumnConfig("FlStatus", "", Strings.FlStatus),
                    //new DGVColumnConfig("TblFlow", "", Strings.TblFlow),
                                    };

                foreach (DGVColumnConfig item in configArray)
                {
                    _flowDgvColumnConfigs.Add(item);
                }
            }
            return _flowDgvColumnConfigs;
        } static private DGVColumnConfigCollection _flowDgvColumnConfigs;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="displayColumns"></param>
        /// <returns></returns>
        internal static DGVColumnConfigCollection GetFlowDgvColumnConfigs(string[] displayColumns)
        {
            DGVColumnConfigCollection r = new DGVColumnConfigCollection();
            DGVColumnConfigCollection dgvs = GetFlowDgvColumnConfigs();
            foreach (string item in displayColumns)
            {
                DGVColumnConfig dgv = dgvs.First(c => StringHelper.Equal(c.DataPropertyName, item));
                r.Add(dgv);
            }

            return r;
        }
    }
}
