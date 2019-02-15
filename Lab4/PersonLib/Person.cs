using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLib
{
    public class Person:ICloneable
    {
        private int _ID;
        private DateTime _DOB;
        private string _LastName;
        private string _FirstName;
        public int ID
        {
            get
            {
                return _ID;
            }

            private set
            {
                if (value > 0 && value < 999999999)
                {
                    _ID = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Valid SSN must be postive and less than 999999999");
                }
            }
        }

        public DateTime DOB
        {
            get
            {
                return _DOB;
            }
            set
            {
                if (value <= DateTime.Now )
                {
                    _DOB = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Date of birth cannot be in the future!");
                }
            }
        }
        public string LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                if(!String.IsNullOrEmpty(value))
                {
                    _LastName = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Last name cannot be blank!");
                }
            }
        }
        public string FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                if(!String.IsNullOrEmpty(value))
                {
                   _FirstName = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("First name cannot be blank!");
                }
            }
        }
       

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
            string SSN = $"{ID: 000000000}";
            string lastFourDigits = SSN.Substring(6);
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
