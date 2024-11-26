namespace EscapeTheCrypt.Model.ItemType
{
    public class Key : Item
    {
        public Room Room { get; private set; }

        public Key(String name, String description, Room room)
            : base(name, description)
        {
            Room = room;
        }

        public override void Use(object target)
        {
            if (target is Room room && room.Unlock(this))
            {
                Durability--;
            }
            else
            {
                Console.WriteLine("That key doesn't unlock this room. Try to find one that does!");
            }
        }
    }
}
