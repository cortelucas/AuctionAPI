using AuctionWebAPI.Contracts;
using AuctionWebAPI.Entities;

namespace AuctionWebAPI.Repositories.DataAccess;

public class OfferRepository: IOfferRepository
{
    private readonly AuctionWebAPIDbContext _dbContext;
    public OfferRepository(AuctionWebAPIDbContext dbContext) => _dbContext = dbContext;
    
    public void Add(Offer offer)
    {
        _dbContext.Offers.Add(offer);
        _dbContext.SaveChanges();
    }
}
