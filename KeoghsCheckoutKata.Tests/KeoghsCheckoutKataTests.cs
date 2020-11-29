using KeoghsCheckoutKata.Library;
using System;
using System.Collections.Generic;
using Xunit;
using Moq;
namespace KeoghsCheckoutKata.Tests
{
    public class KeoghsCheckoutKataTests
    {
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


        }
       
    }
}
