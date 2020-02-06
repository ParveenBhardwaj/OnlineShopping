using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopping.Domain.Interfaces.Managers;
using OnlineShopping.Domain.Interfaces.Services;
using OnlineShopping.Domain.Models;

namespace OnlineShopping.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductManager _productManager;
        private readonly ICustomerManager _customerManager;
        private readonly ILogger _logger;

        public ProductService(IProductManager productManager, ICustomerManager customerManager, ILogger<ProductService> logger)
        {
            _productManager = productManager;
            _customerManager = customerManager;
            _logger = logger;
        }

        public async Task<IList<Product>> GetSortedProductsAsync(SortOption sortOption)
        {
            var products = await _productManager.GetAllAsync();
            IList<Product> sortedProductsList;

            switch (sortOption)
            {
                case SortOption.High:
                    sortedProductsList = products.OrderByDescending(p => p.Price).ToList();
                    break;
                case SortOption.Low:
                    sortedProductsList = products.OrderBy(p => p.Price).ToList();
                    break;
                case SortOption.Ascending:
                    sortedProductsList = products.OrderBy(p => p.Name).ToList();
                    break;
                case SortOption.Descending:
                    sortedProductsList = products.OrderByDescending(p => p.Name).ToList();
                    break;
                case SortOption.Recommended:
                    sortedProductsList = await GetRecommendedProductListAsync(products);
                    break;
                default:
                    sortedProductsList = products;
                    break;
            }

            return sortedProductsList;
        }


        /// <summary>
        /// Returns a List of Products sorted by their popularity. 
        /// The popularity is calculated by the number of times (quantity) a product was sold.
        /// Assumption: Product Names are unique.
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        private async Task<IList<Product>> GetRecommendedProductListAsync(IList<Product> products)
        {
            IDictionary<string, long> productQuantity = await GetProductTotalQuntityAsync();

            // sort the products by quantity (number of times they were sold)
            var sortedProductByQuantity = productQuantity.OrderByDescending(pq => pq.Value);

            IList<Product> sortedProductByQuantityList = new List<Product>();
            foreach (KeyValuePair<string, long> kvp in sortedProductByQuantity)
            {
                sortedProductByQuantityList.Add(products.Where<Product>(p => p.Name == kvp.Key).FirstOrDefault());
            }

            // Add any missing products
            foreach (Product prod in products)
            {
                if (!sortedProductByQuantityList.Any(p => p.Name == prod.Name))
                {
                    sortedProductByQuantityList.Add(prod);
                }
            }

            return sortedProductByQuantityList;
        }


        /// <summary>
        /// Returns the total quantity of all products, they were sold for.
        /// </summary>
        /// <returns></returns>
        private async Task<IDictionary<string, long>> GetProductTotalQuntityAsync()
        {
            try
            {
                var shoppingHistory = await _customerManager.GetCustomerShoppingHistoryAsync();
                IDictionary<string, long> productQuantity = new Dictionary<string, long>();

                foreach (CustomerShoppingHistory shopHistory in shoppingHistory)
                {
                    foreach (Product prod in shopHistory.Products)
                    {
                        if (!productQuantity.ContainsKey(prod.Name))
                        {
                            productQuantity.Add(prod.Name, prod.Quantity);
                        }
                        else
                        {
                            productQuantity[prod.Name] += prod.Quantity;
                        }
                    }
                }

                return productQuantity;
            }
            // Improved Exception handling needs to be implemented. For now just leaving it silmply Exception ex.
            catch (Exception ex) 
            {
                _logger.LogError($"Something went wrong: {ex}");
                throw;
            }
            
        }
    }
}
