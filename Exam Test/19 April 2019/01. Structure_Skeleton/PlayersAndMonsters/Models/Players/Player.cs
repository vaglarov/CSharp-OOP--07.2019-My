using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Players
{
    public abstract class Player : IPlayer
    {

        private string userNane;
        private int healt;
        public Player(ICardRepository cardRepository, string username, int health)
        {
            this.Username = username;
            this.Health = healt;
            this.CardRepository = cardRepository;
        }
        public ICardRepository CardRepository
        {
            get;set;
        }

        public string Username  //ready
        {
            get { return this.userNane; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Player's username cannot be null or an empty string.");
                }
                this.userNane = value;
            }
        }

        public int Health
        {
            get { return this.healt; }
            set
            {
                if (value<0)
                {
                    throw new ArgumentException("Player's health bonus cannot be less than zero.");
                }
                this.healt = value;
            }
        }

        public bool IsDead
        {
            get
            {
                if (this.Health>0)
                {
                    return false;
                }
                return true;
            }
        }

        public void TakeDamage(int damagePoints)
        {
            if (damagePoints<0)
            {
                throw new ArgumentException("Damage points cannot be less than zero.");
            }
            if (this.Health< damagePoints)
            {
                this.Health = 0;
            }
            else
            {
                this.Health = -damagePoints;
            }

        }
    }
}
