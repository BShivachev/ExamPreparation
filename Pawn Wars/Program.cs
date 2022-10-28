using System;
using System.Linq;

namespace Pawn_Wars
{
    internal class Program
    {
        static void Main(string[] args)
        {

            char[,] matrix = new char[8, 8];

            for (int row = 0; row < 8; row++)
            {
                //char[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                string input = Console.ReadLine();
                for (int col = 0; col < 8; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            int whiteRow = 0;
            int whiteCol = 0;
            int blackRow = 0;
            int blackCol = 0;
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (matrix[row, col] == 'w')
                    {
                        whiteRow = row;
                        whiteCol = col;
                    }
                    if (matrix[row, col] == 'b')
                    {
                        blackRow = row;
                        blackCol = col;
                    }
                }
            }
            bool isWhiteTurn = false;
            int turnCounter = 0;
            while (whiteRow != 0 && blackRow != 7)
            {
                turnCounter++;
                if (turnCounter % 2 == 1)
                {
                    isWhiteTurn = true;
                }
                else
                {
                    isWhiteTurn = false;
                }
                if (whiteCol + 1 == blackCol
                    || whiteCol - 1 == blackCol)
                {
                    if (whiteRow - 1 == blackRow
                        || whiteRow + 1 == blackRow)
                    {
                        if (isWhiteTurn)
                        {
                            matrix[blackRow, blackCol] = 'w';
                            matrix[whiteRow, whiteCol] = '-';
                            Console.WriteLine($"Game over! White capture on {(char)(97 + blackCol)}{8 - blackRow}.");
                        }
                        else
                        {
                            matrix[whiteRow, whiteCol] = 'b';
                            matrix[blackRow, blackCol] = '-';
                            Console.WriteLine($"Game over! Black capture on {(char)(97 + whiteCol)}{8 - whiteRow}.");
                        }
                        return;
                    }
                }
                if (isWhiteTurn)
                {

                    matrix[whiteRow, whiteCol] = '-';
                    whiteRow--;
                    matrix[whiteRow, whiteCol] = 'w';

                }
                else
                {

                    matrix[blackRow, blackCol] = '-';
                    blackRow++;
                    matrix[blackRow, blackCol] = 'b';
                }


                //Console.WriteLine("-", 55);
                //for (int row = 0; row < matrix.GetLength(0); row++)
                //{
                //    for (int col = 0; col < matrix.GetLength(1); col++)
                //    {
                //        Console.Write(matrix[row, col] + " ");
                //    }
                //    Console.WriteLine();
                //}
            }
            if (isWhiteTurn)
            {
                Console.WriteLine($"Game over! White pawn is promoted to a queen at {(char)(97 + whiteCol)}8.");
            }
            else
            {
                Console.WriteLine($"Game over! Black pawn is promoted to a queen at {(char)(97 + blackCol)}1.");
            }

        }
    }
}
