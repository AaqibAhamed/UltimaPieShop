using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UltimaPieShop.Migrations;

namespace UltimaPieShop.Models
{
    public class ShoppingCart : IShoppingCart
    {
        UltimaPieShopDbContext _ultimaPieShopDbContext;

        public ShoppingCart(UltimaPieShopDbContext ultimaPieShopDbContext)
        {
            _ultimaPieShopDbContext = ultimaPieShopDbContext;
        }

        public string? ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; } = default!;

        public static ShoppingCart GetCard(IServiceProvider services)
        {
            // ISession session = services.GetService<IHttpContextAccessor>()?.HttpContext?.Session; // add exception explicity 
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;

            string cardId = session?.GetString("CardId") ?? Guid.NewGuid().ToString();

            session?.SetString("CardId", cardId);

            UltimaPieShopDbContext dbContext = services.GetService<UltimaPieShopDbContext>() ?? throw new Exception("Error Registering Service");

            return new ShoppingCart(dbContext) { ShoppingCartId = cardId };

        }

        public void AddToCart(Pie pie)
        {
            var shoppingCartItem = _ultimaPieShopDbContext.ShoppingCartItems.FirstOrDefault(s => s.ShoppingCartId == ShoppingCartId && s.Pie.PieId == pie.PieId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Pie = pie,
                    Quantity = 1,

                };

                _ultimaPieShopDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }

            else
            {
                shoppingCartItem.Quantity++;
            }

            _ultimaPieShopDbContext.SaveChanges();
        }
        public int RemoveFromCart(Pie pie)
        {
            var localQuantity = 0;

            var shoppingCartItem = _ultimaPieShopDbContext.ShoppingCartItems.FirstOrDefault(s => s.ShoppingCartId == ShoppingCartId && s.Pie.PieId == pie.PieId);

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Quantity > 1)
                {
                    shoppingCartItem.Quantity--;
                    localQuantity = shoppingCartItem.Quantity;
                }
                else
                {
                    _ultimaPieShopDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            _ultimaPieShopDbContext.SaveChanges();

            return localQuantity;
        }

        public void ClearCart()
        {
            var shoppingCartItems = _ultimaPieShopDbContext.ShoppingCartItems.Where(s => s.ShoppingCartId == ShoppingCartId);

            _ultimaPieShopDbContext.ShoppingCartItems.RemoveRange(shoppingCartItems);

            _ultimaPieShopDbContext.SaveChanges();
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??= _ultimaPieShopDbContext.ShoppingCartItems.Where(s => s.ShoppingCartId == ShoppingCartId).Include(s => s.Pie).ToList();
        }

        public decimal GetShoppingCartTotal()
        {
            var Total = _ultimaPieShopDbContext.ShoppingCartItems.Where(s => s.ShoppingCartId == ShoppingCartId).Select(s => s.Pie.Price * s.Quantity).Sum();

            return Total;
        }

    }
}
