using System;
using System.Collections.Generic;

namespace RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            int numRow = int.Parse(input[0]);
            int numCol = int.Parse(input[1]);

            char[,] matrix = new char[numRow, numCol];

            int rowStart = 0;
            int colStart = 0;

            for (int i = 0; i < numRow; i++)
            {
                char[] line = Console.ReadLine().ToCharArray();

                for (int j = 0; j < numCol; j++)
                {
                    matrix[i, j] = line[j];
                    if (matrix[i, j] == 'P')
                    {
                        rowStart = i;
                        colStart = j;
                    }
                }
            }

            string command = Console.ReadLine();

            foreach (var direction in command)
            {
                int nextRow = 0;
                int nextCol = 0;

                if (direction == 'L')
                {
                    nextCol--;
                }

                else if (direction == 'R')
                {
                    nextCol++;
                }

                else if (direction == 'U')
                {
                    nextRow--;
                }

                else if (direction == 'D')
                {
                    nextRow++;
                }

                bool hasWon = false;
                bool isDead = false;

                matrix[rowStart, colStart] = '.';

                if (!IsInside(matrix, rowStart + nextRow, colStart + nextCol))
                {
                    hasWon = true;
                }

                else
                {
                    rowStart += nextRow;
                    colStart += nextCol;

                    if (matrix[rowStart, colStart] == 'B')
                    {
                        isDead = true;
                    }

                    else
                    {
                        matrix[rowStart, colStart] = 'P';
                    }
                }

                List<int[]> bunniesCoordinates = new List<int[]>();

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row, col] == 'B')
                        {
                            bunniesCoordinates.Add(new int[] { row, col });
                        }
                    }
                }

                foreach (var bunny in bunniesCoordinates)
                {
                    int bunnyRow = bunny[0];
                    int bunnyCol = bunny[1];

                    if (IsInside(matrix, bunnyRow + 1, bunnyCol))
                    {
                        if (matrix[bunnyRow + 1, bunnyCol] == 'P')
                        {
                            isDead = true;
                        }

                        matrix[bunnyRow + 1, bunnyCol] = 'B';
                    }

                    if (IsInside(matrix, bunnyRow - 1, bunnyCol))
                    {
                        if (matrix[bunnyRow - 1, bunnyCol] == 'P')
                        {
                            isDead = true;
                        }
                        matrix[bunnyRow - 1, bunnyCol] = 'B';
                    }

                    if (IsInside(matrix, bunnyRow, bunnyCol + 1))
                    {
                        if (matrix[bunnyRow, bunnyCol + 1] == 'P')
                        {
                            isDead = true;
                        }

                        matrix[bunnyRow, bunnyCol + 1] = 'B';
                    }

                    if (IsInside(matrix, bunnyRow, bunnyCol - 1))
                    {
                        if (matrix[bunnyRow, bunnyCol - 1] == 'P')
                        {
                            isDead = true;
                        }

                        matrix[bunnyRow, bunnyCol - 1] = 'B';
                    }
                }

                if (hasWon)
                {
                    PrintMatrix(numRow, numCol, matrix);

                    Console.WriteLine($"won: {rowStart} {colStart}");

                    Environment.Exit(0);
                }

                else if (isDead)
                {
                    PrintMatrix(numRow, numCol, matrix);

                    Console.WriteLine($"dead: {rowStart} {colStart}");

                    Environment.Exit(0);
                }
            }
        }


        private static void PrintMatrix(int numRow, int numCol, char[,] matrix)
        {
            for (int i = 0; i < numRow; i++)
            {
                for (int j = 0; j < numCol; j++)
                {
                    Console.Write(matrix[i, j]);
                }

                Console.WriteLine();
            }
        }

        private static bool IsInside(char[,] playboard, int row, int col)
        {
            return row >= 0 && row < playboard.GetLength(0) && col >= 0 && col < playboard.GetLength(1);
        }
    }
}

