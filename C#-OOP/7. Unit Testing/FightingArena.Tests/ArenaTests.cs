using NUnit.Framework;
using System;
using System.Linq;

namespace FightingArena.Tests
{
    [TestFixture]
    public class ArenaTests
    {
        [Test]
        public void ConstructorShouldCreateNewListOfWarriors()
        {
            var arena = new Arena();

            Assert.IsNotNull(arena.Warriors);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(10)]
        [TestCase(30)]
        public void CountShouldReturnWarriorsCount(int count)
        {
            var arena = new Arena();

            for (int i = 0; i < count; i++)
            {
                string name = $"Warrior{i}";
                var warrior = new Warrior(name, 50, 50);
                arena.Enroll(warrior);
            }

            Assert.AreEqual(count, arena.Count);
        }

        [TestCase("Ivan", "Philip")]
        [TestCase("Ana", "Maria")]
        [TestCase("Stoyan", "Niki")]
        public void EnrollShouldAddNewWarriorToTheCollection(string firstWarriorName, string secondWarriorName)
        {
            var arena = new Arena();
            var firstWarrior = new Warrior(firstWarriorName, 50, 60);
            var secondWarrior = new Warrior(secondWarriorName, 20, 100);

            arena.Enroll(firstWarrior);
            arena.Enroll(secondWarrior);

            bool firstWarriorExists = arena.Warriors.Any(x => x.Name == firstWarrior.Name);
            bool secondWarriorExists = arena.Warriors.Any(x => x.Name == secondWarrior.Name);

            Assert.IsTrue(firstWarriorExists);
            Assert.IsTrue(secondWarriorExists);
        }

        [TestCase("Ivan", "Philip", "Ivan")]
        [TestCase("AAA", "BBB", "AAA")]
        [TestCase("Ivan Ivanov", "Maria", "Ivan Ivanov")]
        public void EnrollShouldThrowExceptionIfWarriorAlreadyExistsInTheCollection
            (string firstWarriorName, string secondWarriorName, string thirdWarriorName)
        {
            var arena = new Arena();

            var firstWarrior = new Warrior(firstWarriorName, 50, 60);
            var secondWarrior = new Warrior(secondWarriorName, 20, 100);
            var thirdWarrior = new Warrior(thirdWarriorName, 100, 1000);

            arena.Enroll(firstWarrior);
            arena.Enroll(secondWarrior);

            Assert.Throws<InvalidOperationException>(() => arena.Enroll(thirdWarrior));
        }

        [TestCase(50, 60, 20, 100)]
        [TestCase(80, 80, 70, 90)]
        [TestCase(100, 50, 50, 100)]

        public void FightShouldReduceHP
            (int attackerDamage, int attackerHp, int defenderDamage, int defenderHp)
        {
            var arena = new Arena();

            var attacker = new Warrior("Stoyan", attackerDamage, attackerHp);
            var defender = new Warrior("Niki", defenderDamage, defenderHp);
            arena.Enroll(attacker);
            arena.Enroll(defender);

            var warriorAttacker = arena.Warriors.FirstOrDefault(x => x.Name == attacker.Name);
            var warriorDefender = arena.Warriors.FirstOrDefault(x => x.Name == defender.Name);

            arena.Fight(warriorAttacker.Name, warriorDefender.Name);

            int expectedAttackerHp = attackerHp - defenderDamage;
            int expectedDefenderHp = defenderHp - attackerDamage;

            Assert.AreEqual(expectedAttackerHp, warriorAttacker.HP);
            Assert.AreEqual(expectedDefenderHp, warriorDefender.HP);
        }

        [TestCase(null, "Maria")]
        [TestCase("Ivan", null)]
        [TestCase(null, null)]
        public void FightShouldThrowExceptionIfTheAttackerOrDefenderNameAreNotInTheCollection
            (string attackerName, string defenderName)
        {
            var arena = new Arena();

            var attacker = new Warrior("Ivan", 50, 60);
            var defender = new Warrior("Maria", 20, 100);

            arena.Enroll(attacker);
            arena.Enroll(defender);

            Assert.Throws<InvalidOperationException>(() => arena.Fight(attackerName, defenderName));
        }
    }
}
