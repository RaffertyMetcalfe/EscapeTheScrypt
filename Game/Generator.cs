using EscapeTheCrypt.Model;
using EscapeTheCrypt.Model.Entities;
using EscapeTheCrypt.Model.Entities.Enemies;
using System;
using System.Linq;

namespace EscapeTheCrypt.Game
{
    public static class Generator
    {
        public static readonly Room Entrance = new("Heart of the Crypt", "The start of your adventure!", []);
        public static Player Player;
        public static List<Room> Map { get; set; } = [Entrance];
        public static void GenerateMap(int size)
        {
            for (int i = 0; i < size; i++)
            {
                Map.Add(new Room($"{new Random().Next(0, 1000)}", "", [new Zombie(20), new Skeleton(15)]));
            }
        }

        public static void GeneratePlayer(String name)
        {
            Player = new Player(name, 100, Entrance);
        }
    }
}
