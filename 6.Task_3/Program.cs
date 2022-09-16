using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _6.Task_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandAddCharacter = "1";
            const string CommandUnlockCharacter = "2";
            const string CommandLockCharacter = "3";
            const string CommandDeleteCharacter = "4";
            const string CommandShowCharacterList = "5";
            const string CommandExit = "6";
            bool isWork = true;

            Database database = new Database();

            while (isWork)
            {
                Console.WriteLine(CommandAddCharacter + ". - Add charater");
                Console.WriteLine(CommandUnlockCharacter + ". - Unlock charater");
                Console.WriteLine(CommandLockCharacter + ". - Lock charater");
                Console.WriteLine(CommandDeleteCharacter + ". - Delete charater");
                Console.WriteLine(CommandShowCharacterList + ". - Show charater list");
                Console.WriteLine(CommandExit + ". - EXIT");
                string command = Console.ReadLine();

                switch (command)
                {
                    case CommandAddCharacter:
                        database.AddCharacter();
                        break;
                    case CommandUnlockCharacter:
                        database.UnlockCharacter();
                        break;
                    case CommandLockCharacter:
                        database.LockCharacter();
                        break;
                    case CommandDeleteCharacter:
                        database.DeleteCharacter();
                        break;
                    case CommandShowCharacterList:
                        database.ShowCharacterList();
                        break;
                    case CommandExit:
                        isWork = false;
                        break;
                }
            }
        }
    }

    static class UserUtils
    {
        static public int TryGetNumber()
        {
            int resault = 0;
            bool isWork = true;

            while (isWork)
            {
                string userInput = Console.ReadLine();
                bool success = int.TryParse(userInput, out int resaultParse);

                if (resaultParse >= 0 && success == true)
                {
                    resault = resaultParse;
                    isWork = false;
                }
                else
                {
                    Console.WriteLine("Input error. Please, input number:");
                }
            }

            return resault;
        }
    }

    class Database
    {
        private List<Character> _characters = new List<Character>();

        public void AddCharacter()
        {
            Console.WriteLine("Input NickName you Character:");
            string nickname = Console.ReadLine();
            Console.WriteLine("Input level you Character:");
            int level = UserUtils.TryGetNumber();
            Character character = new Character(nickname, level);
            _characters.Add(character);
        }

        public void UnlockCharacter()
        {
            Console.WriteLine("Input ID Characters for unlock:");
            int idCharacterInput = Convert.ToInt32(Console.ReadLine());
            TryGetPlayerAcess(idCharacterInput);
        }

        public void LockCharacter()
        {
            Console.WriteLine("Input ID Characters for lock:");
            int idCharacterInput = Convert.ToInt32(Console.ReadLine());
            TryGetPlayerAcess(idCharacterInput);
        }

        public void DeleteCharacter()
        {
            Console.WriteLine("Input ID Characters for delete:");
            int idCharacterInput = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < _characters.Count; i++)
            {
                if (_characters[i].IdCharacter == idCharacterInput)
                {
                    _characters.RemoveAt(i);
                }
            }
        }

        public void ShowCharacterList()
        {
            for (int i = 0; i < _characters.Count; i++)
            {
                _characters[i].ShowCharacterInfo();
            }
        }

        private void TryGetPlayerAcess(int idCharacterInput)
        {
            for (int i = 0; i < _characters.Count; i++)
            {
                if (idCharacterInput == _characters[i].IdCharacter && _characters[i].IsUnlocked == false)
                {
                    _characters[i].LockCharacter();
                }
                else if (idCharacterInput == _characters[i].IdCharacter && _characters[i].IsUnlocked == true)
                {
                    _characters[i].UnlockCharacter();
                }
            }
        }
    }

    class Character
    {
        private static int _idCount = 0;
        private string _nickname;
        private int _levelCharacter;

        public int IdCharacter { get; private set; }

        public bool IsUnlocked { get; private set; }

        public Character(string name, int levelCharacter)
        {
            _idCount += 1;
            _nickname = name;
            _levelCharacter = levelCharacter;
            IdCharacter = _idCount;
            IsUnlocked = false;
        }

        public void ShowCharacterInfo()
        {
            Console.Write(IdCharacter + ". " + _nickname + " level " + _levelCharacter);

            if (IsUnlocked == false)
            {
                Console.WriteLine(" LOCKED");
            }
            else if (IsUnlocked == true)
            {
                Console.WriteLine(" UNLOCKED");
            }
        }

        public void LockCharacter()
        {
            IsUnlocked = true;
        }

        public void UnlockCharacter()
        {
            IsUnlocked = false;
        }
    }
}
