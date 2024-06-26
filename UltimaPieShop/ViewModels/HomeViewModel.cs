﻿using UltimaPieShop.Models;

namespace UltimaPieShop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Pie> PiesOfTheWeek { get; set; }

        public HomeViewModel(IEnumerable<Pie> pies)
        {
            PiesOfTheWeek = pies;
        }
    }
}
