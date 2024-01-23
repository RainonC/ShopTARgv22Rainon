using Shop.data;
using Microsoft.EntityFrameworkCore;
using ShopCore.ServiceInterface;
using Shop.ApplicationServices.Services;
using Microsoft.Extensions.FileProviders;
using Shop.Core.ServiceInterface;
using Microsoft.AspNetCore.Identity;
using ShopCore.Domain;
using Shop.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ShopContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<ISpaceshipServices, SpaceshipServices>();
builder.Services.AddScoped<IFileServices, FilesServices>();
builder.Services.AddScoped<IRealEstatesServices, RealEstatesServices>();
builder.Services.AddScoped<IKindergartenServices, KindergartenServices>();
builder.Services.AddScoped<IWeatherForecastServices, WeatherForecastServices>();
builder.Services.AddScoped<IAccuWeatherServices, AccuWeatherServices>();




builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    options.Password.RequiredLength = 3;

    options.Tokens.EmailConfirmationTokenProvider = "CustomEmailConfirmation";
    options.Lockout.MaxFailedAccessAttempts = 2;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
})
    .AddEntityFrameworkStores<ShopContext>()
    .AddDefaultTokenProviders()
    .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>("CustomEmailConfirmation");
//.AddDefaultUI();

builder.Services.Configure<DataProtectionTokenProviderOptions>(o =>
    o.TokenLifespan = TimeSpan.FromHours(5));

//email tokens confirmation
builder.Services.Configure<CustomEmailConfirmationTokenProviderOptions>(o =>
    o.TokenLifespan = TimeSpan.FromDays(3));

builder.Services.AddAuthentication()
    .AddGoogle(options =>
    {
        options.ClientId = "641203150003-sb085c3kddvatiapncea0c10ldc6gu7b.apps.googleusercontent.com";
        options.ClientSecret = "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";
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider
    (Path.Combine(builder.Environment.ContentRootPath, "multipleFileUpload")),
    RequestPath = "/multipleFileUpload"
});

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


