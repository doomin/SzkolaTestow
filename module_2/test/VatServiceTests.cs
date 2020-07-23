using NUnit.Framework;
using System;

namespace szkola_testow {
    public class VatServiceTests {

        private VatService vatService;


        [SetUp]
        public void PrepareVatService(){
            vatService = new VatService();
        }

        [TestCase(TestName="Should return gross price of a product for default VAT - 23%")]
        public void ShouldReturnProductGrossPriceForDefaultVat(){
            //given
            Product product = GenerateProductwithPrice(20.00M);

            //when
            decimal result = vatService.GetGrossPriceForDefaultVat(product);

            //then
            Assert.AreEqual(24.60M, result);
        }

        [TestCase(0.08, TestName="Should return gross price of a product for provided VAT - 8%")]
        public void ShouldReturnProductGrossPriceForProvidedVat(decimal vat){
            //given
            Product product = GenerateProductwithPrice(10.00M);

            //when
            decimal result = vatService.GetGrossPrice(product.NetPrice, vat);

            //then
            Assert.AreEqual(10.80M, result);
        }

        [TestCase(1.2, TestName="Should throw exception when provided VAT is too high")]
        public void ShouldThrowExceptionWhenVatTooHigh(decimal vat){
            //given
            Product product = GenerateProductwithPrice(10.00M);

            //when
            
            //then
            Assert.Throws<Exception>( () => {
                vatService.GetGrossPrice(product.NetPrice, vat);
                });
        }

        private Product GenerateProductwithPrice(decimal price){
            Product product = new Product();
            product.NetPrice = price;
            return product;
        }
    }
}

