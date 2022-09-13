using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player playerOne = new Player();
            Player playerTwo = new Player(200,200,200,2);
            playerOne.ShowPlayerInfo();
            Console.WriteLine();
            playerTwo.ShowPlayerInfo();
            Console.ReadKey();
        }
    }

    class Player
    {
        private int Health;
        private int Mana;
        private int Stamina;
        private int Level;

        public Player()
        {
            Health = 100;
            Mana = 40;
            Stamina = 20;
            Level = 1;
        }

        public Player(int healt, int mana, int stamina, int level)
        {
            Health = healt;
            Mana = mana;
            Stamina = stamina;
            Level = level;
        }

        public void ShowPlayerInfo()
        {
            Console.WriteLine("Health = " + Health);
            Console.WriteLine("Mana = " + Mana);
            Console.WriteLine("Stamina = " + Stamina);
            Console.WriteLine("Level = " + Level);
        }
    }
}
