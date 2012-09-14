
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xdgk.Common;


namespace fnbx
{
    using TMStatusPair = KeyValuePair<FLStatus, FLStatus>;
    public class AdminRight : Right
    {
        static private List<TMStatusPair> GetList()
        {
            if (_list == null)
            {
                _list = new List<TMStatusPair>();
                _list.Add(new TMStatusPair(FLStatus.Created, FLStatus.Received));
                _list.Add(new TMStatusPair(FLStatus.Created, FLStatus.Timeouted));
                _list.Add(new TMStatusPair(FLStatus.Received, FLStatus.Timeouted));
                _list.Add(new TMStatusPair(FLStatus.Received, FLStatus.Completed));
                _list.Add(new TMStatusPair(FLStatus.Completed, FLStatus.Closed));

            }
            return _list;
        } static private List<TMStatusPair> _list;

        /// <summary>
        /// 
        /// </summary>
        public AdminRight()
            : base(Right.AdminValue)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="current"></param>
        /// <returns></returns>
        public override bool CanModifyFLStatus(FLStatus current)
        {
            bool r = false;
            foreach (TMStatusPair item in GetList())
            {
                if (item.Key == current)
                {
                    r = true;
                    break;
                }
            }
            return r;
        }

        public override bool CanActivateForFL(ADEState ade, FLStatus current)
        {
            bool r = false;
            switch (ade)
            {
                case ADEState.Add:
                    break;

                case ADEState.Delete:
                    r = true;
                    break;

                case ADEState.Edit:
                    break;

                default:
                    break;

            }
            return r;
        }

        //public override bool CanActivateForRp(ADEState ade, FLStatus current)
        //{
        //    bool r = false;
        //    switch (ade)
        //    {
        //        case ADEState.Add:
        //            break;

        //        case ADEState.Delete:
        //            r = true;
        //            break;

        //        case ADEState.Edit:
        //            break;

        //        default:
        //            break;

        //    }
        //    return r;
        //}

        public override string ToString()
        {
            return "π‹¿Ì‘±";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override List<KeyValuePair<FLStatus, FLStatus>> GetStatusPairList()
        {
            return GetList();
        }
    }

}
