using Xunit;
using FluentAssertions;
using Moq;
using Bogus;
using AuctionWebAPI.Communication.Requests;
using AuctionWebAPI.Contracts;
using AuctionWebAPI.Entities;
using AuctionWebAPI.Services;
using AuctionWebAPI.UseCases.Offers.CreateOffer;

namespace UseCases.Test.Offers.CreateOffer;

public class CreateOfferUseCaseTest
{
  [Theory]
  [InlineData(1)]
  [InlineData(2)]
  [InlineData(3)]
  public void Success(int itemId)
  {
    // Arrange
    var request = new Faker<RequestCreateOfferJSON>()
      .RuleFor(request => request.Price, faker => faker.Random.Decimal(50, 1000))
      .Generate();

    var offerRepository = new Mock<IOfferRepository>();
    var loggedUser = new Mock<ILoggedUser>();
    loggedUser.Setup(i => i.User()).Returns(new User());

    var useCase = new CreateOfferUseCase(loggedUser.Object, offerRepository.Object);

    // Act
    var act = () => useCase.Execute(itemId, request);
  
    // Assert
    act.Should().NotThrow();
  }
}
