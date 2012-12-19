using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Xdgk.Common;

namespace K
{
    class KConfigException : Exception
    {
        public KConfigException(string msg)
            : base(msg)
        {

        }
    }
    /// <summary>
    /// 
    /// </summary>
    class Class1
    {
    }

    abstract class IDBase
    {
        #region ID
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        } private int _id;
        #endregion //ID
    }



    /// <summary>
    /// 
    /// </summary>
    internal class TimeDefineHelper
    {
    }



    class Person : IDBase
    {
        #region Tm
        /// <summary>
        /// 
        /// </summary>
        public Tm Tm
        {
            get
            {
                if (_tm == null)
                {
                    _tm = GetTmByPersonID(this.ID);
                }
                return _tm;
            }
            set
            {
                _tm = value;
            }
        } private Tm _tm;
        #endregion //Tm

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private Tm GetTmByPersonID(int personID)
        {
            // TODO:
            //
            throw new NotImplementedException();
        }

        #region Name
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get
            {
                if (_name == null)
                {
                    _name = string.Empty;
                }
                return _name;
            }
            set
            {
                _name = value;
            }
        } private string _name;
        #endregion //Name
    }

    class PersonCollection : Collection<Person>
    {
    }

    class Group : IDBase
    {
        #region Name
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get
            {
                if (_name == null)
                {
                    _name = string.Empty;
                }
                return _name;
            }
            set
            {
                _name = value;
            }
        } private string _name;
        #endregion //Name

        #region Persons
        /// <summary>
        /// 
        /// </summary>
        public PersonCollection Persons
        {
            get
            {
                if (_persons == null)
                {
                    _persons = new PersonCollection();
                }
                return _persons;
            }
            set
            {
                _persons = value;
            }
        } private PersonCollection _persons;
        #endregion //Persons
    }

    class GroupCollection : Collection<Group>
    {
    }

    public enum LeaveEnum
    {
        Private = 0,
        Sick = 1,
        Vacation = 2,
        //Out = 3,
    }

    class Leave
    {
        #region LeaveEnum
        /// <summary>
        /// 
        /// </summary>
        public LeaveEnum LeaveEnum
        {
            get
            {
                return _leaveEnum;
            }
            set
            {
                _leaveEnum = value;
            }
        } private LeaveEnum _leaveEnum;
        #endregion //LeaveEnum

        #region Begin
        /// <summary>
        /// 
        /// </summary>
        public DateTime Begin
        {
            get
            {
                return _begin;
            }
            set
            {
                _begin = value;
            }
        } private DateTime _begin;
        #endregion //Begin

        #region End
        /// <summary>
        /// 
        /// </summary>
        public DateTime End
        {
            get
            {
                return _end;
            }
            set
            {
                _end = value;
            }
        } private DateTime _end;
        #endregion //End

    }

    class LeaveCollection : Collection<Leave>
    {
    }

    enum KResultEnum
    {
        Normal = 0,
        Later = 1,
        Early = 2,

        LaterEarly = 3,
        Lose = 4,
        Leave = 5,

        Out = 6,
        Rest = 7,
        None = 999,
    }


    //class KResult
    //{
    //}

    //class KResultCollection : Collection<KResult>
    //{
    //}

    class Tm : IDBase
    {
        #region SN
        /// <summary>
        /// 
        /// </summary>
        public string SN
        {
            get
            {
                if (_sN == null)
                {
                    _sN = string.Empty;
                }
                return _sN;
            }
            set
            {
                _sN = value;
            }
        } private string _sN;
        #endregion //SN


        #region TmDatas
        /// <summary>
        /// 
        /// </summary>
        public TmDataCollection TmDatas
        {
            get
            {
                if (_tmDatas == null)
                {
                    _tmDatas = new TmDataCollection();
                }
                return _tmDatas;
            }
            set
            {
                _tmDatas = value;
            }
        } private TmDataCollection _tmDatas;
        #endregion //TmDatas

        /// <summary>
        /// 
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public TmDataCollection GetTmDatas(string begin, string end)
        {
            throw new NotImplementedException();
        }
    }

    class TmCollection : Collection<Tm>
    {
    }

    class TmData : IDBase
    {
        #region DT
        /// <summary>
        /// 
        /// </summary>
        public DateTime DT
        {
            get
            {
                return _dT;
            }
            set
            {
                _dT = value;
            }
        } private DateTime _dT;
        #endregion //DT
    }

    class TmDataCollection : Collection<TmData>
    {
    }

}
