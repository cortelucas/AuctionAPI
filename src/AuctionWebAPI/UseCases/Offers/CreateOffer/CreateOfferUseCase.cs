using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AuctionWebAPI.Communication.Requests;
using AuctionWebAPI.Entities;
using AuctionWebAPI.Repositories;
using AuctionWebAPI.Services;

namespace AuctionWebAPI.UseCases.Offers.CreateOffer
{
    public class CreateOfferUseCase
    {
        private readonly LoggedUser _loggedUser;
        public CreateOfferUseCase(LoggedUser loggedUser) => _loggedUser = loggedUser;

        public int Execute(int itemId, RequestCreateOfferJSON request)
        {
            var repository = new AuctionWebAPIDbContext();
            var user = _loggedUser.User();            
            var offer = new Offer
            {
                CreatedOn = DateTime.UtcNow,
                ItemId = itemId,
                Price = request.Price,
                UserId = user.Id
            };

            repository.Offers.Add(offer);
            repository.SaveChanges();

            return offer.Id;
        }
    }
}