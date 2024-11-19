using System;
using System.Collections.Generic;
using EscapeTheCrypt.Model;
using EscapeTheCrypt.EffectHelper;

namespace EscapeTheCrypt.Model
{
    public abstract class Entity
    {
        public Room Location { get; protected set; }
        public Dictionary<String, int> Inventory { get; private set; } = new Dictionary<String, int>();
        public double? Health { get; protected set; }
        public int InventorySize { get; protected set; } = 4;
        public Dictionary<String, int> Resistances { get; private set; } = new Dictionary<String, int>();

        protected Entity(Room startingRoom)
        {
            Location = startingRoom;
        }

        public double Damage(double amount, String source, bool isQuery = false)
        {
            int resistance = Resistances.ContainsKey(source) ? Resistances[source] : 0;
            double k = 0.047;
            double damageMultiplier = Math.Exp(-k * resistance);
            double effectiveDamage = amount * damageMultiplier;

            if (!isQuery)
            {
                if (Health.HasValue)
                {
                    Health -= effectiveDamage;
                    Console.WriteLine($"{GetName()} took {effectiveDamage:F2} damage from {source}.");
                }
            }

            return effectiveDamage;
        }

        public void AddResistance(String type, int amount)
        {
            if (Resistances.ContainsKey(type))
            {
                Resistances[type] = Math.Min(50, Resistances[type] + amount);
            }
            else
            {
                Resistances[type] = Math.Min(50, amount);
            }
        }

        public void ApplyEffect(Effect effect, int duration)
        {
            effect.Apply(this);
        }

        public void AddItem(Item item, int amount)
        {
            if (Inventory.Count < InventorySize)
            {
                Inventory[item.Name] = amount;
                Console.WriteLine($"{GetName()} picked up {item.Name} x {amount}.");
            }
            else
            {
                Console.WriteLine($"{GetName()} can't carry any more items.");
            }
        }

        protected abstract void Kill(object source);

        public virtual String GetName()
        {
            return "Entity";
        }
    }
}