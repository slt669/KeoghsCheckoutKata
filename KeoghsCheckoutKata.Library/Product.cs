﻿using System;
using System.Collections.Generic;
using System.Text;

namespace KeoghsCheckoutKata.Library
{
    public class Product:IProduct
    {
        public char SKU { get; set; }
        public decimal Price { get; set; }
    }
}
