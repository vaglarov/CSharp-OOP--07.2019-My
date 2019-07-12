namespace PizzaCalories.Models
{
    using System;
    using System.Collections.Generic;
    using PizzaCalories.Exception;
    using PizzaCalories.Enum;
    public class Dough
    {
        private List<string> doughTypeList = new List<string>() { "White", "Wholegrain" };
        private List<string> bakingTypeList = new List<string>() { "Crispy", "Chewy", "Homemade" };


        private string doughType;
        private string bakingType;
        private int weight;

        public Dough(string doughType, string backingType, int weight)
        {
           this.DoughType = doughType;
           this.BakingType = backingType;
           this.Weight = weight;
        }

        public string DoughType
        {
            get
            { return this.doughType; }
            private set
            {
                if (!this.doughTypeList.Contains(value))
                {
                    throw new ArgumentException(ExceptionMessage.InvalidTypeOfDough);
                }
                this.doughType = value;
            }
        }

        public string BakingType
        {
            get
            { return this.bakingType; }
            private set
            {
                if (!this.bakingTypeList.Contains(value))
                {
                    throw new ArgumentException(ExceptionMessage.InvalidTypeOfDough);
                }
                this.bakingType = value;
            }
        }

        public int Weight
        {
            get
            { return this.weight; }
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException(ExceptionMessage.InvalidDoughWeight);
                }
                this.weight = value;
            }
        }
         

        public double Calories
        {
            get
            {

                double doughCalories = TakeCaloriesFromList(this.DoughType);
                double bakintTypeCalories = TakeCaloriesFromList(this.BakingType);
                double totalCalories = 2 * this.Weight * doughCalories * bakintTypeCalories;
                return totalCalories;
            }
        }

        private double TakeCaloriesFromList(string type)
        {
            DoughCalloriesPerGram caloriesFromList;
            Enum.TryParse(type, out caloriesFromList);
            double result = (double)caloriesFromList;
            return result/10;

        }

        public override string ToString()
        {
            return $"{this.Calories:f2}";
        }
    }
}
