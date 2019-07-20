using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Model.Food.Entities;

namespace WildFarm.Model.Animal.Entities
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        protected override List<Type> listFood =>
            new List<Type>
            {
                typeof(Vegetable),
                typeof(Fruit),
                typeof(Meat),
                typeof(Seeds)
            };

        protected override double WeightGroingCoeficient => 0.35;

        public override string ProduceSound()
        {
            return $"Cluck";
        }
    }
}