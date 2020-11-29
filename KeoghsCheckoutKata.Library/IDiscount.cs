using System;
using System.Collections.Generic;
using System.Text;

namespace KeoghsCheckoutKata.Library
{
    public interface IDiscount
    {
        char SKU { get; set; }
        int Quantity { get; set; }
        decimal Value { get; set; }
    }
}
