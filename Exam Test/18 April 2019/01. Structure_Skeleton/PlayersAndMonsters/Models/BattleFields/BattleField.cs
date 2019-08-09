using PlayersAndMonsters.Models.BattleFields.Contracts;
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
        public BattleField()
        {

        }
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            if (attackPlayer.IsDead||enemyPlayer.IsDead)
            {
            //•	If one of the users is dead, throw new ArgumentException with message "Player is dead!"
                throw new ArgumentException("Player is dead!");
            }
            CheckForBginner(attackPlayer);
            CheckForBginner(enemyPlayer);
            TakeBonusFromDeck(attackPlayer);
            TakeBonusFromDeck(enemyPlayer);
            FightGame(attackPlayer, enemyPlayer);
        }

        private void FightGame(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            //•	Attacker attacks first and after that the enemy attacks.If one of the players is dead you should stop the fight
            int attackDamagePoints = attackPlayer.CardRepository.Cards.Sum(c => c.DamagePoints);
            int enemyDamagePoints= enemyPlayer.CardRepository.Cards.Sum(c => c.DamagePoints);
            while (true)
            {
                enemyPlayer.TakeDamage(attackDamagePoints);
                if (enemyPlayer.IsDead)
                {
                    break;
                }
                attackPlayer.TakeDamage(enemyDamagePoints);
                if (attackPlayer.IsDead)
                {
                    break;
                }
            }
        }

        private void TakeBonusFromDeck(IPlayer player)
        {
            //•	Before the fight, both players get bonus health points from their deck.
            int bonusHealth = player.CardRepository.Cards.Sum(c => c.HealthPoints);
            player.Health += bonusHealth;
        }

        private void CheckForBginner(IPlayer player)
        {
            //•	If the player is a beginner, increase his health with 40 points and increase all damage points of all cards for the user with 30.
            if (player.GetType().Name==nameof(Beginner))
            {
                player.Health += 40;
                foreach (var card in player.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }
        }
    }
}
