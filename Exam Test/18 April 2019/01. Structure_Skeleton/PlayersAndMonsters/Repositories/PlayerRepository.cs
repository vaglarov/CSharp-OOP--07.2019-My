using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly List<IPlayer> listPlayers;
        public PlayerRepository()
        {
            this.listPlayers = new List<IPlayer>();
        }
        public int Count => this.listPlayers.Count;

        public IReadOnlyCollection<IPlayer> Players => this.listPlayers.AsReadOnly();

        public void Add(IPlayer player)
        {
            if (player == null)
            {
                //•	If the player is null, throw an ArgumentException with message "Player cannot be null".
                throw new ArgumentException("Player cannot be null");
            }
            //•	If a player exists with a name equal to the name of the given player, throw an ArgumentException with message "Player {username} already exists!".
            var playExist = this.listPlayers.FirstOrDefault(p => p.Username == player.Username);
            if (playExist!=null)
            {
                throw new ArgumentException($"Player {player.Username} already exists!");
            }
            this.listPlayers.Add(player);
        }

        public IPlayer Find(string username)
        {
           return this.listPlayers.FirstOrDefault(p => p.Username == username);
        }

        public bool Remove(IPlayer player)
        {
            //•	If the player is null, throw an ArgumentException with message "Player cannot be null".
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }
           return this.listPlayers.Remove(player);
        }
    }
}
