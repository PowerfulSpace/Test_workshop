using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using Test_workshop.MigrationFK.Data;
using Test_workshop.MigrationFK.Interfaces;
using Test_workshop.MigrationFK.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLocalization();

var localizationOptions = new RequestLocalizationOptions();
var supportedCultures = new[]
{
                new CultureInfo("en-US"),
                new CultureInfo("es-ES")
};
localizationOptions.SupportedCultures = supportedCultures;
localizationOptions.SupportedUICultures = supportedCultures;
localizationOptions.SetDefaultCulture("en-US");
localizationOptions.ApplyCurrentCultureToResponseHeaders = true;

builder.Services.AddScoped<IProduct, ProductRepository>();
builder.Services.AddScoped<IUnit, UnitRepository>();
builder.Services.AddScoped<IBrand, BrandRepository>();


builder.Services.AddDbContext<InventoryContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<InventoryContext>();



builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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

app.MapRazorPages();

app.Run();
