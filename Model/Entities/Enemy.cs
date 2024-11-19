using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeTheCrypt.Model.Entities
{
    public class Enemy : Entity
    {
        public bool Aggressive { get; private set; } = true;
        public virtual Dictionary<Item, int> Loot { get; protected set; } = new Dictionary<Item, int>();

        public Enemy(Room startingRoom, int health) : base(startingRoom)
        {
            Health = health;
        }

        protected override void Kill(object source)
        {
            Console.WriteLine($"{GetName()} was killed by {source}");

            var random = new Random();
            foreach (var lootItem in Loot)
            {
                var item = lootItem.Key;
                var value = lootItem.Value;

                int chance = value % 100;
                int guaranteedCount = value / 100;
                int droppedCount = random.Next(1, 101) <= chance ? guaranteedCount + 1 : guaranteedCount;

                if (Location != null)
                {
                    Location.AddItem(item, droppedCount);
                }
            }
        }

        public String Name()
        {
            return GetName();
        }

        public override String GetName()
        {
            return "Enemy";
        }
    }
}
