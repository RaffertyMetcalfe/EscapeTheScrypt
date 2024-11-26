using System;
using System.Linq;

namespace EscapeTheCrypt.Model.Entities.Enemies
{
    public class Zombie : Enemy
    {
        public override Dictionary<Item, int> Loot { get; protected set; }

        public Zombie(int health) : base(health)
        {
            Loot = new Dictionary<Item, int>
            {
                { new Item("Rotten Flesh", "Decaying flesh from a zombie"), 150 },
                { new Item("Zombie Heart", "A grotesque heart from a zombie"), 25 }
            };
        }
    }
}
