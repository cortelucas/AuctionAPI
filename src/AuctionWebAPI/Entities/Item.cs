using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
﻿using System.ComponentModel.DataAnnotations.Schema;

namespace AuctionWebAPI.Entities
{
    [Table("Items")]
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public int Condition { get; set; }
        public decimal BasePrice { get; set; }
        public int AuctionId { get; set; }
    }
}