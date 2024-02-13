using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AuctionWebAPI.Communication.Requests;
using AuctionWebAPI.Contracts;
using AuctionWebAPI.Entities;
using AuctionWebAPI.Services;

namespace AuctionWebAPI.UseCases.Offers.CreateOffer
{
    public class CreateOfferUseCase
    {
        private readonly LoggedUser _loggedUser;
        private readonly IOfferRepository _repository;
        public CreateOfferUseCase(LoggedUser loggedUser, IOfferRepository repository) 
        {
            _loggedUser = loggedUser;
            _repository = repository;
        }

        public int Execute(int itemId, RequestCreateOfferJSON request)
        {
            var user = _loggedUser.User();            
            var offer = new Offer
            {
                CreatedOn = DateTime.UtcNow,
                ItemId = itemId,
                Price = request.Price,
                UserId = user.Id
            };

            _repository.Add(offer);

            return offer.Id;
        }
    }
}
