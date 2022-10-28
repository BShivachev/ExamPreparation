using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Masterchef
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> ingredients = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Stack<int> freshness = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Dictionary<string, int> dishes = new Dictionary<string, int>();
            dishes.Add("Dipping sauce", 0);
            dishes.Add("Green salad", 0);
            dishes.Add("Chocolate cake", 0);
            dishes.Add("Lobster", 0);
            while (ingredients.Any() && freshness.Any())
            {
                if (ingredients.Peek() > 0)
                {
                    int currentMix = ingredients.Peek() * freshness.Peek();
                    if (FindMatch(currentMix, dishes))
                    {
                        ingredients.Dequeue();
                    }
                    else
                    {
                        ingredients.Enqueue(ingredients.Dequeue() + 5);
                    }
                    freshness.Pop();
                }
                else
                {
                    ingredients.Dequeue();
                }
            }
            var winningDishes = dishes.Where(x => x.Value > 0);
            if (winningDishes.ToDictionary(x => x.Key, x => x.Value).Count >= 4)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }
            if (ingredients.Any())
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }
            foreach (var dish in winningDishes.OrderBy(x => x.Key))
            {
                Console.WriteLine($" # {dish.Key} --> {dish.Value}");
            }

        }
        public static bool FindMatch(int current, Dictionary<string, int> dishes)
        {
            if (current == 150)
            {
                dishes["Dipping sauce"]++;
            }
            else if (current == 250)
            {
                dishes["Green salad"]++;

            }
            else if (current == 300)
            {
                dishes["Chocolate cake"]++;

            }
            else if (current == 400)
            {
                dishes["Lobster"]++;
            }
            else
            {
                return false;
            }
            return true;
        }
    }
}
