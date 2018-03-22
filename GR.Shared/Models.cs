using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GR.Shared
{
    /// <summary>
    /// Gender options for Person object
    /// </summary>
    public enum Gender
    {
        Female,
        Male
    }

    /// <summary>
    /// Object representing an individual person
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Person's last name
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Person's first name
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Person's gender
        /// </summary>
        public Gender Gender { get; set; }
        /// <summary>
        /// Person's favorite color
        /// </summary>
        public string FavoriteColor { get; set; }
        /// <summary>
        /// Person's date of birth
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        public override bool Equals(object obj)
        {
            Person test = obj as Person;
            if (obj == null)
            {
                return false;
            }
            return LastName == test.LastName &&
                   FirstName == test.FirstName &&
                   Gender == test.Gender &&
                   FavoriteColor == test.FavoriteColor &&
                   DateOfBirth == test.DateOfBirth;
        }

        public static Person GetPerson(string[] input)
        {
            Person person = new Person();
            if (input.Count() != 5)
            {
                throw new FormatException("input array does not contain the required amount (5) of elements");
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
