using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Repositories

{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly List<IPlayer> repo;
        public PlayerRepository()
        {
            this.repo = new List<IPlayer>();
        }
        public int Count => Players.Count;

        public IReadOnlyCollection<IPlayer> Players => this.repo.AsReadOnly();

        public void Add(IPlayer player)
        {
            if (player==null)
            {
                throw new ArgumentException("Player cannot be null");
            }
            var searchingPlayer = this.repo.FirstOrDefault(p => p.Username == player.Username);
            if (searchingPlayer!=null)
            {
                throw new ArgumentException($"Player {player.Username} already exists!");
            }
            this.repo.Add(player);
        }

        public IPlayer Find(string username)
        {
            var searchingPlayer = this.repo.FirstOrDefault(p => p.Username == username);
            return searchingPlayer;
        }

        public bool Remove(IPlayer player)
        {
            //            Removes a player from the collection.
            //•	If the player is null, throw an ArgumentException with message "Player cannot be null".
            var searchingPlayer = this.repo.FirstOrDefault(p => p.Username == player.Username);
            if (searchingPlayer == null)
            {
                throw new ArgumentException("Player cannot be null");
            }
            return this.repo.Remove(player);
        }
    }
}
