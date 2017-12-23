namespace ReefAquarium.Tests.Controllers
{
    using Data.Models;
    using FluentAssertions;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using ReefAquarium.Web.Controllers;
    using Services;
    using Services.Models.Users;
    using System.Threading.Tasks;
    using Xunit;

    public class UserControllerTest
    {
        [Fact]
        public async Task ProfileShouldReturnNotFoundWithInvalidUsername()
        {
            // Arrange
            var userManager = this.GetUserManagerMock();

            var controller = new UsersController(null, userManager.Object);

            // Act
            var result = await controller.Profile("Username");

            // Assert
            result
                .Should()
                .BeOfType<NotFoundResult>();

        }

        [Fact]
        public async Task ProfileShouldReturnViewWithCorrectModelWithValidUsername()
        {
            // Arrange
            const string userId = "SomeId";
            const string username = "SomeUsername";

            var userManager = this.GetUserManagerMock();
            userManager
                .Setup(u => u.FindByNameAsync(It.IsAny<string>()))
                .ReturnsAsync(new User { Id = userId });

            var userService = new Mock<IUserService>();
            userService
                .Setup(u => u.ProfileAsync(It.Is<string>(id => id == userId)))
                .ReturnsAsync(new UserProfileServiceModel { Username = username });

            var controller = new UsersController(
                userService.Object, userManager.Object);

            // Act
            var result = await controller.Profile(username);

            // Assert
            result
                .Should()
                .BeOfType<ViewResult>()
                .Subject
                .Model
                .Should()
                .Match(m => m.As<UserProfileServiceModel>().Username == username);
        }

        private Mock<UserManager<User>> GetUserManagerMock()
            => new Mock<UserManager<User>>(
                Mock.Of<IUserStore<User>>(), null, null, null, null, null, null, null, null);
    }
}
