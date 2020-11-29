using System;
using System.Collections.Generic;
using System.Text;

namespace KeoghsCheckoutKata.Library
{
    public interface IProduct
    {
        char SKU { get; set; }
        decimal Price { get; set; }
    }
}
