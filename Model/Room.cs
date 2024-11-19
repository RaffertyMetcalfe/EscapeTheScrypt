using System;
using System.Collections.Generic;
using System.Linq;
using EscapeTheCrypt.Model.Entities;
using EscapeTheCrypt.Model.ItemType;

namespace EscapeTheCrypt.Model
{
    public class Room
    {
        public String Name { get; private set; }
        public String Description { get; private set; }
        private bool _locked;
        public bool Locked
        {
            get => _locked;
            set => _locked = value;
        }

        public Dictionary<String, Room> Exits { get; private set; } = new Dictionary<String, Room>();
        public Dictionary<Item, int> Items { get; private set; } = new Dictionary<Item, int>();
        public List<Enemy> Enemies { get; private set; } = new List<Enemy>();
        public List<Trap> Traps { get; private set; } = new List<Trap>();

        public Room(String name, String description, List<Enemy> enemies, bool locked = false)
        {
            Name = name;
            Description = description;
            Enemies = enemies;
            _locked = locked;
        }

        public void Connect(String direction, Room room)
        {
            Exits[direction] = room;
        }

        public bool Unlock(Key key)
        {
            if (key.Room == this)
            {
                _locked = false;
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

        public Enemy GetEnemyFromName(String name)
        {
            return Enemies.FirstOrDefault(enemy => enemy.Name() == name);
        }

        public String GetContents()
        {
            var contents = $"{Name}:\n";
            contents += $"Description: {Description}\n";
            contents += "Exits:\n";
            foreach (var exit in Exits)
            {
                contents += $"{exit.Key}: {exit.Value.Name}\n";
            }
            contents += "Items:\n";
            foreach (var item in Items)
            {
                contents += $"{item.Value}x {item.Key.Name}\n";
            }
            contents += "Enemies:\n";
            foreach (var enemy in Enemies)
            {
                contents += $"{enemy.Name()}\n";
            }
            return contents.Trim();
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
