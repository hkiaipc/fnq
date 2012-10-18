using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Xdgk.Common
{
    public class WavePlayer //: IDisposable   
    {
        private const int SND_SYNC            = 0x0000  ; /* play synchronously (default) */
        private const int SND_ASYNC           = 0x0001  ; /* play asynchronously */
        private const int SND_NODEFAULT       = 0x0002  ; /* silence (!default) if sound not found */
        private const int SND_MEMORY          = 0x0004  ; /* pszSound points to a memory file */
        private const int SND_LOOP            = 0x0008  ; /* loop the sound until next sndPlaySound */
        private const int SND_NOSTOP          = 0x0010  ; /* don't stop any currently playing sound */

        private const int SND_NOWAIT      = (int)0x00002000L ; /* don't wait if the driver is busy */
        private const int SND_ALIAS       = (int)0x00010000L ; /* name is a registry alias */
        private const int SND_ALIAS_ID    = (int)0x00110000L ; /* alias is a predefined ID */
        private const int SND_FILENAME    = (int)0x00020000L ; /* name is file name */
        private const int SND_RESOURCE    = (int)0x00040004L ; /* name is resource name or atom */

        
        [DllImport("winmm.DLL", EntryPoint="PlaySound",  SetLastError=true)]//,
            // CharSet=CharSet.Unicode, ExactSpelling=true,
            // CallingConvention=CallingConvention.StdCall)]
        private static extern bool PlaySound(
            string pszSound,  
            int hmod,     
            uint fdwSound    
            );

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        static public bool PlaySimple( string fileName )
        {
            return PlaySound( fileName, 0, SND_FILENAME | SND_ASYNC | SND_NOSTOP );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static public bool StopSimple()
        {
            return PlaySound( null, 0, 0 );
        }

        private string      _fileName; 
        private bool        _async          = true;
        private bool        _noStop         = true;
        private bool        _loop           = false;
        private bool        _isNoDefault    = false;

        
        /// <summary>
        /// 
        /// </summary>
        public string FileName
        {
            get { return _fileName; } 
            set { _fileName = value; }
        }
        
        /// <summary>
        /// play asynchronously
        /// </summary>
        public bool IsAsync
        {
            get { return _async; }
            set { _async = value; }
        }

        /// <summary>
        /// don't stop any currently playing sound
        /// </summary>
        public bool IsNoStop
        {
            get { return _noStop; }
            set { _noStop = value; }
        }

        /// <summary>
        /// loop the sound until next sndPlaySound
        /// </summary>
        public bool IsLoop
        {
            get { return _loop; }
            set 
            {
                _loop = value; 
                if ( _loop )
                    _async = true;
            }
            
        }

        /// <summary>
        /// silence (!default) if sound not found
        /// </summary>
        public bool IsNoDefault
        {
            get { return _isNoDefault; }
            set { _isNoDefault = value; }
        }

        /// <summary>
        /// Play sound
        /// </summary>
        /// <returns></returns>
        public bool Play()
        {
            uint flag = GetFlag() ;
            return PlaySound( _fileName, 0, flag );
        }

        /// <summary>
        /// Stop sound
        /// </summary>
        /// <returns></returns>
        public bool Stop()
        {
            return PlaySound( null, 0, 0 );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private uint GetFlag()
        {
            uint r = 0;
            r = r | SND_FILENAME;
            if ( _async )
                r |= SND_ASYNC;
            if ( _noStop )
                r |= SND_NOSTOP;
            if ( _loop )
                r |= SND_LOOP;
            if ( _isNoDefault )
                r |= SND_NODEFAULT;
            return r;
        }
    }
}