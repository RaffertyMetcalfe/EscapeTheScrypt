using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscapeTheCrypt.EffectHelper;
using EscapeTheCrypt.Model.Entities;

namespace EscapeTheCrypt.Model.Traps
{
    public class CoffinTrap : Trap
    {
        public String Name { get; private set; } = "Coffin Trap";
        public override void activate(Player target)
        {
            target.Damage(10, "slashing");
            if(target.Damage(10, "slashing", true) > 0)
            {
                target.ApplyEffect(new DecayEffect(), 2);
            }
        }
    }
}
