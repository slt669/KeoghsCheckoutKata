using System;
using System.Collections.Generic;
using System.Text;

namespace KeoghsCheckoutKata.Library
{
    public interface ICheckout
    {
        ICheckout AddtoBasket(String Basket);
        decimal Total();
        char[] AddedProducts { get; }
    }
}
