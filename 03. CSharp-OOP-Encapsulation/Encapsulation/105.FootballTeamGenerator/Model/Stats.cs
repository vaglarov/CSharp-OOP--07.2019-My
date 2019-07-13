namespace FootballTeamGenerator.Model
{
    using FootballTeamGenerator.Exception;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Stats
    {
        private const int MinStatValue = 0;
        private const int MaxStatValue = 100;

        private int endurance;
        private int sprint;
        private int dribble;
        private int shooting;
        private int passing;

        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
           this.Endurance = endurance;
           this.Sprint = sprint;
           this.Dribble = dribble;
           this.Passing = passing;
           this.Shooting = shooting;
        }

        public int Endurance
        {
            get
            { return this.endurance; }
            private set
            {
                if (value < MinStatValue || value > MaxStatValue)
                {
                    throw new ArgumentException(string.Format(ExceptionMessega.InvalidStats, nameof(this.Endurance), MinStatValue, MaxStatValue));
                }
                this.endurance = value;
            }

        }
        public int Sprint
        {
            get
            { return this.sprint; }
            private set
            {
                if (value < MinStatValue || value > MaxStatValue)
                {
                    throw new ArgumentException(string.Format(ExceptionMessega.InvalidStats, nameof(this.Sprint), MinStatValue, MaxStatValue));
                }
                this.sprint = value;
            }
        }
        public int Dribble
        {
            get
            { return this.dribble; }
            private set
            {
                if (value < MinStatValue || value > MaxStatValue)
                {
                    throw new ArgumentException(string.Format(ExceptionMessega.InvalidStats, nameof(this.Dribble), MinStatValue, MaxStatValue));
                }
                this.dribble = value;
            }
        }
        public int Passing
        {
            get
            {
                return this.passing;
            }
            private set
            {
                if (value < MinStatValue || value > MaxStatValue)
                {
                    throw new ArgumentException(string.Format(ExceptionMessega.InvalidStats, nameof(this.Passing), MinStatValue, MaxStatValue));
                }
                this.passing = value;
            }
        }
        public int Shooting
        {
            get
            {
                return this.shooting;
            }
            private set
            {
                if (value < MinStatValue || value > MaxStatValue)
                {
                    throw new ArgumentException(string.Format(ExceptionMessega.InvalidStats, nameof(this.Shooting), MinStatValue, MaxStatValue));
                }
                this.shooting = value;
            }
        }

        public double OverallStat
        {
            get
            {
                var result = (this.Endurance + this.Sprint + this.Dribble + this.Passing + this.Shooting) / 5.0;
                return result;
            }
        }

    }
}
