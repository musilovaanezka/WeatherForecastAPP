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
    public class ApiClientServiceTests
    {
        private readonly HttpClient _client;
        private readonly ApiClientService _apiClientService;

        public ApiClientServiceTests()
        {
            var handler = new TestHttpMessageHandler(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent("[{\"Username\":\"karel\",\"Password\":\"123456\"},{\"Username\":\"tonda\",\"Password\":\"09876\"},{\"Username\":\"tutu\",\"Password\":\"0987\"},{\"Username\":\"kolo\",\"Password\":\"koko\"},{\"Username\":\"totu\",\"Password\":\"cucu\"},{\"Username\":\"kolor\",\"Password\":\"lkjh\"}]"),
            });

            _client = new HttpClient(handler);
            _apiClientService = new ApiClientService(_client);
        }

        [Fact]
        public async Task PostAsync_ReturnsCorrectResponse()
        {
            // Arrange
            var data = new { Name = "Test" };

            // Act
            var result = await _apiClientService.PostAsync<List<User>>("test", data); // Use List<User> instead of string

            // Assert
            Assert.NotEmpty(result); // Check that the result is not empty
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
