namespace Restaurant.Beverages
{
    public class Beverage : Product
    {
        private double milliliters;
        public Beverage(string name, decimal price,double milliliters) 
            : base(name, price)
        {
        }
        public double Milliliters
        {
            get { return this.milliliters; }
            set { this.milliliters = value; }
        }
    }
}
