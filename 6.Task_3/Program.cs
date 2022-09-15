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
            bool isWork = true;
            DataBase listCharacters = new DataBase();

            while (isWork)
            {
                Console.WriteLine("1 - Add Character;");
                Console.WriteLine("2 - Unlock Character;");
                Console.WriteLine("3 - Lock Character;");
                Console.WriteLine("4 - Delete Character;");
                Console.WriteLine("5 - Show Character List;");
                Console.WriteLine("6 - EXIT;");
                int command = Convert.ToInt32(Console.ReadLine());

                switch (command)
                {
                    case 1:
                        listCharacters.AddCharacter();
                        break;
                    case 2:
                        listCharacters.UnlockCharacter();
                        break;
                    case 3:
                        listCharacters.LockCharacter();
                        break;
                    case 4:
                        listCharacters.DeleteCharacter();
                        break;
                    case 5:
                        listCharacters.ShowCharacterList();
                        break;
                    case 6:
                        isWork = false;
                        break;
                }
            }
        }
    }

    class DataBase
    {
        private List<Character> characters = new List<Character>();

        public void AddCharacter()
        {
            Console.WriteLine("Input NickName you Character:");
            string nickname = Console.ReadLine();
            Console.WriteLine("Input level you Character:");
            int level = Convert.ToInt32(Console.ReadLine());
            Character character = new Character(nickname, level);
            characters.Add(character);
        }

        public void UnlockCharacter()
        {
            Console.WriteLine("Input ID Characters for unlock:");
            int idCharacterInput = Convert.ToInt32(Console.ReadLine());
            int idCharacterListCharacter = (characters[idCharacterInput - 1].IdCharacter);

            if (idCharacterInput == idCharacterListCharacter && characters[idCharacterListCharacter - 1].IsUnlocked == false)
            {
                bool isLock = true;
                characters[idCharacterInput - 1].ChangeAccessCharacter(isLock);
            }
            else Console.WriteLine("Error, character already UNLOCKed");
        }

        public void LockCharacter()
        {
            Console.WriteLine("Input ID Characters for unlock:");
            int idCharacterInput = Convert.ToInt32(Console.ReadLine());
            int idCharacterListCharacter = (characters[idCharacterInput - 1].IdCharacter);

            if (idCharacterInput == idCharacterListCharacter && characters[idCharacterListCharacter - 1].IsUnlocked == true)
            {
                bool isLock = false;
                characters[idCharacterInput - 1].ChangeAccessCharacter(isLock);

            }
            else Console.WriteLine("Error, character already LOCKed");
        }

        public void DeleteCharacter()
        {
            Console.WriteLine("Input ID Characters for delete:");
            int idCharacterInput = Convert.ToInt32(Console.ReadLine());
            int idCharacterListCharacter = (characters[idCharacterInput - 1].IdCharacter);

            if (idCharacterInput == idCharacterListCharacter)
            {
                characters.RemoveAt(idCharacterListCharacter - 1);
            }
            else Console.WriteLine("Error, can't find this character!");
        }

        public void ShowCharacterList()
        {
            for (int i = 0; i < characters.Count; i++)
            {
                characters[i].ShowCharacterInfo();
            }
        }
    }

    class Character
    {
        private static int _idCharacterCount = 0;
        private string _nickname;
        private int _levelCharacter;
        private bool _isUnlocked;

        public int IdCharacter { get; private set; }

        public bool IsUnlocked { get; private set; }

        public Character(string name, int levelCharacter)
        {
            _idCharacterCount += 1;
            _nickname = name;
            _levelCharacter = levelCharacter;
            _isUnlocked = false;
            IdCharacter = _idCharacterCount;
            IsUnlocked = _isUnlocked;
        }

        public void ShowCharacterInfo()
        {
            Console.Write(IdCharacter + ". " + _nickname + " level " + _levelCharacter);

            if (_isUnlocked == false)
            {
                Console.WriteLine(" LOCKED");
            }
            else if (_isUnlocked == true)
            {
                Console.WriteLine(" UNLOCKED");
            }
        }

        public void ChangeAccessCharacter(bool isLock)
        {
            if (isLock == true)
            {
                _isUnlocked = true;
            }
            else if (isLock == false)
            {
                _isUnlocked = false;
            }
        }
    }
}
