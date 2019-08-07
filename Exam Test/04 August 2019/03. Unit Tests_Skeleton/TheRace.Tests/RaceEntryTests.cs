using NUnit.Framework;
using System;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry raceEntry;
        [SetUp]
        public void Setup()
        {
            this.raceEntry = new RaceEntry();
            UnitMotorcycle moto = new UnitMotorcycle("Test", 10, 10);
            UnitRider rider = new UnitRider("Test", moto);
            this.raceEntry.AddRider(rider);

        }
        [Test]
        public void ConstructorNOTReturnNullableObject()
        {
            RaceEntry test = new RaceEntry();
            Assert.IsNotNull(test);
        }
        [Test]
        public void CountWorkingCorrectly()
        {
            int expectCount = 2;

            UnitMotorcycle moto = new UnitMotorcycle("Test2", 10, 10);
            UnitRider rider = new UnitRider("Test2", moto);
            this.raceEntry.AddRider(rider);

            Assert.AreEqual(expectCount, raceEntry.Counter);
        }
        [Test]
        public void AddNullableObject()
        {
            UnitRider nullObj = null;

            Assert.Throws<InvalidOperationException>(() => this.raceEntry.AddRider(nullObj));
        }
        [Test]
        public void AddRiderWihtExistName()
        {
            UnitMotorcycle moto = new UnitMotorcycle("Test", 20, 10);
            UnitRider rider = new UnitRider("Test", moto);

            Assert.Throws<InvalidOperationException>(() => this.raceEntry.AddRider(rider));
        }
        [Test]
        public void AddWorkingCorrectly()
        {
            string expectMess= "Rider Test1 added in race.";

            UnitMotorcycle moto = new UnitMotorcycle("Test1", 20, 10);
            UnitRider rider = new UnitRider("Test1", moto);
            string actulaMess = this.raceEntry.AddRider(rider);

            Assert.AreEqual(expectMess, actulaMess);
        }

        [Test]
        public void CalculateAverageHorsePowerWithNotEnoughRiders()
        {
            Assert.Throws<InvalidOperationException>(() => this.raceEntry.CalculateAverageHorsePower());
        }
        [Test]
        public void CalculateAverageHorsePowerWithWorkingCorrectly()
        {
            double expectAverageHorsePower = 10.5;

            UnitMotorcycle moto = new UnitMotorcycle("Test2", 11, 10);
            UnitRider rider = new UnitRider("Test2", moto);
            this.raceEntry.AddRider(rider);

            double actualAverageHorsePower = this.raceEntry.CalculateAverageHorsePower();

            Assert.AreEqual(expectAverageHorsePower, actualAverageHorsePower);
        }
    }
}