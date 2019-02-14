using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLib
{
    public class Person:ICloneable
    {
        public int ID { get; private set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime DOB { get; set; }

        internal Person (int id, string lastName, string firstName, DateTime dob)
        {
            ID = id;
            LastName = lastName;
            FirstName = firstName;
            DOB = dob;
        }

        public Person(Person other) : this(other.ID, other.LastName, other.FirstName, other.DOB)
        { }

        public object Clone()
        {
            return new Person(this);
        }

        public int GetAge()
        {
            int age = DateTime.Now.Year - DOB.Year;

            if(DateTime.Now.Month < DOB.Month ||( DateTime.Now.Month == DOB.Month && DateTime.Now.Day < DOB.Day))
            {
                --age;
            }

            return age;
        }

        public string GetFormattedID()
        {
            string lastFourDigits = ID.ToString().Substring(ID.ToString().Length -4);
            return $"XXX-XX-{lastFourDigits}";
        }

        public override string ToString()
        {
            return $"{LastName,-15}{FirstName,-15}{DOB,15: MM-dd-yyyy}{GetAge(),5}     {GetFormattedID()}";
        }

        public static string GetHeader()
        {
            return $"{"LastName",-15}{"FirstName",-15}{"Date of birth",15: MM-dd-yyyy}{"Age",5}     {"SSN"}";
        }


    }
}
