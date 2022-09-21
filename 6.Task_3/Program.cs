using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homeWork6_3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            const string CommandAddCharacter = "1";
            const string CommandShowCharacters = "2";
            const string CommandDeleteCharacter = "3";
            const string CommandLockCharacter = "4";
            const string CommandUnLockCharacter = "5";
            const string CommandExit = "6";
            bool isWork = true;
            Database database = new Database();
            Console.SetCursorPosition(40, 0);
            Console.WriteLine("Меню базы данных:");
            Console.WriteLine("Добавить игрока - " + CommandAddCharacter);
            Console.WriteLine("Показать всех текущих игроков - " + CommandShowCharacters);
            Console.WriteLine("Удалить игрока по его номеру - " + CommandDeleteCharacter);
            Console.WriteLine("Заблокировать игрока - " + CommandLockCharacter);
            Console.WriteLine("Разблокировать игрока - " + CommandUnLockCharacter);
            Console.WriteLine("Завершение работы с базой - " + CommandExit);

            while (isWork)
            {              
                string message = Console.ReadLine();
                              
                switch (message)
                {
                    case CommandAddCharacter:
                        database.AddPlayer();
                        break;

                    case CommandShowCharacters:
                        database.ShowPlayersList();
                        break;

                    case CommandDeleteCharacter:
                        database.DeletePlayer();
                        break;

                    case CommandLockCharacter:
                        database.BanPlayer();
                        break;

                    case CommandUnLockCharacter:
                        database.UnBanPlayer();
                        break;

                    case CommandExit:
                        isWork = false;
                        break;
                }               
            }
        }
    }

    class Database
    {
        private List<Player> _players = new List<Player>();
        public void AddPlayer()
        {
            Console.WriteLine("Введите никнейм игрока:");
            string inputName = Console.ReadLine();
            Console.WriteLine("Введите уровень игрока:");
            int inputLevel = Convert.ToInt32(Console.ReadLine());
            Player player = new Player(inputName, inputLevel);
            _players.Add(player);
        }

        public void ShowPlayersList()
        {
            for (int i = 0; i < _players.Count; i++)
            {
                _players[i].ShowPlayerInfo();
                Console.WriteLine();
                Console.WriteLine();                
            }
        }

        public void DeletePlayer()
        {
            Console.WriteLine("Введите порядковый номер игрока, которого хотите удалить:");
            int userInput = UserUnilities.ReadInt();

            for (int  i = 0;  i < _players.Count;  i++)
            {
                if (userInput == _players[i].Id)
                {
                    _players.RemoveAt(i);
                    Console.WriteLine("Игрок удален!");
                }

                else
                {
                    Console.WriteLine("Игрока с таким номером нет в базе!");
                }
            }         
        }

        public void BanPlayer()
        {
            Console.WriteLine("Введите номер игрока, которого хотите забанить:");
            int inputUserId = UserUnilities.ReadInt();

            for (int i = 0; i < _players.Count; i++)
            {
                if (inputUserId == _players[i].Id)
                {
                    _players[i].Banned();
                    Console.WriteLine("Бан в студию!");
                }

                else
                {
                    Console.WriteLine("Игрока с таким номером нет в базе!");
                }
            }
        }

        public void UnBanPlayer()
        {
            Console.WriteLine("Введите номер игрока, с которого нужно снять бан:");
            int inputUserId = UserUnilities.ReadInt();

            for (int i = 0; i < _players.Count; i++)
            {
                if (inputUserId == _players[i].Id)
                {
                    _players[i].UnBanned();
                    Console.WriteLine("Бан снят!");
                }

                else
                {
                    Console.WriteLine("Игрока с таким номером нет в базе!");
                }
            }
        }
    }

    class Player
    {
        static private int _id = 0;
        private string _name;
        private int _level;
        public int Id { get; private set; }
        public bool IsBan { get; private set; }

        public Player(string name, int level)
        {
            _id++;
            _name = name;
            _level = level;
            Id = _id;
            IsBan = false;
        }

        public void ShowPlayerInfo()
        {
            Console.Write("Порядковый номер игрока - " + Id + "|| Никнейм игрока - " + _name + "|| Уровень игрока - " + _level);

            if (IsBan == false)
            {
                Console.Write(" - Бана нет");
            }

            if (IsBan == true)
            {
                Console.Write(" - Игрок заблокирован!");
            }
        }

        public void Banned()
        {
            IsBan = true;
        }

        public void UnBanned()
        {
            IsBan = false;
        }
    }
    static class UserUnilities
    {
        public static int ReadInt()
        {
            int resalt = 0;
            bool isWork = true;

            while (isWork)
            {
                string userInput = Console.ReadLine();
                bool success = int.TryParse(userInput, out int inputResalt);

                if (inputResalt >= 0 && success == true)
                {
                    resalt = inputResalt;
                    isWork = false;
                }

                else
                {
                    Console.WriteLine("Ошибка ввода. Введите число!");
                }
            }
            return resalt;
        }
    }
}
