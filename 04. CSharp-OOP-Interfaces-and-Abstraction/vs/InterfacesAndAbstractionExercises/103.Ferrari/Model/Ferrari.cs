namespace _103.Ferrari.Model
{
using _103.Ferrari.Interfaces;
    public class Ferrari : ICar
    {
        private const string DefaultModel = "488-Spider";
        public Ferrari( string driverName)
        {
           
           this.DriverName = driverName;
        }

        public string Model
        {
            get { return DefaultModel; }
           
        }

        public string DriverName
        {
            get; private set;
        }

        public string PushBrake()
        {
            return $"Brakes!";
        }

        public string PushGas()
        {
            return $"Gas!";
        }
        public override string ToString()
        {
            return $"{this.Model}/{PushBrake()}/{PushGas()}/{this.DriverName}";
        }
    }
}
