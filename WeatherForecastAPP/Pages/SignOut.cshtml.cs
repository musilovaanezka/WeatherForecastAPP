using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WeatherForecastAPP.Pages
{
    public class SignOutModel : PageModel
    {
        public IActionResult OnGetAsync()
        {
            HttpContext.Session.SetString("IsAuthenticated", "false");
            return RedirectToPage("/Index");
        }
    }
}
