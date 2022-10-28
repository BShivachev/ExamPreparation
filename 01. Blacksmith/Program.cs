using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Blacksmith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> steel = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Stack<int> carbon = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Dictionary<string, int> swords = new Dictionary<string, int>();
            swords.Add("Gladius", 0);
            swords.Add("Shamshir", 0);
            swords.Add("Katana", 0);
            swords.Add("Sabre", 0);
            swords.Add("Broadsword", 0);
            int forgedCount=0;
            while (steel.Any()&&carbon.Any())
            {
                int currentMach = steel.Peek() + carbon.Peek();
                if (FormDictionary(currentMach,swords))
                {
                    steel.Dequeue();
                    carbon.Pop();
                    forgedCount++;  
                }
                else
                {
                    steel.Dequeue() ;
                    int currentCarbon=carbon.Pop()+5;
                    carbon.Push(currentCarbon);
                }

            }
            if (forgedCount>0)
            {
                Console.WriteLine($"You have forged {forgedCount} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }
            Console.Write($"Steel left: ");
            Console.WriteLine(steel.Count > 0 ? $"{string.Join(", ", steel)}" : "none");
            Console.Write($"Carbon left: ");
            Console.WriteLine(carbon.Count > 0 ? $"{string.Join(", ", carbon)}" : "none");
            foreach (var item in swords.OrderBy(x=>x.Key).Where(x=>x.Value>0))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }


        }
        public static bool FormDictionary(int currentQuan, Dictionary<string, int> typeOfCofees)
        {
            if (currentQuan == 70)
            {
                typeOfCofees["Gladius"]++;

            }
            else if (currentQuan == 80)
            {
                typeOfCofees["Shamshir"]++;
            }
            else if (currentQuan == 90)
            {
                typeOfCofees["Katana"]++;
            }
            else if (currentQuan == 110)
            {
                typeOfCofees["Sabre"]++;
            }
            else if (currentQuan == 150)
            {
                typeOfCofees["Broadsword"]++;
            }
            else
            {
                return false;
            }
            return true;
        }
    }
}
