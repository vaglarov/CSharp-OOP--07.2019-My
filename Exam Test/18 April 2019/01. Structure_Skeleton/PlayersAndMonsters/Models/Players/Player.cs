using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string username;
        private int health;
        private ICardRepository cardRepository;
        public Player(ICardRepository cardRepository, string username, int health)
        {
            this.Username = username;
            this.Health = health;
            this.CardRepository = cardRepository;
        }
        public ICardRepository CardRepository { get; private set; }

        public string Username
        {
            get { return this.username; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Player's username cannot be null or an empty string. ");
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
                    throw new ArgumentException("Player's health bonus cannot be less than zero. ");
                }
                this.health = value;
            }
        }

        public bool IsDead
        {
            get
            {
                bool isdead = false;
                if (Health==0)
                {
                    isdead = true;
                }
                return isdead;
            }
        }

        public void TakeDamage(int damagePoints)
        {
            //            The TakeDamage method decreases players' points. 
            //•	If the damagePoints are below 0 throw an ArgumentException with message "Damage points cannot be less than zero."
            //•	Player’s health should not drop below zero
            if (damagePoints<0)
            {
                throw new ArgumentException("Damage points cannot be less than zero.");
            }
            if (this.Health-damagePoints<0)
            {
                this.Health = 0;
            }
            else
            {
                this.Health -= damagePoints;
            }
        }
        public override string ToString()
        {
            //Username: handyUser33 - Health: 180 - Cards 3
            //Card: Cyber - Damage: 150
            //Card: Blaster - Damage: 35
            //Card: Neptune - Damage: 150
            //###
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Username: {this.Username} - Health: {this.Health} - Cards {this.CardRepository.Count}");
            foreach (var card in this.CardRepository.Cards)
            {
                sb.AppendLine($"Card: {card.Name} - Damage: {card.DamagePoints}");
            }
            sb.AppendLine($"###");
            return sb.ToString().TrimEnd();
        }
    }
}
