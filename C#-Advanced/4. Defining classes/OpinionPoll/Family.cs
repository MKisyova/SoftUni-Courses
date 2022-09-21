using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        public List<Person> People { get; set; } = new List<Person>();


        public void AddMember(Person member)
        {
            People.Add(member);
        }

        public Person GetOldestMember()
        {
            Person oldestPerson = People.OrderByDescending(x => x.Age).FirstOrDefault();

            return oldestPerson; 
        }

        public void AlphabeticallyOrdered()
        {
            foreach (var person in People.OrderBy(x => x.Name))
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
