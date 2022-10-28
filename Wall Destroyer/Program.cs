using System;

namespace Wall_Destroyer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dimention = int.Parse(Console.ReadLine());
            char[,] matrix = new char[dimention, dimention];
            int holsCount = 1;
            int rodsHitted = 0;
            bool isVankoElectrocuted = false;
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
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'V')
                    {
                        curRow = row;
                        curCol = col;
                    }
                }
            }

            string command = Console.ReadLine();

            while (command != "End")
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
                        matrix[oldRow, oldCol] = '*';
                        matrix[curRow, curCol] = '*';
                        holsCount++;
                    }
                    else if (matrix[curRow, curCol] == '*')
                    {
                        Console.WriteLine($"The wall is already destroyed at position [{curRow}, {curCol}]!");

                    }
                    else if (matrix[curRow, curCol] == 'R')
                    {
                        Console.WriteLine("Vanko hit a rod!");
                        rodsHitted++;
                        curRow = oldRow;
                        curCol = oldCol;
                    }
                    else if (matrix[curRow, curCol] == 'C')
                    {
                        matrix[curRow, curCol] = 'E';
                        holsCount++;
                        isVankoElectrocuted = true;
                        Console.WriteLine($"Vanko got electrocuted, but he managed to make {holsCount} hole(s).");
                        break;
                    }
                    
                }
                else
                {
                    curRow = oldRow;
                    curCol= oldCol;
                }


                command = Console.ReadLine();
            }
            if (!isVankoElectrocuted)
            {
                matrix[curCol, curRow] = 'V';
                Console.WriteLine($"Vanko managed to make {holsCount} hole(s) and he hit only {rodsHitted} rod(s).");
            }
            for (int row = 0; row < dimention; row++)
            {
                for (int col = 0; col < dimention; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
