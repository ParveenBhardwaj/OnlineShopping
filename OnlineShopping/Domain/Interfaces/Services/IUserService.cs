using System.Threading.Tasks;
using OnlineShopping.Domain.Models;

namespace OnlineShopping.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<User> GetAsync();
    }
}
