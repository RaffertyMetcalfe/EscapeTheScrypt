using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscapeTheCrypt.Model.Entities;
using EscapeTheCrypt.Model.Entities.Enemies;
using EscapeTheCrypt.Model.Traps;

namespace EscapeTheCrypt.Model.Map
{
    public static class Rooms
    {
        private static Room CreateRoom(string id, string name, string description, List<Enemy> enemies, List<Trap>? traps = null, bool locked = false)
        {
            Room room = new Room(id, name, description, traps, locked);

            foreach (var enemy in enemies)
            {
                enemy.Location = room;
                room.AddEnemy(enemy);
            }

            return room;
        }

        public static Room baseRoom { get; private set; } = new Room("base", "Base Room", "A room not on the map that houses unspawned entities");
        public static Room Bone => CreateRoom(
            "bone",
            "Bone Chamber",
            "A room stacked high with brittle bones, echoing faint whispers.",
            new List<Enemy> { new Skeleton(baseRoom), new Skeleton(baseRoom), new Skeleton(baseRoom) }
        );
        public static Room TombHall => CreateRoom(
            "tombhall",
            "Tomb Hall",
            "Rows of dusty coffins line the walls, some cracked open.",
            new List<Enemy> { new Zombie(baseRoom), new Zombie(baseRoom) },
            new List<Trap> { new CoffinTrap()}
           );
    }
}
