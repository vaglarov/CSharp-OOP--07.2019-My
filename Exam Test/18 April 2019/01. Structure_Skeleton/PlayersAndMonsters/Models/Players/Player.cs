using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string username;
        private int health;


        public Player(ICardRepository cardRepository, string username, int health)
        {
            this.Username = username;
            this.Health = health;
            this.CardRepository = cardRepository;
        }

        public ICardRepository CardRepository { get; }

        public string Username
        {
            get { return this.username; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Player's username cannot be null or an empty string.");
                }
                this.username = value;
            }
        }

        public int Health
        {
            get { return this.health; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Player's health bonus cannot be less than zero.");
                }
                this.health = value;
            }
        }

        public bool IsDead
        {
            get
            {
                if (this.health <= 0)
                {
                    return true;
                }
                return false;
            }
        }

        public void TakeDamage(int damagePoints)
        {
            if (damagePoints < 0)
            {
                throw new ArgumentException("Damage points cannot be less than zero.");
            }
            if (this.Health - damagePoints >= 0)
            {
                this.Health -= damagePoints;
            }
            else
            {
                this.Health = 0;
            }

        }//increase all damage points 

    }
}
