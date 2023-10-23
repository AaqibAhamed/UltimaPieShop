using Microsoft.AspNetCore.Mvc;
using UltimaPieShop.Models;
using UltimaPieShop.ViewModels;

namespace UltimaPieShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _pieRepository = pieRepository;
        }

        public IActionResult List()
        {
            // ViewBag.CurrentCategory = "Cheese cakes";
            //return View(_pieRepository.AllPies);

            PieListViewModel pieListViewModel = new PieListViewModel(_pieRepository.AllPies, "Cheese cakes");

            return View(pieListViewModel);

        }

    }
}
