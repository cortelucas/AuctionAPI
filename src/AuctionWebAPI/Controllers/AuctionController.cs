using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AuctionWebAPI.Entities;
using AuctionWebAPI.UseCases.Auctions.GetCurrent;

namespace AuctionWebAPI.Controllers
{
    public class AuctionController : AuctionAPIBaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(Auction), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetCurrentAuction()
        {
            var useCase = new GetCurrentAuctionUseCase();
            var result = useCase.Execute();

            if (result is null)
                return NoContent();
            
            return Ok(result);
        }
    }
}