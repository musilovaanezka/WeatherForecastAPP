using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WeatherForecastAPP.Interfaces;
using WeatherForecastAPP.Model;

namespace WeatherForecastAPP.Pages
{
    public class SignInModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly ILogger<SignInModel> _logger;
        public SignInModel(IUserService userService, ILogger<SignInModel> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        public async Task<IActionResult> OnPostSignIn(string username, string password)
        {
            try
            {
                var response = await _userService.SignInAsync(new User
                {
                    Username = username,
                    Password = password,
                });
                if (response)
                {
                    TempData["SignInSuccess"] = "Sign-in successful. You can see history data now.";
                    HttpContext.Session.SetString("IsAuthenticated", "true");
                    return RedirectToPage("/Index");
                }
                TempData["SignInFailed"] = "Sign in failed. Please try again.";
                return Page();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while sign up");
                return Page();
            }
        }
    }
}
