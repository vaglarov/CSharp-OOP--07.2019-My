using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtePolymorph.Models
{
    public class Car:Vehicle
    {
        private const double AIR_CONDITION_CONSUMPTION = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption+ AIR_CONDITION_CONSUMPTION,tankCapacity)
        {
        }
    }
}
