using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace M133BlazorServerApp.Pages.GoogleLogin
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        public IActionResult OnGetAsync(string returnUrl = null)
        {
            const string provider = "Google";
            var authenticationProperties = new AuthenticationProperties
            {
                RedirectUri = Url.Page("./Login",
                    pageHandler: "Callback",
                    values: new { returnUrl }),
            };
            return new ChallengeResult(provider, authenticationProperties);
        }
        public async Task<IActionResult> OnGetCallbackAsync(
            string returnUrl = null, string remoteError = null)
        {
            var googleUser = this.User.Identities.FirstOrDefault();
            if (googleUser is { IsAuthenticated: false }) return LocalRedirect("/sessionform");
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
                RedirectUri = this.Request.Host.Value
            };
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(googleUser),
                authProperties);
            return LocalRedirect("/sessionform");
            
        }
        
    }
}