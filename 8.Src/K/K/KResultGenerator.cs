using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using KDB;
using NLog;

namespace K
{
    internal class KResultGenerator
    {
        #region Members
        static private Logger _log = LogManager.GetCurrentClassLogger();

        private DB _db;
        private DateTime _monthForGenerator;
        #endregion //Members

        #region KResultGenerator
        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        internal KResultGenerator(DB db, DateTime monthForGenerator)
        {
            Debug.Assert(db != null);
            Debug.Assert ( monthForGenerator > DateTime.Parse ("1900-1-1"));

            _db = db;
            _monthForGenerator = monthForGenerator;

        }
        #endregion //KResultGenerator

        #region Generate
        /// <summary>
        /// 
        /// </summary>
        internal GroupResultCollection Generate()
        {
            //_kResults = new KResultCollection();
            GroupResultCollection groupResults = new GroupResultCollection();

            foreach (tblGroup gp in _db.tblGroup.ToList())
            {
                //foreach (tblPerson p in gp.tblPerson.ToList())
                //{

                //}
                GroupResult gpResult = GenerateGroupResult(gp);
                groupResults.Add(gpResult);
            }
            return groupResults;
        }
        #endregion //Generate

        #region GenerateGroupResult
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gp"></param>
        /// <returns></returns>
        private GroupResult GenerateGroupResult(tblGroup gp)
        {
            Debug.Assert(gp.tblWorkDefine != null);

            GroupResult gpResult = new GroupResult();
            //foreach (tblPerson person in gp.tblPerson)
            //{
            gpResult.TblGroup = gp;
            List<tblPerson> persons = gp.tblPerson.ToList();
            gpResult.PersonResults = GeneratePersonResultCollection(persons);
            //}
            return gpResult;
        }
        #endregion //GenerateGroupResult

        #region GeneratePersonResultCollection
        private PersonResultCollection GeneratePersonResultCollection(List<tblPerson> persons)
        {
            PersonResultCollection r = new PersonResultCollection();
            foreach (tblPerson person in persons)
            {
                PersonResult personResult = GeneratePersonResult(person);
                r.Add(personResult);
            }
            return r;
        }
        #endregion //GeneratePersonResultCollection

        #region GeneratePersonResult
        /// <summary>
        /// 
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        private PersonResult GeneratePersonResult(tblPerson person)
        {
            PersonResult r = new PersonResult();
            r.TblPerson = person;

            //r.TimeResults = GenerateTimeResultCollection(person.tblGroup.tblWorkDefine);
            r.TimeResults = GenerateTimeResultCollection(person);
            return r;
        }
        #endregion //GeneratePersonResult

        #region GetMonthBeginDT
        private DateTime GetMonthBeginDT()
        {
            return new DateTime(this._monthForGenerator.Year, this._monthForGenerator.Month, 1);
        }
        #endregion //GetMonthBeginDT

        #region GetMonthEndDT
        private DateTime GetMonthEndDT ()
        {
            int year = this._monthForGenerator.Year ;
            int mon = this._monthForGenerator.Month + 1;
            if (mon > 12)
            {
                mon = 1;
                year++;
            }
            return new DateTime(year, mon, 1);
        }
        #endregion //GetMonthEndDT

        #region GenerateTimeResultCollection
        private TimeResultCollection GenerateTimeResultCollection(tblPerson person)
        {
            tblWorkDefine workDefine = person.tblGroup.tblWorkDefine;
            DateTime monthBeginDT = GetMonthBeginDT ();
            DateTime monthEndDT = GetMonthEndDT ();

            var vLeaves = from q in _db.tblLeave
                          where q.PersonID == person.PersonID && q.LeaveBegin >= monthBeginDT && q.LeaveBegin < monthEndDT
                          select q;
            List<tblLeave> leaves = vLeaves.ToList();

            var vTmDatas = from q2 in _db.tblTmData
                           where q2.TmID == person.TmID && q2.TmDataDT >= monthBeginDT && q2.TmDataDT < monthEndDT
                           orderby q2.TmDataDT 
                           select q2.TmDataDT ;

            List<DateTime> datetimes = vTmDatas.ToList();

            TimeResultCollection timeResults = new TimeResultCollection();
            TimeStandardCollection timeStandards = GenerateTimeStandards(workDefine, _monthForGenerator);
            _log.Debug("generate time standard count: " + timeStandards.Count);

            foreach (TimeStandard timeStandard in timeStandards)
            {
                TimeResult timeResult = GenerateTimeResult(timeStandard, leaves, datetimes);
                timeResults.Add(timeResult);
            }
            return timeResults;
        }
        #endregion //GenerateTimeResultCollection

        #region GenerateTimeResult
        /// <summary>
        /// 
        /// </summary>
        /// <param name="timeStandard"></param>
        /// <returns></returns>
        private TimeResult GenerateTimeResult(TimeStandard timeStandard, List<tblLeave> leaves, List<DateTime> datetimes)
        {
            return timeStandard.CreateTimeResult(leaves, datetimes);
        }
        #endregion //GenerateTimeResult

        #region GenerateTimeStandards
        private TimeStandardCollection GenerateTimeStandards(tblWorkDefine tblWD, DateTime monthForGenerator)
        {
            // TODO: get timedefines
            //
            //workDefine.WorkDefineContext 
            WorkDefine wd = WorkDefine.Deserialize(tblWD.WorkDefineContext);
            return wd.CreateTimeStandards(monthForGenerator);

            //throw new NotImplementedException();
            // TODO: Generate standard time collection
            // 
            //if (wd.CycleType == CycleTypeEnum.Week)
            //{
            //    return GenerateWeekTimeStandards(wd, monthForGenerator);
            //}
            //else if (wd.CycleType == CycleTypeEnum.UserDefine)
            //{
            //    return GenerateUserDefineTimeStandards(wd, monthForGenerator);
            //}
            //throw new InvalidCastException(wd.CycleType.ToString());

            //TimeDefineCollection timeDefines = wd.TimeDefines[0];
            //TimeStandardCollection timeStandards = new TimeStandardCollection();
            //return timeStandards;
        }
        #endregion //GenerateTimeStandards

        #region CheckLeave
        private KResultEnum CheckLeave(List<tblLeave> leaves, TimeStandard timeStandard)
        {
            KResultEnum r = KResultEnum.None;
            foreach (tblLeave item in leaves)
            {
                //if ( item.
                if (item.IsInLeave(timeStandard))
                {
                    r = (KResultEnum)item.LeaveType;
                }
            }
            return r;
        }
        #endregion //CheckLeave

        #region CheckTime
        private KResultEnum CheckTime(List<tblTmData> tmDatas, TimeStandard timeStandard)
        {
            throw new NotImplementedException();
        }
        #endregion //CheckTime
    }
}
