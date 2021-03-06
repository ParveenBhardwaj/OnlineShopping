﻿using Microsoft.AspNetCore.Mvc;
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
        private readonly ITrolleyService _trolleyService;
        private ILogger _logger;

        public AnswersController(IUserService userService, IProductService productService, 
            ITrolleyService trolleyService, ILogger<AnswersController> logger)
        {
            _userService = userService;
            _productService = productService;
            _trolleyService = trolleyService;
            _logger = logger;
        }

        /// <summary>
        /// Returns User Information.
        /// </summary>
        /// <returns></returns>
        [HttpGet("user")]
        public async Task<User> GetUser()
        {
            try
            {
                _logger.LogInformation("User was fetched.");
                var user = await _userService.GetAsync();
                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                throw;
            }
        }

        /// <summary>
        /// Returns a List of Products in sorted form as per specified request.
        /// </summary>
        /// <param name="sortOption"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tItem"></param>
        /// <returns></returns>
        [HttpPost("trolleyTotal")]
        public async Task<decimal> CalculateTrolleyTotal([FromBody] TrolleyItem tItem)
        {
            try
            {
                _logger.LogInformation("Trolley total was Calculated.");
                var user = await _trolleyService.GetTrolleyTotalAsync(tItem);
                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                throw;
            }
        }
    }
}
