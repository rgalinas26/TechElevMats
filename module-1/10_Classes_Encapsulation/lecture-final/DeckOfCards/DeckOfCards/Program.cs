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

            Deck deck = new Deck();
            List<Card> player1Hand = new List<Card>();
            List<Card> player2Hand = new List<Card>();

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("♠♥♦♣ Welcome to Cards ♠♥♦♣");

            while (true)
            {
                Console.WriteLine("What do you want to do? ");
                Console.WriteLine("1. Create a new deck of cards");
                Console.WriteLine("2. Deal two hands of cards");
                Console.WriteLine("3. Show the players' hands");
                Console.WriteLine("Q. Quit");

                string input = Console.ReadLine();

                if (input == "1")
                {
                    // Create a new deck of cards
                    deck.Reset();
                }
                else if (input == "2")
                {
                    // Deal cards to two players
                    player1Hand = new List<Card>();
                    for (int i = 1; i <= 5; i++)
                    {
                        player1Hand.Add(deck.Deal());
                    }

                    player2Hand = new List<Card>();
                    for (int i = 1; i <= 5; i++)
                    {
                        player2Hand.Add(deck.Deal());
                    }

                }
                else if (input == "3")
                {
                    // Show both hands on the Console
                    Console.WriteLine("Player 1");
                    foreach (Card card in player1Hand)
                    {
                        Console.WriteLine($"\t{card.Name}");
                    }

                    Console.WriteLine("====================");
                    Console.WriteLine("Player 2");
                    foreach (Card card in player2Hand)
                    {
                        Console.WriteLine($"\t{card.Name}");
                    }
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
