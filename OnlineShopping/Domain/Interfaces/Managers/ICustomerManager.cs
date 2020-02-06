using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineShopping.Domain.Models;

namespace OnlineShopping.Domain.Interfaces.Managers
{
    public interface ICustomerManager
    {
        Task<IList<CustomerShoppingHistory>> GetCustomerShoppingHistoryAsync();
    }
}
