using ExtendedDatabase;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase.ExtendedDatabase data;

        [SetUp]
        public void Setup()
        {
            Person personOne = new Person(1, "Abc");
            Person personTwo = new Person(2, "Abcd");
            Person[] persons = new Person[] { personOne, personTwo };
            this.data = new ExtendedDatabase.ExtendedDatabase(persons);

        }
        [Test]
        public void AddWorkCorrectly()
        {
            int expectedCount = 3;

            Person persontree = new Person(3, "Abcde");
            this.data.Add(persontree);
            
            Assert.AreEqual(expectedCount, this.data.Count);
        }

        [Test]
        public void AddPersonWithSameUserName()
        {
            

            Person persontree = new Person(3, "Abcd");

            Assert.Throws<InvalidOperationException>(()=>this.data.Add(persontree) );
        }

        [Test]
        public void AddPersonWithSameID()
        {
            Person persontree = new Person(2, "Abcde");

            Assert.Throws<InvalidOperationException>(() => this.data.Add(persontree));
        }

        [Test]
        public void RemoveWorkingCorrectly()
        {
            int expectedCount = 1;

            this.data.Remove();

            Assert.AreEqual(expectedCount, this.data.Count);
        }

        [Test]
        public void RemoveFromEmptyCorrectly()
        {
            while (this.data.Count!=0)
            {
                this.data.Remove();
            }

            Assert.Throws<InvalidOperationException>(()=>this.data.Remove());
        }
        [Test]
        public void FindByNameWihtNullArgument()
        {
            string emptyName = string.Empty;

            Assert.Throws<ArgumentNullException>(() => this.data.FindByUsername(emptyName));
        }

        [Test]
        public void FindByNameWihtInvalidUserName()
        {
            string invalidName = "invalid name";

            Assert.Throws<InvalidOperationException>(() => this.data.FindByUsername(invalidName));
        }
        [Test]
        public void FindByNameWorkingCorrectly()
        {
            Person expectPerson = new Person(16, "Abcde");

            this.data.Add(expectPerson);
            string currentName = expectPerson.UserName;
            Person personWithThatName = this.data.FindByUsername(currentName);

            Assert.AreEqual(expectPerson, personWithThatName);
        }
        [Test]
        public void FindByIdWorkingCorrectly()
        {
            Person expectPerson = new Person(16, "Abcde");

            this.data.Add(expectPerson);
            long currentName = expectPerson.Id;
            Person personWithThatName = this.data.FindById(currentName);

            Assert.AreEqual(expectPerson, personWithThatName);
        }

        [Test]
        public void FindByIdWihtInvalidId()
        {
           
            long invalidId = 007;


            Assert.Throws<InvalidOperationException>(()=>this.data.FindById(invalidId));
        }
        [Test]
        public void FindByIdWihtNegativeId()
        {

            long invalidId = -007;


            Assert.Throws<ArgumentOutOfRangeException>(() => this.data.FindById(invalidId));
        }
    }
}
