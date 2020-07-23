using NUnit.Framework;
using System;

namespace szkola_testow {
    public class VatServiceTests {

        private Product product;
        private VatService vatService;


        [SetUp]
        public void Setup(){
            product = new Product();
            vatService = new VatService();
            product.NetPrice = 100;
        }

        [Test]
        public void ShouldReturnProductGrossPrice(){
            Assert.AreEqual(123, vatService.GetGrossPriceForDefaultVat(product));
        }
    }
}

