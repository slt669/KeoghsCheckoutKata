using System;
using System.Collections.Generic;
using System.Text;

namespace KeoghsCheckoutKata.Library
{
    public class Discount:IDiscount
    {
        public char SKU { get; set; }
        public int Quantity { get; set; }
        public decimal Value { get; set; }
    }
}
