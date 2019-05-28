using System;
using System.Collections.Generic;
using System.Text;

namespace InheritanceLecture.Auctioneering
{
    public class BuyoutAuction : Auction
    {
        public int BuyoutAmount { get; }

        public BuyoutAuction(int buyoutAmount)
        {
            this.BuyoutAmount = buyoutAmount;
        }

        public override bool PlaceBid(Bid offeredBid)
        {
            // Check to see if aution has ended. Accept no bid if it has.
            if (this.HasEnded)
            {
                Console.WriteLine("This bid was rejected because the Buyout has already been reached");
                return false;
            }

            // Accept the bid using the base class method
            bool IsHighBid = base.PlaceBid(offeredBid);

            if (offeredBid.BidAmount >= this.BuyoutAmount)
            {
                Console.WriteLine($"Buyout amount of {this.BuyoutAmount} has been reached. This ends the auction");
                this.HasEnded = true;
            }
            return IsHighBid;
        }

    }
}
