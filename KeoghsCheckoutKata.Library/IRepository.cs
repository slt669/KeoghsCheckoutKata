﻿using System;
using System.Collections.Generic;
using System.Text;

namespace KeoghsCheckoutKata.Library
{
    public interface IRepository
    {
        public List<Product> GetProducts();
        public List<Discount> GetDiscounts();
    }
}
