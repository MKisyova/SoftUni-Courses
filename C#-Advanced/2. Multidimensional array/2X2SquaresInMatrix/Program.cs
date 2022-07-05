using System;
using System.Linq;

namespace SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

            int rows = size[0];
            int cols = size[1];

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                char[] input = Console.ReadLine().Split(" ").Select(char.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            int counter = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (row < rows - 1 && col < cols - 1)
                    {

                        if (matrix[row, col] == matrix[row, col + 1] && matrix[row, col + 1] == matrix[row + 1, col] && matrix[row + 1, col] == matrix[row + 1, col + 1])
                        {
                            counter++;
                        }
                    }

                }
            }

            Console.WriteLine(counter);
        }
    }
}
