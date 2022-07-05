using System;
using System.Collections.Generic;

namespace EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<int, int> numbers = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int inputNumber = int.Parse(Console.ReadLine());

                if (!numbers.ContainsKey(inputNumber))
                {
                    numbers.Add(inputNumber, 0);
                }

                numbers[inputNumber]++;
            }

            foreach (var element in numbers)
            {
                if (element.Value % 2 == 0)
                {
                    Console.WriteLine(element.Key);
                }
            }
        }
    }
}
