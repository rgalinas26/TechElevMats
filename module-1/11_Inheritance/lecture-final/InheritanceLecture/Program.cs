using InheritanceLecture.Auctioneering;
using System;

namespace InheritanceLecture
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new general auction
            Console.WriteLine("Starting a general auction");
            Console.WriteLine("-----------------");

            Auction generalAuction = new Auction();

            generalAuction.PlaceBid(new Bid("Josh", 1));
            generalAuction.PlaceBid(new Bid("Fonz", 23));
            generalAuction.PlaceBid(new Bid("Rick Astley", 13));
            //....
            //....
            // This might go on until the auction runs out of time or hits a max # of bids


            // The rules of a buyout auction automatically end when the buyout price is met
            BuyoutAuction buyoutAuction = new BuyoutAuction(100);
            buyoutAuction.PlaceBid(new Bid("Tom", 25));
            buyoutAuction.PlaceBid(new Bid("Jacob", 86));
            buyoutAuction.PlaceBid(new Bid("Bobby", 50));
            buyoutAuction.PlaceBid(new Bid("Adam", 100));
            buyoutAuction.PlaceBid(new Bid("John", 300));

            // Reserve auction - reserve must be met before a bid can be considered a winning bid



            Console.ReadLine();
        }
    }
}
