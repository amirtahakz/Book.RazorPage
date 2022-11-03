using Book.RazorPage.Infrastructure.RazorUtils;
using Book.RazorPage.Services.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Book.RazorPage.Pages.Auth
{
    public class LogoutModel : BaseRazorPage
    {
        private readonly IAuthService _authService;

        public LogoutModel(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<IActionResult> OnGet()
        {
            var result = await _authService.Logout();

            if (result.IsSuccess)
            {
                HttpContext.Response.Cookies.Delete("token");
                HttpContext.Response.Cookies.Delete("refresh-token");
            }
            return RedirectAndShowAlert(result, RedirectToPage("../Index"));
        }
    }
}
