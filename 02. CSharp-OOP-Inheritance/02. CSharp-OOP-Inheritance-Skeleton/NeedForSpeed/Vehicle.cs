namespace NeedForSpeed
{
using System;
    public class Vehicle
    {

        private const double ConstDefaultFuelConsumption=1.25;

        private int horsePower;
        private double fuel;
        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }
        public int HorsePower
        {
            get { return this.horsePower; }
            private set { this.horsePower = value; }
        }
        public double Fuel
        {
            get { return this.fuel; }
            private set { this.fuel = value; }
        }

        public virtual double DefaultFuelConsumption
            => ConstDefaultFuelConsumption;
       

        public virtual void Drive(double kilometers)
        {
            this.Fuel -= kilometers * this.DefaultFuelConsumption;
            if (this.Fuel < 0)
            {
                this.Fuel += kilometers * this.DefaultFuelConsumption;
                throw new ArgumentException("Don't have enough fuel for this travel.:(");
            }
        }
    }
}
