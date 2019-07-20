using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension.Models
{
    public class Bus : Vehicle
    {
        private const double AIR_CONDITION_CONSUMPTION = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption+ AIR_CONDITION_CONSUMPTION, tankCapacity)
        {
            
        }
        public string DriveEmpty(double distance)
        {
            string vehicleName = this.GetType().Name;
            double neededFuel = distance * (this.FuelConsumption-AIR_CONDITION_CONSUMPTION);

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
      
    }
}
