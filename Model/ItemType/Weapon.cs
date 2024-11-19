using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeTheCrypt.Model.ItemType
{
    public class Weapon : Item
    {
        public int BaseDamage { get; private set; }

        public Weapon(String name, String description, int baseDamage, int durability)
            : base(name, description)
        {
            BaseDamage = baseDamage;
            Durability = durability;
        }

        public override void Use(object target)
        {
            if (target is Entity entity)
            {
                entity.Damage(BaseDamage, "slashing");
            }
            else
            {
                Console.WriteLine("The target is not a valid entity.");
            }
        }
    }

}
