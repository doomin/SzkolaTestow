using NUnit.Framework;
using System;
using FluentAssertions;

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
            result.Should().Be(24.60M);
        }

        [TestCase(0.08, TestName="Should return gross price of a product for provided VAT - 8%")]
        public void ShouldReturnProductGrossPriceForProvidedVat(decimal vat){
            //given
            Product product = GenerateProductwithPrice(10.00M);

            //when
            decimal result = vatService.GetGrossPrice(product.NetPrice, vat);

            //then
            result.Should().Be(10.80M);
        }

        [TestCase(1.2, TestName="Should throw exception when provided VAT is too high")]
        public void ShouldThrowExceptionWhenVatTooHigh(decimal vat){
            //given
            Product product = GenerateProductwithPrice(10.00M);

            //when
            
            //then
            Action act = () => {
                vatService.GetGrossPrice(product.NetPrice, vat);
                };

            act.Should().Throw<Exception>()                    
                    .WithMessage("VAT needs to be lower!");

        }

        private Product GenerateProductwithPrice(decimal price){
            Product product = new Product();
            product.NetPrice = price;
            return product;
        }
    }
}

