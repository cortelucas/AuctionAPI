using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuctionWebAPI.Contracts;
using AuctionWebAPI.Entities;
using AuctionWebAPI.Repositories;

namespace AuctionWebAPI.Services
{
    public class LoggedUser : ILoggedUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _repository;
        public LoggedUser(IHttpContextAccessor httpContext, IUserRepository repository) 
        {
            _httpContextAccessor = httpContext;
            _repository = repository;
        }
        public User User()
        {
            var token = TokenOnRequest();
            var tokenDecoded = FromBase64String(token);

            return _repository.GetUserByEmail(tokenDecoded);
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