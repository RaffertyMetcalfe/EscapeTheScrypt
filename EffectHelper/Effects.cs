using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscapeTheCrypt.Model;
using static System.Net.Mime.MediaTypeNames;

namespace EscapeTheCrypt.EffectHelper
{
    public class BurningEffect : IEffect
    {
        public void Apply(Entity target, int duration)
        {
            target.TickDamages.Add(new TickDamage("burning", 6, duration));
        }
    }
    public class DefenseEffect : IEffect
    {
        private readonly string _source;
        private readonly int _amount;

        public DefenseEffect(string source = "general", int amount = 1)
        {
            _source = source;
            _amount = amount;
        }

        public void Apply(Entity target, int duration)
        {
            for (int i = 0; i < duration; i++)
            {
                target.AddResistance(_source, _amount);
            }
        }
    }
    public class DecayEffect : IEffect
    {
        private readonly int _amount;

        public DecayEffect(int amount = 1)
        {
            _amount = amount;
        }

        public void Apply(Entity target, int duration)
        {
            target.TickDamages.Add(new TickDamage("decay", _amount, duration));
        }
    }
    public class PoisonEffect : IEffect
    {
        public void Apply(Entity target, int duration)
        {
            target.TickDamages.Add(new TickDamage("poison", 5, duration));
        }
    }

    public class BleedingEffect : IEffect
    {
        private readonly String _location;

        public BleedingEffect(String location = "body")
        {
            _location = location;
        }

        public void Apply(Entity target, int duration)
        {
            target.TickDamages.Add(new TickDamage("bleeding", duration, duration, _location));
        }
    }
}
