using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int elementsToEnqueue = input[0];
            int elementsToDequeue = input[1];
            int elementToLookFor = input[2];

            int[] elToQueue = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Queue<int> queueInt = new Queue<int>();

            for (int i = 0; i < elementsToEnqueue; i++)
            {
                queueInt.Enqueue(elToQueue[i]);
            }

            for (int i = 0; i < elementsToDequeue; i++)
            {
                queueInt.Dequeue();
            }


            if (queueInt.Contains(elementToLookFor))
            {
                Console.WriteLine("true");
            }

            else
            {
                if (queueInt.Count > 0)
                {
                    int smallestNumber = int.MaxValue;

                    foreach (var number in queueInt)
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
