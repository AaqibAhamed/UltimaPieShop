using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UltimaPieShop.Models;

namespace UltimaPieShop.Pages
{
    public class CheckoutPageModel : PageModel
    {
        private readonly IOrderRepository _orderRepository;

        private readonly IShoppingCart _shoppingCart;
        public CheckoutPageModel(IShoppingCart shoppingCart, IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
        }

        [BindProperty]// to get user input data to model
        public Order Order { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost() //Order order can ba passed as argument
        {
            // no need
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            if (_shoppingCart.ShoppingCartItems.Count <= 0)
            {
                ModelState.AddModelError("", "Your cart is empty, add some pies first");
            }

            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(Order);

                _shoppingCart.ClearCart();

                return RedirectToPage("CheckoutCompletePage");
            }

            return Page();
        }
    }
}
