using System;
using System.Linq;

namespace _02.Survivor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            char[][] field = new char[rows][];
            int collectedTokens = 0;
            int opponentsTokens = 0;
            for (int row = 0; row < rows; row++)
            {
                char[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                field[row] = input;

            }
            
            string command = Console.ReadLine();
            while (command != "Gong")
            {
                string[] arrCommand = command.Split(" ");
                string condition = arrCommand[0];
                int row = int.Parse(arrCommand[1]);
                int col = int.Parse(arrCommand[2]);
                if (row >= 0 && row < field.Length && col >= 0 && col < field[row].Length && field[row][col] == 'T')
                {
                    field[row][col] = '-';
                    if (condition == "Find")
                    {
                        //field[row][col] = '-';
                        collectedTokens++;
                    }
                    else if (condition == "Opponent")
                    {
                        string direction = arrCommand[3];
                        
                        int moveCounter = 0;
                        opponentsTokens++;
                        while (moveCounter < 3)
                        {
                            switch (direction)
                            {
                                case "up":
                                    row--;
                                    break;
                                case "down":
                                    row++;
                                    break;
                                case "left":
                                    col--;
                                    break;
                                case "right":
                                    col++;
                                    break;
                            }
                            if (row<0||row>=field.Length||col<0||col>=field[row].Length)
                            {
                                break;
                            }
                            moveCounter++;
                            if (field[row][col]=='T')
                            {
                                opponentsTokens++;

                            }
                            field[row][col] = '-';

                        }

                    }
                    
                }

                //foreach (var curr in field)
                //{
                //    foreach (var item in curr)
                //    {
                //        Console.Write(item.ToString() + " ");
                //    }
                //    Console.WriteLine();
                //}
                command = Console.ReadLine();
            }


            foreach (var curr in field)
            {
                foreach (var item in curr)
                {
                    Console.Write(item.ToString() + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Collected tokens: {collectedTokens}");
            Console.WriteLine($"Opponent's tokens: {opponentsTokens}");
        }
    }
}
