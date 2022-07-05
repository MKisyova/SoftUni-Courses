using System;

namespace SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            int rowNum = int.Parse(input[0]);
            int colNum = int.Parse(input[1]);

            char[,] matrix = new char[rowNum, colNum];

            string snake = Console.ReadLine();

            char[] snakeMatrix = snake.ToCharArray();
            int countSnakeLetter = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (countSnakeLetter == snakeMatrix.Length)
                        {
                            countSnakeLetter = 0;
                        }

                        matrix[row, col] = snakeMatrix[countSnakeLetter];

                        countSnakeLetter++;
                    }
                }

                else
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        if (countSnakeLetter == snakeMatrix.Length)
                        {
                            countSnakeLetter = 0;
                        }

                        matrix[row, col] = snakeMatrix[countSnakeLetter];

                        countSnakeLetter++;
                    }
                }
          
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }

        }
    }
}
