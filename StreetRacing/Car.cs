﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StreetRacing
{
    

    
    public class Car
    {
        public Car(string make, string model,string licensePlate,int horsePower,double weight)
        {
            Make=make;
            Model=model;
            LicensePlate=licensePlate;
            HorsePower=horsePower;
            Weight=weight;
        }
        public string Make  { get; set; }
        public string  Model { get; set; }
        public string LicensePlate { get; set; }
        public int HorsePower { get; set; }
        public double  Weight { get; set; }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Make: {Make}");
            stringBuilder.AppendLine($"Model: {Model}");
            stringBuilder.AppendLine($"License Plate: {LicensePlate}");
            stringBuilder.AppendLine($"Horse Power: {HorsePower}");
            stringBuilder.AppendLine($"Weight: {Weight}");
            return stringBuilder.ToString().Trim();
        }
    }
}
