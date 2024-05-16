using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecastAPP.Model;
using WeatherForecastAPP.Services;

namespace WeatherForecastAPPTest
{
    public class UserServiceTests
    {
        private readonly Mock<IApiClientService> _mockApiClientService;
        private readonly UserService _userService;

        public UserServiceTests()
        {
            _mockApiClientService = new Mock<IApiClientService>();
            _userService = new UserService(_mockApiClientService.Object);
        }

        [Fact]
        public async Task SignInAsync_ReturnsTrue_WhenUserExists()
        {
            // Arrange
            var user = new User { Username = "test", Password = "test" };

            _mockApiClientService
                .Setup(service => service.PostAsync<User>("users/signin", user))
                .ReturnsAsync(user);

            // Act
            var result = await _userService.SignInAsync(user);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task SignInAsync_ReturnsFalse_WhenUserDoesNotExist()
        {
            // Arrange
            var user = new User { Username = "test", Password = "test" };

            _mockApiClientService
                .Setup(service => service.PostAsync<User>("users/signin", user))
                .ReturnsAsync((User)null);

            // Act
            var result = await _userService.SignInAsync(user);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task SignUpAsync_ReturnsTrue_WhenUserIsCreated()
        {
            // Arrange
            var user = new User { Username = "test", Password = "test" };

            _mockApiClientService
                .Setup(service => service.PostAsync<User>("users/signup", user))
                .ReturnsAsync(user);

            // Act
            var result = await _userService.SignUpAsync(user);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task SignUpAsync_ReturnsFalse_WhenUserIsNotCreated()
        {
            // Arrange
            var user = new User { Username = "test", Password = "test" };

            _mockApiClientService
                .Setup(service => service.PostAsync<User>("users/signup", user))
                .ReturnsAsync((User)null);

            // Act
            var result = await _userService.SignUpAsync(user);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task SignInAsync_ReturnsFalse_WhenExceptionIsThrown()
        {
            // Arrange
            var user = new User { Username = "test", Password = "test" };

            _mockApiClientService
                .Setup(service => service.PostAsync<User>("users/signin", user))
                .ThrowsAsync(new Exception());

            // Act
            var result = await _userService.SignInAsync(user);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task SignUpAsync_ReturnsFalse_WhenExceptionIsThrown()
        {
            // Arrange
            var user = new User { Username = "test", Password = "test" };

            _mockApiClientService
                .Setup(service => service.PostAsync<User>("users/signup", user))
                .ThrowsAsync(new Exception());

            // Act
            var result = await _userService.SignUpAsync(user);

            // Assert
            Assert.False(result);
        }
    }
}
