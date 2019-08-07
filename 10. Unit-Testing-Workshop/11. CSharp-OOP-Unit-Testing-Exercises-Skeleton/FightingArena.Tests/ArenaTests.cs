using NUnit.Framework;
using FightingArena;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Tests
{
    public class ArenaTests
    {
        private Arena twoPlayersArena;
        [SetUp]
        public void Setup()
        {
            Warrior first = new Warrior("First", 100, 200);
            Warrior second = new Warrior("Second", 100, 200);


            this.twoPlayersArena = new Arena();

            this.twoPlayersArena.Enroll(first);
            this.twoPlayersArena.Enroll(second);
        }

        [Test]
        public void HaveNoPublicField()
        {
            int expectCountPublicField = 0;

            Type type = this.twoPlayersArena.GetType();
            var allType = type.GetFields().Where(t => t.IsPublic);

            Assert.AreEqual(expectCountPublicField, allType.Count());
        }
        [Test]
        public void EnrolWithExistNameWarriorName()
        {
            Warrior first = new Warrior("First", 100, 200);


            Assert.Throws<InvalidOperationException>(() => this.twoPlayersArena.Enroll(first));
        }
        [Test]
        public void CountAndEnrolWorkingCorrectly()
        {
            int expectCount = 2;

            Assert.AreEqual(expectCount, twoPlayersArena.Count);
        }
        [Test]
        public void WarriorsWorkingCorrectlyButTheyAreNotComperable()
        {
            List<Warrior> listWarrior = new List<Warrior>();

            Warrior first = new Warrior("First", 100, 200);
            Warrior second = new Warrior("Second", 100, 200);
            listWarrior.Add(first);
            listWarrior.Add(second);
            Warrior[] expectedCollection = listWarrior.ToArray();

            Warrior[] actualCollection = this.twoPlayersArena.Warriors.ToArray();

            CollectionAssert.AreNotEqual(expectedCollection, actualCollection);
        }
        [Test]
        public void FightWithNoWarriorInArenaNoExisAttackName()
        {
            string first = "First";
            string second = "Didn'tExist";

            Assert.Throws<InvalidOperationException>(() => this.twoPlayersArena.Fight(first,second));
        }
        [Test]
        public void FightWithNoWarriorInArenaNoExisEnemyName()
        {
            string first = "Didn'tExist";
            string second = "First";

            Assert.Throws<InvalidOperationException>(() => this.twoPlayersArena.Fight(first, second));
        }
        [Test]
        public void FightShouldExecuteAttackMethodOnWarriors()
        {
            Warrior attacker = new Warrior("attacker", 50, 50);
            Warrior defender = new Warrior("defender", 40, 60);

            this.twoPlayersArena.Enroll(attacker);
            this.twoPlayersArena.Enroll(defender);

            this.twoPlayersArena.Fight("attacker", "defender");

            int expectedDefenderHP = 10;

            Assert.AreEqual(expectedDefenderHP, defender.HP);
        }
    }
}
