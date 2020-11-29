using System;
using System.Collections.Generic;
using System.Text;

namespace KeoghsCheckoutKata.Library
{
    public interface IRepository
    {
        public IEnumerable<Product> GetProducts();
        public IEnumerable<Discount> GetDiscounts();
    }
}
