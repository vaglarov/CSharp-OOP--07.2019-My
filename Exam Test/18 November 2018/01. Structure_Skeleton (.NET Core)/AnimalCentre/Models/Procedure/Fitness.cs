using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedure
{
    public class Fitness : Procedure
    {
        private const int Correction_Happiness =-3;
        private const int Correction_Energy = 10;
        public override void DoService(IAnimal animal, int procedureTime)
        {
            base.CheckTime(procedureTime, animal);
            animal.Happiness += Correction_Happiness;
            animal.Energy += Correction_Energy;
            base.procedureHistory.Add(animal);
        }
    }
}
