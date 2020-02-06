using System.Threading.Tasks;
using OnlineShopping.Domain.Interfaces.Repositories;
using OnlineShopping.Domain.Interfaces.Services;
using OnlineShopping.Domain.Models;

namespace OnlineShopping.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetAsync()
        {
            return await _userRepository.GetAsync();
        }
    }
}
