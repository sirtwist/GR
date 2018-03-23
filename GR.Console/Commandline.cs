using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace GR.Console
{

    internal class CommandlineOptions
    {

        [Option('r', "read", Required = true, HelpText = "Input file to process")]
        public string FilePath { get; set; }

        [Option('s', "output", Required = true, HelpText = "Output sort type (1 - gender, 2 - birth date, 3 - last name)")]
        public int OutputType { get; set; }
    }

}
