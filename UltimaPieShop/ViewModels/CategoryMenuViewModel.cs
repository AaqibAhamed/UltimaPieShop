using UltimaPieShop.Models;

namespace UltimaPieShop.ViewModels
{
    public class CategoryMenuViewModel
    {
        public IEnumerable<Category> Categories { get; set; }

        public CategoryMenuViewModel(IEnumerable<Category> categories)
        {
            Categories = categories;
        }
    }
}
