using System;
using System.Collections.Generic;
using System.Text;

namespace KeoghsCheckoutKata.Library
{
    public class Checkout 
    {
        IRepository repository;

        public Checkout(IRepository repository)
        {
            this.repository = repository;

        }

    }
}
