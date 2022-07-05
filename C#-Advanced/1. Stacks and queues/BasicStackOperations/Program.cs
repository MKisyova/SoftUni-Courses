using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int elementsToPush = input[0];
            int elementsToPop = input[1];
            int elementToLookFor = input[2];

            int[] elToStack = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Stack<int> stackInt = new Stack<int>();

            for (int i = 0; i < elementsToPush; i++)
            {
                stackInt.Push(elToStack[i]);
            }

            for (int i = 0; i < elementsToPop; i++)
            {
                stackInt.Pop();
            }

            if (stackInt.Contains(elementToLookFor))
            {
                Console.WriteLine("true");
            }

            else
            {
                if (stackInt.Count > 0)
                {
                    int smallestNumber = int.MaxValue;
                    foreach (var number in stackInt)
                    {
                        if (number < smallestNumber)
                        {
                            smallestNumber = number;
                        }
                    }
                    Console.WriteLine(smallestNumber);

                }

                else
                {
                    Console.WriteLine(0);
                }

            }

        }
    }
}
