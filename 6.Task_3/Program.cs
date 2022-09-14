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
            ListCharacters listCharacters = new ListCharacters();

            while (true)
            {
                Console.WriteLine("1 - Add Character;");
                Console.WriteLine("2 - Unlock Character;");
                Console.WriteLine("3 - Delete Character;");
                Console.WriteLine("4 - Show Character List;");
                int command = Convert.ToInt32(Console.ReadLine());

                switch (command)
                {
                    case 1:
                        ListCharacters.AddCharacter();
                        break;
                    case 2:
                        ListCharacters.UnlockCharacter();
                        break;
                    case 3:
                        ListCharacters.DeleteCharacter();
                        break;
                    case 4:
                        ListCharacters.ShowCharacterList();
                        break;
                    case 5:
                        ListCharacters.ShowCharacterList();
                        break;
                }
            }
        }
    }

    class ListCharacters
    {
        static List<Character> listCharacters = new List<Character>();

        public static void AddCharacter()
        {
            Console.WriteLine("Input NickName you Character:");
            string nickname = Console.ReadLine();
            Console.WriteLine("Input level you Character:");
            int level = Convert.ToInt32(Console.ReadLine());
            Character character = new Character(nickname, level);
            listCharacters.Add(character);
        }

        public static void UnlockCharacter()
        {
            Console.WriteLine("Input ID Characters for unlock:");
            int idCharacterInput = Convert.ToInt32(Console.ReadLine());
            int idCharacterListCharacter = (listCharacters[idCharacterInput-1].IdCharacter);

            if (idCharacterInput == idCharacterListCharacter && listCharacters[idCharacterListCharacter - 1]._isUnlocked == false)
            {
                listCharacters[idCharacterListCharacter-1]._isUnlocked = true;
            }
            else Console.WriteLine("Error, character already UNLOCKed");
        }

        public static void LockCharacter()
        {
            Console.WriteLine("Input ID Characters for unlock:");
            int idCharacterInput = Convert.ToInt32(Console.ReadLine());
            int idCharacterListCharacter = (listCharacters[idCharacterInput - 1].IdCharacter);

            if (idCharacterInput == idCharacterListCharacter && listCharacters[idCharacterListCharacter - 1]._isUnlocked == true)
            {
                listCharacters[idCharacterListCharacter - 1]._isUnlocked = false;
            }
            else Console.WriteLine("Error, character already LOCKed");
        }
        
        public static void DeleteCharacter()
        {
            Console.WriteLine("Input ID Characters for delete:");
            int idCharacterInput = Convert.ToInt32(Console.ReadLine());
            int idCharacterListCharacter = (listCharacters[idCharacterInput - 1].IdCharacter);

            if (idCharacterInput == idCharacterListCharacter)
            {
                listCharacters.RemoveAt(idCharacterListCharacter-1);
            }
            else Console.WriteLine("Error, can't find this character!");
        }

        public static void ShowCharacterList()
        {
            for (int i = 0; i < listCharacters.Count; i++)
            {
                listCharacters[i].ShowCharacterInfo();
            }
        }
    }

    class Character
    {
        private static int _idCharacterCount = 0;
        public int IdCharacter { get; private set; }
        private string _nickname;
        private int _levelCharacter;
        public bool _isUnlocked;

        public Character(string name, int levelCharacter)
        {
            _idCharacterCount += 1;
            _nickname = name;
            _levelCharacter = levelCharacter;
            _isUnlocked = false;
            IdCharacter = _idCharacterCount;
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
    }
}
