using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xdgk.Common;

namespace K
{
    internal class ResultDataTableColumnNames
    {
        internal const string
            PersonName = "人员",
            StandardBegin = "上班时间",
            StandardEnd = "下班时间",

            Type = "工休",
            Week = "星期",
            PracticeBegin = "上班打卡",

            PracticeEnd = "下班打卡",
            WorkTimeSpan = "工作时长",
            StartWorkResult = "上班",

            StopWorkResult = "下班",
            Remark = "备注";
    }
    /// <summary>
    /// 
    /// </summary>
    internal class ResultDataTableConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pr"></param>
        /// <returns></returns>
        static internal DataTable ToPersonResultDataTable(PersonResult pr)
        {
            DataTable t = CreatePersonResultDataTable();
            foreach (TimeResult tr in pr.TimeResults)
            {
                TimeStandard std = tr.TimeStandard;

                object[] values = new object[] { 
                    pr.TblPerson.PersonName,
                    DateTimeToString(std.Begin),
                    DateTimeToString(std.End),

                    GetTimeStandardTypeName(std.Type),
                    GetWeekString(std.DayOfWeek ),
                    //GetResultEnumString(tr.KResultEnum ),
                    DateTimeToString(tr.PracticeBegin),

                    DateTimeToString(tr.PracticeEnd),
                    GetWorkTimeSpanString(tr),

                    GetResultEnumString(std.Type, tr.StartWorkResult),

                    GetResultEnumString(std.Type, tr.StopWorkResult),
                    tr.Remark 
                };
                t.Rows.Add(values);
            }
            return t;
        }

        private static string GetWorkTimeSpanString(TimeResult tr)
        {
            if (tr.TimeStandard.Type == TimeStandard.TypeEnum.Rest)
                //|| tr.StartWorkResult == KResultEnum.Leave)
            {
                return string.Empty;
            }
            return tr.WorkTimeSpan.ToString ();
        }

        static private string DateTimeToString(DateTime dt)
        {
            if (dt == DateTime.MinValue)
            {
                return string.Empty;
            }
            return dt.ToString();
        }

        static private string DateTimeToString(TimeStandard.TypeEnum type, DateTime dt)
        {
            if (type == TimeStandard.TypeEnum.Work)
            {
                return dt.ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        static private string[] _timeStandardTypeNames = new string[] { "工", "休" };
        static private string GetTimeStandardTypeName(TimeStandard.TypeEnum tp)
        {
            return _timeStandardTypeNames[(int)tp];
        }

        static private object[] _kResultEnumNameMap = new object[]{
                KResultEnum.Normal,"正常",
                KResultEnum.Later,"迟到",
                KResultEnum.Early,"早退",

                KResultEnum.LaterEarly,"迟到早退",
                KResultEnum.Lose,"矿工",
                KResultEnum.Leave,"请假",

                KResultEnum.Out,"出差",
                KResultEnum.Rest,"休息",
                KResultEnum.None,"未打卡",
            };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kResultEnum"></param>
        /// <returns></returns>
        static private string GetResultEnumString(TimeStandard.TypeEnum type, KResultEnum kResultEnum)
        {
            if (type == TimeStandard.TypeEnum.Work)
            {
                for (int i = 0; i < _kResultEnumNameMap.Length; i += 2)
                {
                    KResultEnum k = (KResultEnum)_kResultEnumNameMap[i];
                    if (k == kResultEnum)
                    {
                        return (string)_kResultEnumNameMap[i + 1];
                    }
                }
                return kResultEnum.ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        static private object GetWeekString(DayOfWeek dayOfWeek)
        {
            string[] weekNames = new string[] { 
                    "星期日", "星期一", "星期二", "星期三", 
                    "星期四", "星期五", "星期六",
            };

            return weekNames[(int)dayOfWeek];
        }

        static private DataTable CreatePersonResultDataTable()
        {
            DataTable t = new DataTable();
            DataColumnCollection s = t.Columns;

            s.Add(ResultDataTableColumnNames.PersonName, typeof(string));
            s.Add(ResultDataTableColumnNames.StandardBegin, typeof(string));
            s.Add(ResultDataTableColumnNames.StandardEnd, typeof(string));

            s.Add(ResultDataTableColumnNames.Type, typeof(string));
            s.Add(ResultDataTableColumnNames.Week, typeof(string));
            s.Add(ResultDataTableColumnNames.PracticeBegin, typeof(string));

            s.Add(ResultDataTableColumnNames.PracticeEnd, typeof(string));
            s.Add(ResultDataTableColumnNames.WorkTimeSpan, typeof(string));
            s.Add(ResultDataTableColumnNames.StartWorkResult, typeof(string));

            s.Add(ResultDataTableColumnNames.StopWorkResult, typeof(string));
            s.Add(ResultDataTableColumnNames.Remark, typeof(string));

            return t;
        }
    }

    internal class GatherDataTableConverter
    {
        static internal DataTable ToGatherDataTable(PersonGatherCollection personGathers)
        {
            DataTable tbl = CreateDataTable();
            
            foreach (PersonGather pg in personGathers)
            {
                object[] values = CreateDataRow(pg);
                tbl.Rows.Add(values);
            }
            return tbl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pg"></param>
        /// <returns></returns>
        private static object[] CreateDataRow(PersonGather pg)
        {
            List<object> list = new List<object>();
            list.Add(pg.TblPerson.PersonName);

            for (int i = 1; i <= 31; i++)
            {
                Gather g = pg.Gathers.FindByDay(i);
                string gatherString = string.Empty ;
                if (g != null)
                {
                    gatherString = g.GetGatherString ();
                }
                list.Add(gatherString);
            }
            list.Add(pg.Gathers.GetSumString());
            return list.ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static DataTable CreateDataTable()
        {
            
            DataTable tbl = new DataTable();
            tbl.Columns.Add("姓名", typeof(string));

            for (int i = 1; i <= 31; i++)
            {
                tbl.Columns.Add(i.ToString(), typeof(string));
            }
            tbl.Columns.Add("统计", typeof(string));

            return tbl;
        }
    }
}
