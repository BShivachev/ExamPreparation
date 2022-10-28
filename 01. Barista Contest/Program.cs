using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Barista_Contest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> coffee = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Stack<int> milk = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Dictionary<string, int> typeOfCoffees = new Dictionary<string, int>();
            
            typeOfCoffees.Add("Cortado", 0);
            typeOfCoffees.Add("Espresso", 0);
            typeOfCoffees.Add("Capuccino", 0);
            typeOfCoffees.Add("Americano", 0);
            typeOfCoffees.Add("Latte", 0);
            while (coffee.Any() && milk.Any())
            {
                int currentQuantity=coffee.Peek()+milk.Peek();
                if (FormDictionary(currentQuantity,typeOfCoffees))
                {
                    coffee.Dequeue();
                    milk.Pop();
                }
                else
                {
                    coffee.Dequeue();
                    int milkCuant = milk.Pop()-5;
                    milk.Push(milkCuant);
                }
            }
            if (coffee.Any()||milk.Any())
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }
            else
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            }
            Console.Write($"Coffee left: ");
            Console.WriteLine(coffee.Count>0 ? $"{string.Join(", ",coffee)}": "none");
            Console.Write($"Milk left: ");
            Console.WriteLine(milk.Count > 0 ? $"{string.Join(", ", milk)}" : "none");

            foreach (var cofee in typeOfCoffees.OrderBy(x=>x.Value).ThenByDescending(x=>x.Key).Where(x=>x.Value>0))
            {
                Console.WriteLine($"{cofee.Key}: {cofee.Value}");
            }
        }

        public static bool FormDictionary(int currentQuan,Dictionary<string ,int> typeOfCofees)
        {
            if (currentQuan==50)
            {
                typeOfCofees["Cortado"]++;

            }
            else if (currentQuan == 75)
            {
                typeOfCofees["Espresso"]++;
            }
            else if (currentQuan==100)
            {
                typeOfCofees["Capuccino"]++;
            }
            else if (currentQuan==150)
            {
                typeOfCofees["Americano"]++;
            }
            else if (currentQuan==200)
            {
                typeOfCofees["Latte"]++;
            }
            else
            {
                return false;
            }
            return true;     
        }
    }
}
