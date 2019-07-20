using System;
using System.Collections.Generic;
using System.Text;

namespace VehiclesExtension.Models
{
    public class Truck : Vehicle
    {
        private const double AIR_CONDITION_CONSUMPTION = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption + AIR_CONDITION_CONSUMPTION, tankCapacity)
        {
        }
        public override void Refuel(double amount)
        {
            double TotalQuantity = this.FuelQuantity + amount;
            if (TotalQuantity > this.TankCapacity)
            {
                base.Refuel(amount);

            }
            else
            {
                base.Refuel(amount * 0.95);
            }
        }

    }
}
