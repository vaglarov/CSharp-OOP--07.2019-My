using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Truck:Vehicle
    {
        private const double AIR_CONDITION_CONSUMPTION = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption+ AIR_CONDITION_CONSUMPTION)
        {
        }
        public override void Refuel(double amount)
        {
            base.Refuel(amount*0.95);
        }

    }
}
