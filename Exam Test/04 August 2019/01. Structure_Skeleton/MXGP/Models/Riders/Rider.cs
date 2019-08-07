using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Riders.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Riders
{
    public class Rider : IRider
    {
        private string name;
        private int numberWinRace = 0;

        public Rider(string name)
        {
            this.Name = name;
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Name {value} cannot be less than 5 symbols.");
                }
                this.name = value;
            }
        }

        public IMotorcycle Motorcycle { get; private set; }

        public int NumberOfWins => this.numberWinRace;

        public bool CanParticipate
        {
            get
            {
                if (this.Motorcycle==null)
                {
                    return false;
                }
                return true;
            }
        }

        public void AddMotorcycle(IMotorcycle motorcycle)
        {
            if (motorcycle == null)
            {
                throw new ArgumentNullException("Motorcycle cannot be null.");
            }
            this.Motorcycle = motorcycle;
        }

        public void WinRace()
        {
            this.numberWinRace++;
        }
    }
}
