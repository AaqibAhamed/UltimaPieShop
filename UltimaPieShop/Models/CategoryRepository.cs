namespace UltimaPieShop.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly UltimaPieShopDbContext _ultimaPieShopDbContext;
        public CategoryRepository(UltimaPieShopDbContext ultimaPieShopDbContext)
        {
            _ultimaPieShopDbContext = ultimaPieShopDbContext;
        }

        //public IEnumerable<Category> AllCategories
        //{
        //    get
        //    {
        //        return _ultimaPieShopDbContext.Categories.OrderBy(c => c.CategoryName);
        //    }
        //}

        // OR
        public IEnumerable<Category> AllCategories => _ultimaPieShopDbContext.Categories.OrderBy(c => c.CategoryName);
    }
}
