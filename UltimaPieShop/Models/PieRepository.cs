using Microsoft.EntityFrameworkCore;

namespace UltimaPieShop.Models
{
    public class PieRepository : IPieRepository
    {
        private readonly UltimaPieShopDbContext _ultimaPieShopDbContext;

        public PieRepository(UltimaPieShopDbContext ultimaPieShopDbContext)
        {
            _ultimaPieShopDbContext = ultimaPieShopDbContext;
        }

        public IEnumerable<Pie> AllPies
        {
            get
            {
               return _ultimaPieShopDbContext.Pies.Include(c => c.Category);
            }
        }

        public IEnumerable<Pie> PiesOfTheWeek
        {
            get
            {
                return _ultimaPieShopDbContext.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek);
            }
        }

        public Pie? GetPieById(int pieId)
        {
            return _ultimaPieShopDbContext.Pies.FirstOrDefault(i => i.PieId == pieId);
        }

        public IEnumerable<Pie> SearchPies(string searchQuery)
        {
            return _ultimaPieShopDbContext.Pies.Where(p => p.Name.Contains(searchQuery));
        }
    }
}
