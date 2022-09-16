using _6.Task_4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _6.Task_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isWorked = true;
            Player player = new Player();
            DeckCards deck = new DeckCards();
            
            while (isWorked)
            {
                Console.WriteLine("Press ENTER to give next card form desk");
                Console.ReadLine();
                
                if (deck.IsEmpty())
                {
                    Console.WriteLine("Deck is finish. You have full deck in you hands");
                    player.ShowPlayerDeck();                   
                    isWorked = false;
                }
                else
                {
                    Console.WriteLine("Push card from deck");
                    PlayingCard playingCard = deck.GiveCard();
                    player.TakeCard(playingCard);
                }

                Console.WriteLine("Card in you hands");
                player.ShowPlayerDeck();               
            }
        }        
    }

    class PlayingCard
    {
        public string Suit { get; private set; }
        public string Value { get; private set; }

        public PlayingCard(string suit, string points)
        {
            Suit = suit;
            Value = points;
        }
    }

    class DeckCards
    {              
        private Stack<PlayingCard> _cardDeck = new Stack<PlayingCard>();

        public DeckCards()
        {
            CreateShuffleDeck();
        }

        public bool IsEmpty ()
        {
            if (_cardDeck.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public PlayingCard GiveCard()
        {
            return _cardDeck.Pop();
        }
        
        private void CreateShuffleDeck()
        {
            string[] suits = { "Clubs", "Diamonds", "Hearts", "Spades" };
            string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

            List<PlayingCard> allCards = new List<PlayingCard>();

            for (int i = 0; i < suits.Length; i++)
            {
                for (int j = 0; j < ranks.Length; j++)
                {
                    allCards.Add(new PlayingCard(suits[i], ranks[j]));
                }
            }

            Console.WriteLine("Shuffle deck");
            Shuffle(allCards);
            AddCard(allCards);
        }

        private void AddCard(List<PlayingCard> allCards)
        {
            foreach (var card in allCards)
            {
                _cardDeck.Push(card);
            }
        }

        private void Shuffle(List<PlayingCard> allCards)
        {
            Random random = new Random();
            int count = allCards.Count;

            for (int i = 0; i < count; i++)
            {
                PlayingCard tempCard = allCards[i];
                allCards.RemoveAt(i);
                allCards.Insert(random.Next(0, count), tempCard);
            }
        }

        
    }

    class Player
    {
        private List<PlayingCard> _playerCardDeck = new List<PlayingCard>();       

        public void TakeCard(PlayingCard card)
        {
            _playerCardDeck.Add(card);
        }
        
        public void ShowPlayerDeck()
        {
            foreach (var card in _playerCardDeck)
            {
                Console.WriteLine(card.Suit + " " + card.Value);
            }
        }
    }
}



