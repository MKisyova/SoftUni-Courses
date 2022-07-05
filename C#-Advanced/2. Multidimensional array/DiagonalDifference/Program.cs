using System;
using System.Linq;

namespace DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                int[] elements = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = elements[col];
                }
            }

            int sumDiagonal1 = 0;
            int sumDiagonal2 = 0;

            for (int i = 0; i < size; i++)
            {
                sumDiagonal1 += matrix[i, i];
            }
            
            for (int j = 0; j < size; j++)
            {
                sumDiagonal2 += matrix[j, size-j- 1];
            }

            Console.WriteLine(Math.Abs(sumDiagonal1 - sumDiagonal2));
        }
    }
}
