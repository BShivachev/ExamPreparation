using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        public Catalog(string name, int neededRenovators, string project)
        {
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
            Renovators = new List<Renovator>();
        }
        private List<Renovator> renovators;

        public List<Renovator> Renovators
        {
            get { return renovators; }
            set { renovators = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int neededRenovators;

        public int NeededRenovators
        {
            get { return neededRenovators; }
            set { neededRenovators = value; }
        }
        private string project;

        public string Project
        {
            get { return project; }
            set { project = value; }
        }
        public int Count { get { return renovators.Count; } }
        public string AddRenovator(Renovator renovator)
        {
            if (string.IsNullOrEmpty(renovator.Name)  || string.IsNullOrEmpty(renovator.Type))
            {
                return "Invalid renovator's information.";
            }
            if (renovators.Count >= this.NeededRenovators)
            {
                return "Renovators are no more needed.";
            }
            if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }
            renovators.Add(renovator);
            return $"Successfully added {renovator.Name} to the catalog.";

        }
        public bool RemoveRenovator(string name)
        {
            for (int i = 0; i < renovators.Count; i++)
            {
                if (renovators[i].Name.Equals(name))
                {
                    renovators.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
        public int RemoveRenovatorBySpecialty(string type)
        {
            int count = 0;
            for (int i = 0;i < renovators.Count; i++)
            {
                if (renovators[i].Type.Equals(type))
                {
                    renovators.RemoveAt(i);
                    count++;
                }
            }
            return count;
        }
        public Renovator HireRenovator(string name)
        {
            Renovator hiredRenovator = renovators.FirstOrDefault(x=>x.Name.Equals(name));
            if (hiredRenovator !=null)
            {
                hiredRenovator.Hired = true;
            }
            return hiredRenovator;
        }
        public List<Renovator> PayRenovators(int days)
        {
            
            return renovators.Where(x => x.Days >= days).ToList();
        }
        public string Report()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Renovators available for Project {project}:");
            foreach (var renovator in renovators.Where(x => x.Hired != true))
            {
                stringBuilder.AppendLine(renovator.ToString());
            }
           return stringBuilder.ToString().Trim();
        }
    }
}