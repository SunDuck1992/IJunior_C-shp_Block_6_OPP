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
        private int _health;
        private int _mana;
        private int _stamina;
        private int _level;

        public Player()
        {
            _health = 100;
            _mana = 40;
            _stamina = 20;
            _level = 1;
        }

        public Player(int healt, int mana, int stamina, int level)
        {
            _health = healt;
            _mana = mana;
            _stamina = stamina;
            _level = level;
        }

        public void ShowPlayerInfo()
        {
            Console.WriteLine("Health = " + _health);
            Console.WriteLine("Mana = " + _mana);
            Console.WriteLine("Stamina = " + _stamina);
            Console.WriteLine("Level = " + _level);
        }
    }
}
