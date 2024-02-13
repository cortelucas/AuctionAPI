using Microsoft.EntityFrameworkCore;
using AuctionWebAPI.Contracts;
using AuctionWebAPI.Entities;

namespace AuctionWebAPI.Repositories.DataAccess;

public class AuctionRepository : IAuctionRepository
{
    private readonly AuctionWebAPIDbContext _dbContext;
    public AuctionRepository(AuctionWebAPIDbContext dbContext) => _dbContext = dbContext;

    public Auction? GetCurrent()
    {
        var today = DateTime.UtcNow;
        return _dbContext
            .Auctions
            .Include(auction => auction.Items)
            .FirstOrDefault(auction => today >= auction.Starts);
    }
}
