using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Help_A_Mole
{

    internal class Program
    {
        public class Special
        {
            public Special(int row, int col)
            {
                Row = row;
                Column = col;
            }
            public int Row { get; set; }
            public int Column { get; set; }
        }
        static void Main(string[] args)
        {
            int dimention = int.Parse(Console.ReadLine());
            char[,] matrix = new char[dimention, dimention];
            int points=0;


            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            int curRow = 0;
            int curCol = 0;
           
            List<Special> specials = new List<Special>();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'M')
                    {
                        curRow = row;
                        curCol = col;
                    }
                    if (matrix[row,col]=='S')
                    {
                        specials.Add(new Special(row, col));
                    }
                }
            }
            matrix[curRow, curCol] = '-';
            string command = Console.ReadLine();
            while (command != "End")
            {
                if (points>=25)
                {
                    break;
                }
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
                    if (char.IsDigit(matrix[curRow,curCol]))
                    {
                        points += int.Parse(matrix[curRow, curCol].ToString());
                        matrix[curRow, curCol] = 'M';
                       
                    }
                    else if (matrix[curRow, curCol] == 'S')
                    {
                        Special first=specials[0];
                        Special second=specials[1];
                        if (first.Row.Equals(curRow) && first.Column.Equals(curCol))
                        {
                            curRow=second.Row;
                            curCol=second.Column;
                            matrix[curRow, curCol] = 'M';
                            matrix[first.Row, first.Column] = '-';
                        }
                        else
                        {
                            curRow = first.Row;
                            curCol = first.Column;
                            matrix[curRow, curCol] = 'M';
                            matrix[second.Row, second.Column] = '-';
                        }
                        points -= 3;
                    }
                    else
                    {
                        matrix[curRow, curCol] = 'M';
                        
                    }
                    matrix[oldRow, oldCol] = '-';
                }
                else
                {
                    Console.WriteLine("Don't try to escape the playing field!");
                    curRow = oldRow;
                    curCol = oldCol;
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
            if (points>=25)
            {
                Console.WriteLine("Yay! The Mole survived another game!");
                Console.WriteLine($"The Mole managed to survive with a total of {points} points.");
            }
            else
            {
                Console.WriteLine("Too bad! The Mole lost this battle!");
                Console.WriteLine($"The Mole lost the game with a total of {points} points.");
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
