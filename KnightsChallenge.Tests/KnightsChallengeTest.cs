using KnightsChallenge.Models;

namespace KnightsChallenge.Tests

{
    public class KnightsChallengeTest
    {
        [Fact]
        public void Knight_CalculateAttributeModifier_ReturnsCorrectModifier()
        {
            var attributes = new Attributes
            {
                Strength = 16,
                Dexterity = 10,
                Constitution = 12,
                Intelligence = 8,
                Wisdom = 15,
                Charisma = 13
            };

            var knight = new Knight
            {
                Name = "Cavaleiro",
                Nickname = "Ca1",
                Birthday = new DateTime(1990, 1, 1),
                Weapons = new List<Weapon>
                {
                    new Weapon { Name = "Espada", Equipped = true, Mod = 2 }
                },
                Attributes = attributes
            };
            
            int strengthMod = knight.CalculateAttributeModifier("strength");
            Assert.Equal(2, strengthMod);
        }

        [Fact]
        public void Knight_Experience_CalculatesCorrectly()
        {
            var attributes = new Attributes
            {
                Strength = 10,
                Dexterity = 12,
                Constitution = 14,
                Intelligence = 16,
                Wisdom = 18,
                Charisma = 20
            };

            var knight = new Knight
            {
                Name = "Cavaleiro",
                Nickname = "Ca1",
                Birthday = new DateTime(2000, 1, 1),
                Weapons = new List<Weapon>
                {
                    new Weapon { Name = "Espada", Equipped = true, Mod = 2 }
                },
                Attributes = attributes
            };

            double experience = knight.Experience;
            Assert.True(experience > 0, "Experiência deve ser maior que 0.");
        }

        [Fact]
        public void Knight_GetHighestAttribute_ReturnsCorrectAttribute()
        {
            var attributes = new Attributes
            {
                Strength = 14,
                Dexterity = 18,
                Constitution = 12,
                Intelligence = 10,
                Wisdom = 8,
                Charisma = 16
            };

            var knight = new Knight
            {
                Name = "Cavaleiro",
                Nickname = "Ca1",
                Birthday = new DateTime(1995, 5, 15),
                Weapons = new List<Weapon>(),
                Attributes = attributes
            };
            
            string highestAttribute = knight.KeyAttribute;
            Assert.Equal("Dexterity", highestAttribute);
        }

        [Fact]
        public void Knight_Age_CalculatesCorrectly()
        {
            var knight = new Knight
            {
                Name = "Cavaleiro",
                Nickname = "Ca1",
                Birthday = new DateTime(2000, 1, 1),
                Weapons = new List<Weapon>(),
                Attributes = new Attributes()
            };
            
            int age = knight.Age;
            
            int expectedAge = DateTime.Now.Year - 2000;
            if (new DateTime(DateTime.Now.Year, 1, 1) > DateTime.Now)
            {
                expectedAge--;
            }

            Assert.Equal(expectedAge, age);
        }

        [Fact]
        public void Knight_Attack_CalculatesCorrectly()
        {
            
            var attributes = new Attributes
            {
                Strength = 16,
                Dexterity = 10,
                Constitution = 12,
                Intelligence = 8,
                Wisdom = 15,
                Charisma = 13
            };

            var knight = new Knight
            {
                Name = "Cavaleiro",
                Nickname = "Ca1",
                Birthday = new DateTime(1985, 3, 20),
                Weapons = new List<Weapon>
                {
                    new Weapon { Name = "Espada", Equipped = true, Mod = 3 }
                },
                Attributes = attributes
            };

            int attack = knight.Attack;

            Assert.Equal(15, attack);
        }
    }
}