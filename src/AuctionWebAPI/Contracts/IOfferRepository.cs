using AuctionWebAPI.Entities;

namespace AuctionWebAPI.Contracts;

public interface IOfferRepository
{
    void Add(Offer offer);
}
