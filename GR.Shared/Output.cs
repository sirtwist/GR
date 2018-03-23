using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GR.Shared
{
    public enum SortOrder
    {
        GenderThenName = 1,
        Birthdate = 2,
        Lastname = 3
    }

    public static class Output
    {
        /// <summary>
        /// Convert the specified input integer to a SortOrder
        /// </summary>
        /// <param name="input">Integer to convert</param>
        /// <returns>SortOrder</returns>
        public static SortOrder ToSortOrder(this int input)
        {
            var values = Enum.GetValues(typeof(SortOrder)).Cast<int>();
            if (input < values.Min() || input > values.Max())
            {
                throw new ArgumentOutOfRangeException("input", "Output type must be a number between " + values.Min().ToString() + " and " + values.Max().ToString());
            }
            return (SortOrder)input;
        }

        /// <summary>
        /// Sort the provided records by the specified sort order and output the results to string
        /// </summary>
        /// <param name="records">Records to sort</param>
        /// <param name="sortOrder">Sort order type</param>
        /// <returns>Sorted comma-separated lines as a single string</returns>
        public static string Format(IEnumerable<Record> records, SortOrder sortOrder)
        {
            StringBuilder output = new StringBuilder();
            List<Record> sorted = Sort(records, sortOrder);
            sorted.ForEach(x =>
            {
                output.AppendLine(x.ToString());
            });
            return output.ToString();
        }


        /// <summary>
        /// Sort the provided records by the specified sort order
        /// </summary>
        /// <param name="records">Records to sort</param>
        /// <param name="sortOrder">Sort order type</param>
        /// <returns>IEnumerable of Record objects</returns>
        public static List<Record> Sort(IEnumerable<Record> records, SortOrder sortOrder)
        {
            List<Record> sorted = new List<Record>();
            switch (sortOrder)
            {
                case SortOrder.GenderThenName:
                    sorted = records.OrderBy(x => x.Gender).ThenBy(x => x.LastName).ToList();
                    break;
                case SortOrder.Birthdate:
                    sorted = records.OrderBy(x => x.DateOfBirth).ToList();
                    break;
                case SortOrder.Lastname:
                    sorted = records.OrderByDescending(x => x.LastName).ToList();
                    break;
            }
            return sorted;
        }

    }
}
