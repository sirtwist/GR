using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GR.Shared
{
    public class PersonFactory : RecordFactory
    {
        /// <summary>
        /// Parses the specified input string and returns a new Person object if the input is in the correct format
        /// </summary>
        /// <param name="input">Delimited string containing 5 elements (Lastname, Firstname, Gender, FavoriteColor, Birthdate)</param>
        /// <returns>Person object</returns>
        public override Record GetRecord(string[] input)
        {
            Person person = new Person();
            if (input.Count() != 5)
            {
                throw new ArgumentException("input array does not contain the required amount (5) of elements");
            }
            for (var i = 0; i < input.Count(); i++)
            {
                if (String.IsNullOrEmpty(input[i]))
                {
                    throw new FormatException("input[" + i.ToString() + "] is empty or null");
                }
            }
            person.LastName = input[0];
            person.FirstName = input[1];
            person.FavoriteColor = input[3];

            if (!Enum.TryParse<Gender>(input[2], out Gender g))
            {
                throw new FormatException("Unable to parse Gender from input[2]");
            }
            person.Gender = g;

            if (!DateTime.TryParse(input[4], out DateTime dob))
            {
                throw new FormatException("Unable to parse Date of Birth from input[4]");
            }

            person.DateOfBirth = dob.Date;
            return person;
        }
    }
}
