using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeTheCrypt.EffectHelper
{
    public struct TickDamage
    {
        public String Source { get; }
        public int Damage { get; }
        public int TurnsRemaining { get; private set; }
        public String Location { get; private set; }

        public TickDamage(String source, int damage, int turnsRemaining, String location = "general")
        {
            Source = source;
            Damage = damage;
            TurnsRemaining = turnsRemaining;
            Location = location;
        }

        public TickDamage DecrementTurns()
        {
            return new TickDamage(Source, Damage, TurnsRemaining - 1);
        }
    }
}
