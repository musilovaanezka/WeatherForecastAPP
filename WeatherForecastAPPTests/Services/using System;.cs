using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Xunit;

namespace WeatherForecastAPPTests.Services
{
    public class ApiClientServiceTests
    {
        [Fact]
        public async Task PostAsync_WithValidData_ReturnsDeserializedObject()
        {
            // Arrange
            var expectedData = new { Name = "John", Age = 30 };
            var expectedJson = "{\"Name\":\"John\",\"Age\":30}";
            var expectedContent = new StringContent(expectedJson, Encoding.UTF8, "application/json");
            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = expectedContent
            };

            var httpClientMock = new Mock<HttpClient>();
            httpClientMock
                .Setup(client => client.PostAsync(It.IsAny<string>(), It.IsAny<HttpContent>()))
                .ReturnsAsync(expectedResponse);

            var apiClientService = new ApiClientService(httpClientMock.Object);

            // Act
            var result = await apiClientService.PostAsync<object>("endpoint", expectedData);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedData.Name, result.Name);
            Assert.Equal(expectedData.Age, result.Age);
        }

        [Fact]
        public async Task PostAsync_WithInvalidData_ThrowsException()
        {
            // Arrange
            var invalidData = new { InvalidProperty = "InvalidValue" };
            var expectedExceptionMessage = "Error in ApiClientService.PostAsync";

            var httpClientMock = new Mock<HttpClient>();
            httpClientMock
                .Setup(client => client.PostAsync(It.IsAny<string>(), It.IsAny<HttpContent>()))
                .ThrowsAsync(new Exception("Some error occurred"));

            var apiClientService = new ApiClientService(httpClientMock.Object);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<Exception>(() => apiClientService.PostAsync<object>("endpoint", invalidData));
            Assert.Equal(expectedExceptionMessage, exception.Message);
        }
    }
}using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Xunit;

namespace WeatherForecastAPPTests.Services
{
    public class ApiClientServiceTests
    {
        [Fact]
        public async Task PostAsync_ReturnsDeserializedObject()
        {
            // Arrange
            var expectedData = new { Name = "John", Age = 30 };
            var expectedJson = "{\"Name\":\"John\",\"Age\":30}";
            var expectedContent = new StringContent(expectedJson, Encoding.UTF8, "application/json");
            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = expectedContent
            };

            var httpClientMock = new Mock<HttpClient>();
            httpClientMock.Setup(client => client.PostAsync(It.IsAny<string>(), It.IsAny<HttpContent>()))
                .ReturnsAsync(expectedResponse);

            var apiClientService = new ApiClientService(httpClientMock.Object);

            // Act
            var result = await apiClientService.PostAsync<object>("endpoint", expectedData);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedData.Name, result.Name);
            Assert.Equal(expectedData.Age, result.Age);
        }

        [Fact]
        public async Task PostAsync_ThrowsException_WhenHttpClientThrowsException()
        {
            // Arrange
            var expectedException = new Exception("Test exception");

            var httpClientMock = new Mock<HttpClient>();
            httpClientMock.Setup(client => client.PostAsync(It.IsAny<string>(), It.IsAny<HttpContent>()))
                .ThrowsAsync(expectedException);

            var apiClientService = new ApiClientService(httpClientMock.Object);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => apiClientService.PostAsync<object>("endpoint", null));
        }
    }
}