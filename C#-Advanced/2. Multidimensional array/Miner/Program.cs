using System;

namespace Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            string[] command = Console.ReadLine().Split();

            int startRow = 0;
            int startCol = 0;
            int allCoals = 0;

            for (int i = 0; i < n; i++)
            {
                string[] fields = Console.ReadLine().Split();

                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = char.Parse(fields[j]);
                    if (matrix[i, j] == 's')
                    {
                        startRow = i;
                        startCol = j;
                    }

                    else if (matrix[i, j] == 'c')
                    {
                        allCoals++;
                    }
                }
            }

            int coalCount = 0;

            bool ifCollected = false;

            for (int i = 0; i < command.Length; i++)
            {
                if (command[i] == "up")
                {
                    if (startRow - 1 >= 0)
                    {
                        if (matrix[startRow - 1, startCol] == 'c')
                        {
                            coalCount++;

                            matrix[startRow - 1, startCol] = '*';

                            startRow--;
                        }

                        else if (matrix[startRow - 1, startCol] == 'e')
                        {
                            Console.WriteLine($"Game over! ({startRow - 1}, {startCol})");

                            ifCollected = true;

                            break;
                        }

                        else
                        {
                            startRow--;
                        }
                    }
                }

                else if (command[i] == "down")
                {
                    if (startRow + 1 < n)
                    {
                        if (matrix[startRow + 1, startCol] == 'c')
                        {
                            coalCount++;

                            matrix[startRow + 1, startCol] = '*';

                            startRow++;
                        }

                        else if (matrix[startRow + 1, startCol] == 'e')
                        {
                            Console.WriteLine($"Game over! ({startRow + 1}, {startCol})");

                            ifCollected = true;

                            break;
                        }

                        else
                        {
                            startRow++;
                        }
                    }
                }

                else if (command[i] == "left")
                {
                    if (startCol - 1 >= 0)
                    {
                        if (matrix[startRow, startCol - 1] == 'c')
                        {
                            coalCount++;

                            matrix[startRow, startCol - 1] = '*';

                            startCol--;
                        }

                        else if (matrix[startRow, startCol - 1] == 'e')
                        {
                            Console.WriteLine($"Game over! ({startRow}, {startCol - 1})");

                            ifCollected = true;

                            break;
                        }

                        else
                        {
                            startCol--;
                        }
                    }
                }

                else if (command[i] == "right")
                {
                    if (startCol + 1 < n)
                    {
                        if (matrix[startRow, startCol + 1] == 'c')
                        {
                            coalCount++;

                            matrix[startRow, startCol + 1] = '*';

                            startCol++;
                        }

                        else if (matrix[startRow, startCol + 1] == 'e')
                        {
                            Console.WriteLine($"Game over! ({startRow}, {startCol + 1})");

                            ifCollected = true;

                            break;
                        }

                        else
                        {
                            startCol++;
                        }
                    }
                }

                if (coalCount == allCoals)
                {
                    Console.WriteLine($"You collected all coals! ({startRow}, {startCol})");

                    ifCollected = true;

                    break;
                }
            }

            if (ifCollected == false)
            {
                Console.WriteLine($"{allCoals - coalCount} coals left. ({startRow}, {startCol})");
            }
        }
    }
}
