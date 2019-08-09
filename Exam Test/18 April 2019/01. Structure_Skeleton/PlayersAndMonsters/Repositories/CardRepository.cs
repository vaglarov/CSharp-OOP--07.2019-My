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
        private readonly List<ICard> listCards;
        public CardRepository()
        {
            this.listCards = new List<ICard>();
        }

        public int Count => this.listCards.Count;

        public IReadOnlyCollection<ICard> Cards => this.listCards.AsReadOnly();

        public void Add(ICard card)
        {
            if (card == null)
            {
                //            •	If the card is null, throw an ArgumentException with message "Card cannot be null!".
                throw new ArgumentException("Card cannot be null!");
            }
            var carwihtSameName = this.listCards.FirstOrDefault(c => c.Name == card.Name);
            if (carwihtSameName != null)
            {
                //•	If a card exists with a name equal to the name of the given card, throw an ArgumentException with message "Card {name} already exists!".
                throw new ArgumentException($"Card {card.Name} already exists!");
            }
            this.listCards.Add(card);
        }

        public ICard Find(string name)
        {
            //  Returns a card with that name.
            var carwihtSameName = this.listCards.FirstOrDefault(c => c.Name == name);
            return carwihtSameName;
        }

        public bool Remove(ICard card)
        {
            //            Removes a card from the collection.
            //•	If the card is null, throw an ArgumentException with message "Card cannot be null!".
            if (card == null)
            {
                throw new ArgumentException("Card cannot be null!");
            }
            return this.listCards.Remove(card);
        }
    }
}
