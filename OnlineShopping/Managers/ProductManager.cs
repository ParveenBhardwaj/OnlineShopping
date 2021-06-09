using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineShopping.Domain.Interfaces.Managers;
using OnlineShopping.Domain.Models;
using OnlineShopping.Helpers;

namespace OnlineShopping.Managers
{
    public class ProductManager : IProductManager
    {
        /// <summary>
        /// Get a list of all products
        /// </summary>
        /// <returns></returns>
        public virtual async Task<IList<Product>> GetAllAsync()
        {
            // Test Comment
            var uri = UriHelper.GetProductUri();
            var products = await HttpHelper.GetAsync<IList<Product>>(uri);
            return products;
        }
    }
}
