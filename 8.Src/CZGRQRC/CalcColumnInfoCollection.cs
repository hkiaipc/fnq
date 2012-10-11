using System;
using System.Collections.Generic;
using System.Text;

namespace FNGRQRC
{

    /// <summary>
    /// 
    /// </summary>
    public class CalcColumnInfoCollection : Xdgk.Common.Collection<CalcColumnInfo>
    {
        public static CalcColumnInfoCollection GRDataCalcColumns
        {
            get
            {
                if (_calcColumnInfoCollection == null)
                {
                    string[] s = new string[]
                    {
                        "DiffT1", "GT1 - BT1",
                        "DiffT2", "GT2 - BT2",
                        "DiffP1", "GP1 - BP1",
                        "DiffP2", "GP2 - BP2",
                        "DiffBT1GT2", "BT1 - GT2",
                    };

                    _calcColumnInfoCollection = new CalcColumnInfoCollection();

                    for (int i = 0; i < s.Length; i += 2)
                    {
                        CalcColumnInfo cci = new CalcColumnInfo(s[i], s[i + 1]);
                        _calcColumnInfoCollection.Add(cci);
                    }
                }
                return _calcColumnInfoCollection;
            }
        } static private CalcColumnInfoCollection _calcColumnInfoCollection;
    }
}
