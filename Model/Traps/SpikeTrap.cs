using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscapeTheCrypt.EffectHelper;
using EscapeTheCrypt.Model.Entities;

namespace EscapeTheCrypt.Model.Traps
{
   public class SpikeTrap : Trap
    {
        public String Name { get; set; } = "Spike Trap";
        public override void activate(Player target)
        {
            target.ApplyEffect(new BleedingEffect("feet"), 12);
            Console.WriteLine($"{target.Name} was caught in a spike trap!");
        }
    }
}
