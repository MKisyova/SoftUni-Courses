using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            Stack<int> stackOfIntegers = new Stack<int>();

            int maxNumber = int.MinValue;
            int minNumber = int.MaxValue;

            for (int i = 0; i < number; i++)
            {
                int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                if (input[0] == 1)
                {
                    stackOfIntegers.Push(input[1]);
                }

                else if (input[0] == 2)
                {
                    if (stackOfIntegers.Count > 0)
                    {
                        stackOfIntegers.Pop();

                    }
                }

                else if (input[0] == 3)
                {
                    foreach (var element in stackOfIntegers)
                    {
                        if (element >= maxNumber)
                        {
                            maxNumber = element;
                        }
                    }

                    if (stackOfIntegers.Contains(maxNumber))
                    {
                        Console.WriteLine(maxNumber);
                    }
                }

                else if (input[0] == 4)
                {
                    foreach (var element in stackOfIntegers)
                    {
                        if (element <= minNumber)
                        {
                            minNumber = element;
                        }
                    }

                    if (stackOfIntegers.Contains(minNumber))
                    {
                        Console.WriteLine(minNumber);
                    }

                }

            }

            Console.WriteLine(string.Join(", ", stackOfIntegers));


        }
    }
}
