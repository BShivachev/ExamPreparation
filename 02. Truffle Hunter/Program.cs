using System;
using System.Linq;

namespace _02._Truffle_Hunter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dimention = int.Parse(Console.ReadLine());
            char[,] matrix = new char[dimention, dimention];
            int blackTruffleCount = 0;
            int summerTrufleCount = 0;
            int whiteTruffleCount = 0;
            int truffleEaten = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().Split(" ").Select(char.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            string command = Console.ReadLine();

            while (command != "Stop the hunt")
            {
                string[] arrCommand = command.Split();
                int row = int.Parse(arrCommand[1]);
                int col = int.Parse(arrCommand[2]);
                if (command.StartsWith("Collect"))
                {
                    char currentPosition = matrix[row, col];
                    if (row >= 0 && row < dimention && col >= 0 && col < dimention)
                    {
                        if (currentPosition != '-')
                        {
                            switch (currentPosition)
                            {
                                case 'B':
                                    blackTruffleCount++;
                                    break;
                                case 'S':
                                    summerTrufleCount++;
                                    break;
                                case 'W':
                                    whiteTruffleCount++;
                                    break;
                                default:
                                    break;
                            }
                        }
                        matrix[row, col] = '-';
                    }

                }
                else
                {
                    int boarRow = row;
                    int boarCol = col;
                    string direction = arrCommand[3];                                        
                    int moveCounter = 0;
                    while (boarRow < dimention && boarRow >= 0 && boarCol < dimention && boarCol >= 0)
                    {
                        if (moveCounter % 2 !=1 &&matrix[boarRow,boarCol]!='-')
                        {
                            truffleEaten++;
                            matrix[boarRow, boarCol] = '-';
                        }
                        moveCounter++;
                        switch (direction)
                        {
                            case "up":
                                boarRow--;

                                break;
                            case "down":
                                boarRow++;

                                break;
                            case "left":
                                boarCol--;

                                break;
                            case "right":
                                boarCol++;

                                break;
                        }
                        //Console.WriteLine("-", 55);
                        //for (int i = 0; i < matrix.GetLength(0); i++)
                        //{
                        //    for (int j = 0; j < matrix.GetLength(1); j++)
                        //    {
                        //        Console.Write(matrix[i, j] + " ");
                        //    }
                        //    Console.WriteLine();
                        //}
                    }

                }
                command=Console.ReadLine();
            }
            Console.WriteLine($"Peter manages to harvest {blackTruffleCount} black, {summerTrufleCount} summer, and {whiteTruffleCount} white truffles.");
            Console.WriteLine($"The wild boar has eaten {truffleEaten} truffles.");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }



    }
}
