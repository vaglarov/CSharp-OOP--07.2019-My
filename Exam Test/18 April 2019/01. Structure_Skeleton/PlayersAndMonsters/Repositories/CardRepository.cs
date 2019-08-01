using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly List<ICard> repository;
        public CardRepository()
        {
            this.repository = new List<ICard>();
        }
        public int Count => this.Cards.Count;

        public IReadOnlyCollection<ICard> Cards => this.repository.AsReadOnly();

        public void Add(ICard card)
        {
            if (card==null)
            {
                throw new ArgumentException("Card cannot be null!");
            }
            var searchingCard = this.repository.FirstOrDefault(c => c.Name == card.Name);
            if (searchingCard!=null)
            {
                throw new ArgumentException($"Card {card.Name} already exists!");
            }
            this.repository.Add(card);
        }

        public ICard Find(string name)
        {
            var searchingCard = this.repository.FirstOrDefault(c => c.Name == name);

            return searchingCard;
        }

        public bool Remove(ICard card)
        {
            //	If the card is null, throw an ArgumentException with message "Card cannot be null!".
            if (card == null)
            {
                throw new ArgumentException($"Card cannot be null!");
            }
            return this.repository.Remove(card);
        }
    }
}
