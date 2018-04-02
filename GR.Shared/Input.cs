using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GR.Shared
{
    public static class Input
    {
        /// <summary>
        /// Parses a line of text to convert to a Person object. Three seperator formats are supported (" | ", ", ", " ")
        /// </summary>
        /// <param name="Input">line of text to parse</param>
        /// <returns>Person object parsed from input</returns>
        public static Record ParseLine(this RecordFactory Factory, string Input)
        {
            string[] delimiters = new string[] { " | ", ", ", " " };

            foreach (var delimiter in delimiters)
            {
                string[] elements = Input.Split(new string[] { delimiter }, StringSplitOptions.RemoveEmptyEntries);
                if (elements.Count() == 5)
                {
                    return Factory.GetRecord(elements);
                }
            }

            // Unable to determine delimiter format
            throw new FormatException("Unable to determine line format; split did not return 5 elements");
        }
    }
}
