using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineShopping.Domain.Interfaces.Managers;
using OnlineShopping.Domain.Models;
using OnlineShopping.Helpers;

namespace OnlineShopping.Managers
{
    public class CustomerManager : ICustomerManager
    {
        public virtual async Task<IList<CustomerShoppingHistory>> GetCustomerShoppingHistoryAsync()
        {
            var uri = UriHelper.GetCustomerShoppingHistoryUri();
            var shoppingHistory = await HttpHelper.GetAsync<IList<CustomerShoppingHistory>>(uri);
            return shoppingHistory;
        }
    }
}
