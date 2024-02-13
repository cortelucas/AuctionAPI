using AuctionWebAPI.Entities;

namespace AuctionWebAPI.Contracts;

public interface IAuctionRepository
{
    Auction? GetCurrent();
}
