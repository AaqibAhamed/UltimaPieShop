using Microsoft.EntityFrameworkCore;

namespace UltimaPieShop.Models
{
    public class UltimaPieShopDbContext : DbContext
    {
        public UltimaPieShopDbContext(DbContextOptions<UltimaPieShopDbContext> dbContextOptions)
            : base(dbContextOptions)
        {

        }

        public DbSet<Pie> Pies { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
