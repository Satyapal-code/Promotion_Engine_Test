using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using PromotionEngineDemo;

namespace NUnitTest2
{
    [TestFixture]
    public class ProductServiceTest
    {
        ProductService productServiceObj = new ProductService();
        [Test]
        public void GetTotalPriceTest()
        {
            //Arrange
            List<Product> products = new List<Product>()
            {
                new Product(){ Id = "A", Price=50},
                new Product(){ Id = "B", Price=30},
                new Product(){ Id = "C", Price=20},
                new Product(){ Id = "D", Price=15},
            };

            int ExpectedPrice = 110;

            //Act
            int ActualPrice = productServiceObj.GetTotalPrice(products);

            //Assert
            Assert.AreEqual(ExpectedPrice, ActualPrice);
        }

        [Test]
        public void GetPriceByTypeTest()
        {
            //Arrange
            Product product = new Product()
            {
                 Id = "A"
            };

            int ExpectedPrice = 50;

            //Act
            productServiceObj.GetPriceByType(product);

            //Assert
            Assert.AreEqual(ExpectedPrice, product.Price);
        }
    }
}
