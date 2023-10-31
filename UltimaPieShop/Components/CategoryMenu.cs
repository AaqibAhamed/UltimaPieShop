using Microsoft.AspNetCore.Mvc;
using UltimaPieShop.Models;
using UltimaPieShop.ViewModels;

namespace UltimaPieShop.Components
{
    public class CategoryMenu : ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryMenu(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            // var categories = _categoryRepository.AllCategories.OrderBy(c => c.CategoryName);
            // IEnumerable<Category> categories = _categoryRepository.AllCategories.OrderBy(c => c.CategoryName);

            //IEnumerable<Category> categories = _categoryRepository.AllCategories;

            // without ViewModel directly we can pass categories to View 
            var categories = _categoryRepository.AllCategories;

            CategoryMenuViewModel categoryMenuViewModel = new CategoryMenuViewModel(categories);

            return View(categoryMenuViewModel);
        }
    }
}
