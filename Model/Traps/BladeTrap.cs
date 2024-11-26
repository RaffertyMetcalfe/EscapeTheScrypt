using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscapeTheCrypt.Model.Entities;

namespace EscapeTheCrypt.Model.Traps
{
    public class BladeTrap : Trap
    {
        public String Name { get; private set; } = "Blade Trap";
        public override void activate(Player target)
        {
            target.Damage(10, "slashing");
            Console.WriteLine($"{target.Name} was slashed for 10 damage by a blade trap!");
        }
    }
}
