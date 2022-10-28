using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    
    public class Renovator
    {
        public Renovator(string name,string type,double rate,int days)
        {
            Name = name;
            Type = type;
            Rate = rate;
            Days = days;
            Hired = false;
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string type;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        private double rate;

        public double Rate
        {
            get { return rate; }
            set { rate = value; }
        }
        private int days;

        public int Days
        {
            get { return days; }
            set { days = value; }
        }
        private bool hired;

        public bool Hired
        {
            get { return hired; }
            set { hired = value; }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"-Renovator: {name}");
            sb.AppendLine($"--Specialty: {type}");
            sb.AppendLine($"--Rate per day: {rate} BGN");
            return sb.ToString().Trim();
            
        }
    }
}
