using System;
using System.Collections.Generic;
using System.Linq;
using EscapeTheCrypt.Model;
using EscapeTheCrypt.Model.ItemType;

namespace EscapeTheCrypt.Model.Entities
{
    public class Player : Entity
    {
        public String Name { get; private set; }
        public int Health { get; private set; } = 100;
        public int InventorySize { get; private set; } = 10;
        public Weapon EquippedWeapon { get; private set; }
        private List<Item> Inventory { get; } = new List<Item>();

        public Player(String name, Room startingRoom) : base(startingRoom)
        {
            Name = name;
        }

        public void PickUp(Item item)
        {
            if (Inventory.Count >= InventorySize)
            {
                Console.WriteLine("You can't carry any more items!");
            }
            else
            {
                Inventory.Add(item);
                Console.WriteLine($"You picked up {item.Name}.");
            }
        }

        public void Drop(String itemName)
        {
            var item = FindItemInInventory(itemName);
            if (item != null)
            {
                Inventory.Remove(item);
                Console.WriteLine($"You dropped {item.Name}.");
            }
            else
            {
                Console.WriteLine("You don't have that item.");
            }
        }

        public void UseItem(String itemName, Entity target)
        {
            var item = FindItemInInventory(itemName);
            if (item != null)
            {
                item.Use(target);
                if (item.Durability == 0)
                {
                    Inventory.Remove(item);
                }
            }
            else
            {
                Console.WriteLine("You don't have that item.");
            }
        }

        public void Move(String direction)
        {
            if (Location.Exits.TryGetValue(direction, out var nextRoom))
            {
                if (!nextRoom.Locked)
                {
                    Location = nextRoom;
                    Console.WriteLine($"You move {direction} to {Location.Name}.");
                }
                else
                {
                    Console.WriteLine("That exit is locked. Find a key to unlock it.");
                }
            }
            else
            {
                Console.WriteLine("You can't go that way!");
            }
        }

        public void EquipItem(String itemName)
        {
            var item = FindItemInInventory(itemName) as Weapon;
            if (item != null)
            {
                EquippedWeapon = item;
                Console.WriteLine($"{Name} equips {item.Name}.");
            }
            else
            {
                Console.WriteLine("You don't have that item.");
            }
        }

        public void Attack(Enemy target, Weapon weapon)
        {
            if (Inventory.Contains(weapon))
            {
                Console.WriteLine($"{Name} attacks {target.Name()}.");
                weapon.Use(target);
            }
            else
            {
                Console.WriteLine("This shouldn't be seen. Programmer fucked up. Error: Item not found in inventory.");
            }
        }

        public List<Item> GetInventory()
        {
            return new List<Item>(Inventory);
        }

        private Item FindItemInInventory(String itemName)
        {
            if(Inventory != null) 
            {
                return Inventory.FirstOrDefault(item => item.Name == itemName);
            }
            return null;
        }

        protected override void Kill(object source)
        {
            Console.WriteLine($"{Name} was killed by {source}");
        }

        public override string GetName()
        {
            return Name;
        }
    }
}