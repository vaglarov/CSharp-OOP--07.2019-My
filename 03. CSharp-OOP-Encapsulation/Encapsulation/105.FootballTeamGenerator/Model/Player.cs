namespace FootballTeamGenerator.Model
{
    using System;
    using FootballTeamGenerator.Exception;
    public class Player
    {
        private string name;
        public Player(string name, Stats stats)
        {
            this.Name = name;
            this.Stats = stats;
        }

        public string Name
        {
            get
            { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessega.InvalidName);
                }
                this.name = value;
            }
        }
        public Stats Stats
        {
            get; private set;

        }

        public double OverallStats
        {
            get
            {
                return this.Stats.OverallStat;
            }

        }
        public override string ToString()
        {
            return $"{this.Name} - {this.OverallStats}";
        }
    }
}
