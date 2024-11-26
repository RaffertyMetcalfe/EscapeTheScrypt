using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscapeTheCrypt.Model;

namespace EscapeTheCrypt.EffectHelper
{
    public interface IEffect
    {
        void Apply(Entity target, int duration);
    }
}
