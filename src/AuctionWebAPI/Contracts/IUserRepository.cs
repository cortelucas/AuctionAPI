using AuctionWebAPI.Entities;

namespace AuctionWebAPI.Contracts;

public interface IUserRepository
{
  bool ExistUserWithEmail(string email);
  User GetUserByEmail(string email);
}