
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xdgk.Common;


namespace fnbx
{
    using TMStatusPair = KeyValuePair<FLStatus, FLStatus>;

    /// <summary>
    /// 
    /// </summary>
    public class SenderRight : Right
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static private List<TMStatusPair> GetSenderList()
        {
            if (_senderList == null)
            {
                _senderList = new List<TMStatusPair>();
                _senderList.Add(new TMStatusPair(FLStatus.Completed, FLStatus.Closed));
            }
            return _senderList;
        } static private List<TMStatusPair> _senderList;

        public SenderRight()
            : base(Right.SenderValue)
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
            foreach (TMStatusPair item in GetSenderList())
            {
                if (item.Key == current)
                {
                    r = true;
                    break;
                }
            }
            return r;
        }

        //public override bool CanActivateForRp(ADEState ade, FLStatus current)
        //{
        //    return false;
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ade"></param>
        /// <param name="current"></param>
        /// <returns></returns>
        public override bool CanActivateForFL(ADEState ade, FLStatus current)
        {
            bool r = false;
            switch (ade)
            {
                case ADEState.Add:
                    r = true;
                    break;

                case ADEState.Delete:
                    r = current == FLStatus.Created || current == FLStatus.New;
                    break;

                case ADEState.Edit:
                    r = current == FLStatus.Created || current == FLStatus.New || current == FLStatus.Completed;
                    break;

                default:
                    break;

            }
            return r;
        }

        public override string ToString()
        {
            return "Ω”œﬂ‘±";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override List<KeyValuePair<FLStatus, FLStatus>> GetStatusPairList()
        {
            return GetSenderList();
        }
    }

}
