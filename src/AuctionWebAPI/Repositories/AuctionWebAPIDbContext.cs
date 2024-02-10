using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using AuctionWebAPI.Entities;

namespace AuctionWebAPI.Repositories
{
    public class AuctionWebAPIDbContext : DbContext
    {
        public DbSet<Auction> Auctions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=/home/cortelucas/dev/github/rocketseat/AuctionAPI/auction.db");
        }
    }
}