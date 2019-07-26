using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Cards.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Models.BattleFields
{
    public class BattleField : IBattleField
    {
        private const int INCREASE_HEALTH = 40;
        private const int INCREASE_DEMAGE = 30;
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if(IfSomeOneIsDead(attackPlayer, enemyPlayer))
            {
                throw new ArgumentException("Player is dead!");
            }
            CheckForBeginners(attackPlayer, enemyPlayer);
            BonusBothPlayer(attackPlayer, enemyPlayer);
            while (true)
            {
                int attackerDamagePoints = attackPlayer.CardRepository.Cards.Sum(c => c.DamagePoints);
                enemyPlayer.TakeDamage(attackerDamagePoints);

                if (enemyPlayer.Health <= 0)
                {
                    break;
                }

                int enemyDamagePoints = enemyPlayer.CardRepository.Cards.Sum(c => c.DamagePoints);
                attackPlayer.TakeDamage(enemyDamagePoints);

                if (attackPlayer.Health <= 0)
                {
                    break;
                }
            }

        }

        private void CheckForBeginners(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.GetType().Name==nameof(Beginner))
            {
                attackPlayer.Health += INCREASE_HEALTH;
                foreach (ICard card in attackPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += INCREASE_DEMAGE;
                }
            }
            if (enemyPlayer.GetType().Name == nameof(Beginner))
            {
                enemyPlayer.Health += INCREASE_HEALTH;
                foreach (ICard card in enemyPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += INCREASE_DEMAGE;
                }
            }

        }

        private static void BonusBothPlayer(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            foreach (ICard card in attackPlayer.CardRepository.Cards)
            {
                attackPlayer.Health += card.HealthPoints;
            }
            foreach (ICard card in enemyPlayer.CardRepository.Cards)
            {
                enemyPlayer.Health += card.HealthPoints;
            }
        }

        private bool IfSomeOneIsDead(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead||enemyPlayer.IsDead)
            {
                return true;
            }
            return false;
        }
    }
}
