using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace M133BlazorServerApp.Pages.GoogleLogin
{
    public class Logout : PageModel
    {
        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                await HttpContext
                    .SignOutAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme);
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
            return LocalRedirect("/");
        }
    }
}
