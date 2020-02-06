using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineShopping.Domain.Interfaces.Services;
using OnlineShopping.Domain.Models;
using OnlineShopping.Helpers;
using Microsoft.Extensions.Logging;

namespace OnlineShopping.Controllers
{
    [Route("/api/[controller]")]
    public class AnswersController : Controller
    {
        private readonly IUserService _userService;
        private readonly IProductService _productService;
        private ILogger _logger;

        public AnswersController(IUserService userService, IProductService productService, ILogger<AnswersController> logger)
        {
            _userService = userService;
            _productService = productService;
            _logger = logger;
        }

        [HttpGet]
        [HttpGet("user")]
        public async Task<User> GetUser()
        {
            _logger.LogInformation("User was fetched.");
            var user = await _userService.GetAsync();
            return user;
        }

        [HttpGet]
        [HttpGet("products/{sort}")]
        public async Task<IList<Product>> GetProducts(string sortOption)
        {
            try
            {
                _logger.LogInformation("Products were fetched.");
                var sortBy = SortOptionHelper.GetSortOption(sortOption);
                var products = await _productService.GetSortedProductsAsync(sortBy);
                return products;
            }
            catch(Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                throw;
            }
        }
    }
}
