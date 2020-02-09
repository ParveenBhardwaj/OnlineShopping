using OnlineShopping.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.Domain.Interfaces.Services
{
    public interface ITrolleyService
    {
        Task<decimal> GetTrolleyTotalAsync(TrolleyItem tItem);
    }
}
