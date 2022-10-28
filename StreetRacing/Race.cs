using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        public Race(string name,string type,int laps,int capacity,int maxHp)
        {
            Name=name;
            Type=type;
            Laps=laps;
            Capacity=capacity;
            MaxHorsePower=maxHp;
            Participants = new List<Car>();
        }
        public List<Car> Participants { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }
        public int Count => Participants.Count;
        public void Add(Car car)
        {
           var curCar=Participants.FirstOrDefault(x=>x.LicensePlate==car.LicensePlate);
            if (curCar == null)
            {
                if (Capacity>Participants.Count)
                {
                    if (car.HorsePower<=MaxHorsePower)
                    {
                        Participants.Add(car);
                    }
                }
            }
           
        }
        public bool Remove(string licensePlate)
        {
            var curCar = Participants.FirstOrDefault(x => x.LicensePlate == licensePlate);
            return Participants.Remove(curCar); 
        }
        public Car FindParticipant(string licensePlate)
        {
            return  Participants.FirstOrDefault(x => x.LicensePlate == licensePlate);
        }
        public Car GetMostPowerfulCar()
        {
            int maxHP = int.MinValue;
            foreach (var item in Participants)
            {
                if (item.HorsePower>maxHP)
                {
                    maxHP = item.HorsePower;
                }
            }
            if (Participants.Count==0)
            {
                return null;
            }
            return Participants.First(x=>x.HorsePower==maxHP);
        }
        public string Report()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");
            foreach (var item in Participants)
            {
                result.AppendLine(item.ToString());
            }
            return result.ToString().Trim();
        }
    }
}
