using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscapeTheCrypt.Model;
using EscapeTheCrypt.Model.Entities;

namespace EscapeTheCrypt.Game
{
    public class Generator
    {
        public static Room Entrance = new("Heart", "The start of your adventure!", []);
        public static Player Player;
        public static List<Room> Map = [Entrance];
        public static void GenerateMap(int size)
        {
            for (int i = 0; i < size; i++)
            {
                return;
            }
        }

        public static void GeneratePlayer(String name)
        {
            Player = new Player(name, Entrance);
        }
    }
}
