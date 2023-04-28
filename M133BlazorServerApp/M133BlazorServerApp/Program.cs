using System.Configuration;
using System.Drawing;
using M133BlazorServerApp.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Net.Http;
using System.Security.Claims;
using M133BlazorServerApp.Pages.CookieLogin;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using M133BlazorServerApp.M151Data;
using Microsoft.EntityFrameworkCore;
using M133BlazorServerApp;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthenticationCore();
builder.Services.AddServerSideBlazor();
builder.Services.AddRazorPages();

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ProtectedSessionStorage>();
builder.Services.AddScoped<System.Net.Http.HttpClient>();

builder.Services.AddSingleton<UserAccountService>();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddDistributedMemoryCache();

var services = builder.Services;
var config = builder.Configuration;


#region Auth
services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
services.AddAuthentication().AddGoogle(options =>
{
    options.ClientId = config["Google:ClientId"];
    options.ClientSecret = config["Google:ClientSecret"];
    options.ClaimActions.MapJsonKey("urn:google:profile", "link");
    options.ClaimActions.MapJsonKey("urn:google:image", "picture");
});
services.AddHttpContextAccessor();
services.AddScoped<HttpContextAccessor>();
services.AddHttpClient();
services.AddScoped<HttpClient>();
services.AddSingleton<IConfiguration>(config);
#endregion

Microsoft.Extensions.Configuration.ConfigurationManager configuration = builder.Configuration;
configuration.GetSection("AppOptions").Bind(M133BlazorServerApp.ApplicationSettings.AppOptions);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors();

app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapRazorPages();
    endpoints.MapBlazorHub();
    endpoints.MapFallbackToPage("/_Host");

});


app.Run();

