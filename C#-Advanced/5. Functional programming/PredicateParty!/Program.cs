using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> peopleAtParty = Console.ReadLine().Split(" ").ToList();

            Func<string, int, bool> length = (word, n) => word.Length == n;
            Func<string, string, bool> startWith = (word, start) => word.StartsWith(start);
            Func<string, string, bool> endWith = (word, end) => word.EndsWith(end);

            List<string> finalParty = new List<string>();

            foreach (var person in peopleAtParty)
            {
                finalParty.Add(person);
            }

            string input = Console.ReadLine();

            while (input != "Party!")
            {
                string[] inputCommand = input.Split(" ");

                string action = inputCommand[0];
                string criteria = inputCommand[1];

                peopleAtParty.Clear();

                foreach (var person in finalParty)
                {
                    peopleAtParty.Add(person);
                }

                if (criteria == "StartsWith")
                {
                    string start = inputCommand[2];
                    ForeachAllPeople(peopleAtParty, startWith, finalParty, action, start);
                }

                else if (criteria == "EndsWith")
                {
                    string end = inputCommand[2];
                    ForeachAllPeople(peopleAtParty, endWith, finalParty, action, end);
                }

                else if (criteria == "Length")
                {
                    int number = int.Parse(inputCommand[2]);
                    ForeachAllLength(peopleAtParty, length, finalParty, action, number);

                }

                input = Console.ReadLine();
            }

            if (finalParty.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }

            else
            {
                Console.WriteLine(string.Join(", ", finalParty) + " are going to the party!");
            }
        }

        private static void ForeachAllLength(List<string> peopleAtParty, Func<string, int, bool> length, 
            List<string> finalParty, string action, int num)
        {

            for (int i = 0; i < peopleAtParty.Count; i++)
            {
                string person = peopleAtParty[i];

                if (length(person, num))
                {
                    if (action == "Remove")
                    {
                        finalParty.Remove(person);
                    }

                    else if (action == "Double")
                    {
                        finalParty.Insert(i + 1, person);
                    }
                }
            }

        }

        private static void ForeachAllPeople(List<string> peopleAtParty, Func<string, string, bool> startWith, 
            List<string> finalParty, string action, string start)
        {

            for (int i = 0; i < peopleAtParty.Count; i++)
            {
                string person = peopleAtParty[i];

                if (startWith(person, start))
                {
                    if (action == "Remove")
                    {
                        finalParty.Remove(person);
                    }

                    else if (action == "Double")
                    {
                        finalParty.Insert(i + 1, person);
                    }
                }
            }

        }
    }
}
