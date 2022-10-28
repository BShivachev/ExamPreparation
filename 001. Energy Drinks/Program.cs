using System;
using System.Collections.Generic;
using System.Linq;

namespace _001._Energy_Drinks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] miligramsOfCofein=Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] energyDrinks=Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Stack<int> miligrams = new Stack<int>(miligramsOfCofein);
            Queue<int> drinks = new Queue<int>(energyDrinks);
            int cofeinTaken = 0;
            int cofeinLimit = 300;
            while (miligrams.Any() && drinks.Any())
            {
                int currentMix=miligrams.Peek()*drinks.Peek();
                if (currentMix <= cofeinLimit)
                {
                    miligrams.Pop();
                    drinks.Dequeue();
                    cofeinTaken += currentMix;
                    cofeinLimit -= cofeinTaken;
                }
                else
                {
                    miligrams.Pop();
                    drinks.Enqueue(drinks.Dequeue());
                    if (cofeinTaken>=30)
                    {
                        cofeinTaken-=30;
                    }
                    else
                    {
                        cofeinTaken = 0;
                    }
                    cofeinLimit = 300 - cofeinTaken;
                    
                }
                
            }
            if (drinks.Any())
            {
                Console.WriteLine($"Drinks left: {string.Join(", ",drinks)}");
            }
            else
            {
                Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
            }
            Console.WriteLine($"Stamat is going to sleep with { cofeinTaken} mg caffeine.");
        }
    }
}
