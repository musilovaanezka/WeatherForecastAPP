using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecastAPP.Pages;

namespace WeatherForecastAPPTest
{
    public class ErrorModelTests
    {
        private readonly Mock<ILogger<ErrorModel>> _mockLogger;
        private readonly ErrorModel _errorModel;

        public ErrorModelTests()
        {
            _mockLogger = new Mock<ILogger<ErrorModel>>();
            _errorModel = new ErrorModel(_mockLogger.Object);
        }

        [Fact]
        public void OnGet_SetsRequestId()
        {
            // Arrange
            var expectedRequestId = "123";
            var httpContext = new DefaultHttpContext();
            httpContext.TraceIdentifier = expectedRequestId;
            _errorModel.PageContext = new PageContext
            {
                HttpContext = httpContext
            };

            // Act
            _errorModel.OnGet();

            // Assert
            Assert.Equal(expectedRequestId, _errorModel.RequestId);
        }

        [Fact]
        public void ShowRequestId_ReturnsTrue_WhenRequestIdIsNotNullOrEmpty()
        {
            // Arrange
            _errorModel.RequestId = "123";

            // Act
            var result = _errorModel.ShowRequestId;

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void ShowRequestId_ReturnsFalse_WhenRequestIdIsNullOrEmpty()
        {
            // Arrange
            _errorModel.RequestId = "";

            // Act
            var result = _errorModel.ShowRequestId;

            // Assert
            Assert.False(result);
        }
    }
}
