using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeTheCrypt.Model
{
    public class Item
    {
        public String Name { get; private set; }
        public String Description { get; private set; }
        public bool Consumable { get; protected set; } = false;
        public int Durability { get; protected set; } = 1;

        public Item(String name, String description)
        {
            Name = name;
            Description = description;
        }

        public virtual void Use(object target)
        {
            throw new NotImplementedException("This method should be implemented by subclasses.");
        }
    }
}
