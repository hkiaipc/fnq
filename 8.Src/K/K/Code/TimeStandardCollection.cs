using System;
using Xdgk.Common;

namespace K
{
    internal class TimeStandardCollection : Collection<TimeStandard>
    {

        public void Add(TimeStandardCollection value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            foreach (TimeStandard item in value)
            {
                this.Add(item);
            }
        }
    }
}
