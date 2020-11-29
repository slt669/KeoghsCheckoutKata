using System;
using System.Collections.Generic;

namespace KeoghsCheckoutKata.Library
{
    public class Repository : IRepository
    {
        public IEnumerable<Product> GetProducts()
        {
            var listOfProducts = new List<Product>();

            listOfProducts.Add(
                 new Product { SKU = 'A', Price = 10 });
            listOfProducts.Add(
              new Product { SKU = 'B', Price = 15 });
            listOfProducts.Add(
            new Product { SKU = 'C', Price = 40 });
            listOfProducts.Add(
               new Product { SKU = 'D', Price = 55 });
            return listOfProducts;
        }
        public IEnumerable<Discount> GetDiscounts()
        {
            var listOfDiscounts = new List<Discount>();
            listOfDiscounts.Add(
              new Discount { SKU = 'B', Quantity = 3, Value = 5 });
            listOfDiscounts.Add(
              new Discount { SKU = 'D', Quantity = 2, Value = 27.5m });
            return listOfDiscounts;
        }
    }
}
