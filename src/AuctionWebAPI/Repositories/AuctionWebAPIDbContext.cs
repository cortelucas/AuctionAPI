using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AuctionWebAPI.Entities;

namespace AuctionWebAPI.Repositories
{
    public class AuctionWebAPIDbContext : DbContext
    {
        public AuctionWebAPIDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Offer> Offers { get; set; }
    }
}