using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using GR.Shared;

namespace GR.Console
{
    internal class Program
    {
        private const int RETURN_SUCCESS = 0;

        private static int Main(string[] args)
        {
            // Set up the commandline parser
            var parser = new CommandLine.Parser(with =>
            {
                with.CaseSensitive = false;
                with.HelpWriter = System.Console.Error;
            });

            // Parse the commandline arguments and if successful, pass them to ProcessFile
            return parser.ParseArguments<CommandlineOptions>(args).MapResult(
                (CommandlineOptions opts) => ProcessFile(opts.FilePath, opts.SortType.ToSortOrder()),
                errs => 1
                );

        }

        /// <summary>
        /// Process the specified file and output the data in the specified sort order
        /// </summary>
        /// <param name="filename">Filename to parse</param>
        /// <param name="sortOrder"></param>
        /// <returns></returns>
        public static int ProcessFile(string filename, SortOrder sortOrder)
        {
            // Check to see if the file exists, if not throw an exception
            if (!File.Exists(filename))
            {
                throw new FileNotFoundException("File not found", filename);
            }

            // Read all the lines of the file
            var lines = File.ReadAllLines(filename);

            var factory = new PersonFactory();
            List<Record> records = new List<Record>();

            // For each line that isn't null or empty, parse the line and add the record to the list
            foreach (var line in lines.Where(x => !String.IsNullOrEmpty(x)))
            {
                records.Add(factory.ParseLine(line));
            }

            // Output the formatted output in the specified sort order
            System.Console.WriteLine(Output.Format(records, sortOrder));

            return RETURN_SUCCESS;
        }

        /// <summary>
        /// Output unhandled exceptions to the console
        /// </summary>
        /// <param name="sender">Sending object</param>
        /// <param name="e">Event arguments</param>
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;
            System.Console.WriteLine("Exception generated:");
            System.Console.WriteLine("");
            System.Console.WriteLine(ex.ToString());

            Environment.Exit(ex.HResult);
        }
    }
}
