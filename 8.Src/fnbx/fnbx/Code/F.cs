using System;
using System.Data;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BXDB;

namespace fnbx
{
    /// <summary>
    /// 
    /// </summary>
    public class F
    {
        #region ItName
        /// <summary>
        /// 
        /// </summary>
        public string ItName
        {
            get
            {
                if (_itName == null)
                {
                    _itName = string.Empty;
                }
                return _itName;
            }
            set
            {
                _itName = value;
            }
        } private string _itName;
        #endregion //ItName

        #region ItAddress
        /// <summary>
        /// 
        /// </summary>
        public string ItAddress
        {
            get
            {
                if (_itAddress == null)
                {
                    _itAddress = string.Empty;
                }
                return _itAddress;
            }
            set
            {
                _itAddress = value;
            }
        } private string _itAddress;
        #endregion //ItAddress

        #region ItPhone
        /// <summary>
        /// 
        /// </summary>
        public string ItPhone
        {
            get
            {
                if (_itPhone == null)
                {
                    _itPhone = string.Empty;
                }
                return _itPhone;
            }
            set
            {
                _itPhone = value;
            }
        } private string _itPhone;
        #endregion //ItPhone

        #region ItRemark
        /// <summary>
        /// 
        /// </summary>
        public string ItRemark
        {
            get
            {
                if (_itRemark == null)
                {
                    _itRemark = string.Empty;
                }
                return _itRemark;
            }
            set
            {
                _itRemark = value;
            }
        } private string _itRemark;
        #endregion //ItRemark

        #region MtPoseDT
        /// <summary>
        /// 
        /// </summary>
        public DateTime MtPoseDT
        {
            get
            {
                return _mtPoseDT;
            }
            set
            {
                _mtPoseDT = value;
            }
        } private DateTime _mtPoseDT;
        #endregion //MtPoseDT

        #region CreateDT
        /// <summary>
        /// 
        /// </summary>
        public DateTime MTCreateDT
        {
            get
            {
                return _mtCreateDT;
            }
            set
            {
                _mtCreateDT = value;
            }
        } private DateTime _mtCreateDT;
        #endregion //CreateDT

        #region MtBeginDT
        /// <summary>
        /// 
        /// </summary>
        public DateTime MtBeginDT
        {
            get
            {
                return _mtBeginDT;
            }
            set
            {
                _mtBeginDT = value;
            }
        } private DateTime _mtBeginDT;
        #endregion //MtBeginDT

        #region MtTimeoutDT
        /// <summary>
        /// 
        /// </summary>
        public DateTime MtTimeoutDT
        {
            get
            {
                return _mtTimeoutDT;
            }
            set
            {
                _mtTimeoutDT = value;
            }
        } private DateTime _mtTimeoutDT;
        #endregion //MtTimeoutDT

        #region MtLocation
        /// <summary>
        /// 
        /// </summary>
        public string MtLocation
        {
            get
            {
                if (_mtLocation == null)
                {
                    _mtLocation = string.Empty;
                }
                return _mtLocation;
            }
            set
            {
                _mtLocation = value;
            }
        } private string _mtLocation;
        #endregion //MtLocation

        #region MtContent
        /// <summary>
        /// 
        /// </summary>
        public string MtContent
        {
            get
            {
                if (_mtContent == null)
                {
                    _mtContent = string.Empty;
                }
                return _mtContent;
            }
            set
            {
                _mtContent = value;
            }
        } private string _mtContent;
        #endregion //MtContent

        #region MtRemark
        /// <summary>
        /// 
        /// </summary>
        public string MtRemark
        {
            get
            {
                if (_mtRemark == null)
                {
                    _mtRemark = string.Empty;
                }
                return _mtRemark;
            }
            set
            {
                _mtRemark = value;
            }
        } private string _mtRemark;
        #endregion //MtRemark

        #region MtOperatorName
        /// <summary>
        /// 
        /// </summary>
        public string MtOperatorName
        {
            get
            {
                if (_mtOperatorName == null)
                {
                    _mtOperatorName = string.Empty;
                }
                return _mtOperatorName;
            }
            set
            {
                _mtOperatorName = value;
            }
        } private string _mtOperatorName;
        #endregion //MtOperatorName

        #region RcDT
        /// <summary>
        /// 
        /// </summary>
        public DateTime RcDT
        {
            get
            {
                return _rcDT;
            }
            set
            {
                _rcDT = value;
            }
        } private DateTime _rcDT;
        #endregion //RcDT

        #region RcOperatorName
        /// <summary>
        /// 
        /// </summary>
        public string RcOperatorName
        {
            get
            {
                if (_rcOperatorName == null)
                {
                    _rcOperatorName = string.Empty;
                }
                return _rcOperatorName;
            }
            set
            {
                _rcOperatorName = value;
            }
        } private string _rcOperatorName;
        #endregion //RcOperatorName

        #region RpContent
        /// <summary>
        /// 
        /// </summary>
        public string RpContent
        {
            get
            {
                if (_rpContent == null)
                {
                    _rpContent = string.Empty;
                }
                return _rpContent;
            }
            set
            {
                _rpContent = value;
            }
        } private string _rpContent;
        #endregion //RpContent

        #region RpRemark
        /// <summary>
        /// 
        /// </summary>
        public string RpRemark
        {
            get
            {
                if (_rpRemark == null)
                {
                    _rpRemark = string.Empty;
                }
                return _rpRemark;
            }
            set
            {
                _rpRemark = value;
            }
        } private string _rpRemark;
        #endregion //RpRemark

        #region RpEndDT
        /// <summary>
        /// 
        /// </summary>
        public DateTime RpEndDT
        {
            get
            {
                return _rpEndDT;
            }
            set
            {
                _rpEndDT = value;
            }
        } private DateTime _rpEndDT;
        #endregion //RpEndDT

        #region RpWorker
        /// <summary>
        /// 
        /// </summary>
        public string RpWorker
        {
            get
            {
                if (_rpWorker == null)
                {
                    _rpWorker = string.Empty;
                }
                return _rpWorker;
            }
            set
            {
                _rpWorker = value;
            }
        } private string _rpWorker;
        #endregion //RpWorker

        #region FlStatus
        /// <summary>
        /// 
        /// </summary>
        public string FlStatus
        {
            get
            {
                if (_flStatus == null)
                {
                    _flStatus = string.Empty;
                }
                return _flStatus;
            }
            set
            {
                _flStatus = value;
            }
        } private string _flStatus;
        #endregion //FlStatus

        #region TblFlow
        /// <summary>
        /// 
        /// </summary>
        public tblFlow TblFlow
        {
            get
            {
                return _tblFlow;
            }
            set
            {
                _tblFlow = value;
            }
        } private tblFlow _tblFlow;
        #endregion //TblFlow


    }

    public class FlowConverter
    {
        static public F Convert(tblFlow fl)
        {
            F f = new F();

            f.FlStatus = fl.GetFLStatusText();   

            tblIntroducer it = fl.tblIntroducer;
            f.ItAddress = it.it_address;
            f.ItName = it.it_name;
            f.ItPhone = it.it_phone ;
            f.ItRemark = it.it_remark;

            tblMaintain mt = fl.tblMaintain ;
            f.MtBeginDT = mt.mt_begin_dt;
            f.MtContent = mt.mt_content;
            f.MTCreateDT = mt.mt_create_dt;
            f.MtLocation = mt.mt_location;
            f.MtPoseDT = mt.mt_pose_dt;
            f.MtRemark = mt.mt_remark;
            f.MtTimeoutDT = mt.mt_timeout_dt;
            f.MtOperatorName = mt.tblOperator.op_name;

            tblReceive rc = fl.tblReceive;
            if (rc != null)
            {
                f.RcDT = fl.tblReceive.rc_dt;
                f.RcOperatorName = fl.tblReceive.tblOperator.op_name;
            }

            tblReply rp = fl.tblReply;
            if (rp != null)
            {
                f.RpContent = rp.rp_content;
                f.RpEndDT = (DateTime)rp.rp_end_dt;
                f.RpRemark = rp.rp_remark;
                f.RpWorker = rp.rp_worker;
            }

            f.TblFlow = fl;
            return f;
            
        }

        static public F[] Convert(tblFlow[] flArray)
        {
            F[] array = new F[flArray.Length];
            for (int i = 0; i < flArray.Length; i++)
            {
                tblFlow fl = flArray[i];
                F f = Convert(fl);
                array[i] = f;
            }
            return array;
        }


        static public DataTable Convert(F[] fs)
        {
            DataTable t = new DataTable();
            Type ftp = typeof(F);
            PropertyInfo[] pis = ftp.GetProperties();
            foreach (PropertyInfo pi in pis)
            {
                DataColumn col = new DataColumn(pi.Name, pi.PropertyType);
                t.Columns.Add(col);
            }

            foreach (F item in fs)
            {
                DataRow row = t.NewRow();
                foreach (PropertyInfo pi in pis)
                {
                    string colName = pi.Name ;
                    object value = pi.GetValue(item, null);
                    row[colName] = value;
                }

                t.Rows.Add(row);
            }
            return t;
        }

    }
}
