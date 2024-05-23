using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace KnightsChallenge.Models
{
    public class Knight
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("nickname")]
        public string Nickname { get; set; }

        [BsonElement("birthday")]
        public DateTime Birthday { get; set; }

        [BsonElement("weapons")]
        public List<Weapon> Weapons { get; set; }

        [BsonElement("attributes")]
        public Attributes Attributes { get; set; }

        [BsonElement("keyAttribute")]
        public string KeyAttribute
        {
            get
            {
                return GetHighestAttribute();
            }
        }

        [BsonElement("isHero")]
        public bool IsHero { get; set; }

        [BsonIgnore]
        public int WeaponCount => Weapons?.Count ?? 0;

        [BsonIgnore]
        public int Attack
        {
            get
            {
                int keyAttributeMod = CalculateAttributeModifier(KeyAttribute);
                var equippedWeaponMod = Weapons?.FirstOrDefault(w => w.Equipped)?.Mod ?? 0;
                return 10 + keyAttributeMod + equippedWeaponMod;
            }
        }

        public int CalculateAttributeModifier(string attributeName)
        {
            int attributeValue = GetAttributeValue(attributeName);
            if (attributeValue >= 0 && attributeValue <= 8)
            {
                return -2;
            }
            else if (attributeValue >= 9 && attributeValue <= 10)
            {
                return -1;
            }
            else if (attributeValue >= 11 && attributeValue <= 12)
            {
                return 0;
            }
            else if (attributeValue >= 13 && attributeValue <= 15)
            {
                return 1;
            }
            else if (attributeValue >= 16 && attributeValue <= 18)
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }

        private int GetAttributeValue(string attributeName)
        {
            return attributeName.ToLower() switch
            {
                "strength" => Attributes.Strength,
                "dexterity" => Attributes.Dexterity,
                "constitution" => Attributes.Constitution,
                "intelligence" => Attributes.Intelligence,
                "wisdom" => Attributes.Wisdom,
                "charisma" => Attributes.Charisma,
                _ => 0
            };
        }

        [BsonIgnore]
        public double Experience
        {
            get
            {
                var age = DateTime.Now.Year - Birthday.Year;
                if (age < 7)
                {
                    return 0;
                }
                else
                {
                    double experience = Math.Floor((age - 7) * Math.Pow(22, 1.45));
                    return Math.Max(experience, 0);
                }
            }
        }
        private string GetHighestAttribute()
        {
            var attributeCounts = new Dictionary<string, int>
            {
                { "Strength", Attributes.Strength },
                { "Dexterity", Attributes.Dexterity },
                { "Constitution", Attributes.Constitution },
                { "Intelligence", Attributes.Intelligence },
                { "Sisdom", Attributes.Wisdom },
                { "Charisma", Attributes.Charisma }
            };

            var maxCount = attributeCounts.Max(kv => kv.Value);
            var maxAttributes = attributeCounts.Where(kv => kv.Value == maxCount).Select(kv => kv.Key).ToList();
            if (maxAttributes.Count == 1)
            {
                return maxAttributes[0];
            }
            else
            {
                return maxAttributes.OrderBy(attribute => attribute).First();
            }
        }

        [BsonIgnore]
        public int Age
        {
            get
            {
                int age = DateTime.Now.Year - Birthday.Year;
                if (Birthday.Month > DateTime.Now.Month || (Birthday.Month == DateTime.Now.Month && Birthday.Day > DateTime.Now.Day))
                {
                    age--;
                }

                if (age < 0)
                {
                    age = 0;
                }

                return age;
            }
        }
    }
}