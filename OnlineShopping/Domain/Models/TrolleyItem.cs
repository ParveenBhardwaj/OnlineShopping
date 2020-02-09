using System.Collections.Generic;

namespace OnlineShopping.Domain.Models
{
    public class TrolleyItem
    {
        public IList<Product> Products { get; set; }
        public IList<ProductSpecial> Specials { get; set; }
        public IList<Product> Quantities { get; set; }
    }
}
