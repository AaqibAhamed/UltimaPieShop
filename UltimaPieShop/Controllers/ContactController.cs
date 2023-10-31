using Microsoft.AspNetCore.Mvc;

namespace UltimaPieShop.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
