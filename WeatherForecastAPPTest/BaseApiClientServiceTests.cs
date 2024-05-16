using Moq;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherForecastAPP.Model;
using WeatherForecastAPP.Services;

namespace WeatherForecastAPPTest
{
    public class BaseApiClientServiceTests
    {

        [Fact]
        public async Task GetAsync_ShouldSendRequestToCorrectUrl_WhenParametersAreProvided()
        {
            // Arrange
            var expectedResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("{\"key\":\"value\"}", Encoding.UTF8, "application/json")
            };

            var httpMessageHandlerMock = new Mock<HttpMessageHandler>();
            httpMessageHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(request => request.RequestUri.ToString().EndsWith("?param1=value1&param2=value2")),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(expectedResponse);

            var httpClient = new HttpClient(httpMessageHandlerMock.Object);
            var baseApiClientService = new BaseApiClientService(httpClient);
            var endpoint = "testEndpoint";
            var parameters = new Dictionary<string, string>
    {
        { "param1", "value1" },
        { "param2", "value2" }
    };

            // Act
            var result = await baseApiClientService.GetAsync<Dictionary<string, string>>(endpoint, parameters);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("value", result["key"]);
        }

        [Fact]
        public async Task GetAsync_ShouldSendRequestToCorrectUrl_WhenParametersAreNull()
        {
            // Arrange
            var expectedResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("{\"key\":\"value\"}", Encoding.UTF8, "application/json")
            };

            var httpMessageHandlerMock = new Mock<HttpMessageHandler>();
            httpMessageHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(request => !request.RequestUri.ToString().Contains("?")),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(expectedResponse);

            var httpClient = new HttpClient(httpMessageHandlerMock.Object);
            var baseApiClientService = new BaseApiClientService(httpClient);
            var endpoint = "testEndpoint";

            // Act
            var result = await baseApiClientService.GetAsync<Dictionary<string, string>>(endpoint, null);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("value", result["key"]);
        }

        private readonly HttpClient _client;
        private readonly BaseApiClientService _baseApiClientService;

        public BaseApiClientServiceTests()
        {
            var handler = new TestHttpMessageHandler(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("[{\"Username\":\"karel\",\"Password\":\"123456\"},{\"Username\":\"tonda\",\"Password\":\"09876\"},{\"Username\":\"tutu\",\"Password\":\"0987\"},{\"Username\":\"kolo\",\"Password\":\"koko\"},{\"Username\":\"totu\",\"Password\":\"cucu\"},{\"Username\":\"kolor\",\"Password\":\"lkjh\"}]"),
            });

            _client = new HttpClient(handler);
            _baseApiClientService = new BaseApiClientService(_client);
        }

        [Fact]
        public async Task GetAsync_ReturnsCorrectResponse()
        {
            // Arrange
            var endpoint = "test";
            var parameters = new Dictionary<string, string>
            {
                { "param1", "value1" },
                { "param2", "value2" }
            };

            // Act
            var result = await _baseApiClientService.GetAsync<List<User>>(endpoint, parameters);

            // Assert
            Assert.NotEmpty(result);
        }

        private class TestHttpMessageHandler : HttpMessageHandler
        {
            private readonly HttpResponseMessage _response;

            public TestHttpMessageHandler(HttpResponseMessage response)
            {
                _response = response;
            }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                return Task.FromResult(_response);
            }
        }
    }
}
