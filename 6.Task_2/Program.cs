using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _6.Task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player(10, 10);
            Renderer renderer = new Renderer();
            renderer.DrawPlayer(player.PositionX, player.PositionY);
        }
    }

    class Player
    {
        public int PositionX { get; private set; }
        public int PositionY { get; private set; }

        public Player(int positionX, int positionY)
        {
            PositionX = positionX;
            PositionY = positionY;
        }
    }

    class Renderer
    {
        public void DrawPlayer(int x, int y, char playerSymbol = 'P')
        {
            Console.SetCursorPosition(x, y);
            Console.Write(playerSymbol);
        }
    }
}
