using EscapeTheCrypt.EffectHelper;
using System;

namespace EscapeTheCrypt.Model
{
    public abstract class Entity
    {
        public Room Location { get; set; }
        public Dictionary<String, int> Inventory { get; private set; } = new Dictionary<String, int>();
        public double? Health { get; protected set; }
        public int InventorySize { get; protected set; } = 4;
        public Dictionary<String, int> Resistances { get; private set; } = new Dictionary<String, int>();
        public Dictionary<String, int> Protection { get; protected set; }
        public List<TickDamage> TickDamages { get; set; } = new List<TickDamage>();
        private readonly List<IEffect> activeEffects = new();

        protected Entity(int health)
        {
            Health = health;
            Protection = new Dictionary<String, int>
            {
                { "head", 0 }, { "torso", 0}, {"leftarm", 0}, {"rightarm", 0}, {"leftleg", 0}, {"rightleg", 0}

            };
        }

        public double Damage(double amount, String source, bool isQuery = false, String location = "general", bool ignoresArmour = false)
        {
            int resistance = Resistances.ContainsKey(source) ? Resistances[source] : 0;
            double k = 0.047;
            double damageMultiplier = Math.Exp(-k * resistance);
            double effectiveDamage = amount * damageMultiplier;

            if (!ignoresArmour) 
            { 
                if (location != "general")
                {
                    effectiveDamage *= (double) Protection[location] / 100;
                } else
                {
                    effectiveDamage *= ((double) Protection.Skip(1).Sum(x => x.Value) / 6) / 100;
                }
            }

            if (!isQuery)
            {
                if (!Health.HasValue)
                {
                    return effectiveDamage;
                }

                Health -= effectiveDamage;
                Console.WriteLine($"{GetName()} took {effectiveDamage:F2} damage from {source}.");
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

        public void ApplyEffect(IEffect effect, int duration)
        {
            effect.Apply(this, duration);
            activeEffects.Add(effect);

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