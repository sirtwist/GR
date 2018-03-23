using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GR.Shared
{
    public enum OutputType
    {
        Gender = 1,
        Birthdate = 2,
        Lastname = 3
    }

    public static class Output
    {
        public static OutputType GetOutputType(int input)
        {
            var values = Enum.GetValues(typeof(OutputType)).Cast<int>();
            if (input < values.Min() || input > values.Max())
            {
                throw new ArgumentOutOfRangeException("input", "Output type must be a number between " + values.Min().ToString() + " and " + values.Max().ToString());
            }
            return (OutputType)input;
        }

        public static string Format(IEnumerable<Record> original, OutputType outputType)
        {
            StringBuilder output = new StringBuilder();
            List<Record> sorted = Sort(original, outputType);
            sorted.ForEach(x =>
            {
                output.AppendLine(x.ToString());
            });
            return output.ToString();
        }

        public static List<Record> Sort(IEnumerable<Record> original, OutputType outputType)
        {
            List<Record> sorted = new List<Record>();
            switch (outputType)
            {
                case OutputType.Gender:
                    sorted = original.OrderBy(x => x.Gender).ThenBy(x => x.LastName).ToList();
                    break;
                case OutputType.Birthdate:
                    sorted = original.OrderBy(x => x.DateOfBirth).ToList();
                    break;
                case OutputType.Lastname:
                    sorted = original.OrderByDescending(x => x.LastName).ToList();
                    break;
            }
            return sorted;
        }

    }
}
