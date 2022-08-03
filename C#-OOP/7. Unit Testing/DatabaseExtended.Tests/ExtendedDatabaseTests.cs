using ExtendedDatabase;
using NUnit.Framework;
using System;

namespace DatabaseExtended.Tests
{
    [TestFixture]
    public class ExtendedDatabaseTests
    {

        [TestCase(16)]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(10)]
        public void ConstructorShouldAddRangeOfElementsWhileTheyAreBelow16(int count)
        {
            Database database = GetRangeOfElements(count);

            Assert.AreEqual(count, database.Count);
        }

        [TestCase(17)]
        [TestCase(30)]
        public void ConstructorShouldThrowExceptionWhenElementsAreAbove16(int count)
        {
            Assert.Throws<ArgumentException>(() => GetRangeOfElements(count));
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(16)]
        [TestCase(10)]
        public void AddShouldAddElementWhileTheyAreBelow16(int elementsToAdd)
        {
            Database database = GetAddedElements(elementsToAdd);

            Assert.AreEqual(elementsToAdd, database.Count);
        }

        [TestCase(16)]
        public void AddShouldThrowExceptionWhenAddingMoreThan16Elements(int elementsToAdd)
        {
            Database database = GetAddedElements(elementsToAdd);

            Assert.Throws<InvalidOperationException>(()
                => database.Add(new Person(111, "Ivan Ivanov")));
        }

        [TestCase(10, "Person1")]
        [TestCase(15, "Person2")]
        [TestCase(11, "Person10")]
        public void AddShouldThrowExceptionIfGivenUsernameAlreadyExists 
            (int elementsToAdd, string username)
        {
            Database database = GetAddedElements(elementsToAdd);

            Person person = new Person(100, username);
            Assert.Throws<InvalidOperationException>(() => database.Add(person));
        }

        [TestCase(10, 1)]
        [TestCase(15, 14)]
        [TestCase(11, 10)]
        public void AddShouldThrowExceptionIfGivenIDAlreadyExists
            (int elementsToAdd, int id)
        {
            Database database = GetAddedElements(elementsToAdd);

            Person person = new Person(id, "Ivan");
            Assert.Throws<InvalidOperationException>(() => database.Add(person));
        }

        [TestCase(16, 1, 15)]
        [TestCase(16, 16, 0)]
        [TestCase(10, 5, 5)]
        public void RemoveShouldRemoveElementWhileTheyAreMoreThan0
            (int count, int elementsToRemove, int result)
        {
            Database database = GetRangeOfElements(count);

            for (int i = 0; i < elementsToRemove; i++)
            {
                database.Remove();
            }

            Assert.AreEqual(result, database.Count);
        }

        [Test]
        public void RemoveShouldThrowExceptionWhenRemovingFromEmpyCollection()
        {
            var database = new Database();

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [TestCase("Georgi")]
        [TestCase("Ivan ")]
        [TestCase("Maria")]
        public void FindByUsernameShouldFindByGivenUsername(string username)
        {
            var database = new Database();

            Person person1 = new Person(111, username);
            Person person2 = new Person(222, "Stoyan");
            database.Add(person1);
            database.Add(person2);

            Assert.AreEqual(person1, database.FindByUsername(username));
        }

        [TestCase(5, "Ivan")]
        [TestCase(7, "Georgi")]
        [TestCase(1, "Stoyan")]
        public void FindByUsernameShouldThrowExceptionIfNoUserExistsWithTheGivenUsername
            (int elementsToAdd, string username)
        {
            Database database = GetAddedElements(elementsToAdd);

            Assert.Throws<InvalidOperationException>(() => database.FindByUsername(username));
        }

        [Test]
        public void FindByUsernameShouldThrowExceptionIfUsernameParametherIsNull()
        {
            var database = new Database();

            Person person1 = new Person(111, "Stoyan");
            database.Add(person1);

            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(string.Empty));
        }

        [TestCase(111)]
        [TestCase(222)]
        [TestCase(123456789)]
        public void FindByIDShouldFindPersonByGivenID(long id)
        {
            var database = new Database();

            Person person1 = new Person(id, "Ivan");
            Person person2 = new Person(0000, "Georgi");
            database.Add(person1);
            database.Add(person2);

            Assert.AreEqual(person1, database.FindById(id));
        }

        [TestCase(1, 333)]
        [TestCase(5, 112)]
        [TestCase(10, 3454656)]
        public void FindByIDShouldThrowExceptionIfNoUserExistsWithTheGivenID
            (int elementsToAdd,long id)
        {
            Database database = GetAddedElements(elementsToAdd);

            Assert.Throws<InvalidOperationException>(() => database.FindById(id));
        }

        [TestCase(1, -111)]
        [TestCase(5, -1)]
        [TestCase(7, -123456789)]
        public void FindByIDShouldThrowExceptionForNegativeID(int elementsToAdd, long id)
        {
            Database database = GetAddedElements(elementsToAdd);

            Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(id));
        }

        private Database GetRangeOfElements(int count)
        {
            Person[] elementsToAdd = new Person[count];

            for (int i = 0; i < count; i++)
            {
                string username = $"Person{i}";
                elementsToAdd[i] = new Person(i, username);
            }

            var database = new Database(elementsToAdd);
            return database;
        }

        private Database GetAddedElements(int elementsToAdd)
        {
            var database = new Database();

            for (int i = 0; i < elementsToAdd; i++)
            {
                string username = $"Person{i}";
                database.Add(new Person(i, username));
            }

            return database;
        }
    }
}