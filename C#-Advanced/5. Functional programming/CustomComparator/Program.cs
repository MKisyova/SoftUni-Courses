using System;
using System.Linq;

namespace CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            Predicate<int> even = x => x % 2 == 0;

            Array.Sort(numbers);
        }
    }
}
