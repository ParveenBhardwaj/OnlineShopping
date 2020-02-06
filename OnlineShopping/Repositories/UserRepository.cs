using System.Threading.Tasks;
using OnlineShopping.Common;
using OnlineShopping.Domain.Interfaces.Repositories;
using OnlineShopping.Domain.Models;

namespace OnlineShopping.Repositories
{
    public class UserRepository: IUserRepository
    {
        /// <summary>
        /// Returns a User
        /// </summary>
        /// <returns></returns>
        public async Task<User> GetAsync()
        {
            // Simulating an awaited call to a resource (e.g. Database) 
            return await Task.Run(() =>
            {
                return new User
                {
                    Name = ProjectConstants.NAME,
                    Token = ProjectConstants.AUTH_TOKEN_VALUE
                };
            });
        }
    }
}
