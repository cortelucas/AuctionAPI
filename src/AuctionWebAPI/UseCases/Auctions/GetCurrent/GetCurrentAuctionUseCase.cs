using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AuctionWebAPI.Entities;
using AuctionWebAPI.Repositories;

namespace AuctionWebAPI.UseCases.Auctions.GetCurrent
{
    public class GetCurrentAuctionUseCase
    {
        public Auction? Execute()
        {
            var repository = new AuctionWebAPIDbContext();
            var today = DateTime.UtcNow;
            
            return repository
                .Auctions
                .Include(auction => auction.Items)
                .FirstOrDefault(auction => today >= auction.Starts && today <= auction.Ends);
        }
    }
}