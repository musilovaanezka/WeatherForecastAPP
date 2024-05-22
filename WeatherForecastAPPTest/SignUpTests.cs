using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecastAPP.Interfaces;
using WeatherForecastAPP.Model;
using WeatherForecastAPP.Pages;

namespace WeatherForecastAPPTest
{
    public class SignUpTests
    {
        private readonly Mock<ILogger<SignUpModel>> _mockLogger;
        private readonly Mock<IUserService> _mockUserService;
        private readonly SignUpModel _signUpModel;

        public SignUpTests()
        {
            _mockLogger = new Mock<ILogger<SignUpModel>>();
            _mockUserService = new Mock<IUserService>();

            _signUpModel = new SignUpModel(
                _mockUserService.Object,
                _mockLogger.Object);
        }

        [Fact]
        public async Task OnPostSignUp_ShouldReturnRedirectToPageResult_WhenSignUpIsSuccessful()
        {
            // Arrange
            var username = "testuser";
            var password = "TestPassword123";
            var confirmPassword = "TestPassword123";
            _mockUserService.Setup(service => service.SignUpAsync(It.IsAny<User>())).ReturnsAsync(true);

            // Act
            var result = await _signUpModel.OnPostSignUp(username, password, confirmPassword);

            // Assert
            Assert.IsType<PageResult>(result);
        }

        [Fact]
        public async Task OnPostSignUp_ShouldReturnPageResult_WhenPasswordsDoNotMatch()
        {
            // Arrange
            var username = "testuser";
            var password = "TestPassword123";
            var confirmPassword = "DifferentPassword";

            // Act
            var result = await _signUpModel.OnPostSignUp(username, password, confirmPassword);

            // Assert
            Assert.IsType<PageResult>(result);
        }

        [Fact]
        public async Task OnPostSignUp_ShouldReturnPageResult_WhenPasswordLengthIsLessThanEight()
        {
            // Arrange
            var username = "testuser";
            var password = "short";
            var confirmPassword = "short";

            // Act
            var result = await _signUpModel.OnPostSignUp(username, password, confirmPassword);

            // Assert
            Assert.IsType<PageResult>(result);
        }

        [Fact]
        public async Task OnPostSignUp_ShouldReturnPageResult_WhenPasswordDoesNotContainDigit()
        {
            // Arrange
            var username = "testuser";
            var password = "PasswordWithoutDigit";
            var confirmPassword = "PasswordWithoutDigit";

            // Act
            var result = await _signUpModel.OnPostSignUp(username, password, confirmPassword);

            // Assert
            Assert.IsType<PageResult>(result);
        }

        [Fact]
        public async Task OnPostSignUp_ShouldReturnPageResult_WhenSignUpFails()
        {
            // Arrange
            var username = "testuser";
            var password = "TestPassword123";
            var confirmPassword = "TestPassword123";
            _mockUserService.Setup(service => service.SignUpAsync(It.IsAny<User>())).ReturnsAsync(false);

            // Act
            var result = await _signUpModel.OnPostSignUp(username, password, confirmPassword);

            // Assert
            Assert.IsType<PageResult>(result);
        }

        [Fact]
        public async Task OnPostSignUp_ShouldLogError_WhenExceptionIsThrown()
        {
            // Arrange
            var username = "testuser";
            var password = "TestPassword123";
            var confirmPassword = "TestPassword123";
            var exception = new Exception("Test exception");
            _mockUserService.Setup(service => service.SignUpAsync(It.IsAny<User>())).ThrowsAsync(exception);

            // Act
            var result = await _signUpModel.OnPostSignUp(username, password, confirmPassword);

            // Assert
            _mockLogger.Verify(
                x => x.Log(
                    LogLevel.Error,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Error while sign up")),
                    exception,
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()),
                Times.Once
            );
            Assert.IsType<PageResult>(result);
        }
    }
}
