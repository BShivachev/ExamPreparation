using System;
using System.Linq;

namespace _002._Rally_Racing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dimention = int.Parse(Console.ReadLine());
            string racingNum = Console.ReadLine();
            char[,] matrix = new char[dimention, dimention];
            bool isFinished=false;
            int coveredDistance = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            int curRow = 0;
            int curCol = 0;
            int firtsTunnelRow = -1;
            int firstTunnelCol = -1;
            int secondTunnelRow = -1;
            int secondTunnelCol = -1;
            int finishRow=0;
            int finishCol = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'T')
                    {
                        
                        if (firtsTunnelRow < 0 && firstTunnelCol < 0)
                        {
                            firtsTunnelRow = row;
                            firstTunnelCol = col;
                        }
                        else
                        {
                            secondTunnelRow = row;
                            secondTunnelCol = col;
                        }
                    }
                    if (matrix[row,col]=='F')
                    {
                        finishRow = row;
                        finishRow = col;
                    }
                }
            }
            string command = Console.ReadLine();
            while (command!="End")
            {
                matrix[curRow, curCol] = '.';
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
                if (matrix[curRow,curCol]=='T')
                {
                    matrix[curRow, curCol] = '.';
                    if (curRow == firtsTunnelRow && curCol == firstTunnelCol)
                    {
                        curRow = secondTunnelRow;
                        curCol = secondTunnelCol;
                    }
                    else if (curRow == secondTunnelRow && curCol == secondTunnelCol)
                    {
                        curRow = firtsTunnelRow;
                        curCol = firstTunnelCol;

                    }
                    coveredDistance += 30;
                }
                else if (matrix[curRow, curCol] == 'F')
                {
                    coveredDistance += 10;
                    matrix[curRow, curCol] = 'C';
                    isFinished = true;
                    
                    break;
                }
                else
                {
                    coveredDistance += 10;
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
            matrix[curRow, curCol] = 'C';
            if (isFinished)
            {
                Console.WriteLine($"Racing car {racingNum} finished the stage!");
            }
            else
            {
                Console.WriteLine($"Racing car {racingNum} DNF.");
            }
            Console.WriteLine($"Distance covered {coveredDistance} km.");
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
