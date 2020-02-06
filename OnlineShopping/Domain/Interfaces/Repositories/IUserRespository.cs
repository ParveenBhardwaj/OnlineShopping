using System.Threading.Tasks;
using OnlineShopping.Domain.Models;

namespace OnlineShopping.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetAsync();
    }
}
