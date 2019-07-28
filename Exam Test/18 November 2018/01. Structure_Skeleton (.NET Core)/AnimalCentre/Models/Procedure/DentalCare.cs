using System;
using System.Collections.Generic;
using System.Text;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Procedure
{
    public class DentalCare : Procedure
    {

        //adds 12 happiness and 10 energyz
        private const int Correction_Happiness = 12;
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
