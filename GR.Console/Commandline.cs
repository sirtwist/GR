using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace GR.Console
{
    /// <summary>
    /// Options object for the commandline
    /// </summary>
    internal class CommandlineOptions
    {

        /// <summary>
        /// File path to parse
        /// </summary>
        [Option('r', "read", Required = true, HelpText = "Input file to process")]
        public string FilePath { get; set; }

        /// <summary>
        /// Sort type
        /// </summary>
        [Option('s', "sort", Required = true, HelpText = "Output sort type (1 - gender, 2 - birth date, 3 - last name)")]
        public int SortType { get; set; }
    }

}
