namespace FootballTeamGenerator.Model
{
    using FootballTeamGenerator.Exception;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class TeamCatalog: IEnumerable<Team>
    {
        private Dictionary<string, Team> dictTean;

        public TeamCatalog()
        {
            dictTean = new Dictionary<string, Team>();
        }
        public void Add(Team team)
        {
            if (!dictTean.ContainsKey(team.Name))
            {
            dictTean.Add(team.Name, team);
            }
        }


        public Team Take(string teamName)
        {
            if (!dictTean.ContainsKey(teamName))
            {
                throw new ArgumentException(string.Format(ExceptionMessega.TeamDoNotExist, teamName));
            }
            return dictTean[teamName];
        }

        public IEnumerator<Team> GetEnumerator()
        {
            foreach (Team team in this.dictTean.Values)
            {
                yield return team;
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();


    }
}
