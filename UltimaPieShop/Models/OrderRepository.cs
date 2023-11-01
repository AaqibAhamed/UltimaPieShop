namespace UltimaPieShop.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly UltimaPieShopDbContext _ultimaPieShopDbContext;

        private readonly IShoppingCart _shoppingCart;

        public OrderRepository(UltimaPieShopDbContext ultimaPieShopDbContext, IShoppingCart shoppingCart)
        {
            _ultimaPieShopDbContext = ultimaPieShopDbContext;
            _shoppingCart = shoppingCart;
        }


        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;

            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();

            List<ShoppingCartItem>? shoppingCartItems = _shoppingCart.GetShoppingCartItems();

            order.OrderDetails = new List<OrderDetail>();

            foreach (ShoppingCartItem? shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail
                {
                    PieId = shoppingCartItem.Pie.PieId,
                    Quantity = shoppingCartItem.Quantity,
                    Price = shoppingCartItem.Pie.Price
                };

                order.OrderDetails.Add(orderDetail);
            }

            _ultimaPieShopDbContext.Orders.Add(order);

            _ultimaPieShopDbContext.SaveChanges();


        }
    }
}
