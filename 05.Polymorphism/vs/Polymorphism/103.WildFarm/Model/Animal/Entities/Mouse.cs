using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Model.Food.Entities;

namespace WildFarm.Model.Animal.Entities
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        protected override List<Type> listFood
            => new List<Type> {
                typeof(Vegetable),
                typeof(Fruit)
            };

        protected override double WeightGroingCoeficient => 0.1;

        public override string ProduceSound()
        {
            return $"Squeak";
        }
        public override string ToString()
        {
            return base.ToString() + $"{ this.Weight}, { this.LivingRegion}, { this.FoodEaten}]";
        }
    }
}
