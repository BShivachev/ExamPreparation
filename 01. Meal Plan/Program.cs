using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Meal_Plan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> meals = new Queue<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries));
            Stack<int> calories = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Dictionary<string, int> mealCollection = new Dictionary<string, int>();
            mealCollection.Add("salad", 350);
            mealCollection.Add("soup", 490);
            mealCollection.Add("pasta", 680);
            mealCollection.Add("steak", 790);
            int mealCount = 0;
            while (meals.Any()&&calories.Any())
            {               
                int currentDailyCalorie = calories.Pop();
                int currentMealCalorie = mealCollection[meals.Dequeue()];
                currentDailyCalorie-=currentMealCalorie;
                mealCount++;               
                if (currentDailyCalorie>0)
                {
                    calories.Push(currentDailyCalorie);

                }
                else
                {
                    if (calories.Any())
                    {
                        currentDailyCalorie += calories.Pop();
                        calories.Push(currentDailyCalorie);

                    }
                    else
                    {
                        break;
                    }
                }
            }
            if (!meals.Any())
            {
                Console.WriteLine($"John had {mealCount} meals.");
                int[] resultArr=new int[calories.Count];
                resultArr=calories.ToArray();                
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ",resultArr)} calories.");
            }
            else
            {
                Console.WriteLine($"John ate enough, he had {mealCount} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ",meals)}.");
            }
        }
    }
}
