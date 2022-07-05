using System;
using System.Linq;

namespace MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int rows = size[0];
            int cols = size[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] elements = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = elements[col];
                }
            }

            int maxSum = int.MinValue;

            int startRow = 0;
            int startCol = 0;

            for (int row = 0; row < matrix.GetLength(0)-2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1)-2; col++)
                {
                    int sum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] 
                        + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] 
                        + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    if (sum > maxSum)
                    {
                        maxSum = sum;
                        startRow = row;
                        startCol = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int i = startRow; i <= startRow+2; i++)
            {
                for (int j = startCol; j <= startCol+2; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
