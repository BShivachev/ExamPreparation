using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeaverAtWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dimention = int.Parse(Console.ReadLine());
            char[,] matrix = new char[dimention, dimention];
            Stack<char> woodBranch = new Stack<char>();
            int count = 0;
            bool areBranchesCollected = false;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().Split(" ").Select(char.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            int curRow = 0;
            int curCol = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        curRow = row;
                        curCol = col;
                    }
                    if (char.IsLower(matrix[row, col]))
                    {
                        count++;
                    }
                }
            }
            matrix[curRow, curCol] = '-';

            string command = Console.ReadLine();
            while (command != "end")
            {
                int oldRow = curRow;
                int oldCol = curCol;
                switch (command)
                {
                    case "up":
                        curRow--;
                        break;
                    case "down":
                        curRow++;
                        break;
                    case "left":
                        curCol--;
                        break;
                    case "right":
                        curCol++;
                        break;
                }
                if (curRow >= 0 && curRow < dimention && curCol >= 0 && curCol < dimention)
                {

                    if (matrix[curRow, curCol] == '-')
                    {
                        matrix[curRow, curCol] = 'B';
                        matrix[oldRow, oldCol] = '-';
                    }
                    if (matrix[curRow, curCol] == 'F')
                    {
                        matrix[curRow, curCol] = '-';
                        if (command == "right")
                        {
                            if (curCol < matrix.GetLength(1) - 1)
                            {
                                curCol = matrix.GetLength(1) - 1;
                            }
                            else
                            {
                                curCol = 0;
                            }
                        }
                        else if (command == "left")
                        {
                            if (curCol == 0)
                            {
                                curCol = matrix.GetLength(1) - 1;
                            }
                            else
                            {
                                curCol = 0;
                            }
                        }
                        else if (command == "down")
                        {
                            if (curRow < matrix.GetLength(0) - 1)
                            {
                                curRow = matrix.GetLength(0) - 1;
                            }
                            else
                            {
                                curRow = 0;
                            }
                        }
                        else
                        {
                            if (curRow == 0)
                            {
                                curRow = matrix.GetLength(0) - 1;
                            }
                            else
                            {
                                curRow = 0;
                            }
                        }
                    }
                    if (char.IsLower(matrix[curRow, curCol]))
                    {

                        woodBranch.Push(matrix[curRow, curCol]);
                        count--;
                    }
                    matrix[curRow, curCol] = 'B';
                    matrix[oldRow, oldCol] = '-';


                }
                else
                {
                    if (woodBranch.Any())
                    {
                        woodBranch.Pop();
                    }
                    curRow = oldRow;
                    curCol = oldCol;
                }

                if (count == 0)
                {
                    areBranchesCollected = true;
                    break;
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
                command = Console.ReadLine();
            }
            if (areBranchesCollected)
            {
                char[] woodArr = new char[woodBranch.Count];
                woodArr = woodBranch.ToArray();
                Array.Reverse(woodArr);
                Console.WriteLine($"The Beaver successfully collect {woodBranch.Count} wood branches: {string.Join(", ", woodArr)}.");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {count} branches left.");
            }


            for (int row = 0; row < matrix.GetLength(0); row++)
            {

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    string curResult = matrix[row, col].ToString();
                    Console.Write($"{curResult} ");
                }
                Console.WriteLine();
            }
        }
    }
}
