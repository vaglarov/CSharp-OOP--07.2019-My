using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTest
    {
        [Test]
        public void FirstTestAxe()
        {
            Axe axe = new Axe(10, 10);
            Assert.AreEqual(10, axe.AttackPoints);
            Assert.AreEqual(10, axe.AttackPoints);
        }
        [Test]

        public void AxeLooseDurabilityAfterAttack()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);
            axe.Attack(dummy);

            Assert.AreEqual(9, axe.DurabilityPoints);
        }
    }
}
