namespace BlueOrigin.Tests
{
    using System;
    using NUnit.Framework;

    public class SpaceshipTests
    {

        private Spaceship spaceship;
        [SetUp]
        public void Setup()
        {
            string name = "TestName";
            int  cap = 2;

            this.spaceship = new Spaceship(name, cap);
            //Astronaut(string name, double oxygenInPercentage)

            string austronautNane = "Nill";
            double austronautOx = 20;
            Astronaut astTest = new Astronaut(austronautNane, austronautOx);
            this.spaceship.Add(astTest);
        }
        [Test]
        public void ConstructorNOTReturnNullableObject()
        {
            string name = "testName";
            int cap = 10;
            Spaceship test = new Spaceship(name,cap);
            Assert.IsNotNull(test);
        }
        [Test]
        public void Count_WorkCorrectly()
        {
            int expected = 1;

            int actual = this.spaceship.Count;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Construct_With_NullName_Throw_Exception()
        {
            string name = string.Empty;
            int cap = 10;

            Assert.Throws<ArgumentNullException>(() => new Spaceship(name, cap));
        }
        [Test]
        public void Construct_With_NegativeCApacity_Throw_Exception()
        {
            string name = "Test";
            int cap = -10;

            Assert.Throws<ArgumentException>(() => new Spaceship(name, cap));
        }
        [Test]
        public void Construct_With_Null_CApacity()
        {
            int expCount = 0;

            string name = "Test";
            int cap = 0;
            Spaceship testSpaceShip = new Spaceship(name, cap);

                int actualCount = 0;

            Assert.AreEqual(expCount, actualCount);
        }
        [Test]
        public void Add_Work_Correctly()
        {
            int expCount = 2;

            string austronautNane = "Nill2";
            double austronautOx = 202;
            Astronaut astTest1 = new Astronaut(austronautNane, austronautOx);
            this.spaceship.Add(astTest1);
            int actualCount = 2;

            Assert.AreEqual(expCount, actualCount);
        }
        [Test]
        public void Add_OverFlowCap_ThrowException()
        {
            string austronautNane = "Nill2";
            double austronautOx = 202;
            Astronaut astTest1 = new Astronaut(austronautNane, austronautOx);
            this.spaceship.Add(astTest1);

            string austronautNaneOverF = "Nill3";
            double austronautOxOver = 202;
            Astronaut astTest2 = new Astronaut(austronautNaneOverF, austronautOxOver);


            Assert.Throws<InvalidOperationException>(() => this.spaceship.Add(astTest2));
        }
        [Test]
        public void Add_ExistingAstronautName_ThrowException()
        {
            string austronautNameExist = "Nill";
            double austronautOx = 20;
            Astronaut astTest1 = new Astronaut(austronautNameExist, austronautOx);

            Assert.Throws<InvalidOperationException>(() => this.spaceship.Add(astTest1));
        }
        [Test]
        public void Remove_Existng_Returt_True()
        {
            bool expected = true;
            string austronautNameExist = "Nill2";
            double austronautOx = 20;
            Astronaut astTest1 = new Astronaut(austronautNameExist, austronautOx);
            this.spaceship.Add(astTest1);
            bool actual = this.spaceship.Remove(austronautNameExist);

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Remove_NoExistng_Returt_False()
        {
            bool expected = false;
            string austronautNameExist = "Nill2";
            double austronautOx = 20;
            Astronaut astTest1 = new Astronaut(austronautNameExist, austronautOx);
            this.spaceship.Add(astTest1);
            bool actual = this.spaceship.Remove("NOExistingNane");

            Assert.AreEqual(expected, actual);
        }
    }
}