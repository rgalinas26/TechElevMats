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
        /// String representing the suit. Possible values are "Spades", "Hearts", "Diamonds", "Clubs"
        /// </summary>
        public string Suit { get; set; }

        /// <summary>
        /// The card rank. 1=Ace, 11=Jack, 12=Queen, 13=King
        /// </summary>
        public int Value { get; set; }

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
        public bool IsFaceUp { get; set; }

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
                string name = "";
                if (this.Value == 1)
                {
                    name += "Ace";
                }
                else if (this.Value == 11)
                {
                    name += "Jack";
                }
                else if (this.Value == 12)
                {
                    name += "Queen";
                }
                else if (this.Value == 13)
                {
                    name += "King";
                }
                else
                {
                    name += this.Value;
                }

                name += " of " + this.Suit;
                return name;
            }
        }
        
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
