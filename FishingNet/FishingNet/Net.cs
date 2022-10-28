using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        public Net(string material,int capacity)
        {
            Material = material;
            Capacity = capacity;
            Fish = new List<Fish>();
        }
        public List<Fish> Fish { get; set; }
        public string Material { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return Fish.Count; } }
        public string AddFish(Fish fish)
        {
            if (Fish.Count>=Capacity)
            {
                return "Fishing net is full.";
            }
            else
            {
                if (string.IsNullOrWhiteSpace(fish.FishType) || fish.Length <= 0 || fish.Weight <= 0)
                {
                    return "Invalid fish.";
                }
                else
                {
                    Fish.Add(fish);
                    return $"Successfully added {fish.FishType} to the fishing net.";
                }
            }
        }
        public bool ReleaseFish(double weight)
        {
            foreach (var fish in Fish)
            {
                if (fish.Weight==weight)
                {
                    Fish.Remove(fish);
                    return true;
                }
            }
            return false;
        }
        public Fish GetFish(string fishType)
        {
            Fish fishToGot=Fish.FirstOrDefault(x=>x.FishType==fishType);
            return fishToGot;
        }
        public Fish GetBiggestFish()
        {
            double maxLength = double.MinValue;
            foreach (var fish in Fish)
            {
                if (fish.Length>maxLength)
                {
                    maxLength = fish.Length;
                }
            }
            Fish longestFish = Fish.FirstOrDefault(x => x.Length == maxLength);
            return longestFish;
        }
        public string Report()
        {
            StringBuilder report=new StringBuilder();
            report.AppendLine($"Into the {Material}:");
            foreach (var item in Fish.OrderByDescending(x=>x.Length))
            {
                report.AppendLine(item.ToString());
            }
            return report.ToString().Trim();

        }


    }
}
