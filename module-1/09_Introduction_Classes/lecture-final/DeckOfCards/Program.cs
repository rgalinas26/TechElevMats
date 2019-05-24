using System;
using System.Collections.Generic;
using DeckOfCards.Classes;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            // Let's store all of our cards in a list
            // CODE GOES HERE
            List<Card> cards = new List<Card>();
            while (true)
            {
                Console.WriteLine("What do you want to do? ");
                Console.WriteLine("1. Create a new card.");
                Console.WriteLine("2. Display all of the cards.");
                Console.WriteLine("3. Flip all of the cards.");
                Console.WriteLine("Q. Quit");

                string input = Console.ReadLine();

                if (input == "1")
                {
                    // Get the value for the new card
                    Console.Write("What is the value of the card (1-13): ");
                    int value = int.Parse(Console.ReadLine());

                    // Get the suit for the new card
                    Console.Write("What suit does the card have (H, D, C, S): ");
                    string suit = Console.ReadLine().ToLower();

                    switch (suit)
                    {
                        case "h":
                            suit = "Hearts";
                            break;
                        case "d":
                            suit = "Diamonds";
                            break;
                        case "c":
                            suit = "Clubs";
                            break;
                        case "s":
                            suit = "Spades";
                            break;
                    }


                    // Is the card face up or face down
                    Console.Write("Is the card face up (True/False): ");
                    bool isFaceUp = bool.Parse(Console.ReadLine());

                    // Create the card and add to the list
                    Card card = new Card();
                    card.Suit = suit;
                    card.Value = value;
                    card.IsFaceUp = isFaceUp;

                    cards.Add(card);

                    Console.WriteLine($"{card.Name} was added to the deck. Press Enter to continue.");



                }
                else if (input == "2")
                {
                    Console.WriteLine("Displaying all of the cards.");

                    // Loop through each of the cards
                    foreach (Card card in cards)
                    {
                        Console.WriteLine($"Card {card.Name} is face up? {card.IsFaceUp}");
                    }
                    
                }
                else if (input == "3")
                {
                    Console.WriteLine($"Flipping the cards.");
                    
                    // Loop through each of the cards and flip them
                    
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
