using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineShopping.Domain.Models;

namespace OnlineShopping.Domain.Interfaces.Managers
{
    public interface IProductManager
    {
        Task<IList<Product>> GetAllAsync();
    }
}
