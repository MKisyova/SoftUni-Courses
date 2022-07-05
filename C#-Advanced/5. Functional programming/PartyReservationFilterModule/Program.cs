using System;
using System.Collections.Generic;
using System.Linq;

namespace PartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> peopleAtParty = Console.ReadLine().Split(" ").ToList();

            var filters = new Dictionary<string, Predicate<string>>();

            string input = Console.ReadLine();

            while (input != "Print")
            {
                string[] commandArgs = input.Split(";");

                string action = commandArgs[0];
                string predicateAction = commandArgs[1];
                string value = commandArgs[2];

                string key = predicateAction + "_" + value;

                if (action == "Add filter")
                {
                    Predicate<string> predicate = GetPredicate(predicateAction, value);
                    filters.Add(key, predicate);
                }

                else
                {
                    filters.Remove(key);
                }

                input = Console.ReadLine();
            }

            foreach (var (key,predicate) in filters)
            {
                peopleAtParty.RemoveAll(predicate);
            }

            Console.WriteLine(string.Join(" ", peopleAtParty));
        }

        static Predicate<string> GetPredicate(string command, string argument)
        {
            if (command == "Starts with")
            {
                return x => x.StartsWith(argument);
            }

            else if (command == "Ends with")
            {
                return x => x.EndsWith(argument);
            }

            else if (command == "Contains")
            {
                return x => x.Contains(argument);
            }

            else
            {
                int length = int.Parse(argument);
                return x => x.Length == length;
            }

        }
    }
}
