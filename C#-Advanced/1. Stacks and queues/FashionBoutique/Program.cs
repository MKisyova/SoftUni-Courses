using System;
using System.Collections.Generic;
using System.Linq;

namespace FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int capacity = int.Parse(Console.ReadLine());

            int racks = 1;

            int capacityLeft = capacity;

            Stack<int> clothes = new Stack<int>();

            foreach (var cloth in input)
            {
                if (capacityLeft > cloth)
                {
                    clothes.Push(cloth);
                    capacityLeft -= cloth;

                }

                else if (capacityLeft == cloth)
                {
                    racks += 1;
                    capacityLeft = capacity;
                }

                else
                {
                    racks += 1;
                    capacityLeft = capacity - cloth;
                }
            }

            Console.WriteLine(racks);
        }
    }
}
