using System;
using System.Collections.Generic;
using System.Linq;

namespace KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
      
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());

            int[] bulletsInput = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int[] locksInput = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int intelligenceValue = int.Parse(Console.ReadLine());

            Queue<int> locks = new Queue<int>();
            Stack<int> bullets = new Stack<int>();

            for (int i = 0; i < locksInput.Length; i++)
            {
                locks.Enqueue(locksInput[i]);
            }

            for (int i = 0; i < bulletsInput.Length; i++)
            {
                bullets.Push(bulletsInput[i]);
            }

            int countBullets = 0;

            while (bullets.Count > 0 && locks.Count > 0)
            {
                if (bullets.Peek() <= locks.Peek())
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                    bullets.Pop();
                    countBullets++;
                }

                else
                {
                    Console.WriteLine("Ping!");
                    bullets.Pop();
                    countBullets++;
                }

                if (countBullets == gunBarrelSize)
                {
                    if (bullets.Count > 0)
                    {
                        Console.WriteLine("Reloading!");
                        countBullets = 0;
                    }
                }
            }

            if (bullets.Count > 0 || (bullets.Count == 0 && locks.Count == 0) )
            {
                int bulletsLeft = bullets.Count;
                int bulletsUsed = bulletsInput.Length - bulletsLeft;
                int moneyEarned = intelligenceValue - bulletsUsed * bulletPrice;

                Console.WriteLine($"{bulletsLeft} bullets left. Earned ${moneyEarned}");
            }
         
            else // locks > 0
            {
                int locksLeft = locks.Count;

                Console.WriteLine($"Couldn't get through. Locks left: {locksLeft}");
            }
        }
    }
}
