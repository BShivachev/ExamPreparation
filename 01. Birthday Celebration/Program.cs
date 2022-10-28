using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Birthday_Celebration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> guests = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Stack<int> plates = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            int wastedFood = 0;
            while (plates.Any() && guests.Any())
            {
                int currentPlate = plates.Peek();
                int currentGuest = guests.Peek();
                if (currentPlate >= currentGuest)
                {
                    wastedFood+=plates.Pop()-guests.Dequeue();
                }
                else
                {
                    guests.Dequeue();
                    plates.Pop();
                    guests = new Queue<int>(guests.Reverse());
                    guests.Enqueue(currentGuest-currentPlate);
                    guests = new Queue<int>(guests.Reverse());

                }               
            }
            if (plates.Any())
            {
                Console.WriteLine($"Plates: {string.Join(" ",plates)}");

            }
            else
            {
                Console.WriteLine($"Guests: {string.Join(" ", guests)}");
            }
            Console.WriteLine($"Wasted grams of food: {wastedFood}");


        }
    }
}
