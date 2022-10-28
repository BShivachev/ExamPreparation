using System;

namespace _02._Armory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dimention = int.Parse(Console.ReadLine());
            char[,] matrix = new char[dimention, dimention];
            int goldCollected = 0;

            bool isFulfill = true;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            int curRow = -1;
            int curCol = -1;
            int firstMirrorRow = -1;
            int firstMirrorCol = -1;
            int secondMirrorRow = -1;
            int secondMirrorCol = -1;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'A')
                    {
                        curRow = row;
                        curCol = col;
                    }
                    if (matrix[row, col] == 'M')
                    {
                        if (firstMirrorRow < 0 && firstMirrorCol < 0)
                        {
                            firstMirrorRow = row;
                            firstMirrorCol = col;
                        }
                        else
                        {
                            secondMirrorRow = row;
                            secondMirrorCol = col;
                        }
                    }
                }
            }
            string command = Console.ReadLine();
            while (goldCollected < 65)
            {
                matrix[curRow, curCol] = '-';
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
                    if (char.IsDigit(matrix[curRow, curCol]))
                    {
                        goldCollected += int.Parse(matrix[curRow, curCol].ToString());


                    }
                    else if (matrix[curRow, curCol] == 'M')
                    {
                        matrix[curRow, curCol] = '-';

                        if (curRow == firstMirrorRow && curCol == firstMirrorCol)
                        {
                            curRow = secondMirrorRow;
                            curCol = secondMirrorCol;
                        }
                        else if (curRow == secondMirrorRow && curCol == secondMirrorCol)
                        {
                            curRow = firstMirrorRow;
                            curCol = firstMirrorCol;

                        }

                    }
                    matrix[curRow, curCol] = 'A';
                    //matrix[oldRow, oldCol] = '-';
                }
                else
                {
                    matrix[oldRow, oldCol] = '-';
                    isFulfill = false;
                    Console.WriteLine("I do not need more swords!");
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
            if (isFulfill)
            {
                Console.WriteLine("Very nice swords, I will come back for more!");
            }
            Console.WriteLine($"The king paid {goldCollected} gold coins.");
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
