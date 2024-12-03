using System.Text;
using EscapeTheCrypt.Model.Entities;
using EscapeTheCrypt.Model.ItemType;

namespace EscapeTheCrypt.Model
{
    public class Room
    {
        public String Name { get; private set; }
        public String Description { get; private set; }
        public bool Locked { get; set; }

        public Dictionary<String, Room> Exits { get; private set; } = new Dictionary<String, Room>();
        public Dictionary<Item, int> Items { get; private set; } = new Dictionary<Item, int>();
        public List<Enemy> Enemies { get; private set; } = new();
        public List<Trap> Traps { get; private set; } = new List<Trap>();
        public String ID {  get; private set; }

        public Room(String id, String name, String description, List<Trap>? traps = null, bool locked = false)
        {
            ID = id;
            Name = name;
            Description = description;
            Locked = locked;
        }

        public void Connect(String direction, Room room)
        {
            Exits[direction] = room;
        }

        public bool Unlock(Key key)
        {
            if (key.Room == this)
            {
                Locked = false;
                return true;
            }
            return false;
        }

        public void AddItem(Item item, int amount)
        {
            if (Items.ContainsKey(item))
            {
                Items[item] += amount;
            }
            else
            {
                Items[item] = amount;
            }
            Console.WriteLine($"{amount} {item.Name} was added to {Name}");
        }

        public void RemoveItem(Item item, int amount = 1)
        {
            if (Items.ContainsKey(item))
            {
                if (Items[item] <= amount)
                {
                    Items.Remove(item);
                }
                else
                {
                    Items[item] -= amount;
                }
            }
            else
            {
                Console.WriteLine($"{item.Name} is not in this room.");
            }
        }

        public Enemy? GetEnemyFromName(String name)
        {
            return Enemies.Find(enemy => enemy.Name() == name);
        }

        public String GetContents()
        {
            StringBuilder contents = new StringBuilder();
            contents.Append($"{Name}:\n");
            contents.Append($"Description: {Description}\n");
            contents.Append("Exits:\n");
            foreach (var exit in Exits)
            {
                contents.Append($"{exit.Key}: {exit.Value.Name}\n");
            }
            contents.Append("Items:\n");
            foreach (var item in Items)
            {
                contents.Append($"{item.Value}x {item.Key.Name}\n");
            }
            contents.Append("Enemies:\n");
            foreach (var enemy in Enemies)
            {
                contents.Append($"{enemy.Name()}\n");
            }
            return contents.ToString().Trim();
        }

        public void AddEnemy(Enemy enemy)
        {
            Enemies.Add(enemy);
        }

        public void RemoveEnemy(Enemy enemy)
        {
            Enemies.Remove(enemy);
        }
    }
}
