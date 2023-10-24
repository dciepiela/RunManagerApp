//using ExternalViewComponents.Component;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using RunManagerWebApp.Data;
using RunManagerWebApp.Data.Interfaces;
using RunManagerWebApp.Models;
using RunManagerWebApp.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IClubRepository, ClubRepository>();
builder.Services.AddScoped<IRaceRepository, RaceRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IDashboardRepository, DashboardRepository>();
//konfiguracja naszej bazy danych i trafia do miejsca zwanego aplikacj¹ lub ustawieniami aplikacji json i faktycznie musimy dodaæ ten ci¹g po³¹czenia do naszych ustawieñ aplikacji
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//Identity
builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 2;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
}).AddRoles<IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();

//builder.Services.AddIdentity<AppUser,IdentityRole>()
//    .AddEntityFrameworkStores<AppDbContext>();

//builder.Services.Configure<MvcRazorRuntimeCompilationOptions>(options =>
//{
//    options.FileProviders.Clear();
//    options.FileProviders.Add(new CompositeFileProvider(
//       new EmbeddedFileProvider(
//           typeof(Pagination).Assembly,
//           "ExternalViewComponents"
//           )));
//});

var app = builder.Build();

//await Roles.CreateRoles(app);




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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
