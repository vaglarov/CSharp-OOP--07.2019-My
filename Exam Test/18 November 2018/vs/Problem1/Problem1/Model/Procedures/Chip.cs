using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Model.Contends;

namespace AnimalCentre.Model.Procedures
{
    public class Chip : Procedure
    {
     public override void DoService(IAnimal animal, int procedureTime)
        {
            if (animal.IsChipped)
            {
                throw new ArgumentException($"{animal.Name} is already chipped");
            }
            base.DoService(animal, procedureTime);

            animal.Happiness -=5;
            animal.IsChipped = true;
        }
    }
}
