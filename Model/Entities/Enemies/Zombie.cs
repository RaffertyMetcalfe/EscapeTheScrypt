using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscapeTheCrypt.Model;

namespace EscapeTheCrypt.Model.Entities.Enemies
{
    public class Zombie : Enemy
    {
        public override Dictionary<Item, int> Loot { get; protected set; }

        public Zombie(Room startingRoom, int health) : base(startingRoom, health)
        {
            Loot = new Dictionary<Item, int>
            {
                { new Item("Rotten Flesh", "Decaying flesh from a zombie"), 150 },
                { new Item("Zombie Heart", "A grotesque heart from a zombie"), 25 }
            };
        }
    }
}
