using System;
using System.Collections.Generic;
using System.Linq;

namespace FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantityOfFood = int.Parse(Console.ReadLine());

            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            Queue<int> orders = new Queue<int>();

            int maxOrder = int.MinValue;

            bool ifOrdersLeft = false;

            foreach (var order in input)
            {
                orders.Enqueue(order);

                if (order >= maxOrder)
                {
                    maxOrder = order;
                }

                if (order <= quantityOfFood)
                {
                    orders.Dequeue();
                    quantityOfFood -= order;
                }

                else
                {
                    ifOrdersLeft = true;
                }
            }


            Console.WriteLine(maxOrder);

            if (ifOrdersLeft)
            {
                Console.WriteLine("Orders left: " + string.Join(" ", orders));
            }

            else
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
