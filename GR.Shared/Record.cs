using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GR.Shared
{
    public abstract class Record
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

        public abstract override bool Equals(object obj);

        public abstract override string ToString();

    }
}
