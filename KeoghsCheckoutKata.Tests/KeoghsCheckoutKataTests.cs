using KeoghsCheckoutKata.Library;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace KeoghsCheckoutKata.Tests
{
    public class KeoghsCheckoutKataTests
    {
        private ICheckout checkout;

        /// <summary>
        /// Given I have selected to add an item to the basket Then the item should be added to the basket
        /// </summary>
        /// <param name="item"></param>
        /// <param name="expected"></param>
        [Theory]
        [InlineData("A", "A")]
        [InlineData("B", "B")]
        [InlineData("C", "C")]
        [InlineData("D", "D")]
        [InlineData("AD", "AD")]
        [InlineData("BC", "BC")]
        [InlineData("CDD", "CDD")]
        public void Given_add_an_item_to_basket_Then_should_be_added(string item, string expected)
        {
            //Arrange
            //Act
            //Assert

            var listOfProducts = new List<Product>();

            listOfProducts.Add(
            new Product { SKU = 'A', Price = 10 });
            listOfProducts.Add(
            new Product { SKU = 'B', Price = 15 });
            listOfProducts.Add(
            new Product { SKU = 'C', Price = 40 });
            listOfProducts.Add(
            new Product { SKU = 'D', Price = 55 });

            var listOfDiscounts = new List<Discount>();

            listOfDiscounts.Add(
            new Discount { SKU = 'B', Quantity = 3, Value = 5 });
            listOfDiscounts.Add(
            new Discount { SKU = 'D', Quantity = 2, Value = 27.5m });

            // Mock Allows me to test an isolated Repository

            Mock<IRepository> mockRepository = new Mock<IRepository>();
            mockRepository.Setup(x => x.GetProducts()).Returns(listOfProducts);
            mockRepository.Setup(x => x.GetDiscounts()).Returns(listOfDiscounts);

            checkout = new Checkout(mockRepository.Object);
            //Assert
            Assert.Equal(expected, checkout.AddtoBasket(item).AddedProducts);
        }

        /// <summary>
        /// Given items have been added to the basket Then the total cost of the basket should be calculated
        /// </summary>
        /// <param name="items"></param>
        /// <param name="expected"></param>
        [Theory]
        [InlineData("A", 10)]
        [InlineData("B", 15)]
        [InlineData("C", 40)]
        [InlineData("D", 55)]
        [InlineData("AB", 25)]
        [InlineData("AC", 50)]
        [InlineData("AAAA", 40)]
        [InlineData("CCCC", 160)]
        [InlineData("ACAC", 100)]
        public void Given_items_added_Then_total_of_basket_should_be_calculated(string items, int expected)
        {
            //Arrange
            //Act
            //Assert

            var listOfProducts = new List<Product>();

            listOfProducts.Add(
            new Product { SKU = 'A', Price = 10 });
            listOfProducts.Add(
            new Product { SKU = 'B', Price = 15 });
            listOfProducts.Add(
            new Product { SKU = 'C', Price = 40 });
            listOfProducts.Add(
            new Product { SKU = 'D', Price = 55 });

            var listOfDiscounts = new List<Discount>();

            listOfDiscounts.Add(
            new Discount { SKU = 'B', Quantity = 3, Value = 5 });
            listOfDiscounts.Add(
            new Discount { SKU = 'D', Quantity = 2, Value = 27.5m });

            // Mock Allows me to test an isolated Repository

            Mock<IRepository> mockRepository = new Mock<IRepository>();
            mockRepository.Setup(x => x.GetProducts()).Returns(listOfProducts);
            mockRepository.Setup(x => x.GetDiscounts()).Returns(listOfDiscounts);
            checkout = new Checkout(mockRepository.Object);
            //Assert
            Assert.Equal(expected, checkout.AddtoBasket(items).Total());
        }

        /// <summary>
        /// Given I have added a multiple of 3 lots of item ‘B’ to the basket Then a promotion of ‘3 for 40’ should be applied to every multiple of 3 (see: Grid 1).
        /// </summary>
        /// <param name="items"></param>
        /// <param name="expected"></param>
        [Theory]
        [InlineData("B", 15)]
        [InlineData("BB", 30)]
        [InlineData("BBB", 40)]
        [InlineData("BBBB", 55)]
        public void Given_added_multiple_of_3_of_SKU_B_3_for_40(string items, int expected)
        {
            //Arrange
            //Act
            //Assert

            var listOfProducts = new List<Product>();

            listOfProducts.Add(
            new Product { SKU = 'A', Price = 10 });
            listOfProducts.Add(
            new Product { SKU = 'B', Price = 15 });
            listOfProducts.Add(
            new Product { SKU = 'C', Price = 40 });
            listOfProducts.Add(
            new Product { SKU = 'D', Price = 55 });

            var listOfDiscounts = new List<Discount>();

            listOfDiscounts.Add(
            new Discount { SKU = 'B', Quantity = 3, Value = 5 });
            listOfDiscounts.Add(
            new Discount { SKU = 'D', Quantity = 2, Value = 27.5m });

            // Mock Allows me to test an isolated Repository

            Mock<IRepository> mockRepository = new Mock<IRepository>();
            mockRepository.Setup(x => x.GetProducts()).Returns(listOfProducts);
            mockRepository.Setup(x => x.GetDiscounts()).Returns(listOfDiscounts);
            checkout = new Checkout(mockRepository.Object);
            //Assert
            Assert.Equal(expected, checkout.AddtoBasket(items).Total());
        }

        /// <summary>
        /// Given I have added a multiple of 2 lots of item ‘D’ to the basket Then a promotion of ‘25% off’ should be applied to every multiple of 2 (see: Grid 1).
        /// </summary>
        /// <param name="items"></param>
        /// <param name="expected"></param>
        [Theory]
        [InlineData("D", 55)]
        [InlineData("DD", 82.5)]
        [InlineData("DDD", 137.5)]
        [InlineData("DDDD", 165)]
        public void Given_added_multiple_of_2_of_SKU_D_25_percent_off(string items, decimal expected)
        {
            //Arrange
            //Act
            //Assert

            var listOfProducts = new List<Product>();

            listOfProducts.Add(
            new Product { SKU = 'A', Price = 10 });
            listOfProducts.Add(
            new Product { SKU = 'B', Price = 15 });
            listOfProducts.Add(
            new Product { SKU = 'C', Price = 40 });
            listOfProducts.Add(
            new Product { SKU = 'D', Price = 55 });

            var listOfDiscounts = new List<Discount>();

            listOfDiscounts.Add(
            new Discount { SKU = 'B', Quantity = 3, Value = 5 });
            listOfDiscounts.Add(
            new Discount { SKU = 'D', Quantity = 2, Value = 27.5m });

            // Mock Allows me to test an isolated Repository

            Mock<IRepository> mockRepository = new Mock<IRepository>();
            mockRepository.Setup(x => x.GetProducts()).Returns(listOfProducts);
            mockRepository.Setup(x => x.GetDiscounts()).Returns(listOfDiscounts);

            checkout = new Checkout(mockRepository.Object);
            //Assert
            Assert.Equal(expected, checkout.AddtoBasket(items).Total());
        }
    }
}