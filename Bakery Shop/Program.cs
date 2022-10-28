using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01._Bakery_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] waterAmounts = Console.ReadLine().Split().Select(double.Parse).ToArray();
            double[] flourAmounts = Console.ReadLine().Split().Select(double.Parse).ToArray();
            Queue<double> water = new Queue<double>(waterAmounts);
            Stack<double> flour = new Stack<double>(flourAmounts);
            Dictionary<string, int> products = new Dictionary<string, int>();
            products["Croissant"] = 0;
            products["Muffin"] = 0;
            products["Baguette"] = 0;
            products["Bagel"] = 0;
            while (water.Any() && flour.Any())
            {

                if (GetWaterPercent(water.Peek(), flour.Peek()) == 50)
                {
                    products["Croissant"]++;
                    water.Dequeue();
                    flour.Pop();
                }
                else if (GetWaterPercent(water.Peek(), flour.Peek()) == 40)
                {
                    products["Muffin"]++;
                    water.Dequeue();
                    flour.Pop();
                }
                else if (GetWaterPercent(water.Peek(), flour.Peek()) == 30)
                {
                    products["Baguette"]++;
                    water.Dequeue();
                    flour.Pop();
                }
                else if (GetWaterPercent(water.Peek(), flour.Peek()) == 20)
                {
                    products["Bagel"]++;
                    water.Dequeue();
                    flour.Pop();
                }
                else
                {
                    double flourLeft = flour.Pop() - water.Dequeue();
                    flour.Push(flourLeft);
                    products["Croissant"]++;
                }
            }
            foreach (var item in products.OrderByDescending(item => item.Value).ThenBy(item => item.Key))
            {
                if (item.Value > 0)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");

                }
            }
            if (water.Count == 0)
            {
                Console.WriteLine("Water left: None");
            }
            else
            {
                Console.WriteLine($"Water left: {string.Join(", ", water)}");
            }
            if (flour.Count == 0)
            {
                Console.WriteLine("Flour left: None");
            }
            else
            {
                Console.WriteLine($"Flour left: {string.Join(", ", flour)}");
            }
        }
        static double GetWaterPercent(double water, double flour)
        {
            double waterPercent = water * 100 / (water + flour);
            return waterPercent;
        }
    }
}
