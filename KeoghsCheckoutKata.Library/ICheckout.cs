using System;
using System.Collections.Generic;
using System.Text;

namespace KeoghsCheckoutKata.Library
{
    public interface ICheckout
    {
        ICheckout AddtoBasket(String Basket);
        char[] AddedProducts { get; }
    }
}
