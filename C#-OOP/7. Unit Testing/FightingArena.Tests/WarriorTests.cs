using NUnit.Framework;
using System;

namespace FightingArena.Tests
{
    [TestFixture]
    public class WarriorTests
    {
        [TestCase("Ivan", 1, 0)]
        [TestCase("Maria", 100, 1000)]
        [TestCase("Stoyan", 123456789, 6788757)]
        public void ConstructorShouldSetEverythingIfDataIsValid(string name, int damage, int hp)
        {
            var warrior = new Warrior(name, damage, hp);

            Assert.AreEqual(name, warrior.Name);
            Assert.AreEqual(damage, warrior.Damage);
            Assert.AreEqual(hp, warrior.HP);
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase(null)]
        public void ConstructorThrowExceptionIfNameIsEmptyOrWhiteSpace(string name)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, 10, 10));
        }

        [TestCase(0)]
        [TestCase(-100)]
        [TestCase(-123456789)]
        public void ConstructorShouldThrowExceptionForNegativeDamageValueProvided(int damage)
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Ivan", damage, 10));
        }

        [TestCase(-1)]
        [TestCase(-1000)]
        [TestCase(-6788757)]
        public void ConstructorShouldThrowExceptionForNegativeHpValueProvided(int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Ivan", 10, hp));
        }

        [TestCase(41, 40)]
        [TestCase(100, 55)]
        [TestCase(500, 100)]
        public void AttackShouldReduceOurWarriorHPValue(int hp, int enemyDamage)
        {
            var ourWarrior = new Warrior("Ivan", 50, hp);
            var enemy = new Warrior("Stoyan", enemyDamage, 70);

            ourWarrior.Attack(enemy);
            int expectedResult = hp - enemyDamage;

            Assert.AreEqual(expectedResult, ourWarrior.HP);
        }

        [TestCase(51, 50)]
        [TestCase(100, 40)]
        [TestCase(1233, 178)]
        public void AttackShouldEquateEnemyHPWith0IfOurWarriorDamageIsHigherThanEnemyHP
            (int damage, int enemyHp)
        {
            var ourWarrior = new Warrior("Ivan", damage, 60);
            var enemy = new Warrior("Stoyan", 50, enemyHp);
            ourWarrior.Attack(enemy);

            Assert.AreEqual(0, enemy.HP);
        }


        [TestCase(50, 50)]
        [TestCase(40, 100)]
        [TestCase(100, 200)]
        public void AttackShouldReduceEnemyHPWithOurWarriorDamageIfWarriorDamageIsLowerOrEvenToEnemyHP
            (int damage, int enemyHp)
        {
            var ourWarrior = new Warrior("Ivan", damage, 60);
            var enemy = new Warrior("Stoyan", 50, enemyHp);

            ourWarrior.Attack(enemy);
            int enemyHpExpected = enemyHp - damage;

            Assert.AreEqual(enemyHpExpected, enemy.HP);
        }

        [TestCase(10)]
        [TestCase(20)]
        [TestCase(30)]
        public void AttackShouldThrowExceptionIfOurWarriorHPIsLowerOrEvenToMinAttackHP(int hp)
        {
            var ourWarrior = new Warrior("Ivan", 50, hp);
            var enemy = new Warrior("Stoyan", 100, 100);

            Assert.Throws<InvalidOperationException>(() => ourWarrior.Attack(enemy));
        }

        [TestCase(10)]
        [TestCase(20)]
        [TestCase(30)]
        public void AttackShouldThrowExceptionIfEnemyHPIsLowerOrEvenToMinAttackHP(int hp)
        {
            var ourWarrior = new Warrior("Ivan", 70, 80);
            var enemy = new Warrior("Stoyan", 60, hp);

            Assert.Throws<InvalidOperationException>(() => ourWarrior.Attack(enemy));
        }

        [TestCase(40, 41)]
        [TestCase(50, 100)]
        [TestCase(31, 40)]
        public void AttackShouldThrowExceptionIfOurWarriorHPIsLowerThanEnemyDamage(int hp, int enemyDamage)
        {
            var ourWarrior = new Warrior("Ivan", 50, hp);
            var enemy = new Warrior("Stoyan", enemyDamage, 70);

            Assert.Throws<InvalidOperationException>(() => ourWarrior.Attack(enemy));
        }
    }
}