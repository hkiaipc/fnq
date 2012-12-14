using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xdgk.Common;

namespace K
{
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
        internal DataTable ToPersonResultDataTable(PersonResult pr)
        {
            DataTable t = CreatePersonResultDataTable();
            foreach (TimeResult tr in pr.TimeResults)
            {
                TimeStandard std = tr.TimeStandard;

                object[] values = new object[] { 
                    pr.TblPerson.PersonName,
                    std.Begin,
                    std.End,

                    GetWeekString(std.DayOfWeek ),
                    //GetResultEnumString(tr.KResultEnum ),
                    tr.PracticeBegin,
                    tr.PracticeEnd,

                    GetResultEnumString(tr.StartWorkResult),
                    GetResultEnumString(tr.StopWorkResult),
                    tr.Remark 
                };
                t.Rows.Add(values);
            }
            return t;
        }

        private string GetResultEnumString(KResultEnum kResultEnum)
        {
            object[] s = new object[]{
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

            for (int i = 0; i < s.Length; i += 2)
            {
                KResultEnum k = (KResultEnum)s[i];
                if (k == kResultEnum)
                {
                    return (string)s[i + 1];
                }
            }
            return kResultEnum.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        private object GetWeekString(DayOfWeek dayOfWeek)
        {
            string[] weekNames = new string[] { 
                    "星期日", "星期一", "星期二", "星期三", 
                    "星期四", "星期五", "星期六",
            };

            return weekNames[(int)dayOfWeek];
        }

        private DataTable CreatePersonResultDataTable()
        {
            DataTable t = new DataTable();
            DataColumnCollection s = t.Columns;

            s.Add("PersonName", typeof(string));
            s.Add("StandardBegin", typeof(DateTime));
            s.Add("StandardEnd", typeof(DateTime));

            s.Add("Week", typeof(string));
            //s.Add("Result", typeof(string));
            s.Add("PracticeBegin", typeof(DateTime));
            s.Add("PracticeEnd", typeof(DateTime));

            s.Add("StartWorkResult", typeof(string));
            s.Add("StopWorkResult", typeof(string));
            s.Add("Remark", typeof(string));

            return t;
        }
    }
}
