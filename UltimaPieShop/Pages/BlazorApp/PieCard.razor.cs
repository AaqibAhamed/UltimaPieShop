using Microsoft.AspNetCore.Components;
using UltimaPieShop.Models;

namespace UltimaPieShop.Pages.BlazorApp
{
    public partial class PieCard
    {
        [Parameter]
        public Pie? Pie { get; set; }
    }
}
