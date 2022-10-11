using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<Person> persons = new List<Person>();

            while (input != "END")
            {
                string[] personsData = input.Split(" ");

                string name = personsData[0];
                int age = int.Parse(personsData[1]);
                string town = personsData[2];

                Person person = new Person(name, age, town);
                persons.Add(person);

                input = Console.ReadLine();
            }

            int index = int.Parse(Console.ReadLine()) - 1;

            int matches = 0;

            foreach (var person in persons)
            {
                if (persons[index].CompareTo(person) == 0)
                {
                    matches++;
                }
            }

            if (matches <= 1)
            {
                Console.WriteLine("No matches");
            }

            else
            {
                Console.WriteLine($"{matches} {persons.Count - matches} {persons.Count}");
            }

        }
    }
}
