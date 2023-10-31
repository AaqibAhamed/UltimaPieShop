namespace UltimaPieShop.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }

        public Pie Pie { get; set; } = default!;

        public int Quantity { get; set; }

        public string? ShoppingCartId { get; set; }
    }
}
