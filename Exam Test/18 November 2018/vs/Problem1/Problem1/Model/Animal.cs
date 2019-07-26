using AnimalCentre.Model.Contends;
using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Model

{
    public abstract class Animal : IAnimal
    {
        private const string DAFAULT_OWNER_VALUE = "Centre";
        private const bool DEFALUT_ISADOPT = false;
        private const bool DEFALUT_ISCHIPED = false;
        private const bool DEFALUT_ISVACCINATED = false;


        private int energy;
        private int happiness;
        protected Animal(string name, int energy, int happiness, int procedureTime)
        {
            this.Name = name;
            this.Happiness = happiness;
            this.Energy = energy;
            this.ProcedureTime = procedureTime;
            this.Owner = DAFAULT_OWNER_VALUE;
            this.IsAdopt = DEFALUT_ISADOPT;
            this.IsChipped = DEFALUT_ISCHIPED;
            this.IsVaccinated = DEFALUT_ISVACCINATED;
        }

        public string Name { get; private set; }
        public int Happiness
        {
            get
            {
                return this.happiness;
            }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Invalid happiness");
                }
                this.happiness = value;
            }
        }

        public int Energy
        {
            get
            {
                return this.energy;
            }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException("Invalid energy");
                }
                this.energy = value;
            }
        }

        public int ProcedureTime { get;set; }

        public string Owner { get; set; }

        public bool IsAdopt { get; set; }

        public bool IsChipped { get; set; }

        public bool IsVaccinated { get;  set; }
    }
}
