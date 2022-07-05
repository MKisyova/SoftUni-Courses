using System;
using System.Collections.Generic;
using System.Linq;

namespace CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputCupsCapacity = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int[] inputBottle = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            Stack<int> bottles = new Stack<int>();

            for (int i = 0; i < inputBottle.Length; i++)
            {
                bottles.Push(inputBottle[i]);
            }

            Queue<int> cups = new Queue<int>();

            for (int i = 0; i < inputCupsCapacity.Length; i++)
            {
                cups.Enqueue(inputCupsCapacity[i]);
            }

            int wastedWater = 0;
            int leftToFill = 0;

            while (bottles.Count > 0 && cups.Count > 0)
            {
                int nextCup = cups.Peek();

                if (nextCup - leftToFill > bottles.Peek())
                {
                    leftToFill += bottles.Peek();
                    bottles.Pop();
                }

                else 
                {
                    cups.Dequeue();
                    wastedWater += bottles.Peek() - (nextCup - leftToFill);
                    bottles.Pop();
                    leftToFill = 0;
                }
            }

            if (cups.Count > 0)
            {
                int[] cupsLeft = cups.ToArray();
                Console.WriteLine("Cups: " + string.Join(" ", cupsLeft));
            }

            else // bottles > 0
            {
                int[] bottlesLeft = bottles.ToArray();

                for (int i = 0; i < bottles.Count; i++)
                {
                    bottlesLeft[i] = bottles.Pop();
                }

                Console.WriteLine("Bottles: " + string.Join(" ", bottlesLeft));
            }

            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
