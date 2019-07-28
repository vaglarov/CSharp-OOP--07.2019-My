using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedure
{
    public class Play : Procedure
    {
        private const int Correction_Happiness = 12;
        private const int Correction_Energy = -6;
        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.CheckTime(procedureTime, animal);
            animal.Happiness += Correction_Happiness;
            animal.Energy += Correction_Energy;
            base.procedureHistory.Add(animal);
        }
    }
}
