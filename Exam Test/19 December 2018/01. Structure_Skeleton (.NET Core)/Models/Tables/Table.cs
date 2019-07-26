using SoftUniRestaurant.Models.Drinks.Contracts;
using SoftUniRestaurant.Models.Foods.Contracts;
using SoftUniRestaurant.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniRestaurant.Models.Tables
{
    public abstract class Table : ITable
    {

        private IList<IFood> foodOrders;
        private IList<IDrink> drinkOrders;
        private int capacity;
        private int numberOfPeople;
        private decimal pricePerPerson;

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.foodOrders = new List<IFood>();
            this.drinkOrders = new List<IDrink>();

            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.pricePerPerson = pricePerPerson;
            this.numberOfPeople = 0;
            this.IsReserved = false;
        }

        public int Capacity
        {
            get => capacity;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Capacity has to be greater than 0");
                }
                this.capacity = value;
            }
        }
        public int TableNumber
        {
            get;
        }
        public int NumberOfPeople
        {
            get => this.numberOfPeople;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Cannot place zero or less people!");
                }
                this.numberOfPeople = value;
            }
        }

        public decimal Price
        {
            get => this.foodOrders.Sum(x => x.Price)
                + this.drinkOrders.Sum(x => x.Price)
                + this.pricePerPerson * this.NumberOfPeople;
        }


        public bool IsReserved
        {
            get;
            private set;
        }

        //ok
        public void Clear()
        {
            this.drinkOrders.Clear();
            this.foodOrders.Clear();
            this.IsReserved = false;
            this.numberOfPeople = 0;
        }

        //ok
        public decimal GetBill()
        {
            return this.Price;
        }
        //ok
        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {this.TableNumber }");
            sb.AppendLine($"Table: {this.GetType().Name}");
            sb.AppendLine($"Capacity: {this.Capacity}");
            sb.AppendLine($"Price per Person: {this.pricePerPerson:f2}");

            return sb.ToString().TrimEnd();
        }

        public string GetOccupiedTableInfo()       //ok
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {this.TableNumber }");
            sb.AppendLine($"Table: {this.GetType().Name}");
            sb.AppendLine($"Number of people: {this.NumberOfPeople}");
            sb.AppendLine($"Table: {this.GetType().Name}");
            if (this.foodOrders.Count()==0)
            {
                sb.AppendLine($"Food orders: None");
            }
            else
            {
                sb.AppendLine($"Food orders: {this.foodOrders.Count}");
                foreach (var food in this.foodOrders)
                {
                    sb.AppendLine(food.ToString());
                }
            }
            if (this.drinkOrders.Count() == 0)
            {
                sb.AppendLine($"Drink orders: None");
            }
            else
            {
                sb.AppendLine($"Drink orders: {this.drinkOrders.Count}");
                foreach (var drink in this.drinkOrders)
                {
                    sb.AppendLine(drink.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }   
  

        public void OrderDrink(IDrink drink) //ok
        {
            this.drinkOrders.Add(drink); 
        }

        public void OrderFood(IFood food) //ok
        {
            this.foodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople) //ok
        {
            this.NumberOfPeople = numberOfPeople;
            this.IsReserved = true;
        }
    }
}
