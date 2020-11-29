using System;
using KeoghsCheckoutKata.Library;
namespace KeoghsCheckoutKata
{
    class Program
    {

        static void Main()
        {
            ICheckout checkout;
            Repository repository = new Repository();
            //// Type your basket items and press enter
            Console.WriteLine("Enter basket items");

            string basket = Console.ReadLine();

            checkout = new Checkout(repository);
            decimal total = checkout.AddtoBasket(basket).Total();
            //// Print the total
            Console.WriteLine("Total is: " + total);

        }
    }
}
