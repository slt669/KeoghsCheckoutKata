using System;

namespace KeoghsCheckoutKata.Library
{
    public interface ICheckout
    {
        ICheckout AddtoBasket(String Basket);
        decimal Total();
        char[] AddedProducts { get; }
    }
}