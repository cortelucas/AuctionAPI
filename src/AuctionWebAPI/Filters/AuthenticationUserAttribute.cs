using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using AuctionWebAPI.Repositories;

namespace AuctionWebAPI.Filters
{
    public class AuthenticationUserAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                var token = TokenOnRequest(context.HttpContext);
                var repository = new AuctionWebAPIDbContext();
                var tokenDecoded = FromBase64String(token);

                var exist = repository.Users.Any(user => user.Email.Equals(tokenDecoded));

                if (exist == false)
                {
                    context.Result = new UnauthorizedObjectResult("Token is invalid.");
                }
            }
            catch (Exception exception)
            {

                context.Result = new UnauthorizedObjectResult(exception.Message);
            }
        }

        private string TokenOnRequest(HttpContext context)
        {
            var authentication = context.Request.Headers.Authorization.ToString();

            if (string.IsNullOrEmpty(authentication))
            {
                throw new Exception("Token is missing.");
            }

            return authentication["Bearer ".Length..];
        }

        private string FromBase64String(string base64EncodedData)
        {
            var data = Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(data);
        }
    }
}