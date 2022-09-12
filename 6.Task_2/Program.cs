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
            Player player = new Player(20, 20);
            Renderer render = new Renderer();
            render.DrawPlayer(player.X, player.Y);
        }
    }

    class Player
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Player(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    class Renderer
    {
        public void DrawPlayer(int x, int y, char player = 'P')
        {
            Console.SetCursorPosition(x, y);
            Console.Write(player);
        }
    }
}
