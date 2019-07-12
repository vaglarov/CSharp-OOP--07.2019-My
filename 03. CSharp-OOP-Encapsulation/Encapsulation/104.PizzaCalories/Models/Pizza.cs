
namespace PizzaCalories.Models
{
    using PizzaCalories.Exception;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> listTopping;
        public Pizza(string nameInput,Dough doughInput, List<Topping> listToppingInput)
        {
            this.Name = nameInput;
            this.Dough = doughInput;
            this.ListTopping = listToppingInput;
        }

        public string Name
        {
            get
            { return this.name; }
            private set
            {
                if (value.Length == 0 || value.Length > 15)
                {
                    throw new ArgumentException(ExceptionMessage.InvalidPizzaName);
                }
                this.name = value;
            }
        }
        public Dough Dough
        {
            get
            { return this.dough; }
            private set
            {
                this.dough = value;
            }
        }

        public List<Topping> ListTopping
        {
            get
            { return this.listTopping; }
            private set
            {
                if (value.Count==0 || value.Count>=11)
                {
                    throw new ArgumentException(ExceptionMessage.InvalidNuberToppingPizza);
                }
                this.listTopping = value;
            }
        }

        public double Calories
        {
            get
            {
                var totalCalories = listTopping.Sum(x => x.Calories)+this.Dough.Calories;
                return totalCalories;
            }
        }


        public override string ToString()
        {

                return $"{this.Name} - {this.Calories:f2} Calories.";
        }

    }
}
