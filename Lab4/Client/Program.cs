using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonLib;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> personList = new List<Person>();

            PersonFactory factory = PersonFactory.Instance;

            personList.Add(factory.Create(123456789, "Smith", "John", DateTime.Parse("12 / 12 / 1992")));
            personList.Add(factory.Create(111223345, "Kwan", "Steve", DateTime.Parse("06 / 08 / 1978")));
            personList.Add(factory.Create(074897865, "Huey", "Leslie", DateTime.Parse("05 / 08 / 1984")));
            personList.Add(factory.Create(087458741, "Shmitz", "Rob", DateTime.Parse("04 / 01 / 1965")));
            personList.Add(factory.Create(123456789, "May", "Theresa", DateTime.Parse("08 / 09 / 1959")));

            Person clonedPerson = personList[3].Clone() as Person;

            try
            {
                clonedPerson.FirstName = "Dolly";
                clonedPerson.LastName = "The Human";
                clonedPerson.DOB = DateTime.Now;

            }
            catch(ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }


            personList.Add(clonedPerson);

            Console.WriteLine(Person.GetHeader());

            foreach(Person p in personList)
            {
                Console.WriteLine(p);
            }

            Console.ReadLine();

        }
    }
}
