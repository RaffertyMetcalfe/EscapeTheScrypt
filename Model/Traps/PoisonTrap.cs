using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscapeTheCrypt.Model;
using EscapeTheCrypt.Model.Entities;
using EscapeTheCrypt.EffectHelper;

namespace EscapeTheCrypt.Model.Traps
{
    public class PoisonTrap : Trap
    {
        public String Name { get; set; } = "Poison Trap";
        public override void activate(Player target)
        {
            target.ApplyEffect(new PoisonEffect(), 12);
            Console.WriteLine($"{target.Name} was caught in a poison trap!");
        }
    }
}
