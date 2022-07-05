using System;
using System.Linq;

namespace JaggedArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double[][] jaggedArray = new double[n][];

            for (int i = 0; i < n; i++)
            {
                double[] array = Console.ReadLine().Split().Select(double.Parse).ToArray();
                jaggedArray[i] = array;
            }

            for (int i = 0; i < n-1; i++)
            {
                if (jaggedArray[i].Length == jaggedArray[i+1].Length)
                {
                    for (int j = 0; j < jaggedArray[i].Length; j++)
                    {
                        jaggedArray[i][j] *= 2;
                        jaggedArray[i+1][j] *= 2;
                    }
                }

                else
                {
                    for (int j = 0; j < jaggedArray[i].Length; j++)
                    {
                        jaggedArray[i][j] /= 2;
                    }

                    for (int k = 0; k < jaggedArray[i + 1].Length; k++)
                    {
                        jaggedArray[i+1][k] /= 2;
                    }
                }
            }

            string command = Console.ReadLine();

            while (command != "End" )
            {
                string[] splittedCommand = command.Split();

                string action = splittedCommand[0];
                int row = int.Parse(splittedCommand[1]);
                int column = int.Parse(splittedCommand[2]);
                int value = int.Parse(splittedCommand[3]);

                if (row >= 0 && row < jaggedArray.Length && column >= 0 && column < jaggedArray[row].Length)
                {
                    if (action == "Add")
                    {
                        jaggedArray[row][column] += value;
                    }

                    else if (action == "Subtract")
                    {
                        jaggedArray[row][column] -= value;
                    }
                }

                command = Console.ReadLine();
            }

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                Console.WriteLine(String.Join(" ", jaggedArray[i]));
            }
        }
    }
}
