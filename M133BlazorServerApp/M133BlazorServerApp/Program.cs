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

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthenticationCore();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddScoped<ProtectedSessionStorage>();

builder.Services.AddScoped<System.Net.Http.HttpClient>();

builder.Services.AddSingleton<UserAccountService>();

builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddDistributedMemoryCache(); 

var services = builder.Services;
var config = builder.Configuration;


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


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseCookiePolicy();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapControllers();
    endpoints.MapBlazorHub();
    endpoints.MapFallbackToPage("/_Host");

});

app.Run();
