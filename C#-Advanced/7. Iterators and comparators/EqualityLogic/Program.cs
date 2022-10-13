using System;
using System.Collections.Generic;

namespace EqualityLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            HashSet<Person> personsHashSet = new HashSet<Person>();
            SortedSet<Person> personsSortedSet = new SortedSet<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ");

                string name = input[0];
                int age = int.Parse(input[1]);

                Person person = new Person(name, age);

                personsHashSet.Add(person);
                personsSortedSet.Add(person);
            }

            Console.WriteLine(personsSortedSet.Count);
            Console.WriteLine(personsHashSet.Count);
        }
    }
}
