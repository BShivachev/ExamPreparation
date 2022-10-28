using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
   
    public class Airfield
    {
        public Airfield(string name,int capacity,double landingStrip)
        {
            Name = name;
            Capacity = capacity;
            LandingStrip = landingStrip;
            Drones = new List<Drone>();
        }
        public List<Drone> Drones { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }
        public int Count => Drones.Count;
        public string AddDrone(Drone drone)
        {
            if (Drones.Count == Capacity)
            {
                return "Airfield is full.";
            }
            if (string.IsNullOrEmpty(drone.Name)||string.IsNullOrEmpty(drone.Brand)||drone.Range<5||drone.Range>15)
            {
                return "Invalid drone.";
            }
            Drones.Add(drone);
            return $"Successfully added {drone.Name} to the airfield.";
        }
        public bool RemoveDrone(string name)
        {
            var removedDrone=Drones.FirstOrDefault(dr => dr.Name == name);
            if (removedDrone != null)
            {
               return Drones.Remove(removedDrone);
            }
            return false;
        }
        public int RemoveDroneByBrand(string brand)
        {
            return Drones.RemoveAll(dr => dr.Brand == brand);
        }
        public Drone FlyDrone(string name)
        {
            var drone = Drones.FirstOrDefault(dr => dr.Name == name);
            if (drone != null)
            {
                drone.Available = false;
                return drone;
            }
            return null;
        }
        public List<Drone> FlyDronesByRange(int range)
        {
            var list = Drones.Where(x => x.Range >= range).ToList();
            foreach (var item in list)
            {
                item.Available = false;
            }
            return list;
        }
        public string Report()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Drones available at {Name}:");
            foreach (var drone in Drones.Where(x => x.Available != false))
            {
                result.AppendLine(drone.ToString());
            }
            return result.ToString().Trim();
        }
    }
}
