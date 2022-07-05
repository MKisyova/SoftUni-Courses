using System;

namespace MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            int rowNum = int.Parse(input[0]);
            int colNum = int.Parse(input[1]);

            string[,] matrix = new string[rowNum, colNum];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] eachRow = Console.ReadLine().Split();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = eachRow[col];
                }
            }

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] splittedCommand = command.Split();

                if (splittedCommand[0] != "swap" || splittedCommand.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                }

                else
                {
                    int row1 = int.Parse(splittedCommand[1]);
                    int col1 = int.Parse(splittedCommand[2]);
                    int row2 = int.Parse(splittedCommand[3]);
                    int col2 = int.Parse(splittedCommand[4]);

                    if (row1 > matrix.GetLength(0) - 1 || row1 < 0 || row2 > matrix.GetLength(0) - 1 
                        || row2 < 0 || col1 > matrix.GetLength(1) - 1 || col1 < 0 
                        || col1 > matrix.GetLength(1) - 1 || col1 < 0)
                    {
                        Console.WriteLine("Invalid input!");
                    }

                    else
                    {
                        string temp = matrix[row1, col1];
                        matrix[row1, col1] = matrix[row2, col2];
                        matrix[row2, col2] = temp;

                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                Console.Write($"{matrix[row, col]} ");
                            }

                            Console.WriteLine();
                        }
                    }

                }

                command = Console.ReadLine();
            }
        }
    }
}
