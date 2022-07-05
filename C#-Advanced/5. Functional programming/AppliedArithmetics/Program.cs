using System;
using System.Collections.Generic;
using System.Linq;

namespace AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();

            string command = Console.ReadLine();

            Func<List<int>, List<int>> add = newList =>
            {
                for (int i = 0; i < newList.Count; i++)
                {
                    newList[i]++;
                }

                return newList;
            };

            Func<List<int>, List<int>> multiply = newList =>
            {
                for (int i = 0; i < newList.Count; i++)
                {
                    newList[i] *= 2;
                }

                return newList;
            };

            Func<List<int>, List<int>> subtract = newList =>
            {
                for (int i = 0; i < newList.Count; i++)
                {
                    newList[i]--;
                }

                return newList;
            };

            Action<List<int>> print = newList => Console.WriteLine(string.Join(" ", newList));

            while (command != "end")
            {
                if (command == "add")
                {
                    add(numbers);
                }

                else if (command == "multiply")
                {
                    multiply(numbers);
                }

                else if (command == "subtract")
                {
                    subtract(numbers);
                }

                else if (command == "print")
                {
                    print(numbers);
                }

                command = Console.ReadLine();
            }
        }
    }
}
