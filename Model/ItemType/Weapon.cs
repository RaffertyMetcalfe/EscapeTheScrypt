using System;
using System.Linq;

namespace EscapeTheCrypt.Model.ItemType
{
    public class Weapon : Item
    {
        public int BaseDamage { get; private set; }
        public String DamageType { get; private set; }

        public Weapon(String name, String description, int baseDamage, int durability, String damageType)
            : base(name, description)
        {
            BaseDamage = baseDamage;
            Durability = durability;
            DamageType = damageType;
        }

        public override void Use(object target)
        {
            if (target is Entity entity)
            {
                entity.Damage(BaseDamage, DamageType);
            }
            else
            {
                Console.WriteLine("The target is not a valid entity.");
            }
        }
    }

}
