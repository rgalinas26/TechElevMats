using System;
using System.Collections.Generic;
using System.Text;

namespace DeckOfCards.Classes
{
    class Deck
    {
        /// <summary>
        /// Internal data structure to hold our cards
        /// </summary>
        private Stack<Card> cards;

        /// <summary>
        /// Constructor creats a 52-card deck.
        /// </summary>
        public Deck()
        {
            // Call the Reset method to give us a new deck
            Reset();
        }

        /// <summary>
        /// Resets the deck to the factory-made 52-card starting point
        /// </summary>
        public void Reset()
        {
            this.cards = new Stack<Card>(52);

            string[] suits = new string[] { "Hearts", "Clubs", "Spades", "Diamonds" };

            foreach (string suit in suits)
            {
                for (int value=1; value <= 13; value++)
                {
                    Card card = new Card(suit, value);
                    cards.Push(card);
                }
            }
        }

        public Card Deal()
        {
            return this.cards.Pop();
        }

    }
}
