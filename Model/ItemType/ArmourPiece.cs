using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeTheCrypt.Model.ItemType
{
    public class ArmourPiece : Item
    {
        public int Protection {  get; private set; }
        public String BodyPart {  get; private set; }

        public ArmourPiece(String name, String description, int protection, int durability, String bodypart)
            : base(name, description)
        {
            Protection = protection;
            BodyPart = bodypart;
        }

        public override void Use(object target)
        {
            Console.WriteLine("This item can't be used");
        }
    }
}
