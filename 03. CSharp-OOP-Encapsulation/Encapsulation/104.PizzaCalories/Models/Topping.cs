namespace PizzaCalories.Models
{
    using System;
    using PizzaCalories.Exception;
    using PizzaCalories.Enum;
    public class Topping
    {
        private string toppingFrom;
        private int weight;

        public Topping(string toppingFrom, int weight)
        {
            this.ToppingFrom = toppingFrom;
            this.Weight = weight;
        }

        public string ToppingFrom
        {
            get
            { return this.toppingFrom; }
            private set
            {
                if (HaveInAListOfTopping(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessage.InvalidToppingName, value));
                }
                this.toppingFrom = value;
            }
        }


        public int Weight
        {
            get
            { return this.weight; }
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException(string.Format(ExceptionMessage.InvalidToppingWeight,this.ToppingFrom));
                }
                this.weight = value;
            }
        }

        public double Calories
        {
            get
            {
                double toppingCalories = TakeCaloriesFromList(this.ToppingFrom);
                double totalCalories = 2 * this.Weight * toppingCalories;
                return totalCalories;
               
            }
        }

        private double TakeCaloriesFromList(string type)
        {
            EnumToppingCalories caloriesFromList;
            Enum.TryParse(type, out caloriesFromList);
            double result = (double)caloriesFromList;
            return result / 10;
        }

        private bool HaveInAListOfTopping(string value)
        {
            EnumToppingCalories fromList;

            if (Enum.TryParse(value, out fromList))
            {
                return false;
            }

            return true;
        }
        public override string ToString()
        {
            return $"{this.Calories:F2}";
        }

    }
}
