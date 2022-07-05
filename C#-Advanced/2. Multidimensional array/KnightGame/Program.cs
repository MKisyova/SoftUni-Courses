using System;

namespace KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] playBoard = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                char[] charArray = Console.ReadLine().ToCharArray();

                for (int col = 0; col < n; col++)
                {
                    playBoard[row, col] = charArray[col];
                }
            }

            int removedKnight = 0;

            while (true)
            {
                int maxAttacks = 0;
                int knightRow = 0;
                int knightCol = 0;

                for (int row = 0; row < playBoard.GetLength(0); row++)
                {
                    for (int col = 0; col < playBoard.GetLength(1); col++)
                    {
                        int currentAttacks = 0;

                        if (playBoard[row, col] != 'K')
                        {
                            continue;
                        }

                        if (IsInside(playBoard, row - 2, col + 1) && playBoard[row - 2, col + 1] == 'K')
                        {
                            currentAttacks++;
                        }

                        if (IsInside(playBoard, row - 1, col + 2) && playBoard[row - 1, col + 2] == 'K')
                        {
                            currentAttacks++;
                        }

                        if (IsInside(playBoard, row + 1, col + 2) && playBoard[row + 1, col + 2] == 'K')
                        {
                            currentAttacks++;
                        }

                        if (IsInside(playBoard, row + 2, col + 1) && playBoard[row + 2, col + 1] == 'K')
                        {
                            currentAttacks++;
                        }

                        if (IsInside(playBoard, row + 2, col - 1) && playBoard[row + 2, col - 1] == 'K')
                        {
                            currentAttacks++;
                        }

                        if (IsInside(playBoard, row + 1, col - 2) && playBoard[row + 1, col - 2] == 'K')
                        {
                            currentAttacks++;
                        }

                        if (IsInside(playBoard, row - 1, col - 2) && playBoard[row - 1, col - 2] == 'K')
                        {
                            currentAttacks++;
                        }

                        if (IsInside(playBoard, row - 2, col - 1) && playBoard[row - 2, col - 1] == 'K')
                        {
                            currentAttacks++;
                        }

                        if (currentAttacks > maxAttacks)
                        {
                            maxAttacks = currentAttacks;
                            knightRow = row;
                            knightCol = col;
                        }
                    }
                }

                if (maxAttacks == 0)
                {
                    Console.WriteLine(removedKnight);

                    break;
                }

                playBoard[knightRow, knightCol] = '0';

                removedKnight++;

            }
        }

        private static bool IsInside(char[,] playboard, int row, int col)
        {
            return row >= 0 && row < playboard.GetLength(0) && col >= 0 && col < playboard.GetLength(1);
        }
    }
}

