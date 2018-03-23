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
            var parser = new CommandLine.Parser(with =>
            {
                with.CaseSensitive = false;
                with.HelpWriter = System.Console.Error;
            });

            return parser.ParseArguments<CommandlineOptions>(args).MapResult(
                (CommandlineOptions opts) => ProcessFile(opts.FilePath, Output.GetOutputType(opts.OutputType)),
                errs => 1
                );

        }

        public static int ProcessFile(string filename, OutputType outputType)
        {
            if (!File.Exists(filename))
            {
                throw new FileNotFoundException("File not found", filename);
            }
            var lines = File.ReadAllLines(filename);

            var factory = new PersonFactory();

            List<Record> records = new List<Record>();

            foreach (var line in lines.Where(x => !String.IsNullOrEmpty(x)))
            {
                records.Add(factory.ParseLine(line));
            }

            System.Console.WriteLine(Output.Format(records, outputType));

            return RETURN_SUCCESS;
        }

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
