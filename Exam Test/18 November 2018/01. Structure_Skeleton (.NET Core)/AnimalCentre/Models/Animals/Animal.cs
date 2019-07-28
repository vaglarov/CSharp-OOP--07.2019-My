using AnimalCentre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.Animals
{
    public abstract class Animal : IAnimal
    {
        private const string Invalid_Message_Happiness = "Invalid happiness";
        private const string Invalid_Message_Energy = "Invalid energy";

        private const string Default_Owner = "Centre";
        private const bool Defaul_Adopted_Value = false;
        private const bool Defaul_Chipped_Value = false;
        private const bool Defaul_Vaccinate_Value = false;

        private string name;
        private int energy;
        private int happiness;
        private int procedureTime;

        public Animal(string name, int energy, int happiness, int procedureTime)
        {
            this.Name = name;
            this.Energy = energy;
            this.Happiness = happiness;
            this.ProcedureTime = procedureTime;
            this.Owner = Default_Owner;
            this.IsAdopt = Defaul_Adopted_Value;
            this.IsChipped = Defaul_Chipped_Value;
            this.IsVaccinated = Defaul_Vaccinate_Value;
        }
        public string Name //ok
        {
            get { return this.name; }
            private set
            {
                this.name = value;
            }
        }
        public int Energy //ok
        {
            get { return this.energy; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(Invalid_Message_Energy);
                }
                this.energy = value;
            }
        }
        public int Happiness //ok
        {
            get { return this.happiness; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(Invalid_Message_Energy);
                }
                this.happiness = value;
            }
        }
        public int ProcedureTime
        {
            get { return this.procedureTime; }
            set
            {
                this.procedureTime = value;
            }
        }
        public string Owner
        {
            get;
            set;
        }
        public bool IsAdopt { get; set; }
        public bool IsChipped { get; set; }
        public bool IsVaccinated { get; set; }
    }
}
