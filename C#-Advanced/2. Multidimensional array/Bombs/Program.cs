using System;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            string[] command = Console.ReadLine().Split();

            for (int i = 0; i < command.Length; i++)
            {
                int[] positionBomb = command[i].Split(",").Select(int.Parse).ToArray();

                int rowBomb = positionBomb[0];
                int colBomb = positionBomb[1];

                int bomb = matrix[rowBomb, colBomb];

                if (matrix[rowBomb, colBomb] > 0)
                {
                    if (rowBomb - 1 >= 0 && colBomb - 1 >= 0 && rowBomb - 1 < n && colBomb - 1 < n)
                    {
                        if (matrix[rowBomb - 1, colBomb - 1] > 0)
                        {
                            matrix[rowBomb - 1, colBomb - 1] -= bomb;
                        }
                    }

                    if (rowBomb - 1 >= 0 && colBomb >= 0 && rowBomb - 1 < n && colBomb < n)
                    {
                        if (matrix[rowBomb - 1, colBomb] > 0)
                        {
                            matrix[rowBomb - 1, colBomb] -= bomb;
                        }
                    }

                    if (rowBomb - 1 >= 0 && colBomb + 1 >= 0 && rowBomb - 1 < n && colBomb + 1 < n)
                    {
                        if (matrix[rowBomb - 1, colBomb + 1] > 0)
                        {
                            matrix[rowBomb - 1, colBomb + 1] -= bomb;
                        }
                    }

                    if (rowBomb >= 0 && colBomb - 1 >= 0 && rowBomb < n && colBomb - 1 < n)
                    {
                        if (matrix[rowBomb, colBomb - 1] > 0)
                        {
                            matrix[rowBomb, colBomb - 1] -= bomb;
                        }                        
                    }

                    if (rowBomb >= 0 && colBomb + 1 >= 0 && rowBomb < n && colBomb + 1 < n)
                    {
                        if (matrix[rowBomb, colBomb + 1] > 0)
                        {
                            matrix[rowBomb, colBomb + 1] -= bomb;
                        }                      
                    }

                    if (rowBomb + 1 >= 0 && colBomb - 1 >= 0 && rowBomb + 1 < n && colBomb - 1 < n)
                    {
                        if (matrix[rowBomb + 1, colBomb - 1] > 0)
                        {
                            matrix[rowBomb + 1, colBomb - 1] -= bomb;
                        }                       
                    }

                    if (rowBomb + 1 >= 0 && colBomb >= 0 && rowBomb + 1 < n && colBomb < n)
                    {
                        if (matrix[rowBomb + 1, colBomb] > 0)
                        {
                            matrix[rowBomb + 1, colBomb] -= bomb;
                        }                       
                    }

                    if (rowBomb + 1 >= 0 && colBomb + 1 >= 0 && rowBomb + 1 < n && colBomb + 1 < n)
                    {
                        if (matrix[rowBomb + 1, colBomb + 1] > 0)
                        {
                            matrix[rowBomb + 1, colBomb + 1] -= bomb;
                        }                       
                    }

                    matrix[rowBomb, colBomb] = 0;
                }

            }

            int count = 0;
            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        count++;
                        sum += matrix[i, j];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {count}");
            Console.WriteLine($"Sum: {sum}");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
