using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GR.Shared
{
    /// <summary>
    /// Object representing an individual person
    /// </summary>
    public class Person : Record
    {
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

        public override string ToString()
        {
            return String.Format("{0},{1},{2},{3},{4}", this.LastName, this.FirstName, this.Gender.ToString(), this.FavoriteColor, this.DateOfBirth.ToString("M/d/yyyy"));
        }
    }
}
