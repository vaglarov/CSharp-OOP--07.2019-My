﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public abstract class Vehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
           this.FuelQuantity = fuelQuantity;
           this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity
        {
            get;
            private set;
        }
        public double FuelConsumption
        {
            get;
            private set;
        }
        public virtual void Refuel(double amount)
        {
            this.FuelQuantity += amount;
        }
        public string Drive(double distance)
        {
            string vehicleName =  this.GetType().Name ;
            double neededFuel = distance * this.FuelConsumption;

            if (this.FuelQuantity>= neededFuel)
            {
                this.FuelQuantity -= neededFuel;
                return $"{vehicleName} travelled {distance} km";
            }
            else
            {
                return $"{vehicleName} needs refueling";
            }

        }
        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
