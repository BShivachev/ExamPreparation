using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        public Computer(string model,int capacity)
        {
            Model = model;
            Capacity = capacity;
            Multiprocessor = new List<CPU>();
        }
        public List<CPU> Multiprocessor { get; set; }
        public string Model { get; set; }
        public int Capacity { get; set; }
        public int Count => Multiprocessor.Count;
        public void Add(CPU cpu)
        {
            if (Capacity>0)
            {
                Multiprocessor.Add(cpu);
                Capacity--;
            }
        }
        public bool Remove(string brand)
        {
           var current =Multiprocessor.FirstOrDefault(x=>x.Brand == brand);
            if (current!=null)
            {
                Capacity++;
            }
            return Multiprocessor.Remove(current);
        }
        public CPU MostPowerful()
        {
            double highestFreq = double.MinValue;
            foreach (CPU cpu in Multiprocessor)
            {
                if (cpu.Frequency>highestFreq)
                {
                    highestFreq = cpu.Frequency;
                }
            }
            return Multiprocessor.FirstOrDefault(x=>x.Frequency==highestFreq);
        }
        public CPU GetCPU(string brand)
        {
            return Multiprocessor.FirstOrDefault(x=>x.Brand==brand);
        }
        public string Report()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"CPUs in the Computer {Model}:");
            foreach (var cpu in Multiprocessor)
            {
                result.AppendLine(cpu.ToString());
            }
            return result.ToString().Trim();
        }
    }
}
