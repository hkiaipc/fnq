using System;
using System.Collections.Generic;
using System.Text;

using Codeblast;
namespace FNGRQRC
{
    /// <summary>
    /// 
    /// </summary>
    public class CommandLineOptions :Codeblast.CommandLineOptions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public CommandLineOptions(string[] args)
            : base(args)
        {
            _args = args;
        }

        private string[] _args;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetArgsString()
        {
            return string.Join(" ", _args);
        }

        /// <summary>
        /// 
        /// </summary>
        public string StationName = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string Data = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string Appearance = string.Empty;
    }
}
