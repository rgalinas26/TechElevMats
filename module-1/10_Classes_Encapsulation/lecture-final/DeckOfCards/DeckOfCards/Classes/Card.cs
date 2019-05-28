using System;
using System.Collections.Generic;
using System.Text;

namespace DeckOfCards.Classes
{
    /// <summary>
    /// A class to represent a playing card
    /// </summary>
    public class Card
    {

        /// <summary>
        /// Creates a card with the given suit and value
        /// </summary>
        /// <param name="suit">Hearts, Diamonds, Clubs, or Spades</param>
        /// <param name="value">1 for Ace, 2-10 for numbers, 11-13 for face cards</param>
        public Card(string suit, int value)
        {
            this.Suit = suit;
            this.Value = value;
        }

        /// <summary>
        /// Creates a card with the given suit and value and an initial face state
        /// </summary>
        /// <param name="suit">Hearts, Diamonds, Clubs, or Spades</param>
        /// <param name="value">1 for Ace, 2-10 for numbers, 11-13 for face cards</param>
        /// <param name="isFaceUp"><see langword="true"/>to show the face of the card, false to be face-down</param>
        public Card(string suit, int value, bool isFaceUp)
        {
            this.Suit = suit;
            this.Value = value;
            this.IsFaceUp = isFaceUp;
        }

        /// <summary>
        /// String representing the suit. Possible values are "Spades", "Hearts", "Diamonds", "Clubs"
        /// </summary>
        public string Suit { get; }

        /// <summary>
        /// The card rank. 1=Ace, 11=Jack, 12=Queen, 13=King
        /// </summary>
        public int Value { get; }

        /// <summary>
        /// Returns the color of the card. Values are "Red" or "Black"
        /// </summary>
        public string Color
        {
            get
            {
                if (this.Suit == "Hearts" || this.Suit == "Diamonds")
                {
                    return "Red";
                }
                else
                {
                    return "Black";
                }
            }
        }

        /// <summary>
        /// Returns true if the card's face is showing
        /// </summary>
        public bool IsFaceUp { get; private set; }

        /// <summary>
        /// Returns true if the card is a J, Q or K
        /// </summary>
        public bool IsFaceCard
        {
            get
            {
                if (this.Value > 10 && this.Value <= 13)
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// The human-readable full name of the card, e.g. "King of Hearts"
        /// </summary>
        public string Name
        {
            get
            {
                string name = Card.rankNames[this.Value];
                name += " of " + this.Suit;
                return name;
            }
        }


        static readonly private Dictionary<int, string> rankNames = new Dictionary<int, string>()
        {
            {1, "Ace" },
            {2, "Two" },
            {3, "Three" },
            {4, "Four" },
            {5, "Five" },
            {6, "Six" },
            {7, "Seven" },
            {8, "Eight" },
            {9, "Nine" },
            {10, "Ten" },
            {11, "Jack" },
            {12, "Queen" },
            {13, "King" },
        };

        /// <summary>
        /// Flips a card over
        /// </summary>
        /// <returns>The new value of IsFaceUp. True if the face is showing.</returns>
        public bool Flip()
        {
            if (this.IsFaceUp)
            {
                this.IsFaceUp = false;
            }
            else
            {
                this.IsFaceUp = true;
            }
            // Another way of doing the above...
            //this.IsFaceUp = !this.IsFaceUp;
            return this.IsFaceUp;
        }


    }
}
