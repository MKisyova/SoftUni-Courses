using System;
using System.Collections.Generic;
using System.Linq;

namespace ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var sides = new Dictionary<string, SortedSet<string>>();

            while (input != "Lumpawaroo")
            {
                if (input.Contains(" | "))
                {
                    string[] splittedInput = input.Split(" | ");

                    string forceSide = splittedInput[0];
                    string forceUser = splittedInput[1];

                    if (!sides.ContainsKey(forceSide))
                    {
                        sides.Add(forceSide, new SortedSet<string>());
                    }

                    sides[forceSide].Add(forceUser);
                }

                else
                {
                    string[] splittedInput = input.Split(" -> ");

                    string forceUser = splittedInput[0];
                    string forceSide = splittedInput[1];

                    if (!sides.ContainsKey(forceSide))
                    {
                        sides.Add(forceSide, new SortedSet<string>());
                    }

                    bool isTheSame = false;

                    foreach (var side in sides)
                    {
                        if (side.Value.Contains(forceUser))
                        {
                            if (side.Key == forceSide)
                            {
                                isTheSame = true;
                            }

                            side.Value.Remove(forceUser);
                        }
                    }

                    sides[forceSide].Add(forceUser);

                    if (isTheSame == false)
                    {
                        Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                    }

                }

                input = Console.ReadLine();
            }

            foreach (var side in sides.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                if (side.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");

                    foreach (var user in side.Value)
                    {
                        Console.WriteLine($"! {user}");
                    }
                }
            }
        }
    }
}
