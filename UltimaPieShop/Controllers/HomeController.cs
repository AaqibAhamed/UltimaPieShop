using Microsoft.AspNetCore.Mvc;
using UltimaPieShop.Models;
using UltimaPieShop.ViewModels;

namespace UltimaPieShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPieRepository _pieRepository;

        public HomeController(IPieRepository pieRepository)
        {
             _pieRepository = pieRepository;
        }
        public IActionResult Index()
        {
            var piesOfTheWeek = _pieRepository.PiesOfTheWeek;

            HomeViewModel homeViewModel = new HomeViewModel(piesOfTheWeek);

            return View(homeViewModel);
        }
    }
}
