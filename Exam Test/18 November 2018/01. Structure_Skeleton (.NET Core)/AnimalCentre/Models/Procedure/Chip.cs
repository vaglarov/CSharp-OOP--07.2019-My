using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedure
{
    public class Chip : Procedure
    {
        private const string Message_Animal_Is_Chipped = "{0} is already chipped";

        private const int Happiness_Value_For_Chipped = 5;

        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.CheckTime(procedureTime, animal);
            if (animal.IsChipped)
            {
                throw new ArgumentException(string.Format(Message_Animal_Is_Chipped, animal.Name));
            }
            animal.IsChipped = true;
            animal.Happiness -= 5;
            base.procedureHistory.Add(animal);
        }
    }
}
