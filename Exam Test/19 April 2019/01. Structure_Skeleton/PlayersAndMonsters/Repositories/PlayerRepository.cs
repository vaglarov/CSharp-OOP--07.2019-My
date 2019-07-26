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
        private readonly List<IPlayer> players;
        public PlayerRepository()
        {
            this.players = new List<IPlayer>();
        }
        public int Count => this.players.Count;

        public IReadOnlyCollection<IPlayer> Players => this.players;

        public void Add(IPlayer player)
        {
            if (player==null)
            {
                throw new ArgumentException("Player cannot be null");
            }
            if (PlayerIsInRepo(player))
            {
                throw new ArgumentException($"Player {player.Username} already exists!");
            }
            this.players.Add(player);
        }


        public IPlayer Find(string username)
        {
            var playeWhithName = this.players.FirstOrDefault(name => name.Username == username);
            return playeWhithName;

        }

        public bool Remove(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }
            if (!PlayerIsInRepo(player))
            {
                return false;
            }
            this.players.Remove(player);
            return true;
        }
        private bool PlayerIsInRepo(IPlayer player)
        {
            var playeWhithName = this.players.FirstOrDefault(name => name.Username == player.Username);
            if (playeWhithName==null)
            {
                return false;
            }
            return true;
        }
    }
}
