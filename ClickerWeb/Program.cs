using ClickerWeb.DAL;
using ClickerWeb.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=ClickerV0;Trusted_Connection=True;";
builder.Services
    .AddDbContext<WebContext>(option =>
        option
            .UseLazyLoadingProxies(true)
            .UseSqlServer(connectionString));

builder.Services
    .AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<WebContext>();

builder.Services.AddCors(option =>
{
    option.AddDefaultPolicy(policy => 
        policy.WithOrigins("http://localhost:3000"));
});

builder.Services.ConfigureApplicationCookie(option =>
{
    option.LoginPath = "/Account/Login";
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

var seedDatabase = new SeedDatabase();
seedDatabase.Seed(app.Services);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
