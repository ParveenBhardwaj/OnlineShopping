using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineShopping.Domain.Models;

namespace OnlineShopping.Domain.Interfaces.Services
{
    public interface IProductService
    {
        Task<IList<Product>> GetSortedProductsAsync(SortOption sortOption);
    }
}
