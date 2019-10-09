using System;
using System.Collections.Generic;
using System.Text;

namespace HelloAcademy
{
    public class Person
    {
        public readonly string Address;

        public string Address2 { get; }



        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public int Age
        {
            get { return DateTime.Now.Year - BirthDate.Year; }
        }

        public string GetFullName()
        {
            string fullName = FirstName +
                              " " +
                              LastName;

            return fullName;
        }

        /* public int GetAge()
        {
            return DateTime.Now.Year - BirthDate.Year;
        } */
    }
}
