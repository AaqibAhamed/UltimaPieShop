
using Microsoft.EntityFrameworkCore;
using UltimaPieShop.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

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

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

app.UseSession();

app.MapDefaultControllerRoute();

//app.MapGet("/", () => "Hello World!");

DataSeeder.Seed(app); // seed data to db for intialization db

app.Run();
