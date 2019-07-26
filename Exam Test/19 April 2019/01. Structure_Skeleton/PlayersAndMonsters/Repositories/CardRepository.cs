using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly List<ICard> cards;
        private const string NULL_MESSAGE_CARD = "Card cannot be null!";
        public CardRepository()
        {
            this.cards = new List<ICard>();
        }
        public int Count => this.cards.Count;

        public IReadOnlyCollection<ICard> Cards => this.cards;

        public void Add(ICard card)
        {
            if (card==null)
            {
                throw new ArgumentException(NULL_MESSAGE_CARD);
            }
            if (CardExistInRepo(card))
            {
                throw new ArgumentException($"Card {card.Name} already exists!");
            }
            this.cards.Add(card);

        }


        public ICard Find(string name)
        {
            var searchingCard = this.cards.FirstOrDefault(n => n.Name == name);
            return searchingCard;
        }

        public bool Remove(ICard card)
        {
            if (card == null)
            {
                throw new ArgumentException(NULL_MESSAGE_CARD);
            }
            if (!CardExistInRepo(card))
            {
                return false;
            }
            this.cards.Remove(card);
            return true;
        }
        private bool CardExistInRepo(ICard card)
        {
            var searchingCard = this.cards.FirstOrDefault(name => name.Name== card.Name);
            if (searchingCard == null)
            {
                return false;
            }
            return true;
        }
    }
}
