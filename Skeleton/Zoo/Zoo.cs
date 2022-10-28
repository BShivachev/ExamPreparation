using System.Collections.Generic;
using System.Linq;

namespace Zoo
{
    public class Zoo
    {
        public Zoo(string name,int capacity)
        {
            Animals = new List<Animal>();
            Name = name;
            Capacity = capacity;
        }
        public List<Animal> Animals { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return Animals.Count; } }
        public string AddAnimal(Animal animal)
        {
            if (Count>=Capacity)
            {
                return "The zoo is full.";
            }
            else
            {
                if (string.IsNullOrWhiteSpace(animal.Species))
                {
                    return "Invalid animal species.";
                }
                else
                {
                    if (animal.Diet.Equals("herbivore")||animal.Diet.Equals("carnivore"))
                    {
                        Animals.Add(animal);
                        return $"Successfully added {animal.Species} to the zoo.";
                    }
                    else
                    {
                        return "Invalid animal diet.";
                    }
                }
            }
        }
        public int RemoveAnimals(string species)
        {
            return  Animals.RemoveAll(x => x.Species.Equals(species));   
        }
        public List<Animal> GetAnimalsByDiet(string diet)
        {
             return Animals.Where(x=>x.Diet.Equals(diet)).ToList();

        }
        public Animal GetAnimalByWeight(double weight)
        {
            return Animals.FirstOrDefault(x => x.Weight == weight);
        }
        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            List<Animal > list=Animals.Where(x=>x.Length>=minimumLength&&x.Length<=maximumLength).ToList();
            return $"There are {list.Count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}
