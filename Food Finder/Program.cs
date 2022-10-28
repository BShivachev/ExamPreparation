using System;
using System.Collections.Generic;
using System.Linq;

namespace Food_Finder
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Queue<char > vowels = new Queue<char>(Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray());
            Stack<char > consonants = new Stack<char>(Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray());
            int wordFound=0;
            Dictionary<string,HashSet<char>> words= new Dictionary<string,HashSet<char>>();
            words.Add("pear",new HashSet<char>());
            words.Add("flour", new HashSet<char>());
            words.Add("pork",new HashSet<char>());
            words.Add("olive",new HashSet<char>());

            while (consonants.Any())
            {
                char currentVowel=vowels.Dequeue();
                char currentConsonant=consonants.Pop();
                foreach (var word in words)
                {
                    if (word.Key.Contains(currentVowel))
                    {
                        word.Value.Add(currentVowel);
                    }
                    if (word.Key.Contains(currentConsonant))
                    {
                        word.Value.Add(currentConsonant);
                    }

                }
                vowels.Enqueue(currentVowel);
            }
            foreach (var word in words)
            {
                if (word.Value.Count==word.Key.Length)
                {
                    wordFound++;
                }
                else
                {
                    words.Remove(word.Key);
                }
            }
            Console.WriteLine($"Words found: {wordFound}");
            foreach (var word in words)
            {
                Console.WriteLine($"{word.Key}");
            }
        }
    }
}
