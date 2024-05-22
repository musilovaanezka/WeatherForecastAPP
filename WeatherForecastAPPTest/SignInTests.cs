using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecastAPP.Interfaces;
using WeatherForecastAPP.Pages;
using WeatherForecastAPP.Model;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace WeatherForecastAPPTest
{
    public class SignInTests
    {
        private readonly Mock<IUserService> _mockUserService;
        private readonly Mock<ILogger<SignInModel>> _mockLogger;
        private readonly SignInModel _signInModel;
        private readonly Mock<ITempDataDictionary> _mockTempData;
        private readonly DefaultHttpContext _httpContext;

        public SignInTests()
        {
            _mockUserService = new Mock<IUserService>();
            _mockLogger = new Mock<ILogger<SignInModel>>();

            _httpContext = new DefaultHttpContext();
            _httpContext.Features.Set<ISessionFeature>(new SessionFeature());
            _mockUserService.Setup(service => service.SignInAsync(It.IsAny<User>())).ReturnsAsync(true);
            var session = new Mock<ISession>();
            var sessionDictionary = new Dictionary<string, byte[]>();

            session.Setup(s => s.Set(It.IsAny<string>(), It.IsAny<byte[]>()));
            session.Setup(s => s.Remove(It.IsAny<string>()));

            session.Setup(s => s.TryGetValue(It.Is<string>(key => key == "IsAuthenticated"), out It.Ref<byte[]>.IsAny)).Returns(true);

            _httpContext.Features.Set<ISessionFeature>(new SessionFeature { Session = session.Object });

            _mockTempData = new Mock<ITempDataDictionary>();
            _signInModel = new SignInModel(_mockUserService.Object, _mockLogger.Object)
            {
                PageContext = new PageContext
                {
                    HttpContext = _httpContext
                },
                TempData = _mockTempData.Object
            };
        }

        [Fact]
        public async Task OnPostSignIn_ShouldReturnPageResult_WhenSignInFailed()
        {
            // Arrange
            _mockUserService.Setup(service => service.SignInAsync(It.IsAny<User>())).ReturnsAsync(false);
            var username = "testuser";
            var password = "testpassword";

            // Act
            var result = await _signInModel.OnPostSignIn(username, password);

            // Assert
            Assert.IsType<PageResult>(result);
        }
        [Fact]
        public async Task OnPostSignIn_ShouldReturnPageResult_WhenExceptionIsThrown()
        {
            // Arrange
            var username = "testuser";
            var password = "testpassword";
            _mockUserService.Setup(service => service.SignInAsync(It.IsAny<User>())).Throws(new Exception());

            // Act
            var result = await _signInModel.OnPostSignIn(username, password);

            // Assert
            Assert.IsType<PageResult>(result);
            _mockLogger.Verify(
                x => x.Log(
                    It.IsAny<LogLevel>(),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => true),
                    It.IsAny<Exception>(),
                    It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)),
                Times.Once);
        }

        //[Fact]
        //public async Task OnPostSignIn_ShouldRedirectToIndex_WhenSignInSucceeds()
        //{
        //    // Arrange
        //    var username = "testuser";
        //    var password = "testpassword";

        //    // Act
        //    var result = await _signInModel.OnPostSignIn(username, password);

        //    // Assert
        //    Assert.IsType<RedirectToPageResult>(result);
        //    Assert.Equal("/Index", ((RedirectToPageResult)result).PageName);
        //    Assert.Equal("true", _httpContext.Session.GetString("IsAuthenticated"));
        //    _mockTempData.Verify(t => t.Add("SignInSuccess", "Sign-in successful. You can see history data now."), Times.Once);
        //}

    }
}
