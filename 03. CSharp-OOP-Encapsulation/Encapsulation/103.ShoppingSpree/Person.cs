namespace ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> listProducts;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            listProducts = new List<Product>();
        }

        public string Name
        {
            get
            { return this.name; }
            private set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }
        }
        public decimal Money
        {
            get
            { return this.money; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money = value;
            }
        }
        public void Buy(Product product)
        {
            if (product.Cost > this.Money)
            {
                Console.WriteLine($"{this.Name} can't afford {product.Name}");
            }
            else
            {
                listProducts.Add(product);
                this.Money -= product.Cost;
                Console.WriteLine($"{this.Name} bought {product.Name}");

            }
        }

        public override string ToString()
        {
            StringBuilder personOutput = new StringBuilder();
            personOutput.Append($"{this.Name} - ");
            if (this.listProducts.Count == 0)
            {
                string emptyListMessige = "Nothing bought";
                personOutput.Append(emptyListMessige);
            }
            else
            {

                for (int i = 0; i < this.listProducts.Count; i++)
                {
                    string name = this.listProducts[i].Name;
                    if (i == listProducts.Count - 1)
                    {
                        personOutput.Append(name);
                    }
                    else
                    {
                        personOutput.Append($"{name}, ");
                    }
                }
            }
            return personOutput.ToString().TrimEnd();

        }
    }
}
