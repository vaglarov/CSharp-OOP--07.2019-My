namespace Restaurant
{
    public class Product
    {
        private string name;
        private decimal price;
        public Product(string name,decimal price)
        {
            this.Name = name;
            this.Price = price;
        }
        public string Name
        {
            get { return this.name; }
            set{ this.name = value; }
        }
        public decimal Price
        {
            get { return this.price; }
            set { this.price = value; }
        }

        //public override string ToString()
        //{
        //    return $"Type: {this.GetType().Name}  Name: {this.Name} Price: {this.Price}";
        //}

    }
}
