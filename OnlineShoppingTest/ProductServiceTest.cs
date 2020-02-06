using System;
using System.Threading.Tasks;
using Xunit;
using OnlineShopping.Domain.Models;
using OnlineShopping.Domain.Interfaces.Managers;
using OnlineShopping.Services;
using Moq;
using System.Linq;
using OnlineShoppingTest.TestHelpers;
using Microsoft.Extensions.Logging;

namespace OnlineShoppingTest
{
    public class ProductServiceTest
    {
        [Fact]
        public async Task GetSortedProductsTest()
        {
            // Setup
            var productManager = new Mock<IProductManager>();
            productManager.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(ProductTestHelper.GetProductList()));

            var customerManager = new Mock<ICustomerManager>();
            customerManager.Setup(x => x.GetCustomerShoppingHistoryAsync()).Returns(Task.FromResult(ProductTestHelper.GetCustomerShoppingHistory()));
            
            var logger = new Mock<ILogger<ProductService>>();
            // Arrange
            var prodService = new ProductService(productManager.Object, customerManager.Object, logger.Object);

            // Act
            var actual_GetProducts_SortByHigh = await prodService.GetSortedProductsAsync(SortOption.High);
            Assert.True(actual_GetProducts_SortByHigh.Select(l => l.Name).SequenceEqual(ProductTestHelper.GetProductList().OrderByDescending(p => p.Price).Select(l => l.Name)));

            var actual_GetProducts_SortByLow = await prodService.GetSortedProductsAsync(SortOption.Low);
            Assert.True(actual_GetProducts_SortByLow.Select(l => l.Name).SequenceEqual(ProductTestHelper.GetProductList().OrderBy(p => p.Price).Select(l => l.Name)));

            var actual_GetProducts_SortByAscending = await prodService.GetSortedProductsAsync(SortOption.Ascending);
            Assert.True(actual_GetProducts_SortByAscending.Select(l => l.Name).SequenceEqual(ProductTestHelper.GetProductList().OrderBy(p => p.Name).Select(l => l.Name)));

            var actual_GetProducts_SortByDescending = await prodService.GetSortedProductsAsync(SortOption.Descending);
            Assert.True(actual_GetProducts_SortByDescending.Select(l => l.Name).SequenceEqual(ProductTestHelper.GetProductList().OrderByDescending(p => p.Name).Select(l => l.Name)));

            var actual_GetProducts_SortByRecommended = await prodService.GetSortedProductsAsync(SortOption.Recommended);
            Assert.True(actual_GetProducts_SortByRecommended.Select(l => l.Name).SequenceEqual(ProductTestHelper.GetProductList().OrderByDescending(p => p.Name).Select(l => l.Name)));

        }
    }
}
