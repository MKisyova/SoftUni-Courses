using System;
using System.Collections.Generic;
using System.Linq;

namespace FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int start = input[0];
            int end = input[1];

            List<int> numbers = Enumerable.Range(start, end - start + 1).ToList();

            string command = Console.ReadLine();

            Predicate<int> isEven = number => number % 2 == 0;
            Action<int[]> print = numbers => Console.WriteLine(string.Join(" ", numbers));

            if (command == "even")
            {
                print(numbers.Where(x => isEven(x)).ToArray());
            }

            else
            {
                print(numbers.Where(x => !isEven(x)).ToArray());
            }
        }

    }
}
