using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace UltimaPieShop.Models
{
    public class UltimaPieShopDbContext : IdentityDbContext
    {
        public UltimaPieShopDbContext(DbContextOptions<UltimaPieShopDbContext> dbContextOptions)
            : base(dbContextOptions)
        {

        }

        public DbSet<Pie> Pies { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
