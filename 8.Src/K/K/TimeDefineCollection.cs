using System;
using Xdgk.Common;

namespace K
{
    [Serializable]
    public class TimeDefineCollection : Collection<TimeDefine>
    {
        protected override void InsertItem(int index, TimeDefine item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                TimeDefine td = this[i];
                if (TimeDefineHelper.IsOverlapped(td, item))
                {
                    string msg = string.Format(
                            "{0} {1} is overlapped",
                            td, item);
                    throw new KConfigException(msg);
                }
            }
            base.InsertItem(index, item);
        }
    }

}
