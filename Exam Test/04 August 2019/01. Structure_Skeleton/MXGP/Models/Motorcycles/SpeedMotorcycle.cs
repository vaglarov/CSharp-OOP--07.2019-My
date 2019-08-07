using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles
{
    public class SpeedMotorcycle : Motorcycle
    {
        private const double Default_CubicCentimeters = 125;
        private const int Min_HorsePower = 50;
        private const int Max_HorsePower = 69;

        private int horsePower;

        public SpeedMotorcycle(string model, int horsePower)
            : base(model, horsePower, Default_CubicCentimeters)
        {
            this.HorsePower = horsePower;
        }

        public override int HorsePower
        {
            get { return this.horsePower; }
            protected set
            {
                if (value > Max_HorsePower || value < Min_HorsePower)
                {
                    throw new ArgumentException($"Invalid horse power: {value}.");
                }
                this.horsePower = value;
            }
        }
    }
}
