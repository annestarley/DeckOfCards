using System;

namespace DeckOfCards2
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck1 = new Deck();
            deck1.Shuffle();
            Deck deck2 = new Deck();
            // for (int i = 0; i < 52; i++)
            // {
            //     Console.Write("{0,-19}", deck2.DealCard());
            //     if ((i + 1) % 4 == 0) Console.WriteLine();
            // }
            // Console.ReadLine();
            deck2.Shuffle();

            // Console.WriteLine("\n\nShuffled!");
            // for (int i = 0; i < 52; i++)
            // {
            //     Console.Write("{0,-19}", deck2.DealCard());
            //     if ((i + 1) % 4 == 0) Console.WriteLine();
            // }
        }
    }

    class Card 
    {
        private string face;
        private string suit;

        public Card(string cardFace, string cardSuit)
        {
            face = cardFace;
            suit = cardSuit;
        }

        public override string ToString()
        {
            return face + " of " + suit;
        }
    }

    class Deck 
    {
        private Card[] deck;
        private int currentCard;
        private const int NUMBER_OF_CARDS = 52;
        private Random ranNum;

        public Deck()
        {
            string[] faces = {"Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
            string[] suits = {"Hearts", "Spades", "Diamonds", "Clubs"};
            deck = new Card[NUMBER_OF_CARDS];
            ranNum = new Random();
            for (int count = 0; count < deck.Length; count++)
            {
                deck[count] = new Card(faces[count % 13], suits[count / 13]);
            }
        }

        public void Shuffle()
        {
            currentCard = 0;
            for (int first = 0; first < deck.Length; first++)
            {
                int second = ranNum.Next(NUMBER_OF_CARDS);
                Card temp = deck[first];
                deck[first] = deck[second];
                deck[second] = temp;
            }
        }

        public Card DealCard()
        {
            
            if (currentCard < deck.Length) 
            {
                Console.WriteLine(deck[currentCard++]);
                return deck[currentCard++];
            }
            else return null;
        }

    }

    class Player 
    {
        private string name;
        private Card[] hand;

        public Card Draw(Deck deck)
        {
            Card newCard = deck.DealCard();
            hand[hand.Length] = newCard;
            return newCard;
        }

        public Card Discard(int index)
        {
            if (index >= hand.Length) return null;
            else 
            {
                Card discarded = hand[index];
               for (var i = index; i < hand.Length - 1; i++)
                {
                    hand[i] = hand[i+1];
                }
                Array.Resize(ref hand, hand.Length - 1);
                return discarded; 
            }
        }

    }
}
