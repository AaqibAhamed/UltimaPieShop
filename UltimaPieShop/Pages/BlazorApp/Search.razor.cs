using Microsoft.AspNetCore.Components;
using UltimaPieShop.Models;

namespace UltimaPieShop.Pages.BlazorApp
{
    public partial class Search
    {
        public string SearchText = "";

        public List<Pie> FilteredPies { get; set; } = new List<Pie>();

        [Inject]
        public IPieRepository? PieRepository { get; set; }

        private void SearchPies()
        {
            FilteredPies.Clear();

            if(PieRepository != null)
            {
                if(SearchText.Length >= 3)
                {
                    FilteredPies = PieRepository.SearchPies(SearchText).ToList();
                }
            }


        }


    }
}
