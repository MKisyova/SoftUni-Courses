using System;
using System.Collections.Generic;
using System.Linq;

namespace KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(" ").ToList();

            Action<List<string>> print = input => input.ForEach(x => Console.WriteLine($"Sir {x}"));

            print(names);

        }
    }
}
