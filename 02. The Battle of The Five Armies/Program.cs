using System;

namespace _02._The_Battle_of_The_Five_Armies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int armor = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());
            char[][] field = new char[rows][];
            int armorLeft = armor;
            bool isMordorReached = false;
            for (int row = 0; row < rows; row++)
            {
                string input = Console.ReadLine();
                field[row] = input.ToCharArray();
            }
            //foreach (var row in field)
            //{
            //    Console.WriteLine(row);
            //}
            int ArmyRow = 0;
            int ArmyCol = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < field[row].Length; col++)
                {
                    if (field[row][col] == 'A')
                    {
                        ArmyRow = row;
                        ArmyCol = col;
                    }

                }

            }

            while (isMordorReached == false)
            {
                string command = Console.ReadLine();
                string[] arrCommand = command.Split(' ');
                string direction = arrCommand[0];
                int orcRow = int.Parse(arrCommand[1]);
                int orcCol = int.Parse(arrCommand[2]);
                field[orcRow][orcCol] = 'O';
                field[ArmyRow][ArmyCol] = '-';
                int oldRow = ArmyRow;
                int oldCol = ArmyCol;
                switch (direction)
                {
                    case "up":
                        ArmyRow--;
                        break;
                    case "down":
                        ArmyRow++;
                        break;
                    case "left":
                        ArmyCol--;
                        break;
                    case "right":
                        ArmyCol++;
                        break;
                }
                armorLeft--;
               
                if (ArmyRow >= 0 && ArmyRow < field.Length && ArmyCol >= 0 && ArmyCol < field[ArmyRow].Length)
                {
                    if (field[ArmyRow][ArmyCol] == 'O')
                    {
                        armorLeft -= 2;
                        if (armorLeft <= 0)
                        {
                            field[ArmyRow][ArmyCol] = 'X';
                            break;
                        }
                    }

                    if (field[ArmyRow][ArmyCol] == 'M')
                    {
                        field[ArmyRow][ArmyCol] = '-';
                        isMordorReached = true;
                        break;
                    }
                }
                else
                {

                    ArmyRow = oldRow;
                    ArmyCol = oldCol;
                }
                field[ArmyRow][ArmyCol] = 'A';
                if (armorLeft <= 0)
                {
                    field[ArmyRow][ArmyCol] = 'X';
                    break;
                }

                //Console.WriteLine("-------------------------------------");
                //foreach (var row in field)
                //{
                //    Console.WriteLine(row);
                //}
                //Console.WriteLine( armorLeft);
            }
            if (isMordorReached)
            {
                Console.WriteLine($"The army managed to free the Middle World! Armor left: {armorLeft}");
            }
            else
            {

                Console.WriteLine(@$"The army was defeated at {ArmyRow};{ArmyCol}.");
            }

            foreach (var row in field)
            {
                Console.WriteLine(row);
            }
        }
    }
}
