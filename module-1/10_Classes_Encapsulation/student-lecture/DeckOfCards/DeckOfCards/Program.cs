using DeckOfCards.Classes;
using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            // Let's store all of our cards in a list
            // CODE GOES HERE
            List<Card> cards = new List<Card>();
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("♠♥♦♣ Welcome to Cards ♠♥♦♣");
            while (true)
            {
                Console.WriteLine("What do you want to do? ");
                Console.WriteLine("1. Create a new deck of cards");
                Console.WriteLine("2. Deal two hands of cards");
                Console.WriteLine("Q. Quit");

                string input = Console.ReadLine();

                if (input == "1")
                {
                    // Create a new deck of cards
                }
                else if (input == "2")
                {
                    // Deal cards to two players
                }
                else if (input == "Q")
                {
                    break;
                }

                // Wait for user to press enter and clear screen.
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
