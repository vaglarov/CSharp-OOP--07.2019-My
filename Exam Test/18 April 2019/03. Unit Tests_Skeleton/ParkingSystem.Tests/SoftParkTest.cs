namespace ParkingSystem.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    public class SoftParkTest
    {
        private SoftPark testRepo;
        [SetUp]
        public void Setup()
        {
            this.testRepo = new SoftPark();
        }

        [Test]
        public void Constructor_NOTReturnNullableObject()
        {

            SoftPark test = new SoftPark();
            Assert.IsNotNull(test);
        }
        [Test]
        public void ParkCar_WorkingCorrectly()
        {
            string expected = $"Car:test parked successfully!";

            string spot = "A1";
            Car testCarFirst = new Car("A1", "test");
            string actual = this.testRepo.ParkCar(spot, testCarFirst);
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void ParkCar_WrongSpot_Throw_ArgumentException()
        {
            string wrongSpot = "WrongSpot";
            Car testCar = new Car("Test", "test");

            Assert.Throws<ArgumentException>(()=>this.testRepo.ParkCar(wrongSpot, testCar));
        }
        [Test]
        public void ParkCar_CarIsAlreadyPark_Throw_InvalidOperationException()
        {
            string spot = "A1";
            Car testCarFirst = new Car("A1", "test");
            this.testRepo.ParkCar(spot, testCarFirst);
            string spotSecond = "A2";

            Assert.Throws<InvalidOperationException>(() => this.testRepo.ParkCar(spotSecond, testCarFirst));
        }
        [Test]
        public void ParkCar_SpotIsTaken_Throw_ArgumentException()
        {
            string spot = "A1";
            Car testCarFirst = new Car("A1", "test");
            this.testRepo.ParkCar(spot, testCarFirst);
            Car carSecond = new Car("A1", "test");

            Assert.Throws<ArgumentException>(() => this.testRepo.ParkCar(spot, carSecond));
        }
        [Test]
        public void ParkCar_ParkCarWihtSameNumber_Throw_InvalidOperationException()
        {
            string spot = "A1";
            Car testCarFirst = new Car("A1", "test");
            this.testRepo.ParkCar(spot, testCarFirst);
            Car carSecond = new Car("A1", "test");

            Assert.Throws<InvalidOperationException>(() => this.testRepo.ParkCar("A2", carSecond));
        }
  
        [Test]
        public void Remove_WorkingCorrectly()
        {
            string expected = $"Remove car:test successfully!";

            string spot = "A1";
            Car testCarFirst = new Car("A1", "test");
             this.testRepo.ParkCar(spot, testCarFirst);
            string actual = this.testRepo.RemoveCar(spot, testCarFirst);

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Remove_IncorrectParckingSpot_Throw_ArgumentException()
        {
            string spot = "A1";
            Car testCarFirst = new Car("A1", "test");
            this.testRepo.ParkCar(spot, testCarFirst);
            string incorrectSpot = "WrongSpot";

            Assert.Throws<ArgumentException>(() => this.testRepo.RemoveCar(incorrectSpot, testCarFirst));
        }
        [Test]
        public void Remove_IncorrectCarInParckingSpot_Throw_ArgumentException()
        {
            string spot = "A1";
            Car testCarFirst = new Car("A1", "test");
            this.testRepo.ParkCar(spot, testCarFirst);
            Car wrongCar = new Car("A1", "wrong");

            Assert.Throws<ArgumentException>(() => this.testRepo.RemoveCar(spot, wrongCar));
        }
        [Test]
        public void IReadOnlyDictionary_WorkingCorrectly()
        {

            IReadOnlyDictionary<string, Car> expected = new Dictionary<string, Car>
            {
                {"A1", null},
                {"A2", null},
                {"A3", null},
                {"A4", null},
                {"B1", null},
                {"B2", null},
                {"B3", null},
                {"B4", null},
                {"C1", null},
                {"C2", null},
                {"C3", null},
                {"C4", null},
            };

            var actulal = this.testRepo.Parking;

            CollectionAssert.AreEqual(expected, actulal);
        }
    }
}