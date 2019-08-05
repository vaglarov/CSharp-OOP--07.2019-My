using NUnit.Framework;
using Database;
using System;

namespace Tests
{
    public class DatabaseTests
    {
        private Database.Database database;

        [SetUp]
        public void Setup()
        {
            int[] input = new int[] { 1, 2 };
            this.database = new Database.Database(input);
        }

        [Test]
        public void TestIfConstructorWorksCorrectly()
        {
            int expectedCount = 2;
            Assert.AreEqual(expectedCount, database.Count);
        }
        [Test]
        public void TestAddingWorksCorrectly()
        {
            int expectedCount = 3;

            this.database.Add(3);

            Assert.AreEqual(expectedCount, database.Count);
        }
        [Test]
        public void TestAddingOverFlowThrowException()
        {

            for (int i = 3; i <= 16; i++)
            {
                this.database.Add(i);
            }

            Assert.Throws<InvalidOperationException>(() => this.database.Add(17));
        }
        [Test]
        public void TestRemovingWorksCorrectly()
        {
            int expectCount = 1;

            this.database.Remove();

            Assert.AreEqual(expectCount, database.Count);
        }

        [Test]
        public void TestTryToRemoveFromEmptyCollectionShouldThrowException()
        {
            while (this.database.Count != 0)
            {
                this.database.Remove();
            }

            Assert.Throws<InvalidOperationException>(() => this.database.Remove());
        }
        [Test]
        public void TestFetchingWorksCorrectly()
        {
            int[] expected = new int[] { 1, 2 };
            int[] data = this.database.Fetch();

            CollectionAssert.AreEqual(expected, data);
        }
    }
}