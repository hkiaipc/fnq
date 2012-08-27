using System;
using System.Collections.Generic;
using System.Text;
using Xdgk.Common;
using System.IO;

namespace CZGRQRC
{
    using Path = System.IO.Path;

    /// <summary>
    /// 
    /// </summary>
    public class SoundPlayer
    {

        /// <summary>
        /// 
        /// </summary>
        static public string AlarmFileName
        {
            get 
            {
                if (_alarmFileName == null)
                {
                   _alarmFileName = 
                    Path.Combine( Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath), 
                    "Sound\\Alarm.wav" );
                }
                return _alarmFileName;
            }
        } static private string _alarmFileName;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static public bool PlayAlarmSound()
        {
            return WavePlayer.PlaySimple(AlarmFileName);
        }
    }
}
