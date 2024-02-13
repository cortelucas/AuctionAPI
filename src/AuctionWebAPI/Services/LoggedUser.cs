using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuctionWebAPI.Entities;
using AuctionWebAPI.Repositories;

namespace AuctionWebAPI.Services
{
    public class LoggedUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LoggedUser(IHttpContextAccessor httpContext) 
        {
            _httpContextAccessor = httpContext;
        }
        public User User()
        {
            var repository = new AuctionWebAPIDbContext();

            var token = TokenOnRequest();
            var tokenDecoded = FromBase64String(token);

            return repository.Users.First(user => user.Email.Equals(tokenDecoded));
        }

        private string TokenOnRequest()
        {
            var authentication = _httpContextAccessor.HttpContext!.Request.Headers.Authorization.ToString();

            return authentication["Bearer ".Length..];
        }

        private string FromBase64String(string base64EncodedData)
        {
            var data = Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(data);
        }
    }
}