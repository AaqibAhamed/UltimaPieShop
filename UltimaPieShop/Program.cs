
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using UltimaPieShop.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews()
    .AddJsonOptions(option =>
    {
        //// Avoid infinite loop for model references 
        option.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddRazorPages();

builder.Services.AddDbContext<UltimaPieShopDbContext>(
    option =>
    {
        option.UseSqlServer(
        builder.Configuration["ConnectionStrings:UltimaPieShopDbContextConnection"]);
    });

//builder.Services.AddScoped<ICategoryRepository, MockCategoryRepository>();
//builder.Services.AddScoped<IPieRepository, MockPieRepository>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPieRepository, PieRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<IShoppingCart, ShoppingCart>(serviceProvider => ShoppingCart.GetCard(serviceProvider));
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

builder.Services.AddServerSideBlazor();

builder.Services.AddAuthentication();

//builder.Services.AddDefaultIdentity<IdentityUser>()
//    .AddEntityFrameworkStores<UltimaPieShopDbContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

app.UseSession();

app.MapDefaultControllerRoute();
//app.MapControllerRoute(
//name: "default",
//pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

//app.MapGet("/", () => "Hello World!"); {controller=Home}/{action=Index}/{id?}

app.MapBlazorHub();
app.MapFallbackToPage("/app/{*catchall}", "/BlazorApp/Index");

DataSeeder.Seed(app); // seed data to db for intialization db

app.Run();
