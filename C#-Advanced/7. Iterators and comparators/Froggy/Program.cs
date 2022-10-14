using System;
using System.Linq;

namespace Froggy
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            Lake lakeNumbers = new Lake(numbers);

            Console.WriteLine(string.Join(", ", lakeNumbers));
        }
    }
}
