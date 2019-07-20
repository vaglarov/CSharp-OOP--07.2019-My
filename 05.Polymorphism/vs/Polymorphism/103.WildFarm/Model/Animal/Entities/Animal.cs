using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Model.Animal.Interfaces;
using WildFarm.Model.Food.Interfaces;
using WildFarm.ExceptionMessages;

namespace WildFarm.Model.Animal.Entities
{
    public abstract class Animal : IAnimal
    {
        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = 0;
        }
        protected abstract List<Type> listFood
        {
            get;
        }
        protected abstract double WeightGroingCoeficient
        {
            get;
        }
        public string Name
        {
            get;
            private set;
        }

        public double Weight
        {
            get;
            private set;
        }
        public int FoodEaten
        {
            get;
            private set;
        }

        public void Feed(IFood food)
        {
            if (!this.listFood.Contains(food.GetType()))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessage.InvalidFoodType, this.GetType().Name, food.GetType().Name));
            }
            this.Weight += food.Quantity * WeightGroingCoeficient;
            this.FoodEaten += food.Quantity;
        }

        public abstract string ProduceSound();

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }

    }
}
