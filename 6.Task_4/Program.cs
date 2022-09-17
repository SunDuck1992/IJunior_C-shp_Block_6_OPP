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
            Deck deck = new Deck();

            while (isWorked)
            {
                Console.WriteLine("Press ENTER to give next card form desk");
                Console.ReadLine();

                if (deck.IsEmpty())
                {
                    Console.WriteLine("Deck is finish. You have full deck in you hands");
                    isWorked = false;
                }
                else
                {
                    Console.WriteLine("Push card from deck");
                    Card playingCard = deck.GiveCard();
                    player.TakeCard(playingCard);
                }

                Console.WriteLine("Card in you hands");
                player.ShowDeck();
            }
        }
    }

    class Card
    {
        public string Suit { get; private set; }
        public string Value { get; private set; }

        public Card(string suit, string points)
        {
            Suit = suit;
            Value = points;
        }
    }

    class Deck
    {
        private Stack<Card> _cardDeck = new Stack<Card>();

        public Deck()
        {
            Create();
        }

        public bool IsEmpty()
        {
            return _cardDeck.Count == 0;
        }

        public Card GiveCard()
        {
            return _cardDeck.Pop();
        }

        private void Create()
        {
            string[] suits = { "Clubs", "Diamonds", "Hearts", "Spades" };
            string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

            List<Card> allCards = new List<Card>();

            for (int i = 0; i < suits.Length; i++)
            {
                for (int j = 0; j < ranks.Length; j++)
                {
                    allCards.Add(new Card(suits[i], ranks[j]));
                }
            }

            Console.WriteLine("Shuffle deck");
            Shuffle(allCards);
            AddCard(allCards);
        }

        private void AddCard(List<Card> allCards)
        {
            foreach (var card in allCards)
            {
                _cardDeck.Push(card);
            }
        }

        private void Shuffle(List<Card> allCards)
        {
            Random random = new Random();
            int count = allCards.Count;

            for (int i = 0; i < count; i++)
            {
                Card tempCard = allCards[i];
                allCards.RemoveAt(i);
                allCards.Insert(random.Next(0, count), tempCard);
            }
        }
    }

    class Player
    {
        private List<Card> _playerCardDeck = new List<Card>();

        public void TakeCard(Card card)
        {
            _playerCardDeck.Add(card);
        }

        public void ShowDeck()
        {
            foreach (var card in _playerCardDeck)
            {
                Console.WriteLine(card.Suit + " " + card.Value);
            }
        }
    }
}
