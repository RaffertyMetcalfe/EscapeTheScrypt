using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscapeTheCrypt.Model;

namespace EscapeTheCrypt.EffectHelper
{
    public class Effect
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        private Action<Entity> EffectFunction { get; set; }

        public Effect(string name, string description, Action<Entity> effectFunction)
        {
            Name = name;
            Description = description;
            EffectFunction = effectFunction;
        }

        public void Apply(Entity target)
        {
            EffectFunction?.Invoke(target);
        }
    }

}
