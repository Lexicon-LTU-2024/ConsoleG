using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame.Tests
{
    public class CreatureTests
    {
        private const string validSymbol = "T";
        private const string invalidSymbol = "";
        private const int maxHealth = 100;
        private const int overMaxHealth = 150;
        private const int defaultDamage = 50;

        private Cell _cell;
        private Cell _cell1;
        private Cell _cell2;
        private Creature _creature;

        public CreatureTests()
        {
            _cell = new Cell(new Position(0, 0));
            _cell1 = new Cell(new Position(0, 0));
            _cell2 = new Cell(new Position(0, 0));
            _creature = new Creature(_cell, validSymbol, maxHealth);
        }

        [Fact]
        public void Constructor_ShouldInitializeProperties()
        {
            Assert.Equal(_cell, _creature.Cell);
            Assert.Equal(validSymbol, _creature.Symbol);
            Assert.Equal(maxHealth, _creature.MaxHealth);
            Assert.Equal(maxHealth, _creature.Health);
        }

        [Fact]
        public void Constructor_ShouldThrowException_OnInvalidSymbol()
        {
            Assert.Throws<ArgumentException>(() => new Creature(_cell, invalidSymbol, maxHealth));
            Assert.Throws<ArgumentException>(() => new Creature(_cell, null, maxHealth));
        }

        [Fact]
        public void CellProperty_ShouldThrowException_OnNullValue()
        {
            Assert.Throws<ArgumentNullException>(() => _creature.Cell = null);
        }

        [Fact]
        public void HealthProperty_ShouldNotExceedMaxHealth()
        {
            var cell = new Cell(new Position(0, 0));
            var creature = new Creature(cell, "T", 100);
            creature.Health = 150;

            Assert.Equal(100, creature.Health);
        }

        [Fact]
        public void IsDead_ShouldReturnTrue_WhenHealthIsZeroOrLess()
        {
            var cell = new Cell(new Position(0, 0));
            var creature = new Creature(cell, "T", 100);
            creature.Health = 0;

            Assert.True(creature.IsDead);
        }

        [Fact]
        public void Color_ShouldReturnGray_WhenCreatureIsDead()
        {
            var cell = new Cell(new Position(0, 0));
            var creature = new Creature(cell, "T", 100);
            creature.Health = 0;

            Assert.Equal(ConsoleColor.Gray, creature.Color);
        }

        [Fact]
        public void Attack_ShouldReduceTargetHealth_WithDefaultValue_50()
        {
            var cell1 = new Cell(new Position(0, 0));
            var cell2 = new Cell(new Position(0, 0));
            var attacker = new Creature(cell1, "A", 100);
            var target = new Creature(cell2, "T", 100);

            attacker.Attack(target);

            Assert.Equal(50, target.Health);
        }

        [Fact]
        public void Attack_ShouldNotReduceHealth_IfAttackerIsDead()
        {
            var cell1 = new Cell(new Position(0, 0));
            var cell2 = new Cell(new Position(0, 0));
            var attacker = new Creature(cell1, "A", 100);
            var target = new Creature(cell2, "T", 100);

            attacker.Health = 0;
            attacker.Attack(target);

            Assert.Equal(100, target.Health);
        }

        [Fact]
        public void Attack_ShouldNotReduceHealth_IfTargetIsDead()
        {
            var cell1 = new Cell(new Position(0, 0));
            var cell2 = new Cell(new Position(0, 0));
            var attacker = new Creature(cell1, "A", 100);
            var target = new Creature(cell2, "T", 100);

            target.Health = 0;
            attacker.Attack(target);

            Assert.Equal(0, target.Health);
        }

        [Fact]
        public void Attack_ShouldLogAttack()
        {
            var logMessages = new List<string>();
            Creature.AddToLog = logMessages.Add;

            var cell1 = new Cell(new Position(0, 0));
            var cell2 = new Cell(new Position(0, 0));
            var attacker = new Creature(cell1, "A", 100);
            var target = new Creature(cell2, "T", 100);

            attacker.Attack(target);

            var expectedMessage = string.Format(LogMessages.AttackMessage, attacker.Name, target.Name, attacker.Damage);
            Assert.Contains(expectedMessage, logMessages);
        }

        [Fact]
        public void Attack_ShouldLogDeath()
        {
            var logMessages = new List<string>();
            Creature.AddToLog = logMessages.Add;

            var cell1 = new Cell(new Position(0, 0));
            var cell2 = new Cell(new Position(0, 0));
            var attacker = new Creature(cell1, "A", 100);
            var target = new Creature(cell2, "T", 50);

            attacker.Attack(target);

            var expectedDeathMessage = string.Format(LogMessages.DeathMessage, target.Name);
            Assert.Contains(expectedDeathMessage, logMessages);
        }

        private static class LogMessages
        {
            public const string AttackMessage = "The {0} attacks the {1} for {2}";
            public const string DeathMessage = "The {0} is dead";
        }
    }
}
