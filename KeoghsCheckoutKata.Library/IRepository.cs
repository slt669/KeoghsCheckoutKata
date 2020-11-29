using System.Collections.Generic;

namespace KeoghsCheckoutKata.Library
{
    public interface IRepository
    {
        public IEnumerable<Product> GetProducts();

        public IEnumerable<Discount> GetDiscounts();
    }
}