using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscapeTheCrypt.Model;

namespace EscapeTheCrypt.EffectHelper
{ 

    public static class EffectMethods
    {
        public static void Burning(Entity target, int duration)
        {
            for (int i = 0; i < duration; i++)
            {
                target.Damage(5, "burning");
                Console.WriteLine($"{target.GetName()} took 5 damage from burning");
            }
        }

        public static void Defense(Entity target, string source, int amount)
        {
            target.AddResistance(source, amount);
        }

        public static void Decay(Entity target, int duration, int amount)
        {
            for (int i = 0; i < duration; i++)
            {
                target.Damage(amount, "decay");
            }
        }
    }
}
