using System;
using System.Collections.Generic;
using System.Text;
using OnlineShopping.Domain.Models;

namespace OnlineShoppingTest.TestHelpers
{
    public static class ProductTestHelper
    {
        public static IList<Product> GetProductList()
        {
            IList<Product> list = new List<Product>();
            list.Add(new Product
            {
                Name = "Product A",
                Price = 99.9m,
                Quantity = 0
            });

            list.Add(new Product
            {
                Name = "Product C",
                Price = 19.7m,
                Quantity = 0
            });

            list.Add(new Product
            {
                Name = "Product H",
                Price = 119.7m,
                Quantity = 0
            });

            return list;
        }

        public static IList<CustomerShoppingHistory> GetCustomerShoppingHistory()
        {
            IList<CustomerShoppingHistory> list = new List<CustomerShoppingHistory>();
            list.Add(new CustomerShoppingHistory
            {
                CustomerId = 1,
                Products = new List<Product>{
                new Product{
                    Name = "Product H",
                    Price = 119.7m,
                    Quantity = 5
                    }
                }
            });

            list.Add(new CustomerShoppingHistory
            {
                CustomerId = 1,
                Products = new List<Product>{
                new Product{
                    Name = "Product C",
                    Price = 19.7m,
                    Quantity = 5
                    }
                }
            });

            list.Add(new CustomerShoppingHistory
            {
                CustomerId = 1,
                Products = new List<Product>{
                new Product{
                    Name = "Product H",
                    Price = 119.7m,
                    Quantity = 2
                    }
                }
            });
            return list;
        }
    }
}
