using System;
using System.Collections.Generic;
using System.Linq;

namespace KeoghsCheckoutKata.Library
{
    public class Checkout : ICheckout
    {
        private IRepository repository;
        private char[] productsInBasket;
        private readonly IEnumerable<IProduct> products;
        private readonly IEnumerable<IDiscount> discounts;

        //Implement interface member AddedProducts
        public char[] AddedProducts { get { return productsInBasket; } }

        public Checkout(IRepository repository)
        {
            this.repository = repository;
            this.products = repository.GetProducts();
            this.discounts = repository.GetDiscounts();
            productsInBasket = new char[] { };
        }

        //
        public ICheckout AddtoBasket(String Basket)
        {
            if (!String.IsNullOrEmpty(Basket))
            {
                productsInBasket = Basket
                    .ToCharArray()
                    .Where(scannedSKU => products.Any(product => product.SKU == scannedSKU))
                    .ToArray();
            }
            return this;
        }

        //Calculates the total by summing together all of the items then taking away the discounted value
        public decimal Total()
        {
            decimal total = 0;
            decimal totalDiscount = 0;
            total = productsInBasket.Sum(item => PriceForOne(item));
            totalDiscount = discounts.Sum(discount => CalculateDiscount(discount, productsInBasket));
            return total - totalDiscount;
        }

        //Gets the price for item out of the repository where SKU matches the param passed in
        private decimal PriceForOne(char sku)
        {
            return products.Single(p => p.SKU == sku).Price;
        }

        //Counts how many of an item has a discount associated then returns the sum of all the discounted items
        private decimal CalculateDiscount(IDiscount discount, char[] cart)
        {
            int itemCount = cart.Count(item => item == discount.SKU);
            return (itemCount / discount.Quantity) * discount.Value;
        }
    }
}