using Microsoft.AspNetCore.Mvc;
using UltimaPieShop.Models;
using UltimaPieShop.ViewModels;

namespace UltimaPieShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IPieRepository _pieRepository;

        private readonly IShoppingCart _shoppingCart;

        public ShoppingCartController(IPieRepository pieRepository, IShoppingCart shoppingCart)
        {
            _pieRepository = pieRepository;
            _shoppingCart = shoppingCart;
        }

        //public IActionResult Index() -- ViewResult
        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            //  _shoppingCart.ShoppingCartItems = items; -no need see GetShoppingCartItems logic

            var shoppingCartViewModel = new ShoppingCartViewModel(_shoppingCart,
                _shoppingCart.GetShoppingCartTotal());

            return View(shoppingCartViewModel);
        }

        //public IActionResult AddToShoppingCart() -- RedirectToActionResult
        public RedirectToActionResult AddToShoppingCart(int pieId)
        {
           // var selectedPie = _pieRepository.GetPieById(pieId);

            var selectedPie = _pieRepository.AllPies.FirstOrDefault(p => p.PieId == pieId);

            if (selectedPie != null)
            {
                _shoppingCart.AddToCart(selectedPie);
            }

            return RedirectToAction("Index", "ShoppingCart");

        }

        //public IActionResult RemoveFromShoppingCart() -- RedirectToActionResult
        public RedirectToActionResult RemoveFromShoppingCart(int pieId)
        {
            var selectedPie = _pieRepository.GetPieById(pieId);

            if (selectedPie != null)
            {
                _shoppingCart.RemoveFromCart(selectedPie);
            }
            return RedirectToAction("Index");

        }
    }
}
