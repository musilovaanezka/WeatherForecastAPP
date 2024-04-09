using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WeatherForecastAPP.Interfaces;
using WeatherForecastAPP.Model;
using WeatherForecastAPP.Services;
using static System.Net.WebRequestMethods;

namespace WeatherForecastAPP.Pages
{
    public class SignUpModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly ILogger<SignUpModel> _logger;
        public SignUpModel(IUserService userService, ILogger<SignUpModel> logger) 
        {
            _userService = userService;
            _logger = logger;
        }

        public async Task<IActionResult> OnPostSignUp(string username, string password, string confirmPassword)
        {
            try
            {
                if (password != confirmPassword)
                {
                    TempData["SignUpFailed"] = "Passwords are not the same";
                    return Page();
                }
                if (password.Length < 8 || !password.Any(char.IsDigit))
                {
                    TempData["SignUpFailed"] = "Password must be at least 8 characters long and must contain at least 1 digit";
                    return Page();
                }
                var response = await _userService.SignUpAsync(new User
                {
                    Username = username,
                    Password = password,
                });
                if (response)
                {
                    TempData["SignUpSuccess"] = "Sign-up successful. You can now sign in.";
                    return RedirectToPage("/Index");
                }
                TempData["SignUpFailed"] = "Sign-up failed. Please try again.";
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
