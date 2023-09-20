global using Infrastructure.Identity;
global using Microsoft.AspNetCore.Identity;
global using Infrastructure.Data;
global using ApplicationCore.Interfaces;
global using Microsoft.EntityFrameworkCore;
global using Web.Models;
global using ApplicationCore.Entities;
global using Web.Extensions;
using Web.Services;
using Web;
using ApplicationCore.Services;
using Web.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppIdentityContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("AppIdentityContext")));

builder.Services.AddDbContext<WatchHubContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("WatchHubContext")));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppIdentityContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
builder.Services.AddScoped<IHomeViewModelService, HomeViewModelService>();
builder.Services.AddScoped<IBasketService, BasketService>();
builder.Services.AddScoped<IBasketViewModelService, BasketViewModelService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseBasketTransfer();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

using (var scope = app.Services.CreateScope())
{
    var watchHubContext = scope.ServiceProvider.GetRequiredService<WatchHubContext>();
    await WatchHubContextSeed.SeedAsync(watchHubContext);

    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    await AppIdentityContextSeed.SeedAsync(roleManager, userManager);
}

app.Run();
