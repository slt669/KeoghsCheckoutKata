using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KeoghsCheckoutKata.Library
{
    public class Checkout : ICheckout
    {
        IRepository repository;
        private char[] productsInBasket;

        //Implement interface member AddedProducts
        public char[] AddedProducts { get { return productsInBasket; } }

        public Checkout(IRepository repository)
        {
            this.repository = repository;
            productsInBasket = new char[] { };
        }

        public ICheckout AddtoBasket(String Basket)
        {
            if (!String.IsNullOrEmpty(Basket))
            {
                productsInBasket = Basket
                    .ToCharArray()
                    .Where(scannedSKU => repository.GetProducts().Any(product => product.SKU == scannedSKU))
                    .ToArray();
            }
            return this;
        }

    }
}
