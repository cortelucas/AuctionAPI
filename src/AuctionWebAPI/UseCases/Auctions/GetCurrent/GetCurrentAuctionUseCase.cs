using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AuctionWebAPI.Contracts;
using AuctionWebAPI.Entities;
using AuctionWebAPI.Repositories;

namespace AuctionWebAPI.UseCases.Auctions.GetCurrent
{
    public class GetCurrentAuctionUseCase
    {
        private readonly IAuctionRepository _repository;
        public GetCurrentAuctionUseCase(IAuctionRepository repository) => _repository = repository;
        public Auction? Execute() => _repository.GetCurrent();
    }
}