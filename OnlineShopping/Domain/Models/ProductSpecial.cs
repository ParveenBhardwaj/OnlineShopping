using System.Collections.Generic;

namespace OnlineShopping.Domain.Models
{
    public class ProductSpecial
    {
        public IList<Product> Quantities { get; set; }
        public decimal Total { get; set; }
    }
}
