using System;
using System.Linq;

namespace EscapeTheCrypt.Game
{
    public class GameEngine
    {
        public void Start()
        {
            Generator.GenerateMap(10);
            Generator.GeneratePlayer("Meatball Head");
        }

        public void Stop()
        {
            return;
        }
    }
}
