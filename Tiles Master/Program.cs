using System;
using System.Collections.Generic;
using System.Linq;

namespace Tiles_Master
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] whiteTails = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Stack<int> whiteTailStack = new Stack<int>(whiteTails);
            int[] greyTails = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> greyTailQueue = new Queue<int>(greyTails);
            Dictionary<string, int> locations = new Dictionary<string, int>();

            while (whiteTailStack.Any() && greyTailQueue.Any())
            {
                if (greyTailQueue.Peek() == whiteTailStack.Peek())
                {
                    int tailArea = whiteTailStack.Pop() + greyTailQueue.Dequeue();
                    FormDictionary(tailArea, locations);
                }
                else
                {
                    int currentWhiteTail = whiteTailStack.Pop() / 2;
                    whiteTailStack.Push(currentWhiteTail);
                    greyTailQueue.Enqueue(greyTailQueue.Dequeue());
                }
            }
            if (!whiteTailStack.Any())
            {
                Console.WriteLine("White tiles left: none");
            }
            else
            {
                Console.WriteLine($"White tiles left: {string.Join(", ", whiteTailStack)}");
            }
            if (!greyTailQueue.Any())
            {
                Console.WriteLine("Grey tiles left: none");

            }
            else
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", greyTailQueue)}");
            }
            
            foreach (var location in locations.Where(x => x.Value > 0).OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{location.Key}: {location.Value}");
            }

        }

        static void FormDictionary(int area, Dictionary<string, int> locations)
        {
            if (area == 40)
            {
                if (!locations.ContainsKey("Sink"))
                {
                    locations.Add("Sink", 0);
                }
                locations["Sink"]++;
            }
            else if (area == 50)
            {
                if (!locations.ContainsKey("Oven"))
                {
                    locations.Add("Oven", 0);
                }
                locations["Oven"]++;
            }
            else if (area == 60)
            {

                if (!locations.ContainsKey("Countertop"))
                {
                    locations.Add("Countertop", 0);
                }
                locations["Countertop"]++;
            }
            else if (area == 70)
            {
                if (!locations.ContainsKey("Wall"))
                {
                    locations.Add("Wall", 0);
                }
                locations["Wall"]++;
            }
            else
            {
                if (!locations.ContainsKey("Floor"))
                {
                    locations.Add("Floor", 0);
                }
                locations["Floor"]++;
            }
        }

    }
}
