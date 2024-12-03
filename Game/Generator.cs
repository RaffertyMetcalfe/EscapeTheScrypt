using EscapeTheCrypt.Model;
using EscapeTheCrypt.Model.Entities;
using EscapeTheCrypt.Model.Entities.Enemies;
using System;
using System.Linq;

namespace EscapeTheCrypt.Game
{
    public static class Generator
    {
        public static List<String> IDs { get; set; } = new();
        public static readonly Room Entrance = new("heart", "Heart of the Crypt", "The start of your adventure!", []);
        public static Player Player;
        public static List<Room> Map { get; set; } = [Entrance];
        public static void GenerateMap(int size)
        {
            return;
        }

        public static void GeneratePlayer(String name)
        {
            Player = new Player(name, Entrance);
        }
    }
}
