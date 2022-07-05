using System;
using System.Collections.Generic;
using System.Linq;

namespace TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfStations = int.Parse(Console.ReadLine());

            Queue<int> petrolGiven = new Queue<int>();
            Queue<int> distance = new Queue<int>();

            int startedStation = 0;

            for (int i = 0; i < numberOfStations; i++)
            {
                int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                petrolGiven.Enqueue(input[0]);
                distance.Enqueue(input[1]);
            }

            int difference = 0;

            while (distance.Count > 0)
            {
                int petrolToRemove = petrolGiven.Peek() + difference;

                int distanceToRemove = distance.Peek();

                if (petrolToRemove < distanceToRemove)
                {
                    petrolGiven.Dequeue();

                    petrolGiven.Enqueue(petrolToRemove);

                    distance.Dequeue();

                    distance.Enqueue(distanceToRemove);

                    startedStation++;
                }

                else
                {
                    difference = petrolToRemove - distanceToRemove;

                    petrolGiven.Dequeue();

                    distance.Dequeue();
                }
            }

            Console.WriteLine(startedStation);
        }
    }
}
