using System.Collections.Generic;

namespace OnlineShopping.Domain.Models
{
    public class CustomerShoppingHistory
    {
        public long CustomerId { get; set; }

        public IList<Product> Products { get; set; }
    }
}
