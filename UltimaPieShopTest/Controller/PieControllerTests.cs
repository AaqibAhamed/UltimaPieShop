using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltimaPieShop.Controllers;
using UltimaPieShop.ViewModels;
using UltimaPieShopTest.Mocks;

namespace UltimaPieShopTest.Controller
{
    public class PieControllerTests
    {
        [Fact]
        public void List_EmptyString_ReturnAllPies()
        {
            // Arrange
            var pioRepo = RepositoryMocks.GetPieRepository();

            var categoryRepo = RepositoryMocks.GetCategoryRepository();

            var pieController = new PieController (pioRepo.Object, categoryRepo.Object);

            // Act

            var result = pieController.List("");

            // Assert

            var viewResult = Assert.IsType<ViewResult>(result);

            var pieListViewModel = Assert.IsAssignableFrom<PieListViewModel>(viewResult.ViewData.Model);

            Assert.Equal(10, pieListViewModel.Pies.Count());
        }
    }
}
