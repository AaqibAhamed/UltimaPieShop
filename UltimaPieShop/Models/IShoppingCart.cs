using UltimaPieShop.Migrations;

namespace UltimaPieShop.Models
{
    public interface IShoppingCart
    {
        void AddToCart(Pie pie);

        void ClearCart();

        int RemoveFromCart(Pie pie);

        decimal GetShoppingCartTotal();

        List<ShoppingCartItem> GetShoppingCartItems();

        List<ShoppingCartItem> ShoppingCartItems { get; set; }

    }
}
