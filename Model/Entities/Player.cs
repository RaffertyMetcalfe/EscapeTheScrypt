using EscapeTheCrypt.Model.ItemType;
using System;
using System.Linq;
using System.Runtime.InteropServices.Swift;

namespace EscapeTheCrypt.Model.Entities
{
    public class Player : Entity
    {
        public Room Location { get; set; }
        public String Name { get; private set; }
        public int Health { get; private set; } = 100;
        public int InventorySize { get; private set; } = 10;
        public Weapon EquippedWeapon { get; private set; } = new Weapon("Fist", "A bare hand", 1, 2147483647, "impact");
        private List<Item> Inventory { get; } = new List<Item>();
        private Dictionary<String, Item> ArmourSlots { get; }

        public Player(String name, Room location, int health = 100) : base(location, health)
        {
            Location = location;
            Name = name;
            ArmourSlots = new Dictionary<String, Item>
            {
                {"head", null }, { "torso", null }, {"leftarm", null}, {"rightarm", null}, {"leftleg",null}
            };
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
            Item item = FindItemInInventory(itemName);
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
            Item item = FindItemInInventory(itemName);
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
            Item item = FindItemInInventory(itemName);
            if (item != null)
            {
                Console.WriteLine($"{Name} equips {item.Name}.");
                if (item.GetType() == typeof(Weapon))
                { 
                    EquippedWeapon = (Weapon) item;
                } else if (item.GetType() == typeof(ArmourPiece))
                {
                    ArmourPiece Piece = (ArmourPiece) item;
                    this.Protection[Piece.BodyPart] = Piece.Protection;
                }
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
            if (Inventory.Any())
            {
                return Inventory.Find(item => item.Name == itemName);
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