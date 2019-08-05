using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTest
    {
        [Test]
        public void DummyTestIsDead()
        {
            Dummy deadDummy = new Dummy(0, 10);

            Assert.AreEqual(true, deadDummy.IsDead());
        }


        [Test]
        public void DummyLosesHealthAfterAttacked()
        {
            Dummy dummy = new Dummy(10, 10);

            dummy.TakeAttack(5);

            Assert.AreEqual(5,dummy.Health);
        }
        [Test]
        public void DummyThrowExceptionIfIsDeadAndAttacked()
        {
            Dummy dummy = new Dummy(0, 10);

            Assert.Throws<InvalidOperationException>(()=>dummy.TakeAttack(2));

        }
        [Test]
        public void DummyCanGiveXPIfIsDead()
        {
            Dummy dummy = new Dummy(10, 10);

            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());

        }
        [Test]
        public void DummyGiveXPIfIsAlive()
        {
            Dummy dummy = new Dummy(0, 10);

            Assert.AreEqual(10, dummy.GiveExperience());

        }
    }
}
