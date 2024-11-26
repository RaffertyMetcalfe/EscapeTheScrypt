using EscapeTheCrypt.Model.Entities;
using System;
using System.Linq;

namespace EscapeTheCrypt.Model
{
    public class Trap
    {
        public virtual void activate(Player target)
        {
            throw new NotImplementedException("This method should be implemented by subclasses");
        }
    }
}
