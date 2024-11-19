using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscapeTheCrypt.Model.Entities;

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
