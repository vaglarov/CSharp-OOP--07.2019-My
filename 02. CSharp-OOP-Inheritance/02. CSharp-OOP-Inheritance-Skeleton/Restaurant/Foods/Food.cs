namespace Restaurant.Foods
{
    public class Food : Product
    {
        private double grams;
        public Food(string name, decimal price,double grams)
            : base(name, price)
        {
        }
        public double Grams
        {
            get { return this.grams; }
            set { this.grams = value; }
        }
    }
}
