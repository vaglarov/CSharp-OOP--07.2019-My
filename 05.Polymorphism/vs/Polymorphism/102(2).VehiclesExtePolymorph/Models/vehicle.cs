using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtePolymorph.Models
{
    public abstract class Vehicle
    {
        private const double ABOVE_TANK_CAPACITY = 0;
        private double fuelQuantity;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public double TankCapacity
        {
            get;
            private set;
        }
        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            protected set
            {
                if (this.TankCapacity < value)
                {
                    this.fuelQuantity = ABOVE_TANK_CAPACITY;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }
        public double FuelConsumption
        {
            get;
            protected set;
        }
        public virtual void Refuel(double amount)
        {
            if (amount<=0)
            {
                throw new InvalidOperationException("Fuel must be a positive number");
            }
            else
            {
                double TotalQuantity = this.FuelQuantity + amount;
                if (TotalQuantity > this.TankCapacity)
                {
                    throw new InvalidOperationException($"Cannot fit {amount} fuel in the tank");
                }
                else
                {
                    this.FuelQuantity = TotalQuantity;
                }
            }

        }
        public virtual string Drive(double distance)
        {
            string vehicleName = this.GetType().Name;
            double neededFuel = distance * this.FuelConsumption;

            if (this.FuelQuantity >= neededFuel)
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
