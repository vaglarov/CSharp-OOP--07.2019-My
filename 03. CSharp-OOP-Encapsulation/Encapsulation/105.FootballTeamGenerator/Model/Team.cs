namespace FootballTeamGenerator.Model
{
    using FootballTeamGenerator.Exception;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Team
    {
        private string name;
        private Dictionary<string, Player> dictPlayer;
        private Team()
        {
            dictPlayer = new Dictionary<string, Player>();
        }
        public Team(string name)
            :this()
        {
            this.Name = name;
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
        public int Rating
        {
            get
            {
                if (dictPlayer.Count==0)
                {
                    return 0;
                }
                double ratingTeam = dictPlayer.Values.Sum(x => x.OverallStats);
                int rating = (int)Math.Round(ratingTeam, 0);
                return rating;
            }
        }

        public void Add(Player player)
        {
          
                dictPlayer.Add(player.Name, player);
        }
        public void Remove(string playerName)
        {
            if (dictPlayer.ContainsKey(playerName))
            {
                dictPlayer.Remove(playerName);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessega.PlayeDoNotExistInTeam, playerName, this.Name));
            }
        }

        public override string ToString()
        {
            return $"{this.Name} - {this.Rating}";
        }
    }
}
