using MilitaryElite.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Model
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private readonly List<IMissions>missions;
        public Commando(string id, string firstName, string lastName, decimal salary, string corpsStr) 
            : base(id, firstName, lastName, salary, corpsStr)
        {
            this.missions = new List<IMissions>();
        }

        public IReadOnlyCollection<IMissions>
            Missions => this.missions;

        public void Add(IMissions mission)
        {
            this.missions.Add(mission);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
           // sb.AppendLine($"Corps: {this.Corps}");
            sb.AppendLine($"Missions:");
            foreach (var mission in missions)
            {
                sb.AppendLine($"  {mission.ToString()}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
