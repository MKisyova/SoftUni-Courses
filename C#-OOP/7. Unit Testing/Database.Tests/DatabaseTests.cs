namespace Database.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class DatabaseTests
    {

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(16)]
        [TestCase(10)]
        public void AddMethodShouldAddElementWhileCountIsLessThan16(int elementsToAdd)
        {
            var database = new Database();

            for (int i = 0; i < elementsToAdd; i++)
            {
                database.Add(i);
            }

            Assert.AreEqual(elementsToAdd, database.Count);
        }

        [Test]
        public void AddMethodShouldThrowExceptionWhenAddingMoreThan16Elements()
        {
            var database = new Database(new int[16]);

            Assert.Throws<InvalidOperationException>(() => database.Add(10));
        }

        [TestCase(1, 16, 16)]
        [TestCase(0, 0, 0)]
        [TestCase(1, 1, 1)]
        [TestCase(1, 10, 10)]
        public void ConstructorShouldAddElementsWhileTheyAreBelow16(int start, int end, int count)
        {
            int[] elementsToAdd = Enumerable.Range(start, end).ToArray();

            var database = new Database(elementsToAdd);

            Assert.AreEqual(count, database.Count);
        }

        [TestCase(1, 17)]
        [TestCase(1, 30)]
        public void ConstructorShouldThrowExceptionWhenElementsAreAbove16(int start, int end)
        {
            int[] elementsToAdd = Enumerable.Range(start, end).ToArray();

            Assert.Throws<InvalidOperationException>(() => new Database(elementsToAdd));
        }

        [TestCase(1, 16, 1, 15)]
        [TestCase(1, 16, 16, 0)]
        [TestCase(1, 10, 5, 5)]
        public void RemoveMethodShouldRemoveElementWhileTheyAreMoreThan0(int start, int end, int elementsToRemove, int result)
        {
            int[] elementsToAdd = Enumerable.Range(start, end).ToArray();

            var database = new Database(elementsToAdd);

            for (int i = 0; i < elementsToRemove; i++)
            {
                database.Remove();
            }

            Assert.AreEqual(result, database.Count);
        }

        [Test]
        public void RemoveMethodShouldThrowExceptionForRemovingFromEmpyCollection()
        {
            var database = new Database();

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }


        [Test]
        public void FetchMethodShouldReturnAllValidElementsAsArray()
        {
            var database = new Database();

            for (int i = 0; i < 6; i++)
            {
                database.Add(i);
            }

            for (int i = 0; i < 3; i++)
            {
                database.Remove();
            }

            int[] expectedResult = new int[] { 0, 1, 2 };

            Assert.AreEqual(expectedResult, database.Fetch());
        }
    }
}
