namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        private const double ConstDefaultFuelConsumption = 3;
        public Car(int horsePower, double fuel)
            : base(horsePower, fuel)
        {
        }
        public override double DefaultFuelConsumption => ConstDefaultFuelConsumption;
        public override void Drive(double kilometers)
        {
            base.Drive(kilometers);
        }
    }
}