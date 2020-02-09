using OnlineShopping.Domain.Interfaces.Services;
using OnlineShopping.Domain.Models;
using OnlineShopping.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.Services
{
    public class TrolleyService : ITrolleyService
    {
        /// <summary>
        /// Calculates the total based on TrolleyItem specifications.
        /// </summary>
        /// <param name="tItem"></param>
        /// <returns></returns>
        public async Task<decimal> GetTrolleyTotalAsync(TrolleyItem tItem)
        {
            if (tItem == null)
            {
                return 0.0m;
            }

            var uri = UriHelper.GeTrolleyCalculatorUri();
            var result = await HttpHelper.PostAsync<decimal>(uri, tItem);
            return result;
        }
    }
}
