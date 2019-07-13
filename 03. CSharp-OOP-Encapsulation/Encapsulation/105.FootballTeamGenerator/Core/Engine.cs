namespace FootballTeamGenerator.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FootballTeamGenerator.Model;
    public class Engine
    {
        private TeamCatalog catalogTeam = new TeamCatalog();
        public Engine()
        {

        }
        public void Run()
        {
            try
            {
                string command = string.Empty;
                while ((command = Console.ReadLine()) != "END")
                {
                    string[] commandArg = command.Split(";", StringSplitOptions.RemoveEmptyEntries);
                    switch (commandArg[0])
                    {
                        case "Team":
                            TeamFactory(commandArg.Skip(1).ToArray());
                            break;
                        case "Add":
                            AddPlayerInTeam(commandArg.Skip(1).ToArray());
                            break;
                        case "Rating":
                            PintTeamRating(commandArg.Skip(1).ToArray());
                            break;
                        case "Remove":
                            RemovePlayerFromTeam(commandArg.Skip(1).ToArray());
                            break;
                        default:
                            Console.WriteLine("Wrong input");
                            break;
                    }

                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void RemovePlayerFromTeam(string[] line)
        {
            try
            {
                string teamName = line[0];
                string playerName = line[1];
                Team currentTeam = this.catalogTeam.Take(teamName);
                currentTeam.Remove(playerName);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void PintTeamRating(string[] line)
        {
            string teamName = line[0];
            Team current = this.catalogTeam.Take(teamName);
            Console.WriteLine(current.ToString());

        }

        private void TeamFactory(string[] input)
        {
            try
            {
                string teamName = input[0];
                Team team = new Team(teamName);
                this.catalogTeam.Add(team);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private void AddPlayerInTeam(string[] input)
        {
            Queue<string> line = new Queue<string>(input);
            try
            {
                string teamName = line.Dequeue();
                Team team = catalogTeam.Take(teamName);
                Player player = CreatePlayer(line);
                if (player != null)
                {
                    team.Add(player);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private Player CreatePlayer(Queue<string> line)
        {
            try
            {
                string name = line.Dequeue();

                Stats stats = StatsFactory(line);
                if (stats != null)
                {
                    Player player = new Player(name, stats);
                    return player;
                }
                return null;

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }

        }

        private Stats StatsFactory(Queue<string> line)
        {
            try
            {


                int endurance = int.Parse(line.Dequeue());
                int sprint = int.Parse(line.Dequeue());
                int dribble = int.Parse(line.Dequeue());
                int shooting = int.Parse(line.Dequeue());
                int passing = int.Parse(line.Dequeue());

                Stats stats = new Stats(endurance, sprint, dribble, shooting, passing);
                return stats;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
