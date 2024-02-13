using AuctionWebAPI.Contracts;
using AuctionWebAPI.Entities;

namespace AuctionWebAPI.Repositories.DataAccess;

public class UserRepository : IUserRepository
{
  private readonly AuctionWebAPIDbContext _dbContext;
  public UserRepository(AuctionWebAPIDbContext dbContext) => _dbContext = dbContext;

  public bool ExistUserWithEmail(string email)
  {
    return _dbContext.Users.Any(user => user.Email.Equals(email));
  }

  public User GetUserByEmail(string email)
  {
    return _dbContext.Users.First(user => user.Email.Equals(email));
  }
}