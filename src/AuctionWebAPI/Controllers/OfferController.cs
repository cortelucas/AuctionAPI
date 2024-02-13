using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AuctionWebAPI.Communication.Requests;
using AuctionWebAPI.Filters;
using AuctionWebAPI.UseCases.Offers.CreateOffer;

namespace AuctionWebAPI.Controllers
{
    [ServiceFilter(typeof(AuthenticationUserAttribute))] 
    public class OfferController : AuctionAPIBaseController
    {
        [HttpPost]
        [Route("{itemId}")]
        public IActionResult CreateOffer(
            [FromRoute]int itemId, 
            [FromBody] RequestCreateOfferJSON request,
            [FromServices] CreateOfferUseCase useCase
        )
        {
            var id = useCase.Execute(itemId, request);

            return Created(string.Empty, id);
        }
    }
}