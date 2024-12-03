using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeTheCrypt.Model.Entities.Enemies
{
    public class Skeleton : Enemy
    {
        public override Dictionary<Item, int> Loot { get; protected set; }

        public Skeleton(Room location, int health = 15) : base(location, health)
        {
            Loot = new Dictionary<Item, int>
            {
                { new Item("Bone", "The bone of a skeleton"), 325 },
                { new Item("Bow", "A ranged weapon capable of striking fleeing enemies"), 25 }
            };
        }
    }
}
