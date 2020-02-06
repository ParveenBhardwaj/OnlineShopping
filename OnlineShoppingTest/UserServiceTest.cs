using Moq;
using System.Threading.Tasks;
using OnlineShopping.Domain.Interfaces.Repositories;
using OnlineShopping.Domain.Models;
using OnlineShopping.Services;
using Xunit;

namespace OnlineShoppingTest
{
    public class UserServiceTest
    {
        [Fact]
        public async Task GetTest()
        {
            // Setup
            var userRepository = new Mock<IUserRepository>();
            userRepository.Setup(x => x.GetAsync()).Returns(Task.FromResult(new User { Name = "TestUser", Token = "This is a Token."}));

            // Arrange
            var userService = new UserService(userRepository.Object);

            // Act
            var actual_GetUser = await userService.GetAsync();
            Assert.True(string.Equals(actual_GetUser.Name, "TestUser"));
            Assert.True(string.Equals(actual_GetUser.Token, "This is a Token."));
        }
    }
}
