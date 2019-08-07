using MXGP.Models.Races.Contracts;
using MXGP.Models.Riders.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Models.Races
{
    public class Race : IRace
    {
        private string name;
        private int laps;

        // readonly?
        private readonly List<IRider> ridersList;

        public Race(string name, int laps)
        {
            this.Name = name;
            this.Laps = laps;
            this.ridersList = new List<IRider>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Name {value} cannot be less than 5 symbols.");
                }
                this.name = value;
            }
        }

        public int Laps
        {
            get { return this.laps; }
            private set
            {
                if (value<1)
                {
                    throw new ArgumentException("Laps cannot be less than 1.");
                }
                this.laps = value;
            } }

        public IReadOnlyCollection<IRider> Riders => this.ridersList.AsReadOnly();

        public void AddRider(IRider rider)
        {
            if (rider==null)
            {
                throw new ArgumentNullException("Rider cannot be null.");
            }
            if (!rider.CanParticipate)
            {
                throw new ArgumentException($"Rider {rider.Name} could not participate in race.");
            }
            if (this.ridersList.Where(r=>r.Name==rider.Name).ToList().Count()!=0)
            {
                throw new ArgumentNullException($"Rider {rider.Name} is already added in {this.Name} race.");
            }
            this.ridersList.Add(rider);
        }
    }
}
