using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
