using BethanysPieShop.Controllers;
using BethanysPieShop.ViewModels;
using BethanysPieShopTests.Mocks;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BethanysPieShopTests.Controllers
{
    public class PieControllerTests
    {
        [Fact]
        public void List_EmptyCategory_ReturnsAllPies()
        {
            // Arrange
            var mockPieRepository = RepositoryMocks.GetPieRepository();
            var mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
            var pieController = new PieController(mockPieRepository.Object, mockCategoryRepository.Object);

            // Act
            var result = pieController.List("");

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);     // We assert that what is returned is of type ViewResult

            var pieListViewModel = Assert.IsAssignableFrom<PieListViewModel>(viewResult.ViewData.Model);    // We assert that the Model returned in the View is of type PistListViewModel

            Assert.Equal(10, pieListViewModel.Pies.Count());    // We assert that the amount of pies returned is 10
        }
    }
}
