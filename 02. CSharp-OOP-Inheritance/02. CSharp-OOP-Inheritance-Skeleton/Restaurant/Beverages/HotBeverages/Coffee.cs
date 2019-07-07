namespace Restaurant.Beverages.HotBeverages
{
    public class Coffee : HotBeverage
    {
        private const double DefaultCoffeeMilliliters = 50;
        private const decimal DefaultCoffeePrice = 3.50m;

        private double caffeine;
        public Coffee(string name, double caffeine) 
            : base(name, DefaultCoffeePrice, DefaultCoffeeMilliliters)
        {
            this.Caffeine = caffeine;
        }
        public double Caffeine
        {
            get { return this.caffeine; }
            set { this.caffeine = value; }
        }
    }
}
